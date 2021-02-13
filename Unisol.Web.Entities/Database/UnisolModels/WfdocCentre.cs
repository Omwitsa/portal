using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class WfdocCentre
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string DocNo { get; set; }
        public string Description { get; set; }
        public string UserRef { get; set; }
        public string Names { get; set; }
        public string Department { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Personnel { get; set; }
        public string LatestApprovalBy { get; set; }
        public string LatestApprovalStatus { get; set; }
        public string LatestApprovalReason { get; set; }
        public string FinalStatus { get; set; }
    }
}
