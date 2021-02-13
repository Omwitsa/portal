using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class Complaint
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Reason { get; set; }
		public string Status { get; set; }
		public string Hostel { get; set; }
		public string Room { get; set; }
		public string Action { get; set; }
		public string Assignee { get; set; }
		public DateTime? ActionDate { get; set; }
		public string Remarks { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(3);
	}
}
