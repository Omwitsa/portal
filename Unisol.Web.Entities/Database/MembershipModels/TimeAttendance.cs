using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class TimeAttendance
	{
		public int Id { get; set; }
		public string EmpNo { get; set; }
		public DateTime? DateTime { get; set; }
		public DateTime? Date { get; set; }
		public TimeSpan? Time { get; set; }
		public string Status { get; set; }
		public string Device { get; set; }
		public string DeviceNo { get; set; }
		public string Names { get; set; }
		public string CardNo { get; set; }
	}
}
