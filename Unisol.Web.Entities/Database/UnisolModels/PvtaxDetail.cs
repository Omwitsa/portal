using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PvtaxDetail
    {
        public int Id { get; set; }
        public string VoucherNo { get; set; }
        public string InvRef { get; set; }
        public string SupRef { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal? Amount { get; set; }
        public string Notes { get; set; }
    }
}
