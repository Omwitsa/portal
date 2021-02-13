using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PayeMembers
    {
        public int Id { get; set; }
        public string MemberId { get; set; }
        public string BarcodeId { get; set; }
        public string Names { get; set; }
        public string Department { get; set; }
        public string Category { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool? Lost { get; set; }
        public DateTime? DateLost { get; set; }
        public DateTime? Rdate { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
    }
}
