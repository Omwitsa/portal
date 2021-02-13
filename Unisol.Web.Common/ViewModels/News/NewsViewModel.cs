using System;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Common.ViewModels.News
{
    public class NewsViewModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string NewsBody { get; set; }
        public bool NewsStatus { get; set; }
        public int ?Id { get; set; }
        public string NewsTitle { get; set; }
        public int PortalNewsTypeId { get; set; }
        public virtual PortalNewsType PortalNewsType { set; get; }
        public bool SendEmailFlag { get; set; }
		public string portalUrl { get; set; }
		public int TargetAudience { get; set; }
        public string TargetGroups { get; set; }
    }
}
