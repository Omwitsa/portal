using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class DebtorBalances
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Names { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Rdate { get; set; }
        public string Type { get; set; }
        public string Account { get; set; }
    }
}
