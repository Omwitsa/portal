using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpEarningsAdhoc
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public string Earning { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Sdate { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
