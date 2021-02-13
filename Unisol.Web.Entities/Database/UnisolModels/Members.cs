using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Members
    {
        public string MemberId { get; set; }
        public string Names { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? Edate { get; set; }
        public DateTime? Createdate { get; set; }
        public bool? Suspended { get; set; }
        public DateTime? DtSuspended { get; set; }
        public string Notes { get; set; }
    }
}
