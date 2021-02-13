using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.HostelBooking;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class HostelBookingController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly PortalCoreContext _context;
		private string classStatus;
        private readonly TokenValidator _tokenValidator;

        public HostelBookingController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
        {
            _unisolApiProxy = unisolApiProxy;
            _context = context;
			classStatus = _context.Settings.FirstOrDefault()?.ClassStatus;
            _tokenValidator = new TokenValidator(_context);
        }

        [HttpGet("myhostelbookings")]
        public JsonResult MyHostelBookings(string usercode, bool fetchLatestHostel = false)
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
                        Message = "Sorry, you are not authorized to access this page",
                    });

                var createResults = _unisolApiProxy.GetMyBookings(usercode, fetchLatestHostel, classStatus).Result;
                var jdata = JsonConvert.DeserializeObject<ReturnData<List<HostelBooking>>>(createResults);
                if (jdata.Success)
                {
                    if (!fetchLatestHostel)
                    {
                        return Json(new ReturnData<dynamic>
                        {
                            Success = true,
                            Message = jdata.Message,
                            Data = jdata.Data
                        });
                    }
                    var data = jdata.Data.FirstOrDefault();
                    return Json(new ReturnData<dynamic>
                    {
                        Success = true,
                        Message = jdata.Message,
                        Data = data
                    });
                }
                else
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "There was a problem while retrieving your booking history"
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "There was a problem while retrieving your hostel booking history, please try again",
                    Error = new Error(ex)
                });
            }
        }

        [HttpGet("retrieveopenhostels")]
        public JsonResult RetrieveOpenHostels(string usercode)
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
                        Message = "Sorry, you are not authorized to access this page",
                    });

                var bookable = _unisolApiProxy.GetBookableHostels(usercode, classStatus).Result;
                var jdata = JsonConvert.DeserializeObject<ReturnData<List<Hostels>>>(bookable);

				return Json(jdata);
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "There was a problem while retrieving your hostel booking history, please try again",
					Error = new Error(ex)
                });
            }
        }

        [HttpGet("retrievebookablerooms")]
        public JsonResult GetBookableRooms(string hostel, string usercode, string searchString)
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
                        Message = "Sorry, you are not authorized to access this page",
                    });

                var hostelRatio = _context.Settings.FirstOrDefault()?.HostelRatio ?? "";
                var bookable = _unisolApiProxy.GetRoomsForBooking(hostel, usercode, searchString, classStatus, hostelRatio).Result;
                var jdata = JsonConvert.DeserializeObject<ReturnData<List<HostelRooms>>>(bookable);
				return Json(jdata);
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "There was a problem while retrieving bookable rooms " + ex.Message
                });
            }
        }

        [HttpGet("checkeligibility")]
        public JsonResult CheckIfEligibleToBook(string usercode)
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
                        Message = "Sorry, you are not authorized to access this page",
                    });

                var bookable = _unisolApiProxy.CheckBookingEligibility(usercode, classStatus).Result;
                var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(bookable);
				if (!jdata.Success)
					return Json(jdata);

				string inistitutionInitial = jdata.Data.data?.inistitutionInitial ?? "";
				if (inistitutionInitial.ToUpper().Equals("UOEM"))
				{
					var rationStr = _context.Settings.FirstOrDefault()?.HostelRatio ?? "";
					var ratios = rationStr.Split(")*(");
					double bookedRate = jdata.Data.data.rate;
					int yearIndex = jdata.Data.data.yearIndex;
					double allowedRate = bookedRate;
					var val = ratios.Length;
					if(ratios.Length >= yearIndex)
						double.TryParse(ratios[yearIndex] ?? "", out allowedRate);
					allowedRate = allowedRate > 0 ? allowedRate : 100;
					if (bookedRate > allowedRate)
						return Json(new ReturnData<string>
						{
							Success = false,
							NotAuthenticated = true,
							Message = "Sorry, Your cohort has reached maximum booking capacity",
						});
				}
				
				return Json(jdata);
			}
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "There was a problem while checking your eligibilty " + ex.Message
                });
            }
        }

        [HttpPost("savebooking")]
        public JsonResult SaveHostelBooking(HostelBookingModel hostelBookingModel)
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

                var hostelRatio = _context.Settings.FirstOrDefault()?.HostelRatio;
                var bookingResults = _unisolApiProxy.SubmitBooking(hostelBookingModel, classStatus, hostelRatio).Result;
                var jdata = JsonConvert.DeserializeObject<ReturnData<string>>(bookingResults);
				return Json(jdata);
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "There was a problem while retrieving your hostel booking history, please try again"
                });
            }
        }

        [HttpGet("checkhostelbookingstatus")]
        public JsonResult CheckHostelbookingStatus()
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
                        Message = "Sorry, you are not authorized to access this page",
                    });

                var settings = _context.PortalConfigs.FirstOrDefault(c => c.Code == "001");
                if (settings == null)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "This setting has not been enabled by admin,please consult the admin"
                    });

                var message = settings.Status
                    ? "Hostel booking has been enabled"
                    : "Hostel booking has been disabled by administrator";

                return Json(new ReturnData<string>
                {
                    Success = settings.Status,
                    Message = message
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<bool>
                {
                    Success = false,
                    Message = "This setting has not been enabled by admin,please consult the admin " + ex.Message
                });
            }
        }
    }
}