using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class AccStatementDet2
    {
        public string AdmnNo { get; set; }
        public string Names { get; set; }
        public string Class { get; set; }
        public string ClassType { get; set; }
        public decimal? Paid { get; set; }
        public decimal? Refund { get; set; }
    }
}
