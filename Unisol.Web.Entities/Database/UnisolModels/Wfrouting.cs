using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Wfrouting
    {
        public int Id { get; set; }
        public string Document { get; set; }
        public string ApprovalSubject { get; set; }
        public string ApprovalMsg { get; set; }
        public string DenialSubject { get; set; }
        public string DenialMsg { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
