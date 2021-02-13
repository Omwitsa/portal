using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class GcsMembers
    {
        public int Id { get; set; }
        public string MemberId { get; set; }
        public string BarcodeId { get; set; }
        public string Names { get; set; }
        public string Category { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Edate { get; set; }
        public string Personnel { get; set; }
        public bool? Suspended { get; set; }
        public DateTime? DateSus { get; set; }
        public bool? Closed { get; set; }
        public bool? Lost { get; set; }
        public DateTime? DateLost { get; set; }
        public bool? Epermission { get; set; }
        public string Notes { get; set; }
        public bool? BiostarUpdate { get; set; }
        public bool? DeviceUpdate { get; set; }
    }
}
