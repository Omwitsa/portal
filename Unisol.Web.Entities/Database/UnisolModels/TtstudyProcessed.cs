using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class TtstudyProcessed
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public string StudyPeriod { get; set; }
        public string Rday { get; set; }
        public string StudyMode { get; set; }
        public string Campus { get; set; }
        public DateTime? Stime { get; set; }
        public DateTime? Etime { get; set; }
        public string LecturerUsed { get; set; }
        public string UnitCode { get; set; }
		public string UUCode { get; set; }
		public string StudyType { get; set; }
        public int? ReqMins { get; set; }
        public int? PossibleMins { get; set; }
        public int? ActualMins { get; set; }
        public int? NumOfStudentsUsed { get; set; }
        public string Room { get; set; }
		public string Programme { get; set; }
	}
}
