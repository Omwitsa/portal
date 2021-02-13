using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Memo;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class MemoController : Controller
    {
		private readonly IUnisolApiProxy _unisolApiProxy;
		private readonly TokenValidator _tokenValidator;
		public MemoController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
		{
			_unisolApiProxy = unisolApiProxy;
			_tokenValidator = new TokenValidator(context);
		}

		[HttpGet("[action]")]
		public JsonResult GetImprestMemo(string usercode, string searchText)
		{
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var result = _unisolApiProxy.GetImprestMemo(usercode, searchText).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
			return Json(response);
		}

		[HttpGet("[action]")]
		public JsonResult GetMemoResources(string usercode)
		{
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var result = _unisolApiProxy.GetMemoResources(usercode).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
			return Json(response);
		}

		[HttpPost("[action]")]
		public JsonResult ReguestMemo([FromBody] MemoViewModel memoModel, string usercode)
		{
			memoModel.ImprestMemo.Sdate = memoModel.ImprestMemo.Sdate.GetValueOrDefault().AddDays(1);
			memoModel.ImprestMemo.Edate = memoModel.ImprestMemo.Edate.GetValueOrDefault().AddDays(1);
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});
			
			var result = _unisolApiProxy.ReguestMemo(memoModel, usercode).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
			return Json(response);
		}
	}
}