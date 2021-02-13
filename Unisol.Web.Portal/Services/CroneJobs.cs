using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net.NetworkInformation;
using Unisol.Web.Common.ViewModels.Login;
using Unisol.Web.Common.ViewModels.Messages;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Model;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Services
{
	public class CroneJobs : ICroneJobs
	{
		private PortalCoreContext _context;
		private readonly IUnisolApiProxy _unisolApiProxy;
		private EmailSender emailSender;
		private string classStatus;
		public CroneJobs(PortalCoreContext context, IUnisolApiProxy unisolApiProxy, IEmailService emailService, IHostingEnvironment env, IEmailConfiguration emailConfiguration, IConfiguration configuration)
		{
			_context = context;
			_unisolApiProxy = unisolApiProxy;
			classStatus = _context.Settings.FirstOrDefault()?.ClassStatus;
			emailSender = new EmailSender(configuration, context, emailConfiguration, env, emailService);
		}

		public void ClearHostel()
		{
			var settings = _context.Settings.FirstOrDefault();
			var bookingEndTime = settings.HostelBookingStartDate.GetValueOrDefault().AddHours(settings.HostelDuration);
			if (bookingEndTime < DateTime.UtcNow.AddHours(3))
				_unisolApiProxy.DeallocateHostel(classStatus);
		}

		public void PingPortals()
		{
			var clientIps = ClientIpValues.GetClientIps();
			var clientIp = new ClientIp();
			Ping pinger = new Ping();
			try
			{
				clientIps.ForEach(p => {
					clientIp = p;
					var ip = _context.ClientIp.FirstOrDefault(c => c.Ip.ToLower().Equals(clientIp.Ip.ToLower()));
					PingReply reply = pinger.Send(p.Ip);
					ip.Fails = 0;
				});
				_context.SaveChanges();
			}
			catch (PingException)
			{
				var ip = _context.ClientIp.FirstOrDefault(c => c.Ip.ToLower().Equals(clientIp.Ip.ToLower()));
				if(ip.Fails < 2)
				{
					ip.Fails = ip.Fails + 1;
				}
				else
				{
					ip.Fails = 0;
					//NotifyPortalDown(ip);
				}
				_context.SaveChanges();
			}
			pinger.Dispose();
		}

		private void NotifyPortalDown(ClientIp ip)
		{
			var mailReceiver = "womwitsa@abnosoftwares.com";
			try
			{
				var emailContent = new MailsViewModel
				{
					Code = ip.Institution,
					Email = mailReceiver,
					MailMethod = MailSendMethod.PortalDown,
					Subject = $"{ip.Institution} portal is inaccessible",
					PortalUrl = ip.Ip
				};

				var emailResponse = emailSender.SendEmail(emailContent);
				_context.InaccessibiltyLog.Add(new InaccessibiltyLog
				{
					Ip = ip.Ip,
					Institution = ip.Institution,
					MailReceiver = mailReceiver,
					DateCreated = DateTime.UtcNow.AddHours(3)
				});
			}
			catch (Exception)
			{
				
			}
		}
	}
}
