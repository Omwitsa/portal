using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class EvaluationsCurrentActive
    {

        public EvaluationsCurrentActive()
        {
            EvaluationTargetGroups = new HashSet<EvaluationTargetGroup>();
          
        }
        public int Id { get; set; }
        public int? EvaluationTarget { get; set; }
        public int EvaluationsCurrentId { get; set; }
        public int EvaluationsId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
		public bool IsMandatory { get; set; }
		public bool IsElearnigEvaluation { get; set; }
		public DateTime DateCreated { get; set; } = DateTime.Now;
        public ICollection<EvaluationTargetGroup> EvaluationTargetGroups { get; set; }
    }
}