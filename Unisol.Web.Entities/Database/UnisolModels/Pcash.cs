using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Pcash
    {
        public string Pcref { get; set; }
        public string PayeeRef { get; set; }
        public string ImpRef { get; set; }
        public string Names { get; set; }
        public string Ledger { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
    }
}
