using System;
using System.Collections.Generic;
using System.Text;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Common.ViewModels.Users
{
    public class UserGroupViewModel
    {
        public int? Id { get; set; }
        public string GroupName { get; set; }
        public Role Role { get; set; }
        public bool IsDefault { get; set; } = false;
        public bool Status { get; set; } = true;
        public string Privileges { get; set; }

    }
}
