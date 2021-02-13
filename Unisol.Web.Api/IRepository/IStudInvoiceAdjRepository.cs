using System.Collections.Generic;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.IRepository
{
	public interface IStudInvoiceAdjRepository : IGenericRepository<StudInvoiceAdj>
	{
		IEnumerable<StudInvoiceAdj> GetStudInvoiceAdj(string userCode);
	}
}
