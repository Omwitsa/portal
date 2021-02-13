using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpDeductionsAdhoc
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public string Deduction { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Sdate { get; set; }
        public string Notes { get; set; }
        public string Fi { get; set; }
        public string NumType { get; set; }
        public string MemNo { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
