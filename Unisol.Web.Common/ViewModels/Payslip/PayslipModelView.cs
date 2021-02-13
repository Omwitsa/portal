using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Payslip
{
    public class PayslipModelView
    {
        public string AccountType { get; set; }
        public List<IndividualAccountType> IndividualAccountType { get; set; }
        public double TotalAmount { get; set; }
    }

    public  class EarningDeductions
    {
        public  double Earnings { get; set; } = 0.0;
        public  double Deductions { get; set; } = 0.0;
    }
    public static class AccountTypeImpact{
        public  static HashSet<string> EarningsList { get; set; } =new HashSet<string>{
            "EARNING",
        };
        public  static HashSet<string> DeductionsList { get; set; } =new HashSet<string>{"DEDUCTION",
            "UNION",
            "PENSION",
			"BENEFIT",
			"LOAN"};
    }

    public class PaymentPerDeductionEarning
    {
        public List<IndividualAccountType> Earnings { get; set; }
        public List<IndividualAccountType> Deductions { get; set; }
        
    }
}