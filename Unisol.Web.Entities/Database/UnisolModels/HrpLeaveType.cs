using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpLeaveType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Names { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
		public bool? CalendarDays { get; set; }
		public bool? Emergency { get; set; }
	}
}
