using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.LibraryModels
{
	public class AccountLines
	{
		public int AccountlinesId { get; set; }
		public int BorrowerNumber { get; set; }
		public int AccountNo { get; set; }
		public int? ItemNumber { get; set; }
		public DateTime? Date { get; set; }
		public decimal? Amount { get; set; }
		public string Description { get; set; }
		public string Dispute { get; set; }
		public string AccountType { get; set; }
		public decimal? AmountOutstanding { get; set; }
		public decimal? LastIncrement { get; set; }
		public DateTime Timestamp { get; set; }
		public int NotifyId { get; set; }
		public int NotifyLevel { get; set; }
		public string Note { get; set; }
		public int? ManagerId { get; set; }
	}
}
