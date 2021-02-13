using System.Collections.Generic;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Messages;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.IServices
{
    public interface ISystemServices
	{
		ReturnData<SysSetup> GetSystemSetup();
        ReturnData<List<RecipientViewModel>> GetMessageRecepients(string userName);
	}
}
