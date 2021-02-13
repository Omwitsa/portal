using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Eclaim
    {
        public string Ecref { get; set; }
        public string PayeeRef { get; set; }
        public string Names { get; set; }
        public string Ledger { get; set; }
        public string Project { get; set; }
        public string VehicleRegNo { get; set; }
        public string Cc { get; set; }
        public string DestFrom { get; set; }
        public string DestTo { get; set; }
        public string Distance { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public string ClaimDays { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public string Personnel { get; set; }
        public DateTime? Rdate { get; set; }
        public string ImpRef { get; set; }
        public string Notes { get; set; }
        public string ChequeNo { get; set; }
        public string OrderNo { get; set; }
        public string OnlineId { get; set; }
        public string Status { get; set; }
    }
}
