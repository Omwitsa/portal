using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class PayeCardIssue
    {
        public string BarcodeId { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
