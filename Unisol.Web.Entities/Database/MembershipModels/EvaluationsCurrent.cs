using System;
using System.Collections.Generic;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class EvaluationsCurrent
    {
        public int Id { get; set; }
        public int EvaluationId { get; set; }
        public int? YearId { get; set; }
        public int? SemesterId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string CurrentEvaluationName { get; set; }
        public bool Status { get; set; } = true;
        //all=0,year=1,department=2,programme=3,class=5
        public int EvaluationTarget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<EvaluationsCurrentActive> EvaluationsCurrentActive { get; set; }
        public virtual Evaluation Evaluation { get; set; }
        
    }


}