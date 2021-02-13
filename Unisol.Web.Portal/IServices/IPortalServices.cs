using System.Collections.Generic;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Users;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Portal.IRepository
{
	public interface IPortalServices
	{
		ReturnData<List<User>> GetUsers();
		ReturnData<User> GetUserByCode(string userCose);
		ReturnData<List<UserViewModelList>> FilterUsers(string searchText, int? offset = null, int? itemsPerPage = null, int? role = null, bool unconfirmed = false);
		ReturnData<List<PortalMessage>> GetMessages();
		ReturnData<List<UserGroups>> GetUserGroups();
		ReturnData<List<PortalNews>> GetNews(string searchText, string userCode, int offset = 0);
		ReturnData<List<PortalEvents>> GetEvents(string searchText, string tokenString, string userCode, int? offset = null, int? itemsPerPage = null, int? eventsType = null);
		ReturnData<List<UserGroupPrivilege>> FilterPrivileges(string searchText, Role role, ActionLevel level, int? offset = null, int? itemsPerPage = null);
		ReturnData<List<PortalConfig>> GetConfigurations();
		ReturnData<List<EvaluationsCurrent>> GetCurrentEvaluations(string searchText, int? offset = null, int? itemsPerPage = null);
	}
}
