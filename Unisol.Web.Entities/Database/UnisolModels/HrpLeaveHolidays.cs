using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpLeaveHolidays
    {
        public int Id { get; set; }
        public string LeavePeriod { get; set; }
        public string Names { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public DateTime? Hdate { get; set; }
        public bool? Recur { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
