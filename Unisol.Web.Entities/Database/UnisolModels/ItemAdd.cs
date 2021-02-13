using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ItemAdd
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Qty { get; set; }
        public string Orderno { get; set; }
        public string Grnno { get; set; }
        public string Supref { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
        public string Invoice { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? NetAmount { get; set; }
        public string Spec { get; set; }
    }
}
