using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class TtexamProcessed
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public string ExamPeriod { get; set; }
        public string StudyMode { get; set; }
        public string Campus { get; set; }
        public TimeSpan? Stime { get; set; }
        public TimeSpan? Etime { get; set; }
        public string UnitCode { get; set; }
        public string ExamType { get; set; }
        public int? NumOfStudentsUsed { get; set; }
        public string Room { get; set; }
		public DateTime? Rdate { get; set; }
		public float? Rhours { get; set; }
		public string DayPlan { get; set; }
		public string Invigilator { get; set; }
	}
}
