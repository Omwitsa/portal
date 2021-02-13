using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PreqDetail
    {
        public int Id { get; set; }
        public string ReqNo { get; set; }
        public string Code { get; set; }
        public string Spec { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Cost { get; set; }
        public bool? Vat { get; set; }
        public decimal? Amount { get; set; }
        public string Campus { get; set; }
        public string Department { get; set; }
        public string Account { get; set; }
        public decimal? SetBudget { get; set; }
        public decimal? Ytdate { get; set; }
        public decimal? Commitment { get; set; }
        public decimal? BudgetBal { get; set; }
    }
}
