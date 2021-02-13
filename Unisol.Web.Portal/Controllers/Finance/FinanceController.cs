using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Finance;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly PortalCoreContext _context;
        private readonly TokenValidator _tokenValidator;
        private readonly string classStatus;

		public FinanceController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
        {
            _unisolApiProxy = unisolApiProxy;
            _context = context;
            _tokenValidator = new TokenValidator(_context);
            classStatus = _context.Settings.FirstOrDefault()?.ClassStatus;
		}

        [HttpGet("GetStudentFeeStatement")]
        public JsonResult GetStudentFeeStatement(string usercode)
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
                    Message = "Sorry, you are not authorized to view this page",
                });

            var statementResult = _unisolApiProxy.GetStudentFeeStatement(usercode, classStatus).Result;
			var jdata = new ProcessJsonReturnResults<dynamic>(statementResult).UnisolApiData;
			return Json(jdata);
        }

        [HttpPost("GetStudentFeeStructure")]
        public JsonResult GetStudentFeeStructure(FeesStructureFilter feesStructureFilter)
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
            if (token.Role != Role.Student)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = "Sorry, you are not authorized to perform this action",
                });
            }
            var statementResult = _unisolApiProxy.GetStudentFeeStructure(feesStructureFilter, classStatus).Result;
			var jdata = new ProcessJsonReturnResults<dynamic>(statementResult).UnisolApiData;
			return Json(jdata);
        }

        [HttpGet("getStudentFeeInfo")]
        public JsonResult GetStudentFeeInfo(string usercode)
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
            if (token.Role != Role.Student)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = "Sorry, you are not authorized to view this page",
                });
            }
            var statementResult = _unisolApiProxy.GetStudentFeeInfo(usercode, classStatus).Result;
			var jdata = new ProcessJsonReturnResults<dynamic>(statementResult).UnisolApiData;
			return Json(jdata);
		}
    }
}