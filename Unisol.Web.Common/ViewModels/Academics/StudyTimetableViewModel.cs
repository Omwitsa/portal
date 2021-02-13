using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Academics
{
	public class StudyTimetableViewModel
	{
		public String Day { get; set; }
		public List<StudyTableViewModel> UnitDetails { get; set; }
	}
}
