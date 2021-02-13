using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ImprestSurRcpt
    {
        public string ReceiptNumber { get; set; }
        public string ImpRef { get; set; }
        public decimal? Amount { get; set; }
        public string Bank { get; set; }
        public string ChequeNo { get; set; }
        public string Ledger { get; set; }
    }
}
