using Unisol.Web.Common.Utilities.Email;

namespace Unisol.Web.Portal.IServices
{
	public interface IEmailConfiguration
    {
        string SmtpServer { get; }
        int SmtpPort { get; }
        string SmtpUsername { get; set; }
        string SmtpPassword { get; set; }
        EmailAddress SmtpFromName { get; set; }

    }

    public class EmailConfiguration : IEmailConfiguration
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public EmailAddress SmtpFromName { get; set; }

    }
}
