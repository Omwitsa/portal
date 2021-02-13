using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HevisitReferral
    {
        public int Id { get; set; }
        public string Vid { get; set; }
        public string Subject { get; set; }
        public string Reason { get; set; }
        public string Recipient { get; set; }
    }
}
