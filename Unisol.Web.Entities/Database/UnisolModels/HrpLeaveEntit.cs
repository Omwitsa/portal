using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpLeaveEntit
    {
        public int Id { get; set; }
        public string LeavePeriod { get; set; }
        public string EmpNo { get; set; }
        public string LeaveType { get; set; }
        public string Type { get; set; }
        public decimal? LeaveDays { get; set; }
        public string Notes { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
