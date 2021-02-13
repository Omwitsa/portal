using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpMedicalClaimsPay
    {
        public string Ref { get; set; }
        public string Names { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
    }
}
