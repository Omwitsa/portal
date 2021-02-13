using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class StaffPerformance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string Notes { get; set; }
        public IEnumerable<PerformanceSection> PerformanceSections { get; set; }
        public IEnumerable<PerformanceQuestionnaire> PerformanceQuestionnaire { get; set; }
    }
}
