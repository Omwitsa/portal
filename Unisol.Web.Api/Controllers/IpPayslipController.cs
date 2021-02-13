using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Unisol.Web.Api.IServices;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class IpPayslipController : Controller
	{
		private readonly UnisolAPIdbContext _context;
		private IConfiguration _configuration;
		private IStaffServices _staffServices;

		public IpPayslipController(UnisolAPIdbContext context, IConfiguration configuration, IStaffServices staffServices)
		{
			_context = context;
			_configuration = configuration;
			_staffServices = staffServices;
		}

		[HttpGet("[action]")]
		public JsonResult GetIpProjects(string userCode)
		{
			try
			{
				var salPeriod = _context.HrpSalPeriod.OrderByDescending(p => p.Cdate)
					.FirstOrDefault(p => p.Cdate < DateTime.UtcNow.AddHours(3));
				var projectNames = _context.HrpIpprojects.Join(_context.HrpIpprocess,
				i => i.Names,
				p => p.Project,
				(i, p) => new
				{
					i.Names,
					p.EmpNo,
					i.Cdate
				}
				).Where(p => p.EmpNo.ToUpper().Equals(userCode.ToUpper()) && p.Cdate < salPeriod.Cdate)
				.OrderByDescending(p => p.Cdate).Select(p => p.Names).Distinct().ToList();

				return Json(new ReturnData<List<string>>
				{
					Success = true,
					Data = projectNames
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<List<string>>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpGet("[action]")]
		public JsonResult GetIpPaySlip(string userCode, string project)
		{
			project = project ?? "";
			try
			{
				var ipProcess = _context.HrpIpprocess.Select(p => new {
					p.RDate,
					p.EmpNo,
					p.Project
				}).FirstOrDefault(p => p.EmpNo == userCode 
				&& p.Project == project);

				var earnings = _context.HrpIpearnings.Where(e => e.EmpNo == userCode
				&& e.Project == project).ToList();

				var deductionResponse = GetDeductions(userCode, project);
				if (!deductionResponse.Success)
					return Json(deductionResponse);
				var totalDetuction = 0;
				
				foreach(var deduction in deductionResponse.Data)
				{
					totalDetuction += deduction.deductionAmount;
				}

				var totalTaxable = earnings.Where(x=>x.Taxable).Sum(i=>i.Amount);
				

				var payeTax = _staffServices.GetTaxCharged(Convert.ToDouble(totalTaxable), "4");
					deductionResponse.Data.Add(new
					{
						projectName="P.A.Y.E",
						deductionAmount=payeTax
					});
					totalDetuction += Convert.ToInt32(payeTax);

				return Json(new ReturnData<dynamic> {
					Success = true,
					Data = new
					{
						ipProcess,
						earnings,
						deductions = deductionResponse.Data,
						totalEarnings = earnings.Select(e => e.Amount).Sum(),
						totalDeductions = totalDetuction
					}
				});
			}
			catch(Exception ex)
			{
				return Json(new ReturnData<List<string>>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		private ReturnData<dynamic> GetDeductions(string userCode, string project)
		{
			var PayeCode = _context.HrpIppayAcc.OrderByDescending(a => a.Account).FirstOrDefault(a => a.Names =="PAYE")?.Code;
			var deductions = _context.HrpIpdeductions.Where(d => d.EmpNo == userCode && d.Project == project).ToList();
			var deductionAmount = deductions.Select(d => d.Amount).Sum() ?? 0;
			var processAmount = GetProcessAmount(userCode, project, PayeCode, deductionAmount);
			if (!processAmount.Success)
				return new ReturnData<dynamic> {
					Success = processAmount.Success,
					Message = processAmount.Message
				};

			return new ReturnData<dynamic> {
				Success = true,
				Data = processAmount.Data
			};
		}

		private ReturnData<dynamic> GetProcessAmount(string userCode, string project, string payeCode, decimal deductionAmount)
		{
			try
			{
				string connetionString = DbSetting.ConnectionString(_configuration, "Unisol");
				SqlConnection connection = new SqlConnection(connetionString);
				connection.Open();
				var processAmountQuery = $"SELECT ISNULL(hrpIPProcess.[{payeCode}], 0) as Amount, Project FROM hrpIPProcess where EmpNo = '{userCode}' and Project = '{project}'";
				var sqlCommand = new SqlCommand(processAmountQuery, connection);
				var reader = sqlCommand.ExecuteReader();
				var deductions = new List<dynamic>();
				while (reader.Read())
				{
					var projectName = reader[1].ToString();
					decimal.TryParse(reader[0].ToString(), out decimal processAmount);
					deductionAmount = deductionAmount < 0 ? processAmount : deductionAmount;
					deductions.Add(new {
						projectName,
						deductionAmount
					});
				}

				sqlCommand.Dispose();
				connection.Close();
				
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = deductions
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}
	}
}
