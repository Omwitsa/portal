using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Academics
{
	public class StudyTableViewModel
	{
		public DateTime? StartTime { get; set; }  
		public DateTime? EndTime { get; set; }
		public string UnitCode { get; set; }
		public string Room { get; set; }
		public string LecturerName { get; set; }
		public string Campus { get; set; }
	}
}
