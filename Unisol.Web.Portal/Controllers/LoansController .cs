using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public  class  LoansController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly PortalCoreContext _context;
        private readonly TokenValidator _tokenValidator;

        public LoansController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
        {
            _unisolApiProxy = unisolApiProxy;
            _context = context;
            _tokenValidator = new TokenValidator(_context);
        }

       
        [HttpGet("GetEmployeeLoans")]
        public JsonResult GetEmployeeLoans(string userCode)
        {
            try
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
                        Message = "Sorry, you are not authorized to access this page",
                    });

                var createResults = _unisolApiProxy.GetEmployeeLoans(userCode).Result;
                var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(createResults);
				return Json(jdata);
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<bool>
                {
                    Success = false,
                    Message = "Oops,seems like an error occurred while processing your request",
                    Error = new Error(ex)
                });
            }
        }

        [HttpGet("GetEmployeeLoanStatement")]
        public JsonResult GetEmployeeLoanStatement(string userCode,int refId)
        {
            try
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
                        Message = "Sorry, you are not authorized to access this page",
                    });

                var createResults = _unisolApiProxy.GetEmployeeLoanStatement(userCode, refId).Result;
                var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(createResults);
				return Json(jdata);
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<bool>
                {
                    Success = false,
                    Message = "Sorry,seems like an error occurred while processing your request",
                    Error = new Error(ex)
                });
            }
        }
        

    }
}