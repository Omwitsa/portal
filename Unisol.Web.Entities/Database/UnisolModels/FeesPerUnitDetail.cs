using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class FeesPerUnitDetail
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Account { get; set; }
        public decimal? Amount { get; set; }
        public string Notes { get; set; }
    }
}
