using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ItemReq
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Usercode { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Reaction { get; set; }
        public string Reactby { get; set; }
        public DateTime? ReactDate { get; set; }
        public DateTime? ReactTime { get; set; }
    }
}
