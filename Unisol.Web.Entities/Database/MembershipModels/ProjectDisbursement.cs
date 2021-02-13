using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class ProjectDisbursement
	{
		public int Id { get; set; }
		public string InstallmentNo { get; set; }
		public decimal? Amount { get; set; }
		public DateTime? Date { get; set; }
		public int? ProjectId { get; set; }
	}
}
