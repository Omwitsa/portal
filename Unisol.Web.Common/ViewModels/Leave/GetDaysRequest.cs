using System;
using System.Collections.Generic;

namespace Unisol.Web.Common.ViewModels.Leave
{
   public class GetDaysRequest
    {
        public DateTime SDate { get; set; }
        public DateTime EDate { get; set; }
        public string LeavePeriod { get; set; }
        public List<string> Dates { get; set; }
		public string LeaveType { get; set; }
	}
}
