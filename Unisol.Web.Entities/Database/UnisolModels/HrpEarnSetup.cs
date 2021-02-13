using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpEarnSetup
    {
        public int Ref { get; set; }
        public string Earning { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public bool? Fixed { get; set; }
        public string Notes { get; set; }
    }
}
