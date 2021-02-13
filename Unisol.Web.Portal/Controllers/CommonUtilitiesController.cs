using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IRepository;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class CommonUtilitiesController : Controller
	{
		private readonly IUnisolApiProxy _unisolApiProxy;
		private readonly PortalCoreContext _context;
		private string classStatus;
		private IPortalServices _portalServices;
        private readonly TokenValidator _tokenValidator;
        public CommonUtilitiesController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context, IPortalServices portalServices)
		{
			_unisolApiProxy = unisolApiProxy;
			_context = context;
			_portalServices = portalServices;
			classStatus = _context.Settings.FirstOrDefault()?.ClassStatus;
            _tokenValidator = new TokenValidator(_context);
        }

		[HttpGet("getStudentcurrentTerm")]
		public JsonResult GetStudentCurrentTerm(string usercode)
		{
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });

            var onlineReporting = _unisolApiProxy.GetStudentCurrentTerm(usercode, classStatus).Result;
			var jdata = new ProcessJsonReturnResults<Term>(onlineReporting).UnisolApiData;
			return Json(jdata);
		}

		[HttpGet("currectActiveTerm")]
		public JsonResult CurrectActiveTerm(string usercode)
		{
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });
            }
            var onlineReporting = _unisolApiProxy.CurrectActiveTerm(usercode, classStatus).Result;
			var jdata = new ProcessJsonReturnResults<string>(onlineReporting).UnisolApiData;
			return Json(jdata);
		}

		[HttpGet("checkReportStatus")]
		public JsonResult CheckReportStatus(string usercode)
		{
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });
            }
            var onlineReporting = _unisolApiProxy.CheckReportStatus(usercode, classStatus).Result;
			var jdata = new ProcessJsonReturnResults<OnlineReporting>(onlineReporting).UnisolApiData;
			return Json(jdata);
		}

		[HttpGet("settingstatus")]
		public JsonResult CheckSettingStatus(string settingCode)
		{
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });

            var message = "";
			var ConfigResponse = _portalServices.GetConfigurations();
			if (!ConfigResponse.Success)
				return Json(ConfigResponse);

			var settings = ConfigResponse.Data.FirstOrDefault(c => c.Code == settingCode);
			if(settings == null)
				return Json(new ReturnData<dynamic> {
					Success = false,
					Message = "Sorry, the service has been temporarily disabled",
					Data = ConfigResponse.Data
				});

			var service = settings.Name.ToLower().Split(" ");
			if (service != null)
			{
				var name = service[1] != null ? service[1] : "";
				message = service[2] != null ? service[1] + " " + service[2] : service[1];
			};

			message = settings.Status
					? settings.Name.First().ToString().ToUpper() + settings.Name.Substring(1).ToLower() + " has been enabled"
					: message.First().ToString().ToUpper() + message.Substring(1).ToLower() + " has been temporarily disabled";

			return Json(new ReturnData<string>
			{
				Success = settings.Status,
				Message = message
			});
		}

		[HttpGet("GetStudentAcademicInfo")]
		public JsonResult GetStudentAcademicInfo(string userCode, bool isPreviousTermCard = false)
		{
			var studentDetails = _unisolApiProxy.GetStudentDetails(userCode, classStatus, isPreviousTermCard).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<StudentAcademicViewModel>>(studentDetails);
			
			return Json(jdata);
		}

		[HttpGet("GetStudentFeeStructureYears")]
		public JsonResult GetStudentFeeStructureYears(string progCode)
		{
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });
            }
            var structure = _unisolApiProxy.GetStudentFeeStructureYears(progCode, classStatus).Result;
			var jdata = new ProcessJsonReturnResults<dynamic>(structure).UnisolApiData;
			return Json(jdata);
		}

		[HttpGet("GetInstitutionInfo")]
		public JsonResult GetInstitutionInfo()
		{
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });
            }
            var structure = _unisolApiProxy.GetInstitutionInfo().Result;
			var jdata = new ProcessJsonReturnResults<dynamic>(structure).UnisolApiData;
			return Json(jdata);
		}
	}
}