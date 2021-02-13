using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class ClearanceQuestionSection
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DateCreated { get; set; } = DateTime.UtcNow.AddHours(3);
		public List<ClearanceQuestion> Questions { get; set; }
		public int? ClearanceQuestionnaireTemplateId { get; set; }
	}
}
