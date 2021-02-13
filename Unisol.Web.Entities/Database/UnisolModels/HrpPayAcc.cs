using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpPayAcc
    {
        public string Code { get; set; }
        public string Names { get; set; }
        public string Type { get; set; }
        public bool? Closed { get; set; }
        public bool? Paye { get; set; }
        public bool? Nhif { get; set; }
        public bool? AllowDed { get; set; }
        public string Notes { get; set; }
        public int? Rank { get; set; }
        public string Account { get; set; }
        public string Eraccount { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string ItaxName { get; set; }
    }
}
