using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PayeTopUp
    {
        public int Id { get; set; }
        public string MemberId { get; set; }
        public decimal? Amount { get; set; }
        public string Ref { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
        public string TopUpSource { get; set; }
    }
}
