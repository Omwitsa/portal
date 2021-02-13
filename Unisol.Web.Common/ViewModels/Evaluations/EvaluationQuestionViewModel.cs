using System;
using System.Collections.Generic;
using System.Text;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Common.ViewModels.Evaluations
{
    public class EvaluationQuestionViewModel
    {
        public bool AllowMultiple { get; set; }
        public string QuestionDesc { get; set; }
        public int EvaluationSectionId { get; set; }
        public int? Id { get; set; }
        public List<EvaluationQuestionOption> Options { get; set; }

    }

   
}
