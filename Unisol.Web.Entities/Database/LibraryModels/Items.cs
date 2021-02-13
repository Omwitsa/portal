using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.LibraryModels
{
	public class Items
	{
		[Key]
		public int ItemNumber { get; set; }
		public int BiblioNumber { get; set; }
		public int BiblioItemNumber { get; set; }
		public string Barcode { get; set; }
		public string BookSellerId { get; set; }
		public string HomeBranch { get; set; }
		public decimal? Price { get; set; }
		public decimal? ReplacementPrice { get; set; }
		public int? Stack { get; set; }
		public int NotForLoan { get; set; }
		public int Damaged { get; set; }
		public int ItemLost { get; set; }
		public int Withdrawn { get; set; }
		public string ItemCallNumber { get; set; }
		public string CodedLocationQualifier { get; set; }
		public int? Issues { get; set; }
		public int? Renewals { get; set; }
		public int? Reserves { get; set; }
		public int? Restricted { get; set; }
		public string ItemNotes { get; set; }
		public string ItemNotesNonPublic { get; set; }
		public string HoldingBranch { get; set; }
		public string PaidFor { get; set; }
		public string Location { get; set; }
		public string PermanentLocation { get; set; }
		public DateTime? OnLoan { get; set; }
		public string CnSource { get; set; }
		public string CnSort { get; set; }
		public string Ccode { get; set; }
		public string Materials { get; set; }
		public string Uri { get; set; }
		public string IType { get; set; }
		public string MoreSubfieldsXml { get; set; }
		public string EnumChron { get; set; }
		public string CopyNumber { get; set; }
		public string StockNumber { get; set; }
	}
}
	