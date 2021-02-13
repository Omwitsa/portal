using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class CustProInv
    {
        public string InvRef { get; set; }
        public string CustRef { get; set; }
        public string Names { get; set; }
        public string Department { get; set; }
        public string Campus { get; set; }
        public decimal? Amount { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public string Terms { get; set; }
        public string Notes { get; set; }
        public string Curr { get; set; }
    }
}
