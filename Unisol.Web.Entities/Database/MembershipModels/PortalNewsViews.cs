using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class PortalNewsViews
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public int? AspNetUsersId { get; set; }
        public int PortalNewsId { get; set; }
   
    }
}