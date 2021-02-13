using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class Obstructor
	{
		public int Id { get; set; }
		public string LeaveRef { get; set; }
		public string Requestor { get; set; }
		public string Reliver { get; set; }
		public string Status { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(3);
	}
}
