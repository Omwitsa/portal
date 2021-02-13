using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Banking
    {
        public int Id { get; set; }
        public string LedgerFrom { get; set; }
        public string Account { get; set; }
        public string LedgerTo { get; set; }
        public string Payee { get; set; }
        public decimal? Amount { get; set; }
        public string Reference { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string BankRef { get; set; }
        public string Cashier { get; set; }
    }
}
