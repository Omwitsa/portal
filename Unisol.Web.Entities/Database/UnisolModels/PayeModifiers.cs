using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PayeModifiers
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public decimal? Cost { get; set; }
        public string Notes { get; set; }
        public bool? Closed { get; set; }
    }
}
