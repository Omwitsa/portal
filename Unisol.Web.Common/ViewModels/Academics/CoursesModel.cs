using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Academics
{
	public class CoursesModel
	{
		public int Id { get; set; }
		public int Category { get; set; }
		public int Sortorder { get; set; }
		public string Shortname { get; set; }
		public string Fullname { get; set; }
		public int Idnumber { get; set; }
	}
}
