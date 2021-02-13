using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Pocancel
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string Reason { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
    }
}
