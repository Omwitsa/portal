using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class PerformanceSession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TemplateName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
