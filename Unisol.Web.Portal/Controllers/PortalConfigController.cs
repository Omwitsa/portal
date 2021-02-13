using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.ExamCard;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Models;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PortalConfigController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly PortalCoreContext _context;
        private readonly TokenValidator _tokenValidator;
        private IHostingEnvironment _env;

     
        public PortalConfigController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context,IHostingEnvironment env)
        {
            _unisolApiProxy = unisolApiProxy;
            _context = context;
            _env = env;
            _tokenValidator = new TokenValidator(_context);
        }

        public JsonResult GetPortalSettings()
        {
            var jsonConfigs = System.IO.File.ReadAllLines(System.IO.Path.Combine(_env.WebRootPath, "portalconfigs.json"));
            return Json(jsonConfigs);
        }

        [HttpPost("savePortalSettingsConfigs")]
        public JsonResult SavePortalSettingsConfig(PortalConfigData portalConfigData)
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

				var setting = _context.Settings.FirstOrDefault();
				setting.UnitsRegLevels = portalConfigData.UnitsLevel;
				setting.HostelRatio = portalConfigData.HostelRatio ?? "";
				setting.ExamCardNotes = portalConfigData.ExamCardNotes ?? "";
				setting.HostelDuration = portalConfigData.HostelDuration;
				setting.HostelBookingStartDate = portalConfigData.BookingStartDate.GetValueOrDefault().AddDays(1).Date;
				var rations = setting.HostelRatio.Split(")*(");
				double totalPercentage = 0;
				foreach(var ratio in rations)
				{
					double.TryParse(ratio, out double percentage);
					totalPercentage = totalPercentage + percentage;
				}

				if(totalPercentage > 100)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, hostel allocation percentage cannot be greater than 100%",
					});

				if (portalConfigData.ClassStatus != null)
					setting.ClassStatus = portalConfigData.ClassStatus;

                var portalConfigs = _context.PortalConfigs.ToList();
                var message = "";
                if (portalConfigs.Count >0)
                {
                    portalConfigs.ForEach(p =>
                    {
						portalConfigData.PortalConfigs.ForEach(r =>
                         {
                             if (p.Code == r.Code)
                             {
                                 p.Status = r.Status;
                             }
                         });
                    });
                    _context.PortalConfigs.UpdateRange(portalConfigs);
                    message ="Settings have been updated" ;
                }
                else
                {
                    _context.PortalConfigs.AddRange(portalConfigData.PortalConfigs);
                    message = "Settings have been saved";
                }

                _context.SaveChanges();
                return Json(new ReturnData<ExamCardStatusModel>
                {
                    Message = message,
                    Data = new ExamCardStatusModel {Status = true}
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "There was a problem when switching exam card status " + ex.Message
                });
            }
        }

        [HttpGet("getexamcardstatus")]
        public JsonResult GetExamCardStatus()
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
            var configs = _context.PortalConfigs.ToList();
            return Json(new ReturnData<List<PortalConfig>>
            {
                Success = configs.Count >0,
                Message = configs.Count > 0 ? "" : "No portal settings found",
                Data = configs
			});
        }

		[HttpGet("getClassStatus")]
		public JsonResult GetClassStatus()
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
                var result = _unisolApiProxy.GetClassStatus().Result;
				var response = new ProcessJsonReturnResults<dynamic>(result).UnisolApiData;
				return Json(response);
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Oops,an error, please contact admin " + ErrorMessangesHandler.ExceptionMessage(ex)
				});
			}
		}

		[HttpGet("selectedPortalClassStutus")]
		public JsonResult SelectedPortalClassStutus()
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

				var unitsLevels = Enum.GetNames(typeof(UnitsLevels));
				var setting = _context.Settings.FirstOrDefault();
                
                return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						setting,
						unitsLevels,
                        unitLevel = $"{setting.UnitsRegLevels}"
					}
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Server Error"
				});
			}
		}
	}
}