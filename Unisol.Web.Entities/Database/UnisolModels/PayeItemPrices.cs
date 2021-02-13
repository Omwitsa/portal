using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PayeItemPrices
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public DateTime? Rdate { get; set; }
        public string Taxes { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
    }
}
