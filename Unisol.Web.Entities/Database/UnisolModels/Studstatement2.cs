using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Studstatement2
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Term { get; set; }
        public decimal? Required { get; set; }
        public decimal? Refund { get; set; }
        public decimal? Paid { get; set; }
    }
}
