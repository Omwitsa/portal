using Microsoft.AspNetCore.Mvc;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PNineController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly PortalCoreContext _context;
        private readonly TokenValidator _tokenValidator;
        public PNineController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
        {
            _unisolApiProxy = unisolApiProxy;
            _context = context;
            _tokenValidator = new TokenValidator(_context);
        }

        [HttpGet("GetEmpPnine")]
        public JsonResult GetEmpPnine(string userCode,int year)
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

            var statementResult = _unisolApiProxy.GetEmpPnine(userCode, year).Result;
			var jdata = new ProcessJsonReturnResults<dynamic>(statementResult).UnisolApiData;
			return Json(jdata);
		}
    }
}