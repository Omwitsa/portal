using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class AppWork
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Names { get; set; }
        public string Designation { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public string Station { get; set; }
        public string EmpNo { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
    }
}
