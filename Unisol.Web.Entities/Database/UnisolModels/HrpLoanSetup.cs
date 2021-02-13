using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpLoanSetup
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public string Loan { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public string IntType { get; set; }
        public decimal? IntRate { get; set; }
        public string IntPeriod { get; set; }
        public decimal? LoanTerm { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public bool? Closed { get; set; }
        public string Fi { get; set; }
        public string NumType { get; set; }
        public string MemNo { get; set; }
        public DateTime? DateClosed { get; set; }
        public string Personnel { get; set; }
    }
}
