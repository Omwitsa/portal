using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PayInvoice
    {
        public string InvRef { get; set; }
        public string InvoiceNumber { get; set; }
        public string Ref { get; set; }
        public string Names { get; set; }
        public string Lpo { get; set; }
        public string Ledger { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Invdate { get; set; }
        public string Terms { get; set; }
        public DateTime? DueDate { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
        public string Project { get; set; }
        public string Apaccount { get; set; }
    }
}
