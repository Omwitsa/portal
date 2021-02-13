using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PayeRecipe
    {
        public int Id { get; set; }
        public string MenuCode { get; set; }
        public string ItemCode { get; set; }
        public decimal? Qty { get; set; }
        public string Notes { get; set; }
    }
}
