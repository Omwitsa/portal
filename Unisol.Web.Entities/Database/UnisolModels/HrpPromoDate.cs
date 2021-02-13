using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpPromoDate
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public DateTime? Pdate { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
