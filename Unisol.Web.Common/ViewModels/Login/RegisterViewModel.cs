using System;
using System.Collections.Generic;
using System.Text;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Common.ViewModels.Login
{
    public class RegisterViewModel
    {
        public string RegNumber { get; set; }
        public Role Role { get; set; }
        public int UserGroup { get; set; }
        public string Email { get; set; }
		public string Password { get; set; }
		public string PortalUrl { get; set; }
		public string PasswordConfirm { get; set; }
	}
 
   
}
