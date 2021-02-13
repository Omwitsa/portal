using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpSalPeriod
    {
        public int Id { get; set; }
        public string Ryear { get; set; }
        public string Names { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public DateTime? Cdate { get; set; }
        public string Pfreq { get; set; }
        public string Notes { get; set; }
    }
}
