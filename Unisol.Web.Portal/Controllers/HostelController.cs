using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Unisol.Web.Common.Process;
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
    public class HostelController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly TokenValidator _tokenValidator;
        public HostelController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
        {
            _unisolApiProxy = unisolApiProxy;
            _tokenValidator = new TokenValidator(context);
        }

        [HttpGet("gethostels")]
        public JsonResult GetHostels()
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
                var hostels = _unisolApiProxy.GetHostels().Result;
                var jdata = JsonConvert.DeserializeObject<ReturnData<List<Hostels>>>(hostels);
                if (jdata.Success)
                {
                    return Json(new ReturnData<List<Hostels>>
                    {
                        Success = true,
                        Message = jdata.Message,
                        Data = jdata.Data
                    });
                }

                return Json(new ReturnData<ProcOnlineReq>
                {
                    Success = false,
                    Message = "There was a problem while retrieving Hostels, please try again"
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

        [HttpGet("hostelrooms")]
        public JsonResult GetRooms(string hostel,string searchRoom)
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
                var hostelrooms = _unisolApiProxy.GetHostelRooms(hostel,searchRoom).Result;
                var jdata = JsonConvert.DeserializeObject<ReturnData<List<HostelRooms>>>(hostelrooms);
                if (jdata.Success)
                {
                    return Json(new ReturnData<List<HostelRooms>>
                    {
                        Success = true,
                        Message = jdata.Message,
                        Data = jdata.Data
                    });
                }
                else
                {
                    return Json(new ReturnData<ProcOnlineReq>
                    {
                        Success = false,
                        Message = "There was a problem while retrieving Hostels, please try again"
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occured while trying to get Hostels, please try again"
                });
            }
        }
    }
}