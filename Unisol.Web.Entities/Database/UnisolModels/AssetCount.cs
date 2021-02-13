using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class AssetCount
    {
        public int Id { get; set; }
        public string Period { get; set; }
        public string AssetNo { get; set; }
        public string Eroom { get; set; }
        public string Aroom { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
