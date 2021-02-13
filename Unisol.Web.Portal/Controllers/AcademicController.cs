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
    public class AcademicController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
		private string classStatus;
        private readonly TokenValidator _tokenValidator;
        public AcademicController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
        {
            _unisolApiProxy = unisolApiProxy;
			classStatus = context.Settings.FirstOrDefault()?.ClassStatus;
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
            var result = _unisolApiProxy.GetStudentProgram(regNo, year, classStatus).Result;
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
            var result = _unisolApiProxy.GetYearsOfStudy(regNo, classStatus).Result;
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
            var result = _unisolApiProxy.GetSemisterUnits(regNo, classStatus).Result;
			var response = new ProcessJsonReturnResults<List<ProgCurriculumDetail>>(result).UnisolApiData;
			return Json(response);
		}

        [HttpPost("unitRegistration")]
        public JsonResult RegisterUnits(UnitRegistrationViewModel regunits)
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
            var result = _unisolApiProxy.RegisterUnits(regunits, classStatus).Result;
			var response = new ProcessJsonReturnResults<string>(result).UnisolApiData;
			return Json(response);
		}

		[HttpGet("getStudentFucultyInfo")]
		public JsonResult GetStudentFucultyInfo(string userCode)
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
            var result = _unisolApiProxy.GetStudentFucultyInfo(userCode, classStatus).Result;
			var response = new ProcessJsonReturnResults<FucultyViewModel>(result).UnisolApiData;
			return Json(response);
		}
	}
}