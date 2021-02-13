using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ProcItemIssueDept
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Department { get; set; }
        public decimal? Qty { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string UserRef { get; set; }
        public string PayesaleRef { get; set; }
    }
}
