using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpSetup
    {
        public int Id { get; set; }
        public string Pin { get; set; }
        public string Nhifno { get; set; }
        public string Nssfno { get; set; }
        public decimal? Ordinary { get; set; }
        public decimal? Farm { get; set; }
        public decimal? Oointerest { get; set; }
        public string Paye { get; set; }
        public string Nhif { get; set; }
        public string Nssf { get; set; }
        public string Fringe { get; set; }
        public string Relief { get; set; }
        public string EmpNssf { get; set; }
        public string Basic { get; set; }
        public string Rent { get; set; }
        public string Nearest { get; set; }
        public decimal? Prelief { get; set; }
        public decimal? Mnssf { get; set; }
        public decimal? Wnssf { get; set; }
        public decimal? RetAge { get; set; }
        public decimal? RetRemAge { get; set; }
        public string RetMonths { get; set; }
        public string PayslipMsg { get; set; }
        public bool? ThermalPayslip { get; set; }
        public string TerminationStatus { get; set; }
        public decimal? InsRelief { get; set; }
        public decimal? InsReliefMax { get; set; }
        public string Whtax { get; set; }
        public decimal? ConsMin { get; set; }
        public decimal? ConsRate { get; set; }
        public decimal? Ippayeentry { get; set; }
        public string PayslipEmailMsg { get; set; }
        public string ImpAcc { get; set; }
        public string ImpFi { get; set; }
        public decimal? MaxPensionAllowable { get; set; }
        public string NetAccount { get; set; }
        public decimal? Payemax { get; set; }
    }
}
