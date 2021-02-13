using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class FyearPeriods
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Caption { get; set; }
        public string Fyear { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Notes { get; set; }
    }
}
