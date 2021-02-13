using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpIpearnings
    {
        public int Id { get; set; }
        public string Project { get; set; }
        public string PayAccount { get; set; }
        public string EmpNo { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Qty { get; set; }
        public string Units { get; set; }
        public decimal? Amount { get; set; }
        public bool? Cons { get; set; }
        public bool Taxable { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
    }
}
