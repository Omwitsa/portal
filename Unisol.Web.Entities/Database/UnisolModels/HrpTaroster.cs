using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpTaroster
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public string Category { get; set; }
        public string DayProgram { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Personnel { get; set; }
    }
}
