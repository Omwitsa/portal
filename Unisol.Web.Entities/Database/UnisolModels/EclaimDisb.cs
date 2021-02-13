using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class EclaimDisb
    {
        public string Ecref { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
        public string Bank { get; set; }
        public bool? BankTransfer { get; set; }
        public bool? Printed { get; set; }
    }
}
