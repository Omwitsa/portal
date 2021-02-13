using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class TtexamSchedule
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public string UnitCode { get; set; }
        public string ExamPeriod { get; set; }
        public string StudyMode { get; set; }
        public string Campus { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
