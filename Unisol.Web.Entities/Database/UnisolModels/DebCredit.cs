using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class DebCredit
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Ledger { get; set; }
        public string Account { get; set; }
        public decimal? Amount { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
    }
}
