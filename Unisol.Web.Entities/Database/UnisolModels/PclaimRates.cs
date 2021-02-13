using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PclaimRates
    {
        public int Id { get; set; }
        public string PayAccount { get; set; }
        public string CertType { get; set; }
        public decimal? Rate { get; set; }
        public string Units { get; set; }
        public bool? Taxable { get; set; }
        public bool? Cons { get; set; }
        public bool? Closed { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public bool? UnitNotRequired { get; set; }
    }
}
