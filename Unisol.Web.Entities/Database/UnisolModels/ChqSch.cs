using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ChqSch
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Ledger { get; set; }
        public string Bank { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
    }
}
