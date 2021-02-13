using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class PortalEvaluationQuestionOptions
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
		public int PortalEvaluationQuestionId { get; set; }
        public string QuestionOption { get; set; }
        public bool QuestionOptionStatus { get; set; }

        public PortalEvaluationQuestions PortalEvaluationQuestion { get; set; }
    }
}
