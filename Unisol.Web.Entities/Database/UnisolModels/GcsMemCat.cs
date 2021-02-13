using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class GcsMemCat
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string DaysAllowed { get; set; }
        public DateTime? ExDate { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public bool? MultipleEntries { get; set; }
        public bool? Closed { get; set; }
    }
}
