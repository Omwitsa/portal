using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Repository
{
	public class MarkSheetRepository : GenericRepository<MarkSheet>, IMarkSheetRepository
	{
		private UnisolAPIdbContext _context;
		public MarkSheetRepository(UnisolAPIdbContext context) : base(context)
		{
			_context = context;
		}
		
		public IEnumerable<MarksheetResults> GetStudentResults(TranscriptRequestViewModel transcriptModel, string institutionInitials, 
			IConfiguration configuration)
		{
			var sysSetup = _context.SysSetup.FirstOrDefault();
			var results = _context.MarkSheet.Join(_context.Subjects,
					m => m.Subject,
					s => s.Code,
					(m, s) => new MarksheetResults
					{
						AdmnNo = m.AdmnNo,
						Term = m.Term,
						Code = m.Subject,
						Title = s.Names,
						Exam = m.Exam,
						Cat = m.Cat
					}).Where(r => r.AdmnNo == transcriptModel.Usercode).ToList();

			if (institutionInitials.ToUpper().Equals("KCNP") || institutionInitials.ToUpper().Equals("NTTI"))
			{
				string connetionString = DbSetting.ConnectionString(configuration, "Unisol");
				SqlConnection connection = new SqlConnection(connetionString);
				if (connection.State == ConnectionState.Closed)
					connection.Open();

				var marks = "SELECT m.admnno, m.term, m.subject, s.names, m.exam, m.[cat1], m.[cat2] FROM MarkSheet m INNER JOIN Subjects s ON m.subject = s.code " +
					"WHERE m.admnno = '" + transcriptModel.Usercode + "'";
				if(institutionInitials.ToUpper().Equals("NTTI"))
					marks = "SELECT m.admnno, m.term, m.subject, s.names, m.exam, m.[cat 1], m.[cat 2] FROM MarkSheet m INNER JOIN Subjects s ON m.subject = s.code " +
						"WHERE m.admnno = '" + transcriptModel.Usercode + "'";
				var sqlCommand = new SqlCommand(marks, connection);
				var reader = sqlCommand.ExecuteReader();
				results = new List<MarksheetResults>();
				while (reader.Read())
				{
					decimal cat1 = 0, cat2 = 0, exam = 0;
					decimal.TryParse(reader[5].ToString(), out cat1);
					decimal.TryParse(reader[6].ToString(), out cat2);
					decimal.TryParse(reader[4].ToString(), out exam);
					var cat = (cat1 + cat2) * 0.5m;
					if (institutionInitials.ToUpper().Equals("NTTI"))
                    {
						cat = (sysSetup.OtherTests / 100) * cat1 ?? 0;
						exam = (sysSetup.Exam / 100) * exam ?? 0;
					}
					
					results.Add(new MarksheetResults
					{
						AdmnNo = reader[0].ToString(),
						Term = reader[1].ToString(),
						Code = reader[2].ToString(),
						Title = reader[3].ToString(),
						Exam = Math.Round(exam, MidpointRounding.AwayFromZero),
						Cat = Math.Round(cat, MidpointRounding.AwayFromZero)
					});
				}

				sqlCommand.Dispose();
				connection.Close();
			}

			return results;
		}
	}
}
