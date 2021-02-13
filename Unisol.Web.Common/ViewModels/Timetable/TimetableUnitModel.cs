using System;

namespace Unisol.Web.Common.ViewModels.Timetable
{
	public class TimetableUnitModel
	{
		public string UnitCode { get; set; }
		public string UnitName { get; set; }
		public string Day { get; set; }
		public string Campus { get; set; }
		public TimeSpan StartTime { get; set; }
		public TimeSpan EndTime { get; set; }
		public string Lecturer { get; set; }
		public string Room { get; set; }
	}
}
