using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class StaffPerformanceResponse
    {
        public int Id { get; set; }
        public int? PerformanceSessionId { get; set; }
        public string EmpNo { get; set; }
        public string Department { get; set; }
        public string JobCat { get; set; }
        public string JobTitle { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(3);
        public string Supervisor { get; set; }
        public IEnumerable<PerformanceActivityResponse> PerformanceActivityResponse { get; set; }
        public IEnumerable<PerformanceQuestionnaireResponse> PerformanceQuestionnaireResponse { get; set; }
        public IEnumerable<PerformanceTraining> PerformanceTraining { get; set; }
    }
}
