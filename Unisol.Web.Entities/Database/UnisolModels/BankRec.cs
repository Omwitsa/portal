using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class BankRec
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Ledger { get; set; }
        public string Bank { get; set; }
        public DateTime? RecDate { get; set; }
        public DateTime? LastDate { get; set; }
        public decimal? StateBal { get; set; }
        public string Notes { get; set; }
        public DateTime? Cdate { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
