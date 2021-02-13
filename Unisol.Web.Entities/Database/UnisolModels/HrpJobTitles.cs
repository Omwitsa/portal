using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpJobTitles
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Description { get; set; }
        public string Duties { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
        public string Pgrade { get; set; }
    }
}
