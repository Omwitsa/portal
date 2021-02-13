using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class ClearanceQuestionnaireTemplate
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DateCreated { get; set; } = DateTime.UtcNow.AddHours(3);
		public List<ClearanceQuestionSection> QuestionSections { get; set; }
	}
}
