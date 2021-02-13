using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class PortalNews
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime ExpiryDate { get; set; }
        public string NewsBody { get; set; }
        public bool NewsStatus { get; set; }
        public string NewsTitle { get; set; }
        public int PortalNewsTypeId { get; set; }
        public virtual PortalNewsType PortalNewsType { set; get; }
        public virtual List<PortalNewsViews> PortalNewsViews { set; get; }
        public bool SendEmailFlag { get; set; }
        public int TargetAudience { get; set; }
        public string TargetGroups { get; set; }
        public Guid CreatorId { get; set; }

    }
}
