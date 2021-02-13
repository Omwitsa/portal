using System.Collections.Generic;

namespace Unisol.Web.Common.ViewModels.Payslip
{
    public class IndividualAccountType
    {
        public string Name { get; set; }
        public double Amount { get; set; }
		public double Balance { get; set; }
	}
    public class AccountAmountViewModel
    {
        public string AccountName { get; set; }
        public string Amount { get; set; }
	}

    public class ActiveAccountMainClass
    {
        public List<AccountAmountViewModel> AccountAmountViewModel { get; set; }
        public List<string> ActiveAccounts { get; set; }
    }
}