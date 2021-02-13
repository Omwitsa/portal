using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Academics
{
	public class UnitDetails
	{
		public string UnitName { get; set; }
		public TimeSpan? StartTime { get; set; }
		public TimeSpan? EndTime { get; set; }
		public string UnitCode { get; set; }
		public string Campus { get; set; }
		public string Room { get; set; }
		public string LecturerName { get; set; }
		public string Date { get; set; }
	}
}
