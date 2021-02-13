using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class EClaimsController : Controller
    {
		private readonly IUnisolApiProxy _unisolApiProxy;
		private readonly PortalCoreContext _context;
		private readonly TokenValidator _tokenValidator;
		public EClaimsController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
		{
			_unisolApiProxy = unisolApiProxy;
			_context = context;
			_tokenValidator = new TokenValidator(_context);
		}

		[HttpGet("[action]")]
		public JsonResult GetEClaims(string userCode, string searchText)
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

			var createResults = _unisolApiProxy.GetEClaims(userCode, searchText).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(createResults);
			return Json(jdata);
		}

		[HttpGet("[action]")]
		public JsonResult GetUnitOfMeasure()
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

			var createResults = _unisolApiProxy.GetUnitOfMeasure().Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(createResults);
			return Json(jdata);
		}

		[HttpPost("[action]")]
		public JsonResult AddEClaim(EclaimUnits claimUnits, string userCode, string description)
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

			var eclaims = _unisolApiProxy.AddEClaim(claimUnits, userCode, description).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(eclaims);
			return Json(jdata);
		}
	}
}