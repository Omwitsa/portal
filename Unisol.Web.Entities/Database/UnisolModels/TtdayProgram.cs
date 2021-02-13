using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class TtdayProgram
    {
        public int Id { get; set; }
        public string Rday { get; set; }
        public string StudyMode { get; set; }
        public string Campus { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
