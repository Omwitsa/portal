using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class PortalEvaluationQuestions
    {
        public PortalEvaluationQuestions()
        {
            PortalEvaluationQuestionOptions = new HashSet<PortalEvaluationQuestionOptions>();
        }

        public int Id { get; set; }
        public bool AllowMultiple { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
		public int PortalEvaluationId { get; set; }
        public string Question { get; set; }
        public string Status { get; set; }

        public PortalEvaluations PortalEvaluation { get; set; }
        public ICollection<PortalEvaluationQuestionOptions> PortalEvaluationQuestionOptions { get; set; }
    }
}
