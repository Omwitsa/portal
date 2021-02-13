using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class Project
	{
		public int Id { get; set; }
		public string EmpNo { get; set; }
		public string Title { get; set; }
		public string Status { get; set; }
		public bool NeedApproval { get; set; }
		public string FundingAgency { get; set; }
		public string Sponsor { get; set; }
		public string ContactPerson { get; set; }
		public string Code { get; set; }
		public string FileUrl { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public decimal? Cost { get; set; }
		public List<ProjectCoReseacher> ProjectCoReseachers { get; set; }
		public List<ProjectReport> ProjectReports { get; set; }
		public List<ProjectDisbursement> ProjectDisbursements { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(3);
		public string Reason { get; set; }
	}
}
