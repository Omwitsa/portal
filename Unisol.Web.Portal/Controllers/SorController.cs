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
    public class SorController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly PortalCoreContext _context;
        private readonly TokenValidator _tokenValidator;
        public SorController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
        {
            _unisolApiProxy = unisolApiProxy;
            _context = context;
            _tokenValidator = new TokenValidator(_context);
        }

        [HttpPost("get")]
        public JsonResult CreateSor(CreateSorModel createSor)
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

                var createResults = _unisolApiProxy.CreateAnSor(createSor).Result;
                var jdata = JsonConvert.DeserializeObject<ReturnData<CreateSorModel>>(createResults);
				return Json(jdata);
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occured while trying to create SORs, please try again"
                });
            }
        }

        [HttpGet("getraised")]
        public JsonResult GetAllSors(string usercode)
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

                var sors = _unisolApiProxy.GetSors(usercode).Result;
                var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(sors);
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

        [HttpGet("getsoritems")]
        public JsonResult GetSorItems(string reqref)
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

                var sors = _unisolApiProxy.GetSorItems(reqref).Result;
                var jdata = JsonConvert.DeserializeObject<ReturnData<List<ProcOnlineReqDetail>>>(sors);
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

        [HttpPost("addsoritems")]
        public JsonResult AddItemsSor(AddItems addItems)
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

                var result = _unisolApiProxy.AddSorItems(addItems).Result;
                var jdata = JsonConvert.DeserializeObject<ReturnData<string>>(result);
				return Json(jdata);
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occured while adding SORs, please try again"
                });
            }
        }
    }
}
