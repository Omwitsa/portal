using System;

namespace Unisol.Web.Common.ViewModels.Events
{
    public class EventsViewModel
    {
        public int? Id { get; set; }
        public string EventTitle { get; set; }
        public string EventDesc { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public bool SendEmailFlag { get; set; }
        public bool EventsStatus { get; set; }
		public string PortalUrl { get; set; }
		public int TargetAudience { get; set; }
		public int? portalEventsTypeId { get; set; }
		public string EventVenue { get; set; }
        public string TargetGroups { get; set; }
		public string Campus { get; set; }
		public string School { get; set; }
		public string Department { get; set; }
		public string YearOfStudy { get; set; }
	}
}
