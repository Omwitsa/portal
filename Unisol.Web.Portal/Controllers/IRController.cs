using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Sor;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class IRController : Controller
	{
		private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly TokenValidator _tokenValidator;
        private readonly PortalCoreContext _context;
        public IRController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
		{
            _context = context;
            _unisolApiProxy = unisolApiProxy;
            _tokenValidator = new TokenValidator(_context);
        }

		[HttpGet("getIR")]
		public JsonResult GetIR(string usercode)
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

            var ir = _unisolApiProxy.GetIR(usercode).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(ir);
			if (!jdata.Success)
				return Json(new ReturnData<ProcOnlineReq>
				{
					Success = false,
					Message = jdata.Message
				});

			return Json(new ReturnData<dynamic>
			{
				Success = true,
				Message = jdata.Message,
				Data = jdata.Data
			});
		}

		[HttpPost("createIR")]
		public JsonResult CreateIR(CreateSorModel createIR, string usercode)
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

            var createResults = _unisolApiProxy.CreateIR(createIR, usercode).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<CreateSorModel>>(createResults);
			if (!jdata.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, there was a problem while creating Internal Requisition, please try again"
				});

			return Json(new ReturnData<string>
			{
				Success = true,
				Message = "Internal Requisition created successfully"
			});
		}

		[HttpGet("getIRItems")]
		public JsonResult GetIRItems(string reqref)
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
						Message = "Sorry, you are not authorized to perform this action",
					});

				var irs = _unisolApiProxy.GetSorItems(reqref).Result;
				var jdata = JsonConvert.DeserializeObject<ReturnData<List<ProcOnlineReqDetail>>>(irs);
				return Json(jdata);
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "An error occured while trying to get SORs, please try again"
				});
			}
		}
	}
}
