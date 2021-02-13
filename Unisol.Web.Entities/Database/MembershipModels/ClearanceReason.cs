using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class ClearanceReason
	{
		public int Id { get; set; }
		public string Reason { get; set; }
		public DateTime CreateDate { get; set; } = DateTime.UtcNow.AddHours(3);
	}
}
