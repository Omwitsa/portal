using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpUnion
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public string Names { get; set; }
        public string MemNo { get; set; }
        public DateTime? Joined { get; set; }
        public DateTime? Exited { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
    }
}
