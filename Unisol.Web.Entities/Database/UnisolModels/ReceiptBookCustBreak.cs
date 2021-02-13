using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ReceiptBookCustBreak
    {
        public int Id { get; set; }
        public string ReceiptNumber { get; set; }
        public string CustRef { get; set; }
        public string InvRef { get; set; }
        public string Code { get; set; }
        public string Account { get; set; }
        public decimal? Amount { get; set; }
    }
}
