using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class User : BaseTable
    {
        public User()
        {
            AspNetUserTokens = new HashSet<UserToken>();
        }

        public int AccessFailedCount { get; set; }
        public int AccountType { get; set; }
        public string ConcurrencyStamp { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public byte[] FingerTemplate1 { get; set; }
        public byte[] FingerTemplate2 { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        public int UserGroupsId { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
        public Role Role { get; set; }
        public UserGroups UserGroup { get; set; }
        public PortalAdmins PortalAdmins { get; set; }
        public ICollection<UserToken> AspNetUserTokens { get; set; }
    }
}
