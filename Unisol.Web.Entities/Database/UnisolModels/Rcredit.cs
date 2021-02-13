using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Rcredit
    {
        public string ReceiptNumber { get; set; }
        public string AdmnNo { get; set; }
        public string CustRef { get; set; }
        public string Account { get; set; }
        public decimal? Amount { get; set; }
        public string Curr { get; set; }
    }
}
