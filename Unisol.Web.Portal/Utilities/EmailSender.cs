using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unisol.Web.Common.Utilities.Email;
using Unisol.Web.Common.ViewModels.Login;
using Unisol.Web.Common.ViewModels.Messages;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IServices;

namespace Unisol.Web.Portal.Utilities
{
	public class EmailSender
	{
		private IConfiguration _configuration;
		private PortalCoreContext _context;
		private IEmailConfiguration _emailConfiguration;
		private IHostingEnvironment _env;
		private IEmailService _emailService;
		private Logger logger = LogManager.GetLogger("fileLogger");
		public EmailSender(IConfiguration configuration, PortalCoreContext context, IEmailConfiguration emailConfiguration, IHostingEnvironment env, 
			IEmailService emailService)
		{
			_env = env;
			_context = context;
			_emailService = emailService;
			_configuration = configuration;
			_emailConfiguration = emailConfiguration;
		}

		public bool SendEmail(MailsViewModel mailsViewModel)
		{
			try
			{
				mailsViewModel.Email = string.IsNullOrEmpty(_configuration["RegTestEmail:EmailAddress"]) ? mailsViewModel.Email : _configuration["RegTestEmail:EmailAddress"];
				var emailAddress = new EmailAddress
				{
					Name = mailsViewModel.Firstname + "<" + mailsViewModel.UserCode + ">",
					Address = mailsViewModel.Email
				};

				var UnisolPortalUrl = mailsViewModel.PortalUrl;
				var varificationLink = $"{UnisolPortalUrl}/login/confirm/{mailsViewModel.Code}";
				if (mailsViewModel.MailMethod == MailSendMethod.PasswordReset)
					varificationLink = $"{UnisolPortalUrl}/login/reset-password/{mailsViewModel.Code}";

				var emailSettings = _context.Settings.FirstOrDefault();
				var address = new EmailAddress
				{
					Name = emailSettings == null ? _configuration["Settings:DefaultInstitutionName"] : emailSettings.Name,
					Address = emailSettings == null ? _configuration["RegTestEmail:EmailAddress"] : emailSettings.EmailUserName
				};

				address = emailSettings == null ? _emailConfiguration.SmtpFromName : address;
			
				var logoUrl = emailSettings.LogoImageUrl.Split("/");
				var assetUrl = Path.Combine(_env.WebRootPath, logoUrl[1]);
				var imageFlderUrl = Path.Combine(assetUrl, logoUrl[2]);
				var logoImageUrl = Path.Combine(imageFlderUrl, logoUrl[3]);

				var emailMessage = new EmailMessage
				{
					ToAddresses = new List<EmailAddress> { emailAddress },
					Content = getMailMessage(mailsViewModel.Firstname, varificationLink, mailsViewModel.Code, address, mailsViewModel.MailMethod),
					Subject = mailsViewModel.Subject,
					FromAddresses = new List<EmailAddress> { address },
					InstitutionLogo = logoImageUrl
				};

				var interfaceResponse = _emailService.Send(emailMessage, emailSettings);
				return interfaceResponse.Result;
			}
			catch (Exception ex)
			{
				logger.Error($"\t EmailConfigurationError: \t {ex}");
				return false;
			}
		}

		private string getMailMessage(string firstname, string varificationLink, string code, EmailAddress address, MailSendMethod mailMethod)
		{
			var message = "";
			if (mailMethod == MailSendMethod.PasswordReset)
			{
				message = "<div style='margin: 2em 5em 2em 5em; background-color: #f2f2f2'>" +
							"<table style='width: 100 %; margin: 5% 10% 5% 10%;'><br>" +
								"<tr><td><img src='cid:logoId' style='width:200px; display: block; margin-left: auto; margin-right: auto;'/></td></tr>" +
								"<tr><td><h2 style='text-align: center; color: red'> Forgot Password ?<br></h2></td></tr>" +
								"<tr><td><h4>Dear " + firstname + ",</h4></td></tr>" +
								"<tr><td>You have requested for a password reset. Click on the 'reset password' button below to enter a new passsword <br> <br></td></tr>" +
								"<tr><td style='text-align: center;'><a href='" + varificationLink + "' style='background-color: red; color: white; padding: 0.5em 1em; text-align: center; text-decoration: none; border-radius: 0.5em;'> Reset Password<br></a></td></tr> " +
								"<tr><td><p><span style='font-weight: bold'> Disclaimer:- </span> <i>The content of this email is confidential and intended for the recipient specified in this message only. " +
								"It is strictly forbidden to share any part of this message with any third party. " +
								"If you received this message by mistake, please reply to this message and follow with its deletion, " +
								"so that we can ensure such a mistake does not occur in the future.</i> </p></td></tr>" +
								"<tr><td><p>Sincerely, <br><br> <span style='font-weight: bold'> " + address.Name + " </span><br></p></td></tr> " +
							"</table>" +
							"<p style='text-align: center'>Powered By <a href='http://www.abnosoftwares.co.ke/' target='_blank' style='color:blue;'>" +
							"<b>ABNO Softwares International Ltd.</b></a> &copy; Copyright <span id='c-year'>" + DateTime.UtcNow.Year + "</span></p> <br>" +
						"</div>";

				return message;
			}

			if (mailMethod == MailSendMethod.AccountConfirmation)
			{
				message = "<div style='margin: 2em 5em 2em 5em; background-color: #f2f2f2'>" +
							"<table style='width: 100 %; margin: 5% 10% 5% 10%;'><br>" +
								"<tr><td><img src='cid:logoId' style='width:200px; display: block; margin-left: auto; margin-right: auto;'/></td></tr>" +
								"<tr><td><h2 style='text-align: center; color: red'> Account Created Successfully <br></h2></td></tr>" +
								"<tr><td><h4>Dear " + firstname + ",</h4></td></tr>" +
								"<tr><td> Your Account has been created. Click on the 'Confirm Account' button below to confirm your account <br> <br></td></tr>" +
								"<tr><td style='text-align: center;'><a href='" + varificationLink + "' style='background-color: red; color: white; padding: 0.5em 1em; text-align: center; text-decoration: none; border-radius: 0.5em;'> Confirm Account <br></a></td></tr> " +
								"<tr><td><p><span style='font-weight: bold'> Disclaimer:- </span> <i>The content of this email is confidential and intended for the recipient specified in this message only. " +
								"It is strictly forbidden to share any part of this message with any third party. " +
								"If you received this message by mistake, please reply to this message and follow with its deletion, " +
								"so that we can ensure such a mistake does not occur in the future.</i> </p></td></tr>" +
								"<tr><td><p>Sincerely, <br><br> <span style='font-weight: bold'> " + address.Name + " </span><br></p></td></tr> " +
							" </table>" +
							"<p style='text-align: center'>Powered By <a href='http://www.abnosoftwares.co.ke/' target='_blank' style='color:blue;'>" +
							"<b>ABNO Softwares International Ltd.</b></a> &copy; Copyright <span id='c-year'>" + DateTime.UtcNow.Year + "</span></p><br>" +
						"</div>";
			}

			if(mailMethod == MailSendMethod.NewsPosting || mailMethod == MailSendMethod.EventPosting)
			{
				message = code;
			}

			if (mailMethod == MailSendMethod.PortalDown)
			{
				message = $"{code} portal is inaccessible, kindly assist";
			}

			return message;
		}
	}
}
