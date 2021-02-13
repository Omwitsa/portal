using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PayeSalesDetail
    {
        public int Id { get; set; }
        public int? Ref { get; set; }
        public string Code { get; set; }
        public string Names { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Total { get; set; }
    }
}
