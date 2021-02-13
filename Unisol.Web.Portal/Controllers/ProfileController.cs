using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Profile;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
        public PortalCoreContext _context;
        private readonly TokenValidator _tokenValidator;
        private string classStatus;

        public ProfileController(PortalCoreContext context, IUnisolApiProxy unisolApiProxy)
        {
            _unisolApiProxy = unisolApiProxy;
            _context = context;
            classStatus = _context.Settings.FirstOrDefault()?.ClassStatus;
            _tokenValidator = new TokenValidator(_context);
        }

        [HttpGet("getStudentData")]
        public JsonResult GetStudentData(string userCode)
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
            var result = _unisolApiProxy.GetStudentData(userCode, classStatus).Result;
            var response = new ProcessJsonReturnResults<dynamic>(result).UnisolApiData;
            return Json(response);
        }

        [HttpGet("getStudentEnrollment")]
        public JsonResult GetStudentEnrollment(string userCode)
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
            var result = _unisolApiProxy.GetStudentEnrollment(userCode, classStatus).Result;
            var response = new ProcessJsonReturnResults<dynamic>(result).UnisolApiData;
            return Json(response);
        }

        [HttpGet("getStaffData")]
        public JsonResult GetStaffData(string userCode)
        {
            var result = _unisolApiProxy.GetStaffData(userCode).Result;
            var response = new ProcessJsonReturnResults<dynamic>(result).UnisolApiData;
            return Json(response);
        }

        [HttpGet("[action]")]
        public JsonResult GetJobTitle(string userCode)
        {
            var result = _unisolApiProxy.GetJobTitle(userCode).Result;
            var response = new ProcessJsonReturnResults<dynamic>(result).UnisolApiData;
            return Json(response);
        }

        [HttpGet("getEmploymentProfile")]
        public JsonResult GetEmploymentProfile(string userCode)
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
            var result = _unisolApiProxy.GetEmploymentProfile(userCode).Result;
            var response = new ProcessJsonReturnResults<HrpIpprofile>(result).UnisolApiData;
            return Json(response);
        }

        [HttpPost]
        [Route("editStudentProfile")]
        public JsonResult EditStudentProfile(StudentprofileViewModel profileViewModel, ProfileEditor editOperation)
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

                var settings = _context.PortalConfigs.Any(c => c.Code == "008" && c.Status);
                var profileUpdates = new ProfileUpdates
                {
                    TelNo = profileViewModel.Telno,
                    Email = profileViewModel.Email,
                    HomeAddress = profileViewModel.Homeaddress,
                    UserCode = profileViewModel.AdmnNo,
                    DateCreated = DateTime.Now,
                    AllowedAdminApproval = true,
                    Status = false
                };

                if (settings)
                {
                    var updateProfileResults = _unisolApiProxy.EditStudentProfile(profileViewModel, classStatus, editOperation).Result;
                    var jdata = JsonConvert.DeserializeObject<ReturnData<string>>(updateProfileResults);
                    if (jdata.Success)
                    {
						var portalUser = _context.Users.FirstOrDefault(u => u.UserName.ToUpper().Equals(profileViewModel.AdmnNo.ToUpper()));
						if (portalUser != null)
						{
							portalUser.Email = profileViewModel.Email;
							_context.SaveChanges();
						}
							
						return Json(new ReturnData<string>
                        {
                            Success = true,
                            Message = "Profile Updated successfully"
                        });
                    }
                }
				
				_context.ProfileUpdate.Add(profileUpdates);
                _context.SaveChanges();

                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Profile Updated Request received, We shall contact yo shortly"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occured while trying to update the profile, please try again"
                });
            }
        }

        [HttpPost]
        [Route("editStaffProfile")]
        public JsonResult EditStaffProfile(StaffProfileViewModel profileViewModel)
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
            var updateProfileResults = _unisolApiProxy.EditStaffProfile(profileViewModel).Result;
            var jdata = JsonConvert.DeserializeObject<ReturnData<string>>(updateProfileResults);
            return Json(jdata);
        }
	}
}