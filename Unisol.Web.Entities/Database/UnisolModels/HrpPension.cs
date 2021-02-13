using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpPension
    {
        public int Ref { get; set; }
        public string Pension { get; set; }
        public string Pgrade { get; set; }
        public decimal? Eevalue { get; set; }
        public decimal? Ervalue { get; set; }
        public string Fi { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
    }
}
