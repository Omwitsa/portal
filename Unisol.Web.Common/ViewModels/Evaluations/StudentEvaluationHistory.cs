using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Evaluations
{
    public class StudentEvaluationHistory
    {
        public int EvaluationCurrentActiveId { get; set; }
        public string EvaluationCurrentTargetName { get; set; }
        public string EvaluationCurrentName { get; set; }
        public List<RespondedUnits> RespondedUnits { get; set; }
    }

    public class RespondedUnits
    {
        public string UnitCode { get; set; }
        public int TotalQuestions { get; set; }
        public int TotalQuestionsRequired { get; set; }
        public string UnitName { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
