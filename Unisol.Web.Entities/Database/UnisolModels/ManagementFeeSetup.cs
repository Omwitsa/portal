using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ManagementFeeSetup
    {
        public string Names { get; set; }
        public decimal? Rate { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
        public string Account { get; set; }
        public string RoundType { get; set; }
        public string RoundTo { get; set; }
    }
}
