using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class StudDepositRefundBd
    {
        public string Ref { get; set; }
        public string DepositRefundName { get; set; }
        public string AdmnNo { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public decimal? Amount { get; set; }
    }
}
