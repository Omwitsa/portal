using System.Collections.Generic;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.IRepository
{
	public interface IStudentStatementRepository : IGenericRepository<StudentStatementModelVirtual>
	{
		IEnumerable<StudentStatementModelVirtual> GetInvoicedAmount(string userCode, string finalStudentInvoiceCols);
	}
}
