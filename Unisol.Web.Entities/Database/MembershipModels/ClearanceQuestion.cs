using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class ClearanceQuestion
	{
		public int Id { get; set; }
		public string Question { get; set; }
		public DateTime DateCreated { get; set; } = DateTime.UtcNow.AddHours(3);
		public string Options { get; set; }
		public int? ClearanceQuestionSectionId { get; set; }
		public QuestionType? Type { get; set; }
	}
}
