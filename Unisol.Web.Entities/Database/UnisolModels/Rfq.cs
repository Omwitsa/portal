using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Rfq
    {
        public string Rfqref { get; set; }
        public string SupRef { get; set; }
        public DateTime? Stime { get; set; }
        public DateTime? Sdate { get; set; }
        public string Ref { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string Subject { get; set; }
    }
}
