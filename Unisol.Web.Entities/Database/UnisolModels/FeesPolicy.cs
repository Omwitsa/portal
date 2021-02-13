using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class FeesPolicy
    {
        public int Ref { get; set; }
        public string Names { get; set; }
        public bool? Advanced { get; set; }
        public decimal? Paid { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public string Sponsor { get; set; }
    }
}
