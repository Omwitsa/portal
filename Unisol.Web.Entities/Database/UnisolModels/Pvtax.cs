using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Pvtax
    {
        public int Id { get; set; }
        public string VoucherNo { get; set; }
        public string SupRef { get; set; }
        public string Names { get; set; }
        public string Ledger { get; set; }
        public string Project { get; set; }
        public string TaxType { get; set; }
        public string Description { get; set; }
        public string InvSpec { get; set; }
        public decimal? Amount { get; set; }
        public string ChequeNo { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
    }
}
