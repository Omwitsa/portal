using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class EvaluationTargetGroup
    {
        public int Id { get; set; }
        public int EvaluationsCurrentId { get; set; }
        public int EvaluationsCurrentActiveId { get; set; }

        public int? TargetGroupId { get; set; }
        public string ReferenceId { get; set; }
        public int TargetType { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime ExpiryDate { get; set; }
        public string Names { get; set; }
        public string Year { get; set; }
    }
}