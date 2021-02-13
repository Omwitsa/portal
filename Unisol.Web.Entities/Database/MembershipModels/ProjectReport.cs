using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class ProjectReport
	{
		public int Id { get; set; }
		public string ReportNo { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public int? ProjectId { get; set; }
	}
}
