using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class GcsTracking
    {
        public int Id { get; set; }
        public string MemberNo { get; set; }
        public string InOut { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
        public string DeviceId { get; set; }
        public string EventId { get; set; }
    }
}
