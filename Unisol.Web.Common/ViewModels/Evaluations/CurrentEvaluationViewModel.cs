using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Evaluations
{
    public class CurrentEvaluationViewModel
    {
        public int? Id { get; set; }
        public string CurrentEvaluationName { get; set; }
        public string Level { get; set; }
        public int EvaluationId { get; set; }
        public int ? YearId { get; set; }
        public string YearOfStudy { get; set; }
        public string Semester { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
		public bool IsMandatory { get; set; }
		public bool IsElearnigEvaluation { get; set; }
		public List<TargetLevel> Levels { get; set; }
    }

    public class TargetLevel
    {
        public string Id { get; set; }
        public string Names { get; set; }
        public string Level { get; set; }
        public string Extras { get; set; }
        public string Year { get; set; }
    }
}
