using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpTraining
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public string Course { get; set; }
        public string Period { get; set; }
        public DateTime? Began { get; set; }
        public DateTime? Completed { get; set; }
        public string Institution { get; set; }
        public decimal? Cost { get; set; }
        public string Results { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
    }
}
