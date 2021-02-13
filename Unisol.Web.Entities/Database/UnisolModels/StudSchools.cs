using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class StudSchools
    {
        public int Id { get; set; }
        public string AdmnNo { get; set; }
        public string Names { get; set; }
        public string Type { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public string Qualification { get; set; }
        public string Grades { get; set; }
        public string IndexNo { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
    }
}
