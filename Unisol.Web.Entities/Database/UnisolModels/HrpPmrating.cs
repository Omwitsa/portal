using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpPmrating
    {
        public int Id { get; set; }
        public decimal? Rate { get; set; }
        public string Names { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
