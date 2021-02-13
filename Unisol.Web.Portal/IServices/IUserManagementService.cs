using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Login;

namespace Unisol.Web.Portal.IServices
{
	public interface IUserManagementService
	{
		ReturnData<dynamic> Login(LoginViewModel request);
		ReturnData<bool> Register(RegisterViewModel request, bool isAdmin = false, bool isTest = false);
	}
}
