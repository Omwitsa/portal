using System;
using System.Collections.Generic;
using System.Text;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Common.ViewModels.Evaluations
{
    public class EvaluationsCurrentWithSubjectViewModel
    {
        public string UnitCode { get; set; }
		public string LecturerName { get; set; }
		public int CurrentActiveEvaluationId { get; set; }
        public int CurrentEvaluationId { get; set; }
        public Evaluation Evaluation { get; set; }
        public string UserCode { get; set; }
    }
}
