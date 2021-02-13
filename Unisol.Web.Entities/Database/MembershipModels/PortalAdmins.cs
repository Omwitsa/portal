using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class PortalAdmins
    {
        public int Id { get; set; }
        public Guid ApplicationUserId { get; set; }
        public bool Closed { get; set; }
        public string ClosureReason { get; set; }
        public DateTime DateClosed { get; set; }
        public string FullName { get; set; }
        public int Type { get; set; }

        public User ApplicationUser { get; set; }
    }
}
