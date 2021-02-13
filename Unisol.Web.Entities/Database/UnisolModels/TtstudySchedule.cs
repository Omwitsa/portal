using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class TtstudySchedule
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public string UnitCode { get; set; }
        public string StudyPeriod { get; set; }
        public string StudyMode { get; set; }
        public string Campus { get; set; }
        public int? NumStudents { get; set; }
        public string DoubleBlock { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
