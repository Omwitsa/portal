using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Xrate
    {
        public int Id { get; set; }
        public string CurFrom { get; set; }
        public string CurTo { get; set; }
        public decimal? Rate { get; set; }
        public string Cmethod { get; set; }
        public DateTime? Xdate { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
    }
}
