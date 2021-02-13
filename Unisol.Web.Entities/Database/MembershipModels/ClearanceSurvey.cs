using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class ClearanceSurvey
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string TempleteName { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(3);
		public DateTime? StartTime { get; set; }
		public DateTime? EndTime { get; set; }
		//public string Status { get; set; }
	}
}
