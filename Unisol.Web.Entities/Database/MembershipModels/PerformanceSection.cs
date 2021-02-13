namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class PerformanceSection
    {
        public int Id { get; set; }
        public int? StaffPerformanceId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
    }
}