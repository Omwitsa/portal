using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class PortalEvents
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
		public string EventDesc { get; set; }
        public DateTime EventEndDate { get; set; }
        public DateTime EventStartDate { get; set; }
        public string EventTitle { get; set; }
        public int? PortalEventTypeId { get; set; }
        public bool SendEmailFlag { get; set; }
        public int? TargetAudience { get; set; }
        public virtual PortalEventTypes PortalEventType { get; set; }
		public string EventVenue { get; set; }
        public string TargetGroups { get; set; }
		public string Campus { get; set; }
		public string School { get; set; }
		public string Department { get; set; }
		public string YearOfStudy { get; set; }
	}
}
