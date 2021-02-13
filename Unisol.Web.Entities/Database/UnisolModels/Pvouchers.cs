using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Pvouchers
    {
        public int Id { get; set; }
        public string VoucherNo { get; set; }
        public bool? Supplier { get; set; }
        public string SupRef { get; set; }
        public string Names { get; set; }
        public string Ledger { get; set; }
        public string Project { get; set; }
        public string Description { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Amount { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
        public string PayToNames { get; set; }
        public string SponsorName { get; set; }
    }
}
