using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class AssetCheckHistory
    {
        public int Id { get; set; }
        public string MemberId { get; set; }
        public string AssetNo { get; set; }
        public string Event { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Personnel { get; set; }
    }
}
