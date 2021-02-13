using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class AssetService
    {
        public int Id { get; set; }
        public string AssetNo { get; set; }
        public string Description { get; set; }
        public string Stype { get; set; }
        public string ServiceBy { get; set; }
        public decimal? Lcost { get; set; }
        public decimal? Pcost { get; set; }
        public DateTime? Cdate { get; set; }
        public DateTime? Nsdate { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
