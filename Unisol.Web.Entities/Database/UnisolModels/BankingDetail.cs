using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class BankingDetail
    {
        public int Id { get; set; }
        public string BankRef { get; set; }
        public string ReceiptNumber { get; set; }
        public decimal? Amount { get; set; }
    }
}
