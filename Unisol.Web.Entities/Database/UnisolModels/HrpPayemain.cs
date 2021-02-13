using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpPayemain
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public decimal? Prelief { get; set; }
    }
}
