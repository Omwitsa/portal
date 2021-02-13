using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpLeaveRules
    {
        public int Id { get; set; }
        public string LeaveGroup { get; set; }
        public string LeaveType { get; set; }
        public decimal? LeaveDays { get; set; }
        public decimal? CfdaysLimit { get; set; }
        public decimal? CfdayValidity { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public bool Accrue { get; set; }
        public bool? Exceed { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Gender { get; set; }
    }
}
