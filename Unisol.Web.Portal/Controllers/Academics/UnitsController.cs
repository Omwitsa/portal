using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
		private Settings settings;
        private readonly TokenValidator _tokenValidator;

        public UnitsController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
        {
            _unisolApiProxy = unisolApiProxy;
			settings = context.Settings.FirstOrDefault();
            _tokenValidator = new TokenValidator(context);
        }

        [HttpGet("getstudentprogram")]
        public JsonResult GetProgram(string regNo, string year)
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
            var result = _unisolApiProxy.GetStudentProgram(regNo, year, settings?.ClassStatus).Result;
			var response = new ProcessJsonReturnResults<List<ProgramType>>(result).UnisolApiData;
			return Json(response);
		}

		[HttpGet("yearsofstudy")]
        public JsonResult GetYearsOfStudy(string regNo)
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
            var result = _unisolApiProxy.GetYearsOfStudy(regNo, settings?.ClassStatus).Result;
			var response = new ProcessJsonReturnResults<List<ProgCurriculumDetail>>(result).UnisolApiData;
			return Json(response);
		}

		[HttpGet("semisterunits")]
        public JsonResult GetSemisterUnits(string regNo)
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
            var result = _unisolApiProxy.GetSemisterUnits(regNo, settings?.ClassStatus).Result;
			var response = new ProcessJsonReturnResults<string>(result).UnisolApiData;
			return Json(response);
		}


		[HttpGet("GetRegisteredUnits")]
        public JsonResult GetRegisteredUnits(string userCode)
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
            var result = _unisolApiProxy.GetRegisteredUnits(userCode, settings?.ClassStatus).Result;
			var response = new ProcessJsonReturnResults<List<FormattedSubjects>>(result).UnisolApiData;
			return Json(response);
		}

        [HttpGet("ReturnStudentCurriulum")]
        public JsonResult ReturnStudentCurriulum(string userCode)
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
            var result = _unisolApiProxy.GetStudentCurriculum(userCode, settings?.ClassStatus).Result;
			var response = new ProcessJsonReturnResults<dynamic>(result).UnisolApiData;
			return Json(response);
		}

        [HttpGet("GetStudentUnitRegisteredHistory")]
        public JsonResult GetStudentUnitRegisteredHistory(string userCode)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });

            if (token.Role != Role.Student)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = "Sorry, you are not authorized to perform this action",
                });

            var result = _unisolApiProxy.GetStudentUnitRegisteredHistory(userCode, settings?.ClassStatus).Result;
			var response = new ProcessJsonReturnResults<object>(result).UnisolApiData;
			return Json(response);
		}
		
        [HttpGet("ReturnStudentCurrentSemesterUnits")]
        public JsonResult ReturnStudentCurrentSemesterUnits(string userCode)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });
            if (token.Role != Role.Student)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = "Sorry, you are not authorized to perform this action",
                });
			var regLevel = "";
			if (settings.UnitsRegLevels == UnitsLevels.YearlyUnits)
				regLevel = "Yearly Units";
			if (settings.UnitsRegLevels == UnitsLevels.SessionUnits)
				regLevel = "Session Units";

			var result = _unisolApiProxy.ReturnStudentCurrentSemesterUnits(userCode, settings?.ClassStatus, regLevel).Result;
			var response = new ProcessJsonReturnResults<dynamic>(result).UnisolApiData;
			return Json(response);
		}

        [HttpPost("SaveStudentCurrentSemesterUnits")]
        public JsonResult SaveStudentCurrentSemesterUnits(CurriculumUnitsModel curriculumUnits)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });

            var result = _unisolApiProxy.SaveStudentCurrentSemesterUnits(curriculumUnits, settings?.ClassStatus).Result;
			var response = new ProcessJsonReturnResults<List<string>>(result).UnisolApiData;
			return Json(response);
		}
    }
}