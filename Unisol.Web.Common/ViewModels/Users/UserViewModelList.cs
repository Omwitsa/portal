using System;

namespace Unisol.Web.Common.ViewModels.Users
{
    public class UserViewModelList
    {
        public UserViewModelList(dynamic user)
        {
            Id = user.Id;
            Email = string.IsNullOrEmpty(user.Email) ? "" : user.Email;
            UserName = user.UserName;
            ActivationStatus = user.EmailConfirmed;
            Status = user.Status;
            UserGroupId = user.UserGroupsId;
            DateCreated = user.DateCreated;
            UserGroup = user.UserGroup?.GroupName;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool ActivationStatus { get; set; }
        public bool Status { get; set; }
        public string UserGroup { get; set; }
        public int? UserGroupId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
