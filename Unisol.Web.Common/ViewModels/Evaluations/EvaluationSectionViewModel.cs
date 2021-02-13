using System;
using System.Collections.Generic;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Common.ViewModels.Evaluations
{
    public class EvaluationSectionViewModel
    {
        public int? Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public int EvaluationId { get; set; }
        public string SectionName { get; set; }

        public bool Status { get; set; } = true;

        public ICollection<EvaluationQuestion> EvaluationQuestions { get; set; }
    }
}