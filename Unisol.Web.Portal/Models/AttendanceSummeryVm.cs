using System;

namespace Unisol.Web.Portal.Models
{
	public class AttendanceSummeryVm
	{
		public string EmpNo { get; set; }
		public string Names { get; set; }
		public TimeSpan? HoursWorked { get; set; }
		public TimeSpan? OverTime { get; set; }
		public TimeSpan? LostHours { get; set; }
	}
}
