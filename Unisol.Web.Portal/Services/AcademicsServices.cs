using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Login;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IServices;

namespace Unisol.Web.Portal.Services
{
	public class AcademicsServices : IAcademicsServices
	{
		private readonly IUnisolApiProxy _unisolApiProxy;
		private string classStatus;
		private readonly PortalCoreContext _context;
		public AcademicsServices(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
		{
			_context = context;
			_unisolApiProxy = unisolApiProxy;
			classStatus = context.Settings.FirstOrDefault()?.ClassStatus ?? "Active";
		}

		public ReturnData<List<dynamic>> GetStudentExamCard(string userCode, bool isPreviousTermCard)
		{
			var result = _unisolApiProxy.GetStudentExamCard(userCode, classStatus, isPreviousTermCard).Result;
			var response = new ProcessJsonReturnResults<List<dynamic>>(result).UnisolApiData;
			if (!response.Success)
				return response;

			var evaluationIsMandatory = _context.EvaluationsCurrentActive.FirstOrDefault();
			if (evaluationIsMandatory != null)
			{
				var units = new List<string>();
				response.Data.ForEach(r => {
					units.Add(r.unitCode.ToString());
				});
				var hasResponded = _context.Users.Join(_context.EvaluationTakenUnitWiseByUsers,
					u => u.Id,
					e => e.AspNetUserId,
					(u, e) => new { u.UserName, e.UnitCode }
					).Where(u => u.UserName == userCode).ToList();

				if (!hasResponded.Any())
					return new ReturnData<List<dynamic>>
					{
						Success = false,
						Message = "Kindly fill evaluations for all units",
					};
				var respondedUnits = hasResponded.Select(u => u.UnitCode).ToList();
				var unrespondedUnits = units.Any(u => !respondedUnits.Contains(u));

				if (unrespondedUnits)
					return new ReturnData<List<dynamic>>
					{
						Success = false,
						Message = "Kindly fill evaluations for all units",
					};
			}

			return response;
		}
	} 
}
