using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.LibraryModels
{
	public class Issue
	{
		public int IssueId { get; set; }
		public int? BorrowerNumber { get; set; }
		public int? ItemNumber { get; set; }
		public DateTime? DueDate { get; set; }
		public string BranchCode { get; set; }
		public DateTime? ReturnDate { get; set; }
		public DateTime? LastRenewedDate { get; set; }
		public string Return { get; set; }
		public int? Renewals { get; set; }
		public int? AutoRenew { get; set; }
		public DateTime Timestamp { get; set; }
		public DateTime? IssueDate { get; set; }
		public int OnSiteCheckout { get; set; }
	}
}
