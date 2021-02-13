using System;
using System.Collections.Generic;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Portal.Models
{
    public class PerformanceRespVm
    {
        public PerformanceTemplate Template { get; set; }
        public PerformanceSession Performance { get; set; }
        public bool IsSupervisor { get; set; }
        public int TargetId { get; set; }
        public EmployeeDetailVm EmployeeDetails { get; set; }
        public IEnumerable<PerformanceTraining> PerformanceTraining { get; set; }
    }

    public class PerformanceTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string Notes { get; set; }
        public IEnumerable<PerformanceSections> PerformanceSections { get; set; }
        public IEnumerable<PerformanceQuestionnaire> PerformanceQuestionnaire { get; set; }
    }

    public class PerformanceSections
    {
        public int Id { get; set; }
        public int? StaffPerformanceId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public IEnumerable<PerformanceTargetDetail> PerfomanceActivities { get; set; }
    }
}
