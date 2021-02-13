using System.Collections.Generic;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Portal.Models
{
    public class PerformanceTargetVm
    {
        public int? TargetId { get; set; }
        public int SessionId { get; set; }
        public bool IsSupervisor { get; set; }
        public string UserName { get; set; }
        public List<TargetSection> PerformanceSections { get; set; }
    }

    public class TargetSection
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<PerformanceTargetDetail> PerformanceTargets { get; set; }
    }
}
