using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class EvaluationSection
    {
        public EvaluationSection()
        {
            EvaluationQuestions = new HashSet<EvaluationQuestion>();
        }

        public int Id { get; set; }
        public int EvaluationId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
		public string SectionName { get; set; }
        public string Status { get; set; }
        public ICollection<EvaluationQuestion> EvaluationQuestions { get; set; }
        public string SectionDesc { get; set; }
    }
}