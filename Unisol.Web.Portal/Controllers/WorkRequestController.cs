using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
	public class WorkRequestController : Controller
	{
		private readonly IUnisolApiProxy _unisolApiProxy;
		private readonly TokenValidator _tokenValidator;

		public WorkRequestController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
		{
			_unisolApiProxy = unisolApiProxy;
			_tokenValidator = new TokenValidator(context);
		}

		[HttpGet("[action]")]
		public JsonResult GetWorkOrders(string usercode) {
			usercode = usercode ?? "";
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var result = _unisolApiProxy.GetWorkOrders(usercode.Trim()).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<List<ESWorkRequest>>>(result);
			return Json(response);
		}

		[HttpPost("[action]")]
		public JsonResult OrderWork([FromBody] ESWorkRequest workRequest, bool isUpdate = false)
		{
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var result = _unisolApiProxy.OrderWork(workRequest, isUpdate).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<string>>(result);
			return Json(response);
		}

		[HttpGet("[action]")]
		public JsonResult GetUserWorkRequestDetails(string usercode)
		{
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var result = _unisolApiProxy.GetUserWorkRequestDetails(usercode).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
			return Json(response);
		}

		[HttpGet("[action]")]
		public JsonResult GetWorkOrderDetails(string usercode, string orderRef)
		{
			usercode = usercode ?? "";
			orderRef = orderRef ?? "";
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var result = _unisolApiProxy.GetWorkOrderDetails(usercode.Trim(), orderRef.Trim()).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
			return Json(response);
		}

		[HttpPost("[action]")]
		public JsonResult SaveWorkOrderFeedback([FromBody] ESWorkRequest workRequest)
		{
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var result = _unisolApiProxy.OrderWork(workRequest, true).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<string>>(result);
			return Json(response);
		}
	}
}
