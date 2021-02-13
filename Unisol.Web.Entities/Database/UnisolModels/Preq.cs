using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Preq
    {
        public int Id { get; set; }
        public string ReqNo { get; set; }
        public string SupRef { get; set; }
        public string DeliverTo { get; set; }
        public string Vote { get; set; }
        public string Department { get; set; }
        public string ReqOn { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string BudgetStatus { get; set; }
        public string BudgetBy { get; set; }
        public DateTime? BudgetDate { get; set; }
        public string Curr { get; set; }
        public string ShowNotes { get; set; }
        public decimal? Amount { get; set; }
        public string Ledger { get; set; }
        public string Project { get; set; }
        public string QuoteNo { get; set; }
        public string Status { get; set; }
    }
}
