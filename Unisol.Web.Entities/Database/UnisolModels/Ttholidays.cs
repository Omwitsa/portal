using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Ttholidays
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Campus { get; set; }
        public string StudyMode { get; set; }
        public DateTime? Hdate { get; set; }
        public bool? Recur { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
