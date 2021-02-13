using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class ClearanceSurveyResponse
	{
		public int Id { get; set; }
		public string Admnno { get; set; }
		public DateTime DateCreated { get; set; } = DateTime.UtcNow.AddHours(3);
		public string SurveyName { get; set; }
		public List<ClearanceSurveyResponseRef> ClearanceSurveyResponseRefs { get; set; }
	}
}
