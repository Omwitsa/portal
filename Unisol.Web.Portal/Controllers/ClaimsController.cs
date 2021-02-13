using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Claims;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly PortalCoreContext _context;
        private readonly TokenValidator _tokenValidator;
        public ClaimsController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
        {
            _unisolApiProxy = unisolApiProxy;
            _context = context;
            _tokenValidator = new TokenValidator(_context);
        }

        public JsonResult ClaimsHistory(string userCode)
        {
            return Json(new { });
        }

        [HttpGet("GetEmployeeClaimSummary")]
        public JsonResult GetEmployeeClaimsSummary(string userCode,string searchString)
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
            var createResults = _unisolApiProxy.GetEmployeeClaimsSummary(userCode,searchString).Result;
            var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(createResults);
			return Json(jdata);
        }

        [HttpGet("GetEmployeeTermsForClaim")]
        public JsonResult GetEmployeeTermsForClaim()
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
            var createResults = _unisolApiProxy.GetEmployeeTermsForClaim().Result;
            var jdata = JsonConvert.DeserializeObject<ReturnData<List<Term>>>(createResults);
			return Json(jdata);
        }

        [HttpGet("GetUnitsForAddingClaim")]
        public JsonResult GetUnitsForAddingClaim(string unitNameCode)
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
            var createResults = _unisolApiProxy.GetUnitsForAddingClaim(unitNameCode).Result;
            var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(createResults);
			return Json(jdata);
        }

        [HttpGet("GetClaimDetails")]
        public JsonResult GetClaimDetails(string pcref)
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
            var createResults = _unisolApiProxy.GetClaimDetails(pcref).Result;
            var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(createResults);
			return Json(jdata);
        }

        [HttpGet("GetClaimRates")]
        public JsonResult GetClaimRates()
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
            var createResults = _unisolApiProxy.GetClaimRates().Result;
            var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(createResults);
			return Json(jdata);
		}

        [HttpPost("SaveEmployeeClaimDetails")]
        public JsonResult SaveEmployeeClaimDetails(List<ClaimDetailsViewModel> claimDetailsViewModel)
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
            var createResults = _unisolApiProxy.SaveEmployeeClaimDetails(claimDetailsViewModel).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<string>>(createResults);
			return Json(jdata);
		}
    }
}