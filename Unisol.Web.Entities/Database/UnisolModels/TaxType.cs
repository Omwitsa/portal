using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class TaxType
    {
        public string Names { get; set; }
        public decimal? Rate { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
        public string Account { get; set; }
        public bool? Vat { get; set; }
        public bool? Retention { get; set; }
        public string RoundType { get; set; }
        public string RoundTo { get; set; }
        public bool? IncomeTax { get; set; }
        public bool? Vatwithhold { get; set; }
    }
}
