using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ImprestDisb
    {
        public string ImpRef { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
        public string Bank { get; set; }
        public bool? BankTransfer { get; set; }
        public bool? Printed { get; set; }
    }
}
