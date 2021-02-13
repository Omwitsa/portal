using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Unisol.Web.Common.ViewModels.P9
{
    public class P9ViewModel
    {
        
        public string Month  { get; set; }
        public double A_BasicSalary { get; set; }
        public double B_Beneficts  { get; set; }
        public double C_HousingQuarters  { get; set; }
        public double D_TotalGrossIncome  { get; set; }
        public double E1_RetirementScheme { get; set; }
        public double E2_RetirementScheme { get; set; }
        public double E3_RetirementScheme  { get; set; }
        public double F_InterestAmountOnHouse  { get; set; }
        public double G_RetirementContribution  { get; set; }
        public double H_ChargeablePay  { get; set; }
        public double J_TaxCharged  { get; set; }
        public double K_PersonalRelief  { get; set; }
        public double L_PayeTax  { get; set; }

    }

    public class PNineMainViewModel
    {
        public List<P9ViewModel> MonthlyAmounts { get; set; }
        public P9ViewAnnualTotalsViewModel AnnualTotals { get; set; }
        public PNineDetailsViewModel P9Details { get; set; }
    }

    public class P9ViewAnnualTotalsViewModel : P9ViewModel
    {
        public string Totals { get; set; }
    }

    public class PNineDetailsViewModel
    {
        public string EmployerName { get; set; }
        public string EmployerPin { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeOtherNames { get; set; }
        public string EmployeePin { get; set; }
        public string Year { get; set; }
    }
}
