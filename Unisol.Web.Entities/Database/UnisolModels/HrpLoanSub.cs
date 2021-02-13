using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpLoanSub
    {
        public int Id { get; set; }
        public int? Ref { get; set; }
        public DateTime? Rdate { get; set; }
        public decimal? Principal { get; set; }
        public decimal? Interest { get; set; }
        public decimal? Premium { get; set; }
    }
}
