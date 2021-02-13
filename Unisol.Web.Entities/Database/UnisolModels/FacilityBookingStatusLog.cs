using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class FacilityBookingStatusLog
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public string Computer { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Personnel { get; set; }
    }
}
