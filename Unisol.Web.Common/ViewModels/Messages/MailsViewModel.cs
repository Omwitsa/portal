using System;
using System.Collections.Generic;
using System.Text;
using Unisol.Web.Common.ViewModels.Login;

namespace Unisol.Web.Common.ViewModels.Messages
{
	public class MailsViewModel
	{
		public string UserCode { get; set; }
		public string Firstname { get; set; }
		public string Code { get; set; }
		public string Email { get; set; }
		public MailSendMethod MailMethod { get; set; }
		public string PortalUrl { get; set; }
		public string Subject { get; set; }
	}
}
