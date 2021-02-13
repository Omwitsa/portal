using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class FeesPerProgDetail
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Account { get; set; }
        public decimal? Amount { get; set; }
        public bool? Mandatory { get; set; }
        public string Stage { get; set; }
        public string Term { get; set; }
        public string Notes { get; set; }
    }
}
