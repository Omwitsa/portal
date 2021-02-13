using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class Evaluation
    {
        public Evaluation()
        {
            EvaluationSections = new HashSet<EvaluationSection>();
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public string EvaluationName { get; set; }

        public bool Status { get; set; } = true;

        public ICollection<EvaluationSection> EvaluationSections { get; set; }
        public string EvaluationDesc { get; set; }
    }
}