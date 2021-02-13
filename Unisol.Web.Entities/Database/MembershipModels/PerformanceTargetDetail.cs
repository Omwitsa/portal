namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class PerformanceTargetDetail
    {
        public int Id { get; set; }
        public int? PerformanceTargetId { get; set; }
        public int? PerformanceSectionId { get; set; }
        public string Activity { get; set; }
        public string Target { get; set; }
        public string Indicator { get; set; }
        public string Achievement { get; set; }
        public double? Weight { get; set; }
        public double? SelfScore { get; set; }
        public double? FinalScore { get; set; }
        public string Notes { get; set; }
    }
}
