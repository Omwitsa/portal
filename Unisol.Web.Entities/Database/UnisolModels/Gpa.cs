using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Gpa
    {
        public string Grade { get; set; }
        public string Names { get; set; }
        public decimal? Points { get; set; }
        public string Notes { get; set; }
    }
}
