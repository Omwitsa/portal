using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class FacilityBooking
    {
        public string Ref { get; set; }
        public string Facility { get; set; }
        public string EventType { get; set; }
        public string BookingBy { get; set; }
        public bool? AllDay { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Stime { get; set; }
        public DateTime? Edate { get; set; }
        public DateTime? Etime { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
