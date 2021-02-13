using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpIpprofile
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public decimal? Salary { get; set; }
        public string Pmode { get; set; }
        public bool? TaxExempt { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public string Bank { get; set; }
        public string AccNo { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
        public string Center { get; set; }
        public string JobTitle { get; set; }
        public bool? Relief { get; set; }
    }
}
