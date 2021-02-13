using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PayeIngredients
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public decimal? Cost { get; set; }
        public string Uom { get; set; }
        public string Notes { get; set; }
        public bool? Closed { get; set; }
    }
}
