using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpIncrementalDates
    {
        public int Id { get; set; }
        public DateTime IncDate { get; set; }
        public string Notes { get; set; }
    }
}
