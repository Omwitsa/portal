using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Rfqdetail
    {
        public int Id { get; set; }
        public string Rfqref { get; set; }
        public string Code { get; set; }
        public string Spec { get; set; }
        public decimal? Qty { get; set; }
    }
}
