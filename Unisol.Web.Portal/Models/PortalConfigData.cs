using System;
using System.Collections.Generic;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Portal.Models
{
	public class PortalConfigData
	{
		public List<PortalConfig> PortalConfigs { get; set; }
		public string ClassStatus { get; set; }
		public UnitsLevels UnitsLevel { get; set; }
		public string HostelRatio { get; set; }
		public int HostelDuration { get; set; }
		public string ExamCardNotes { get; set; }
		public DateTime? BookingStartDate { get; set; }
	}
}
