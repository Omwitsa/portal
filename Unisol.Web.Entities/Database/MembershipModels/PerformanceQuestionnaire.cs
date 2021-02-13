namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class PerformanceQuestionnaire
    {
        public int Id { get; set; }
        public int? StaffPerformanceId { get; set; }
        public string Question { get; set; }
        public string Response { get; set; }
    }
}