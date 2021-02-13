using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpService
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public string Event { get; set; }
        public string JobTitle { get; set; }
        public string EmpStatus { get; set; }
        public string Pgrade { get; set; }
        public string Rank { get; set; }
        public string Pfreq { get; set; }
        public string Pmode { get; set; }
        public DateTime Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public string Bank { get; set; }
        public string AccNo { get; set; }
        public string HseType { get; set; }
        public string HseTerms { get; set; }
        public string HseRentType { get; set; }
        public decimal? HseValue { get; set; }
        public decimal? HseRent { get; set; }
        public decimal? Oointerest { get; set; }
        public bool? Paye { get; set; }
        public bool? Nhif { get; set; }
        public bool? Nssf { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? IncDate { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
        public bool? Pension { get; set; }
        public string Department { get; set; }
    }
}
