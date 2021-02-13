using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class SmsSent
    {
        public int Id { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Ref { get; set; }
        public string Recipient { get; set; }
        public string Msg { get; set; }
        public string Status { get; set; }
    }
}
