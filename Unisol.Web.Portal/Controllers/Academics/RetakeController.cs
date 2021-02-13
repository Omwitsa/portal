using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
	public class RetakeController : Controller
    {
		private readonly IUnisolApiProxy _unisolApiProxy;
		private readonly PortalCoreContext _context;
		private readonly TokenValidator _tokenValidator;
		private UserValidator userValidator;
		private string classStatus;
		public RetakeController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
		{
			_unisolApiProxy = unisolApiProxy;
			_context = context;
			_tokenValidator = new TokenValidator(_context);
			userValidator = new UserValidator();
			classStatus = context.Settings.FirstOrDefault()?.ClassStatus;
		}

		[HttpGet("getRetakes")]
		public JsonResult GetRetakes(string userCode)
		{
			var valid = userValidator.Validate(_tokenValidator, HttpContext, Role.Student);
			if (!valid.Success)
				return Json(valid);

			var results = _unisolApiProxy.GetRetakes(userCode).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(results);
			return Json(jdata);
		}

		[HttpGet("getRetakeUnits")]
		public JsonResult GetRetakeUnits(string userCode)
		{
			var valid = userValidator.Validate(_tokenValidator, HttpContext, Role.Student);
			if (!valid.Success)
				return Json(valid);

			var results = _unisolApiProxy.GetRetakeUnits(userCode, classStatus).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(results);
			return Json(jdata);
		}

		[HttpPost("saveRetake")]
		public JsonResult SaveRetake(RetakeModel retake)
		{
			if(string.IsNullOrEmpty(retake.Term))
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, Session cannot be empty",
				});
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var result = _unisolApiProxy.SaveRetake(retake, classStatus).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<string>>(result);
			return Json(response);
		}

		[HttpGet("getRetakeDetails")]
		public JsonResult GetRetakeDetails(string userCode, int retakeId)
		{
			var valid = userValidator.Validate(_tokenValidator, HttpContext, Role.Student);
			if (!valid.Success)
				return Json(valid);

			var results = _unisolApiProxy.GetRetakeDetails(userCode, retakeId).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(results);
			return Json(jdata);
		}
	}
}