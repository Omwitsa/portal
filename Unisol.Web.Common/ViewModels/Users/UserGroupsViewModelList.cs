using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Common.ViewModels.Users
{
    public class UserGroupsViewModelList
    {

        public UserGroupsViewModelList(UserGroups u)
        {
            Id = u.Id;
            GroupName = u.GroupName;
            Role = u.Role.ToString();
            Status = u.Status;
            IsDefault = u.IsDefault;
            Privileges = u.AllowedPrivileges;
        }
		
        public string GroupName { get; set; }
        public int Id { get; set; }
        public bool Status { get; set; }
        public string Role { get; set; }
        public bool IsDefault { get; set; }
        public string Privileges { get; set; }
    }
}
