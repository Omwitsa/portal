using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Repository
{
	public class HrpSalProcessRepository : GenericRepository<HrpSalProcess>, IHrpSalProcessRepository
	{
		private UnisolAPIdbContext _context;
		public HrpSalProcessRepository(UnisolAPIdbContext context) : base(context)
		{
			_context = context;
		}

		public IEnumerable<string> GetActiveAccounts(IConfiguration configuration)
		{
			string connetionString = DbSetting.ConnectionString(configuration, "Unisol");
			SqlConnection connection = new SqlConnection(connetionString);
			connection.Open();

			string sql = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS" +
				  " WHERE TABLE_NAME = 'hrpSalProcess' AND COLUMN_NAME IN (SELECT [Code]" +
				  " FROM hrpPayAcc where Closed = 0) ORDER BY COLUMN_NAME ASC";

			SqlCommand command = new SqlCommand(sql, connection);
			var listActiveColumns = new List<string>();
			using (var rdr = command.ExecuteReader())
			{
				while (rdr.Read())
				{
					listActiveColumns.Add(Convert.ToString(rdr[0]));
				}
			}

			command.Dispose();
			connection.Close();

			return listActiveColumns;
		}

		public IEnumerable<string> GetAccountsAmount(IConfiguration configuration, List<string> activeAccounts, StaffUtilities staffUtilities, string month, string userCode)
		{
			string connetionString = DbSetting.ConnectionString(configuration, "Unisol");
			SqlConnection connection = new SqlConnection(connetionString);
			connection.Open();

			var colString = staffUtilities.GetColumnTypes(activeAccounts);
			var getAmountsSql = "SELECT " + colString + " FROM hrpSalProcess WHERE SPeriod='" + month +
								"' AND EmpNo='" + userCode + "'";

			if (connection.State == ConnectionState.Closed)
				connection.Open();

			var amountCommand = new SqlCommand(getAmountsSql, connection);
			var reader = amountCommand.ExecuteReader();
			var listActiveAmountOnColumns = new List<string>();
			while (reader.Read())
			{
				activeAccounts.ForEach(column => { listActiveAmountOnColumns.Add(Convert.ToString(reader[column])); });
			}

			amountCommand.Dispose();
			connection.Close();
			return listActiveAmountOnColumns;
		}

		public double GetBalance(string accType, string userCode, string code, IConfiguration configuration, string accName, string month)
		{
			var balance = 0.0;
			string connetionString = DbSetting.ConnectionString(configuration, "Unisol");
			var queryResults = new QueryResults();
			if (accType.ToUpper().Equals("DEDUCTION"))
			{
				var hrpPayemain = _context.HrpPayemain.OrderByDescending(p => p.Id).FirstOrDefault();
				var personalRelief = hrpPayemain.Prelief == null ? balance : Convert.ToDouble(hrpPayemain.Prelief);
				balance = (accName.ToUpper().Contains("P.A.Y.E") || accName.ToUpper().Contains("PAYE")) ? personalRelief : balance;
			}

			if (accType.ToUpper().Equals("UNION"))
			{
				var sharesContributionQuery = "SELECT CONVERT(decimal(12, 4), ISNULL(SUM([" + code + "]), 0) ) as totalunion from " +
					"hrpSalProcess where EmpNo='" + userCode + "'";
				queryResults = ExecuteQuery(sharesContributionQuery, connetionString);
				double.TryParse(queryResults.Balance, out double processedAmount);

				var sharesQuery = "SELECT CONVERT(decimal(12, 4), ISNULL(SUM(Shares), 0) ) as totalunion from hrpSharesOB " +
					"where EmpNo='" + userCode + "' and Account like '%" + accName + "%'";
				queryResults = ExecuteQuery(sharesQuery, connetionString);
				double.TryParse(queryResults.Balance, out double abtainedShares);

				var payoffSharesQuery = "SELECT CONVERT(decimal(12, 4), ISNULL(SUM(Shares), 0) ) as totalunion from hrpSharesPayOff " +
					"where EmpNo='" + userCode + "'and Account like '%" + accName + "%'";
				queryResults = ExecuteQuery(payoffSharesQuery, connetionString);
				double.TryParse(queryResults.Balance, out double payoffShares);

				balance = processedAmount + abtainedShares - payoffShares;
			}

			if (accType.ToUpper().Equals("LOAN"))
			{
				DateTime date = DateTime.UtcNow;
				var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
				var firstdayom = firstDayOfMonth.ToString("dd/MM/yyyy");
				var loanQuery = "set DATEFORMAT dmy select sum(b.Premium) as Amount,a.SDate from hrpLoanSetup a join hrpLoanSub b " +
					"on a.ID = b.Ref join hrpPayAcc c on a.Loan =c.[Names] where a.EmpNo='" + userCode + "' and c.Code='" + code + "' " +
					"and a.Closed= 0 AND a.EDate >='" + firstdayom + "' group by a.SDate";
				queryResults = ExecuteQuery(loanQuery, connetionString, "loanQuery");
				double.TryParse(queryResults.Balance, out double loanAmount);

				var startDate = queryResults.Date?.ToString("dd/MM/yyyy");
				var loanContributionQuery = "SET DATEFORMAT dmy select CONVERT(decimal(12, 4), ISNULL(SUM([" + code + "]), 0) ) as totalunion " +
					"from hrpSalProcess p LEFT JOIN hrpSalPeriod s ON s.[Names]=p.SPeriod where EmpNo='" + userCode + "' " +
					"AND s.SDate >='" + startDate + "' and rDate <=(SELECT rdate FROM hrpSalProcess WHERE SPeriod = '" + month + "' AND EmpNo='" + userCode + "')";

				queryResults = ExecuteQuery(loanContributionQuery, connetionString);
				double.TryParse(queryResults.Balance, out double loanContributions);

				balance = loanAmount - loanContributions;
			}

			return balance;
		}

		private QueryResults ExecuteQuery(string query, string connetionString, string loanQuery = "")
		{
			SqlConnection connection = new SqlConnection(connetionString);
			if (connection.State == ConnectionState.Closed)
				connection.Open();
			var sqlCommand = new SqlCommand(query, connection);
			var reader = sqlCommand.ExecuteReader();
			var amount = "";
			var datestr = "";
			while (reader.Read())
			{
				amount = reader[0].ToString();
				datestr = string.IsNullOrEmpty(loanQuery) ? "" : reader[1].ToString();
			}

			DateTime.TryParse(datestr, out DateTime date);
			sqlCommand.Dispose();
			connection.Close();
			return new QueryResults
			{
				Balance = amount,
				Date = date
			};
		}

		public double GetIpTax(IConfiguration configuration, HrpSalPeriod salaryPeriod, string userCode)
		{
			string connetionString = DbSetting.ConnectionString(configuration, "Unisol");
			SqlConnection connection = new SqlConnection(connetionString);
			connection.Open();
			var code = GetIPPayeCode(configuration);
			if (salaryPeriod == null)
				salaryPeriod = new HrpSalPeriod
				{
					Sdate = DateTime.UtcNow,
					Edate = DateTime.UtcNow
				};

			var query = $"SET DATEFORMAT mdy SELECT ISNULL(SUM(p.[{code}]), 0) FROM hrpIPProcess p " +
				$"INNER JOIN hrpIPProjects j ON p.Project = j.Names WHERE j.Duedate >= '{salaryPeriod.Sdate}' AND j.Duedate <= '{salaryPeriod.Edate}' AND j.NonTaxable = 0 AND p.EmpNo = '{userCode}'";

			if (connection.State == ConnectionState.Closed)
				connection.Open();

			double ipTax = 0;
			try
			{
				var amountCommand = new SqlCommand(query, connection);
				var reader = amountCommand.ExecuteReader();
				while (reader.Read())
				{
					double.TryParse(reader[0].ToString(), out ipTax);
				}

				amountCommand.Dispose();
				connection.Close();
			}
			catch (Exception)
			{
				
			}
			return Math.Round(ipTax);
		}

		public string GetIPPayeCode(IConfiguration configuration)
		{
			string connetionString = DbSetting.ConnectionString(configuration, "Unisol");
			SqlConnection connection = new SqlConnection(connetionString);
			connection.Open();

			var query = "select code from hrpPayAcc where names = (SELECT PAYE FROM hrpSetup)";

			if (connection.State == ConnectionState.Closed)
				connection.Open();

			var amountCommand = new SqlCommand(query, connection);
			var reader = amountCommand.ExecuteReader();
			var code = "";
			while (reader.Read())
			{
				code = reader[0].ToString();
			}

			amountCommand.Dispose();
			connection.Close();
			return code;
		}
	}
}
