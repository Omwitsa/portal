using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class ClearanceSurveyResponseRef
	{
		public int Id { get; set; }
		public string SectionName { get; set; }
		public string Question { get; set; }
		public string Response { get; set; }
	}
}
