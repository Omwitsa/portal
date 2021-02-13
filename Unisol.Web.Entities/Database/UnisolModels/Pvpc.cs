using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Pvpc
    {
        public int Id { get; set; }
        public string VoucherNo { get; set; }
        public string SupRef { get; set; }
        public string Names { get; set; }
        public string Ledger { get; set; }
        public string Project { get; set; }
        public string Description { get; set; }
        public string PayMode { get; set; }
        public string ModeNo { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
    }
}
