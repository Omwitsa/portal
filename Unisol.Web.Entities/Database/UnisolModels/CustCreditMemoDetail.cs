using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class CustCreditMemoDetail
    {
        public int Id { get; set; }
        public string MemoRef { get; set; }
        public string Code { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Amount { get; set; }
    }
}
