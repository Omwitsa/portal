using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpIppayAcc
    {
        public string Code { get; set; }
        public string Names { get; set; }
        public string Type { get; set; }
        public bool? Closed { get; set; }
        public bool? Paye { get; set; }
        public string Notes { get; set; }
        public int? Rank { get; set; }
        public decimal? PayeMin { get; set; }
        public string Account { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string ItaxName { get; set; }
    }
}
