using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ChqRegister
    {
        public int Id { get; set; }
        public string Ledger { get; set; }
        public string Bank { get; set; }
        public string ChequeNo { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
