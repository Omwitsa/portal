using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class EvaluationQuestion
    {
        public int Id { get; set; }
		public DateTime DateCreated { get; set; } = DateTime.Now;
		public int EvaluationSectionId { get; set; }
		public string QuestionDesc { get; set; }
		public string QuestionResponse { get; set; }
		public QuestionType? QuestionType { get; set; }
		public string MultiAnswers { get; set; }
	}

	public enum QuestionType
	{
		MultipleOptions = 1,
		YesNo = 2,
		Text = 3,
		MultipleAnswers = 4,
		Info = 5
	}
}
