using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpContract
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public string Ref { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
    }
}
