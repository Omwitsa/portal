using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IRepository;

namespace Unisol.Web.Portal.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private PortalCoreContext _context;
		public UnitOfWork(PortalCoreContext context)
		{
			_context = context;
			//Term = new TermRepository(context);
			Users = new GenericRepository<User>(context);
			PortalMessage = new GenericRepository<PortalMessage>(context);
			UserGroups = new GenericRepository<UserGroups>(context);
			PortalNews = new GenericRepository<PortalNews>(context);
			UserToken = new GenericRepository<UserToken>(context);
			PortalEvents = new GenericRepository<PortalEvents>(context);
			UserGroupPrivilege = new GenericRepository<UserGroupPrivilege>(context);
			PortalConfig = new GenericRepository<PortalConfig>(context);
		}

		public IGenericRepository<User> Users { get; }

		public IGenericRepository<PortalMessage> PortalMessage { get; }

		public IGenericRepository<UserGroups> UserGroups { get; }

		public IGenericRepository<PortalNews> PortalNews { get; }

		public IGenericRepository<UserToken> UserToken { get; }

		public IGenericRepository<PortalEvents> PortalEvents { get; }

		public IGenericRepository<UserGroupPrivilege> UserGroupPrivilege { get; }

		public IGenericRepository<PortalConfig> PortalConfig { get; }

		public int Save()
		{
			return _context.SaveChanges();
		}
	}
}
