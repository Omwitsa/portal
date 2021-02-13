using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TranscriptController  : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
		private string classStatus;
        private readonly TokenValidator _tokenValidator;
        public TranscriptController (IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
        {
            _unisolApiProxy = unisolApiProxy;
			classStatus = context.Settings.FirstOrDefault()?.ClassStatus;
            _tokenValidator = new TokenValidator(context);
        }

        [HttpPost("GetStudentProvivisonalTranscript")]
        public JsonResult GetStudentProvisionalTranscript(TranscriptRequestViewModel transcriptRequestViewModel)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });

            var result = _unisolApiProxy.GetStudentProvisionalTranscript(transcriptRequestViewModel, classStatus).Result;
			var response = new ProcessJsonReturnResults<dynamic>(result).UnisolApiData;
			return Json(response);
		}

        [HttpGet("GetStudentPreviousAcademicYears")]
        public JsonResult GetStudentPreviousAcademicYears(string userCode)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });
			
			var result = _unisolApiProxy.GetStudentPreviousAcademicYears(userCode, classStatus).Result;
			var response = new ProcessJsonReturnResults<List<YearWithSemesterViewModel>>(result).UnisolApiData;
			var studentYears = response.Data.FirstOrDefault();
			var tabTitle = studentYears.isTivetTranscript ? "Progress Reports" : "Provisional Transcripts / Result Slip";
			tabTitle = studentYears.Institution.ToUpper().Equals("UOEM") ? "Academic Results" : tabTitle;
			var yearsResults = new
			{
				tabTitle,
				response.Data
			};
			return Json(new ReturnData<dynamic> {
				Success = response.Success,
				Data = yearsResults,
				Message = response.Message
			});
		}
    }
}