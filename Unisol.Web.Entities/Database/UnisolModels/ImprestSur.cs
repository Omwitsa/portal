using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ImprestSur
    {
        public string ImpRef { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public decimal? ActualAmount { get; set; }
    }
}
