using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Unisol.Web.Api.IServices;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Reporting;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineReportingController : Controller
    {
        private readonly UnisolAPIdbContext _context;
		private StudentCredential studentCredentials;
		private IStudentServices _studentServices;
		public OnlineReportingController(UnisolAPIdbContext context, IStudentServices studentServices, ISystemServices systemServices)
        {
            _context = context;
			_studentServices = studentServices;
			studentCredentials = new StudentCredential(context, studentServices, systemServices);
		}

        [HttpGet("GetOnlineReporting")]
        public JsonResult GetOnlineReporting(string usercode, string classStatus)
        {
            try
            {
                var onlineReporting = _context.OnlineReporting.Where(r => r.AdmnNo == usercode).OrderByDescending(r => r.Rdate).ToList();

				var erpReporting = _context.Reporting.Where(r => r.AdmnNo == usercode).OrderByDescending(r => r.Rdate).ToList();

                var onlineReportingViewModel = new List<ReportingViewModel>();
                if (onlineReporting.Count > 0)
                {
                    onlineReporting.ForEach(oR =>
                    {
                        onlineReportingViewModel.Add(new ReportingViewModel
                        {
                            AdmnNo = oR.AdmnNo,
                            Term = oR.Term,
                            Rdate = oR.Rdate,
                            Personnel = oR.Personnel,
                            Type = "Reported Online"
                        });
                    });
                }

                if (erpReporting.Count > 0)
                {
                    erpReporting.ForEach(eR =>
                    {
                        if (onlineReportingViewModel.All(oR => oR.Term != eR.Term))
                        {
                            onlineReportingViewModel.Add(new ReportingViewModel
                            {
                                AdmnNo = eR.AdmnNo,
                                Term = eR.Term,
                                Rdate = eR.Rdate,
                                Rtime = eR.Rtime,
                                Personnel = eR.Personnel,
                                Type = "Reported Via ERP"
                            });
                        }
                    });
                }

                return Json(new ReturnData<List<ReportingViewModel>>
                {
                    Success = onlineReportingViewModel.Count > 0,
                    Message =
                        onlineReportingViewModel.Count > 0 ? "My Reporting history" : "No reporting history found",
                    Data = onlineReportingViewModel
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message =
                        "Sorry something went wrong while retrieving your reporting history, please try again : " +
                        ex.Message
                });
            }
        }

        [HttpPost("AddOnlineReporting")]
        public JsonResult AddOnlineReporting(ReportOnlineViewModel reportOnlineModel, string classStatus)
        {
			var sysSetup = _context.SysSetup.FirstOrDefault();
			if (sysSetup.ReportingDeadline.Date < DateTime.UtcNow.Date)
				return Json(new ReturnData<OnlineReporting>
				{
					Success = false,
					Message = "Sorry, Your reporting deadline has expired, Please contact School Admin. ",
				});

			var plannerDetails = _studentServices.GetSessionPlannerCurrentDetails(reportOnlineModel.UserCode, classStatus);
			if (!plannerDetails.Success)
				return Json(new ReturnData<OnlineReporting>
				{
					Success = plannerDetails.Success,
					Message = plannerDetails.Message,
				});

			var currentTerm = _studentServices.GetCurrentTerm(reportOnlineModel.UserCode, classStatus);
			if (!currentTerm.Success)
				return Json(currentTerm);

			var erpReporting = _studentServices.CheckErpReporting(reportOnlineModel.UserCode, classStatus);
			if (erpReporting.Success)
				return Json(new ReturnData<bool> {
					Success = false,
					Message = erpReporting.Message
				});

			var onlineReporting = _studentServices.CheckOnlineReporting(reportOnlineModel.UserCode, classStatus);
			if (onlineReporting.Success)
				return Json(new ReturnData<bool>
				{
					Success = false,
					Message = onlineReporting.Message
				});

			var hasReported = studentCredentials.ValidateSessionReporting(reportOnlineModel.UserCode, classStatus);
			if (hasReported.Success)
				return Json(hasReported);

			_context.OnlineReporting.Add(
                new OnlineReporting
                {
                    Term = currentTerm.Data.Names,
                    AdmnNo = reportOnlineModel.UserCode,
                    Personnel = reportOnlineModel.UserCode,
                    Rdate = DateTime.Today,
                    Status = "Pending"
                }
            );

            _context.SaveChanges();

            return Json(new ReturnData<bool>
            {
                Success = true,
                Message = "You have successfully reported to current semester (" + currentTerm + ")"
            });
        }
    }
}