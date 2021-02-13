using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Finance
{
    public class StudentFeeStatementClass
    {
        public string Ref { get; set; }
        public string Term { get; set; }
        public DateTime? RDate { get; set; }
        public decimal? TotalInvoiceAmounts { get; set; }
        public string AdmnNo { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
        public string StudentClass { get; set; }
    }

    public class TotalDebitCreditViewModel
    {
        public string Debit { get; set; }
        public string Credit { get; set; }
	}
}