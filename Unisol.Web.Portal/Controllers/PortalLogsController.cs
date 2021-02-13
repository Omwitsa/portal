using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Login;
using Unisol.Web.Common.ViewModels.Messages;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PortalLogsController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly PortalCoreContext _context;
        private IHostingEnvironment _env;
        private readonly TokenValidator _tokenValidator;
		private EmailSender emailSender;
		public PortalLogsController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context, IHostingEnvironment env, 
			IConfiguration configuration, IEmailConfiguration emailConfiguration, IEmailService emailService)
        {
            _unisolApiProxy = unisolApiProxy;
            _context = context;
            _env = env;
            _tokenValidator = new TokenValidator(_context);
			emailSender = new EmailSender(configuration, context, emailConfiguration, env, emailService);
		}


        [HttpPost("saveexaminationlogging")]
        public JsonResult SaveExaminationLogging(ExaminationLog examinationLog)
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
                _context.ExaminationLogs.Add(examinationLog);
                _context.SaveChanges();

                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Logs save successfully"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "There was a problem when saving logs " + ex.Message
                });
            }
        }

        [HttpGet("getexaminationloggingHistory")]
        public JsonResult GetExaminationLoggingHistory(string usercode)
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
                var logs =  _context.ExaminationLogs.OrderByDescending(l => l.Id).Where(e=>e.AdminNo==usercode).ToList();
                return Json(new ReturnData<List<ExaminationLog>>
                {
                    Success = logs.Any(),
                    Message = "Logs save successfully",
                    Data = logs
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "There was a problem when saving logs " + ex.Message
                });
            }
        }

		[HttpGet("getExamCardLogs")]
		public JsonResult GetExamCardLogs(int itemsPerPage, int offset, string searchText)
		{
			searchText = searchText ?? "";
			try
			{
				var logs = _context.ExaminationLogs.Where(l => l.AdminNo.CaseInsensitiveContains(searchText)).OrderByDescending(l => l.Id).ToList();
				return Json(new ReturnData<List<ExaminationLog>>
				{
					Success = true,
					Data = logs
				});
			}
			catch (Exception e)
			{
				return Json(new ReturnData<List<ExaminationLog>>
				{
					Success = false,
					Data = new List<ExaminationLog>()
				});
			}
		}


		[HttpGet("notifyPortalDown")]
		public JsonResult NotifyPortalDown(string institution, string ip, string mailReceiver)
		{
			institution = institution ?? "";
			ip = ip ?? "";
			mailReceiver = mailReceiver ?? "";

			try
			{
				var emailContent = new MailsViewModel
				{
					Code = institution,
					Email = mailReceiver,
					MailMethod = MailSendMethod.PortalDown,
					Subject = $"{institution} portal is inaccessible",
					PortalUrl = ip
				};

				var emailResponse = emailSender.SendEmail(emailContent);
				_context.InaccessibiltyLog.Add(new InaccessibiltyLog
				{
					Ip = ip,
					Institution = institution,
					MailReceiver = mailReceiver,
					DateCreated = DateTime.UtcNow.AddHours(3)
				});

				_context.SaveChanges();
				return Json("");
			}
			catch (Exception ex)
			{
				return Json("");
			}
		}

		[HttpGet("getInaccessibilityLogs")]
		public JsonResult GetInaccessibilityLogs(int itemsPerPage, int offset, string searchText)
		{
			try
			{
				var logs = _context.InaccessibiltyLog.OrderByDescending(l => l.Id).ToList();
				if (!string.IsNullOrEmpty(searchText))
					logs = logs.Where(l => l.Institution.ToUpper().Contains(searchText.ToUpper())).ToList();
				return Json(new ReturnData<List<InaccessibiltyLog>>
				{
					Success = true,
					Data = logs
				});
			}
			catch (Exception e)
			{
				return Json(new ReturnData<List<InaccessibiltyLog>>
				{
					Success = false,
					Data = new List<InaccessibiltyLog>()
				});
			}
		}

	}
}