using System;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.IRepository
{
	public interface ITermRepository : IGenericRepository<Term>
	{
		string GetTermByDate(string studentclass, DateTime serverdate);
	}
}
