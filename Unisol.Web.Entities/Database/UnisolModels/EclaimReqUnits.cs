using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class EclaimReqUnits
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Units { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Amount { get; set; }
    }
}
