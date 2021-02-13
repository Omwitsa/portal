using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Evaluations
{
    public class EvaluationFilter
    {
        public DateTime StartDate { get; set; }
		public string SearchText { get; set; }
		public DateTime? EndDate { get; set; }
    }
}
