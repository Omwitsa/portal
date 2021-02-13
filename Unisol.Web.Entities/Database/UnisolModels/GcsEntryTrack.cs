using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class GcsEntryTrack
    {
        public int Id { get; set; }
        public string BarcodeId { get; set; }
        public string InPlan { get; set; }
        public DateTime? InDate { get; set; }
        public DateTime? InTime { get; set; }
        public string OutPlan { get; set; }
        public DateTime? OutDate { get; set; }
        public DateTime? OutTime { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
    }
}
