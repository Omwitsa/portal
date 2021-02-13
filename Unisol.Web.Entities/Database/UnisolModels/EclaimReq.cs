using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class EclaimReq
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public string VehicleRegNo { get; set; }
        public string Cc { get; set; }
        public string DestFrom { get; set; }
        public string DestTo { get; set; }
        public string Distance { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public string ClaimDays { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Reaction { get; set; }
        public string Reactby { get; set; }
        public DateTime? ReactDate { get; set; }
        public DateTime? ReactTime { get; set; }
    }
}
