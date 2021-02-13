using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class GcsTimePlan
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Station { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Notes { get; set; }
        public bool? Closed { get; set; }
    }
}
