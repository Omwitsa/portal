using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Portal.Models
{
	public class AttendanceVm
	{
		public string EmpNo { get; set; }
		public DateTime? Date { get; set; }
		public TimeSpan? In { get; set; }
		public TimeSpan? Out { get; set; }
		public TimeSpan? WorkedHours { get; set; }
	}
}
