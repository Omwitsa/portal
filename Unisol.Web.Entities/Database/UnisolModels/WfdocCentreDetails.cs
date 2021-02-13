using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class WfdocCentreDetails
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Approver { get; set; }
        public int? Level { get; set; }
        public string UserCode { get; set; }
        public string Action { get; set; }
        public string Reason { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string ActionSelected { get; set; }
        public string Station { get; set; }
    }
}
