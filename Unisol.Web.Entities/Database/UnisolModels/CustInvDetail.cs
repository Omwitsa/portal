using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class CustInvDetail
    {
        public int Id { get; set; }
        public string InvRef { get; set; }
        public string Account { get; set; }
        public string Code { get; set; }
        public string Spec { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Amount { get; set; }
        public string TaxName { get; set; }
    }
}
