using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ItemBid
    {
        public int Id { get; set; }
        public string SupRef { get; set; }
        public string Code { get; set; }
        public decimal? Cost { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public DateTime? ValidUntil { get; set; }
        public string Fyear { get; set; }
    }
}
