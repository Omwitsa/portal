using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpBenefits
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public string Benefit { get; set; }
        public string Provider { get; set; }
        public string Coverage { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public decimal? EmployeePrem { get; set; }
        public decimal? EmployerPrem { get; set; }
        public string IndPno { get; set; }
        public string GrpPno { get; set; }
        public bool? InsRelief { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Type { get; set; }
    }
}
