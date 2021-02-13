using System.Linq;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Repository
{
	public class UsersRepository : GenericRepository<Users>, IUsersRepository
	{
		private UnisolAPIdbContext _context;
		public UsersRepository(UnisolAPIdbContext context) : base(context)
		{
			_context = context;
		}

		public Users GetUsersByCode(string code)
		{
			var user = _context.Users.Select(u => new Users {
				EmpNo = u.EmpNo,
				UserCode = u.UserCode
			}).FirstOrDefault(u => u.EmpNo.ToUpper().Equals(code.ToUpper()));
			return user;
		}
	}
}
