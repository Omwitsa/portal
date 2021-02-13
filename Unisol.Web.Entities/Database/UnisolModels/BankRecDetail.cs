using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class BankRecDetail
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public DateTime? Tdate { get; set; }
        public DateTime? Ddate { get; set; }
        public string Payee { get; set; }
        public decimal? Amount { get; set; }
        public bool? Rec { get; set; }
        public string Type { get; set; }
    }
}
