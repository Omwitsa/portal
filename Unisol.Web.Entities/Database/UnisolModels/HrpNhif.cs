using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpNhif
    {
        public int Id { get; set; }
        public string MinAmt { get; set; }
        public string MaxAmt { get; set; }
        public decimal? Deduction { get; set; }
        public string Ref { get; set; }
    }
}
