using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ItemAdjustDept
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal? Qty { get; set; }
        public string Department { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
    }
}
