namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class PerformanceQuestionnaireResponse
    {
        public int Id { get; set; }
        public int? PerformanceQuestionnaireId { get; set; }
        public int? StaffPerformanceResponseId { get; set; }
        public string Response { get; set; }
    }
}