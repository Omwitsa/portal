using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class RentAutoInv
    {
        public int Id { get; set; }
        public string CustRef { get; set; }
        public string Names { get; set; }
        public string Ledger { get; set; }
        public string Account { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Ndate { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
    }
}
