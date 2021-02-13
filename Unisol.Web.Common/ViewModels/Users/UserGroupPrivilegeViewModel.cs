using System;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Common.ViewModels.Users
{
    public class UserGroupPrivilegeViewModel
    {
        public int? Id { get; set; }
        public string Action { get; set; }
        public string PrivilegeName { get; set; }
        public Role Role { get; set; }
    }
}
