using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Academics
{
	public class FormattedSubjects
	{
		public string Code { get; set; }
		public string Names { get; set; }
		public string Department { get; set; }
		public string CreditLevel { get; set; }
		public decimal? CreditUnits { get; set; }
		public int? Nhours { get; set; }
		public bool? Common { get; set; }
		public bool? Closed { get; set; }
		public bool? Thesis { get; set; }
		public string Status { get; set; }
		public List<string> Lecturers { get; set; }
	}
}
