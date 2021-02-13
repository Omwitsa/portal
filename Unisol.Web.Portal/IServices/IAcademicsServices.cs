using System.Collections.Generic;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Login;

namespace Unisol.Web.Portal.IServices
{
	public interface IAcademicsServices
	{
		ReturnData<List<dynamic>> GetStudentExamCard(string userCode, bool isPreviousTermCard);
	}
}
