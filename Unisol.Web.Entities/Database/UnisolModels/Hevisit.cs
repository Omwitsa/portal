using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Hevisit
    {
        public int Id { get; set; }
        public string Vid { get; set; }
        public string Pid { get; set; }
        public string Location { get; set; }
        public string Condition { get; set; }
        public string Medication { get; set; }
        public string Notes { get; set; }
        public bool? Closed { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
