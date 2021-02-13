using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class EvaluationQuestionResponse
    {
        public int Id { get; set; }
        public int EvaluationQuestionId { get; set; }
        public int? EvaluationId { get; set; }
		public int EvaluationSectionId { get; set; }
		public QuestionType? QuestionType { get; set; }
		public string SectionName { get; set; }
		public Guid? UserId { get; set; }
        public int EvaluationsCurrentActiveId { get; set; }
        public string UnitCode { get; set; }
        public string QuestionResponse { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public int EvaluationTakenUnitWiseByUserId { get; set; }
	}
}