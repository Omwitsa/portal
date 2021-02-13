using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpMedicalClaims
    {
        public string Ref { get; set; }
        public string EmpNo { get; set; }
        public string Patient { get; set; }
        public string Hospital { get; set; }
        public decimal? Amount { get; set; }
        public string Doctor { get; set; }
        public DateTime? DocDate { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
    }
}
