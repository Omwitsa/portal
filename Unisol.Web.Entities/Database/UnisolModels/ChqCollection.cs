using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ChqCollection
    {
        public int Id { get; set; }
        public string Ledger { get; set; }
        public string Bank { get; set; }
        public string ChequeNo { get; set; }
        public string CollectedBy { get; set; }
        public string Idnumber { get; set; }
        public string Tel { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
