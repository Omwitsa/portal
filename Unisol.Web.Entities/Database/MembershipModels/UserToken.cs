using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class UserToken : BaseTable
    {
        public Guid UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public User User { get; set; }
    }
}
