using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Repository
{
	public class StudentStatementRepository : GenericRepository<StudentStatementModelVirtual>, IStudentStatementRepository
	{
		private UnisolAPIdbContext _context;
		public StudentStatementRepository(UnisolAPIdbContext context) : base(context)
		{
			_context = context;
		}

		public IEnumerable<StudentStatementModelVirtual> GetInvoicedAmount(string userCode, string finalStudentInvoiceCols)
		{
			var dataquery =
					" DECLARE @StudentStatementModelVirtual TABLE([AdmnNo][varchar](50) NULL,[Term] [varchar] (100) NULL,[Rdate] [datetime] NULL,[Type] [varchar] (100) NULL,[Ref] [varchar] (100) NULL,[Description] [varchar] (500) NULL,[Debit] [decimal](19, 4) NULL,[Credit] [decimal](19, 4) NULL,[Balance] [decimal](19, 4) NULL,[Notes] [varchar] (500) NULL,[Id] [int] IDENTITY(1,1) NOT NULL);" +
					"INSERT INTO @StudentStatementModelVirtual([AdmnNo], [Term], [Rdate], [Type], [Ref], [Description], [Debit], [Credit], [Balance], [Notes])" +
					"SELECT '" + userCode + "',term,rdate,'Type' as type,StudInvoice.Ref,'Invoice' as Description," + finalStudentInvoiceCols + " as debit,0 as credit,0 as balance,'Invoice'  FROM StudInvoice LEFT JOIN Term ON StudInvoice.term = Term.[names] WHERE dbo.StudInvoice.AdmnNo ='" + userCode + "' SELECT* FROM @StudentStatementModelVirtual";

			var studentInvoice = _context.StudentStatementModelVirtual.AsNoTracking().FromSql(dataquery).ToList();

			return studentInvoice;
		}
	}
}
