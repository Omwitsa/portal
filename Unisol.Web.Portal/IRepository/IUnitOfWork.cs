
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Portal.IRepository
{
	public interface IUnitOfWork
	{
		// Custome repositories
		////ITermRepository Term { get; }

		// Generic repositories
		IGenericRepository<User> Users { get; }
		IGenericRepository<PortalMessage> PortalMessage { get; }
		IGenericRepository<UserGroups> UserGroups { get; }
		IGenericRepository<PortalNews> PortalNews { get; }
		IGenericRepository<UserToken> UserToken { get; }
		IGenericRepository<PortalEvents> PortalEvents { get; }
		IGenericRepository<UserGroupPrivilege> UserGroupPrivilege { get; }
		IGenericRepository<PortalConfig> PortalConfig { get; }

		int Save();
	}
}
