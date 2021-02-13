using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class BankingPosted
    {
        public string BankRef { get; set; }
        public string Reference { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Bdate { get; set; }
        public string Personnel { get; set; }
        public bool? Advanced { get; set; }
    }
}
