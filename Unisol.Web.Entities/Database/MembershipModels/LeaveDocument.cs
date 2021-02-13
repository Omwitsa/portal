using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class LeaveDocument
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Type { get; set; }
		public string Name { get; set; }
		public string EndPoint { get; set; }
		public DateTime DateCreated { get; set; } = DateTime.UtcNow.AddHours(3);
		public string LeaveRef { get; set; }
	}
}
