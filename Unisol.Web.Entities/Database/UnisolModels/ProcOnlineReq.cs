using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ProcOnlineReq
    {
        public string ReqRef { get; set; }
		public string DocType { get; set; }
		public string Usercode { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Reaction { get; set; }
        public string Reactby { get; set; }
        public DateTime? ReactDate { get; set; }
        public DateTime? ReactTime { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
    }
}
