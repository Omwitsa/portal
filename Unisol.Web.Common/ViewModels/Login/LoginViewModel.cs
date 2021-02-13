using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Login
{
    public class LoginViewModel
    {
        public string Username { set; get; }
        public string Password { set; get; }
    }
	
	public enum MailSendMethod
	{
		AccountConfirmation = 1,
		PasswordReset = 2,
		NewsPosting = 3,
		EventPosting = 4,
		PortalDown = 5,
	}
}
