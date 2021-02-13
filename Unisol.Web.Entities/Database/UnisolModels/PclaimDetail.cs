using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PclaimDetail
    {
        public int Id { get; set; }
        public string Pcref { get; set; }
        public string PayAccount { get; set; }
        public string Code { get; set; }
        public decimal? Rate { get; set; }
        public string Units { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Amount { get; set; }
        public string Notes { get; set; }
        public string IpearningRef { get; set; }
    }
}
