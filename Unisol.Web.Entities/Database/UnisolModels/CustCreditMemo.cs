using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class CustCreditMemo
    {
        public string MemoRef { get; set; }
        public string InvRef { get; set; }
        public decimal? Amount { get; set; }
        public string Reason { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
    }
}
