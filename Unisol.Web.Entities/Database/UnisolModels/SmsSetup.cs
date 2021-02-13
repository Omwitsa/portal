using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class SmsSetup
    {
        public int Id { get; set; }
        public string Smsport { get; set; }
        public string Smsspeed { get; set; }
        public string Smspin { get; set; }
        public bool? Smsdisablepin { get; set; }
        public bool? Smsdelete { get; set; }
        public string Smsstore { get; set; }
        public int? SmsSecs { get; set; }
        public bool? Smsmultipart { get; set; }
        public bool? Smsflash { get; set; }
        public bool? Smsreport { get; set; }
        public string SmsReplyMsg { get; set; }
        public int? SmsBlnum { get; set; }
    }
}
