using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class PerformanceTarget
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public int? PerformanceSessionId { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string Supervisor { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public IEnumerable<PerformanceTargetDetail> PerformanceTargetDetail { get; set; }
    }
}
