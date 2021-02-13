using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class PortalEvaluations
    {
        public PortalEvaluations()
        {
            PortalEvaluationQuestions = new HashSet<PortalEvaluationQuestions>();
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
		public DateTime EvaluationEndDate { get; set; }
        public string EvaluationName { get; set; }
        public DateTime EvaluationStartDate { get; set; }
        public string Status { get; set; }

        public ICollection<PortalEvaluationQuestions> PortalEvaluationQuestions { get; set; }
    }
}
