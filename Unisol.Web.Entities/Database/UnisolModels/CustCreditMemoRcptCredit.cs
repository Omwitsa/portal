using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class CustCreditMemoRcptCredit
    {
        public int Id { get; set; }
        public string CustRef { get; set; }
        public string MemoRef { get; set; }
        public string Code { get; set; }
        public string Account { get; set; }
        public decimal? Amount { get; set; }
    }
}
