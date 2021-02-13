using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ProcBudget
    {
        public int Id { get; set; }
        public string Fyear { get; set; }
        public string Department { get; set; }
        public decimal? Amount { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
    }
}
