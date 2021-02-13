using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpRetroDetail
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Account { get; set; }
        public decimal? Amount { get; set; }
        public string Type { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public string Fi { get; set; }
        public string NumType { get; set; }
        public string MemNo { get; set; }
        public string Notes { get; set; }
    }
}
