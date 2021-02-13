using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class MissedPunch
	{
		public int Id { get; set; }
		public string EmpNo { get; set; }
		public string Supervisor { get; set; }
		public string Status { get; set; }
		public string Reason { get; set; }
		public DateTime? PunchDate { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(3);
	}
}
