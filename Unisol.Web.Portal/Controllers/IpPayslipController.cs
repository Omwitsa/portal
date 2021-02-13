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
	public class IpPayslipController : Controller
    {
		private readonly IUnisolApiProxy _unisolApiProxy;
		private readonly PortalCoreContext _context;
		private readonly TokenValidator _tokenValidator;
		private UserValidator userValidator;
		public IpPayslipController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
		{
			_unisolApiProxy = unisolApiProxy;
			_context = context;
			_tokenValidator = new TokenValidator(_context);
			userValidator = new UserValidator();
		}

		[HttpGet("getIpProjects")]
		public JsonResult GetIpProjects(string userCode)
		{
			var valid = userValidator.Validate(_tokenValidator, HttpContext, Role.Staff);
			if (!valid.Success)
				return Json(valid);

			var createResults = _unisolApiProxy.GetIpProjects(userCode).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(createResults);
			return Json(jdata);
		}

		[HttpGet("getIpPaySlip")]
		public JsonResult GetIpPaySlip(string userCode, string project)
		{
			var valid = userValidator.Validate(_tokenValidator, HttpContext, Role.Staff);
			if (!valid.Success)
				return Json(valid);

			var createResults = _unisolApiProxy.GetIpPaySlip(userCode, project).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(createResults);
			return Json(jdata);
		}
	}
}