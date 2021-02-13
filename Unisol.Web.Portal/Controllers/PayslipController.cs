using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public  class  PayslipController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly PortalCoreContext _context;
        private readonly TokenValidator _tokenValidator;
        public PayslipController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
        {
            _unisolApiProxy = unisolApiProxy;
            _context = context;
            _tokenValidator = new TokenValidator(_context);
        }
       
        [HttpGet("GetEmployeePayslip")]
        public JsonResult GetEmployeePayslip(string userCode,string month)
        {
			if (string.IsNullOrEmpty(month))
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Kindly select the month"
				});

			var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });
			
			if (token.Role != Role.Staff)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = "Sorry, you are not authorized to perform this action",
                });

            var createResults = _unisolApiProxy.GetEmployeePayslip(userCode, month).Result;
            var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(createResults);
			return Json(jdata);
        }

        [HttpGet("GetPayslipYears")]
        public JsonResult GetPayslipYears()
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
            if (token.Role != Role.Staff)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = "Sorry, you are not authorized to perform this action",
                });
            }
            var createResults = _unisolApiProxy.GetPayslipYears().Result;
            var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(createResults);
			return Json(jdata);
        }

        [HttpGet("GetPayslipPeriod")]
        public JsonResult GetPayslipPeriod(string year)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });

            if (token.Role != Role.Staff)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = "Sorry, you are not authorized to perform this action",
                });

            var createResults = _unisolApiProxy.GetPayslipPeriod(year).Result;
            var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(createResults);
			return Json(jdata);
        }
    }
}