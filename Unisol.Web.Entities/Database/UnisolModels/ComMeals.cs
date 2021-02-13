using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ComMeals
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public decimal? Boarding { get; set; }
        public decimal? Ewc { get; set; }
    }
}
