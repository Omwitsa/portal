using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.IRepository
{
	public interface IUsersRepository : IGenericRepository<Users>
	{
		Users GetUsersByCode(string code);
	}
}
