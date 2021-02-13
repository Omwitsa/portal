using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class RegList
    {
        public int Id { get; set; }
        public string AdmnNo { get; set; }
        public string Names { get; set; }
        public string Stay { get; set; }
        public decimal? Arrears { get; set; }
        public decimal? Expected { get; set; }
        public decimal? Total { get; set; }
        public decimal? Paid { get; set; }
        public decimal? Refund { get; set; }
    }
}
