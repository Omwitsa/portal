namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class PerformanceActivityResponse
    {
        public int Id { get; set; }
        public int? PerformanceSectionId { get; set; }
        public int? PerfomanceActivityId { get; set; }
        public int? StaffPerformanceResponseId { get; set; }
        public double? Weight { get; set; }
        public double? SelfScore { get; set; }
        public double? FinalScore { get; set; }
        public string Notes { get; set; }
    }
}
