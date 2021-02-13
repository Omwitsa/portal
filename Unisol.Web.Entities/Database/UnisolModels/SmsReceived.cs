using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class SmsReceived
    {
        public int Id { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Sender { get; set; }
        public string Msgtype { get; set; }
        public string Msg { get; set; }
        public bool? Replied { get; set; }
        public string ReplyMsg { get; set; }
    }
}
