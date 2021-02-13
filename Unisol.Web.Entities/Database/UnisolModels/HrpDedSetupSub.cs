using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpDedSetupSub
    {
        public int Id { get; set; }
        public int? Ref { get; set; }
        public string Pgrade { get; set; }
        public decimal? Amount { get; set; }
    }
}
