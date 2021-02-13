using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ProcItemIssue
    {
        public int Id { get; set; }
        public float Ref { get; set; }
        public string Code { get; set; }
        public string Department { get; set; }
        public decimal? Qty { get; set; }
        public string ReqStaff { get; set; }
        public string RecBy { get; set; }
        public string Fpcode { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public decimal? ReqQty { get; set; }
    }
}
