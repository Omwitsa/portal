using System.Collections.Generic;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Portal.Models
{
    public class PerformanceGradeLevelVm
    {
        public List<PerformanceGradeLevelSection> Sections { get; set; }
        public List<dynamic> LevelGradings { get; set; }
    }
}
