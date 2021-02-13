using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Reporting;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineReportingController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
		private readonly PortalCoreContext _context;
        private readonly TokenValidator _tokenValidator;
        private string classStatus;
		public OnlineReportingController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
        {
            _unisolApiProxy = unisolApiProxy;
			_context = context;
			classStatus = context.Settings.FirstOrDefault()?.ClassStatus;
            _tokenValidator = new TokenValidator(_context);
        }

        [HttpGet("OnlineReporting")]
        public JsonResult OnlineReporting(string usercode,string searchString="",int offset=1)
        {
            try
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
                if (token.Role != Role.Student)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to access this page",
                    });
                }
                var onlineReporting = _unisolApiProxy.GetOnlineReporting(usercode, classStatus).Result;
                var jdata = new ProcessJsonReturnResults<List<ReportingViewModel>>(onlineReporting).UnisolApiData;
                if (jdata.Success)
                {
                    return Json(new ReturnData<List<ReportingViewModel>>
                    {
                        Success = true,
                        Message = jdata.Message,
                        Data = jdata.Data
                    });
                }

                return Json(new ReturnData<bool>
                {
                    Success = false,
                    Message = jdata.Message
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occured while trying to get Hostels, please try again " + ex.Message
                });
            }
        }

        [HttpPost("report")]
        public JsonResult ReportOnline(ReportOnlineViewModel reportOnlineViewModel)
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

                if (token.Role != Role.Student)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to perform this action",
                    });

                var classStatus = _context.Settings.FirstOrDefault()?.ClassStatus;
				var hostelrooms = _unisolApiProxy.ReportOnline(reportOnlineViewModel, classStatus).Result;
                var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(hostelrooms);
                if (!jdata.Success)
					return Json(new ReturnData<bool>
					{
						Success = false,
						Message = jdata.Message
					});

				return Json(new ReturnData<List<HostelRooms>>
				{
					Success = true,
					Message = jdata.Message
				});
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Oops,An error occured while trying saving your reporting, please try again " + ErrorMessangesHandler.ExceptionMessage(ex)
                });
            }
        }
    }
}