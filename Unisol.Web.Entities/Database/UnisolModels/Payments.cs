using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Payments
    {
        public int Id { get; set; }
        public string VoucherNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string Ref { get; set; }
        public string Names { get; set; }
        public string Lpo { get; set; }
        public string Campus { get; set; }
        public string Department { get; set; }
        public string Account { get; set; }
        public decimal? Amount { get; set; }
        public string Ledger { get; set; }
        public string Project { get; set; }
        public string PaymentMode { get; set; }
        public string ModeNumber { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? ActualDate { get; set; }
        public string UniqId { get; set; }
    }
}
