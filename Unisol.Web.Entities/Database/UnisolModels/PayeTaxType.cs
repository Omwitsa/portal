using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PayeTaxType
    {
        public string Names { get; set; }
        public decimal? Rate { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
    }
}
