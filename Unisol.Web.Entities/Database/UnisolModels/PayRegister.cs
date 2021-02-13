using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PayRegister
    {
        public int Id { get; set; }
        public string DocNo { get; set; }
        public string PayeeRef { get; set; }
        public string Payee { get; set; }
        public string Ledger { get; set; }
        public string Bank { get; set; }
        public string ChequeNo { get; set; }
        public decimal? Amount { get; set; }
        public string Status { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
