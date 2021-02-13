using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpIpprojects
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? NonTaxable { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
        public DateTime? Cdate { get; set; }
    }
}
