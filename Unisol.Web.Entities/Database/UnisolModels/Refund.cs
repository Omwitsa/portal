using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Refund
    {
        public int Id { get; set; }
        public string ReceiptNumber { get; set; }
        public string AdmnNo { get; set; }
        public string CustRef { get; set; }
        public string Names { get; set; }
        public string Account { get; set; }
        public decimal? Amount { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
    }
}
