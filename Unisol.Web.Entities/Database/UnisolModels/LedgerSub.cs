using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class LedgerSub
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Ledger { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public string ProjNo { get; set; }
        public string ProjLoc { get; set; }
        public decimal? OverallAmount { get; set; }
        public decimal? Ob { get; set; }
        public int? CompPercent { get; set; }
    }
}
