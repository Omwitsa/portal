using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpEmpStatus
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public decimal? Rate { get; set; }
        public string PayType { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
        public string ExAccount { get; set; }
    }
}
