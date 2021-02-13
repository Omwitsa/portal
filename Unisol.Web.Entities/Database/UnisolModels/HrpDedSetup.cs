using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpDedSetup
    {
        public int Ref { get; set; }
        public string Deduction { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public bool? Fixed { get; set; }
        public string Fi { get; set; }
        public string Notes { get; set; }
    }
}
