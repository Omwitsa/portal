using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class SmsBlackList
    {
        public int Id { get; set; }
        public string Bnum { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Personnel { get; set; }
    }
}
