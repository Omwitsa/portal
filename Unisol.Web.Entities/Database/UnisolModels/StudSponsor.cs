using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class StudSponsor
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Rcptno { get; set; }
        public string Account { get; set; }
        public decimal? Amount { get; set; }
        public string Prefix { get; set; }
        public string Notes { get; set; }
        public DateTime? Edate { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public string Faid { get; set; }
    }
}
