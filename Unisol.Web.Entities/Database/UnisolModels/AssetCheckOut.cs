using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class AssetCheckOut
    {
        public int Id { get; set; }
        public float? Ref { get; set; }
        public string MemberId { get; set; }
        public string AssetNo { get; set; }
        public string Room { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public bool? CheckedIn { get; set; }
    }
}
