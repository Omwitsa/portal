namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class PerformanceTraining
    {
        public int Id { get; set; }
        public int? StaffPerformanceResponseId { get; set; }
        public string Training { get; set; }
        public string Objectives { get; set; }
        public string Results { get; set; }
        public string Recommendations { get; set; }
    }
}