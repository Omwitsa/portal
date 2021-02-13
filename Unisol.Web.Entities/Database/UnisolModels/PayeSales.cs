using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PayeSales
    {
        public int InvNo { get; set; }
        public string Barcode { get; set; }
        public string Names { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountPaid { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Personnel { get; set; }
        public string Cafeteria { get; set; }
    }
}
