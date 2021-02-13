using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpPayGrades
    {
        public string Names { get; set; }
        public decimal? Drate { get; set; }
        public decimal? Hrate { get; set; }
        public decimal? Otrate { get; set; }
        public string Notes { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public int Id { get; set; }
        public decimal? MedicalExp { get; set; }
    }
}
