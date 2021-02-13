using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unisol.Web.Common.Utilities.Email;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Portal.IServices
{
    public interface IEmailService
    {
        Task<bool> Send(EmailMessage emailMessage, Settings emailSettings);
        List<EmailMessage> ReceiveEmail(int maxCount = 10);
    }

    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;
		private Logger logger = LogManager.GetLogger("fileLogger");

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public List<EmailMessage> ReceiveEmail(int maxCount = 10)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Send(EmailMessage emailMessage, Settings emailSettings)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

            message.Subject = emailMessage.Subject;
           
            var builder = new BodyBuilder();
            var image = builder.LinkedResources.Add(emailMessage.InstitutionLogo);
            image.ContentId = "logoId";
            builder.HtmlBody = emailMessage.Content;

            message.Body = builder.ToMessageBody();

            //Be careful that the SmtpClient class is the one from Mailkit not the framework!
            using (var emailClient = new SmtpClient())
            {
                var smtpServer = emailSettings == null ? _emailConfiguration.SmtpServer : emailSettings.SmtpClient;
                var smtpPort = emailSettings == null ? _emailConfiguration.SmtpPort : Int32.Parse(emailSettings.Port);
                var smtpUsername = emailSettings == null ? _emailConfiguration.SmtpUsername : emailSettings.EmailUserName;
                var smtpPassword = emailSettings == null ? _emailConfiguration.SmtpPassword : emailSettings.Password;
                
                var options = SecureSocketOptions.StartTls;
                if (emailSettings.SocketOption.ToLower().Equals("sslonconnect"))
                    options = SecureSocketOptions.SslOnConnect;
                if (emailSettings.SocketOption.ToLower().Equals("none"))
                    options = SecureSocketOptions.None;

                try
                {
					emailClient.Connect(smtpServer, smtpPort, options);
					emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
					emailClient.Authenticate(smtpUsername, smtpPassword);
				}
                catch (Exception ex)
                {
					logger.Error($"SendingEmailError: \t {ex}");
					return false;
                }

				await emailClient.SendAsync(message);
                emailClient.Disconnect(true);
            }
            return true;
        }
    }
}
