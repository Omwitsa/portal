using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ReceiptBreak
    {
        public string ReceiptNumber { get; set; }
        public string AdmnNo { get; set; }
        public string CustRef { get; set; }
        public string Names { get; set; }
        public string Account { get; set; }
        public decimal? Amount { get; set; }
        public string Curr { get; set; }
        public decimal? Credit { get; set; }
        public string Ledger { get; set; }
        public string Project { get; set; }
        public string PaymentMode { get; set; }
        public string ModeNumber { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Notes { get; set; }
        public string InvDetails { get; set; }
        public DateTime? DocDate { get; set; }
    }
}
