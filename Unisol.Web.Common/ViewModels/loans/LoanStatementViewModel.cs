using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.loans
{
    public class LoanStatementViewModel
    {
        public double TotalRequired { get; set; }
        public double TotalRecovered { get; set; }
        public double Balance { get; set; }
        public List<LoanTransactions> LoanTransactions { get; set; }
    }

    public class LoanTransactions
    {
        public string Month { get; set; }
        public double? Required { get; set; }
        public double? Recovered { get; set; }
        public double Balance { get; set; } = 0.0;
		public double? Interest { get; set; }
		public double? Premium { get; set; }
	}
}
