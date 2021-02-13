using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class FeesPerProg
    {
        public int Id { get; set; }
        public string ProgCode { get; set; }
        public string Sponsor { get; set; }
        public string Campus { get; set; }
        public string StudyMode { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Specialization { get; set; }
    }
}
