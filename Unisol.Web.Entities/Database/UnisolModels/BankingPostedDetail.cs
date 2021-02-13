using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class BankingPostedDetail
    {
        public int Id { get; set; }
        public string BankRef { get; set; }
        public string ReceiptNumber { get; set; }
        public string Reference { get; set; }
    }
}
