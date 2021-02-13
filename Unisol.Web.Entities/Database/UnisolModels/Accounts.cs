using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Accounts
    {
        public string AccNo { get; set; }
        public string Names { get; set; }
        public string Type { get; set; }
        public string Stype { get; set; }
        public bool? Caccount { get; set; }
        public string Paccount { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
        public string Class { get; set; }
        public bool? StudentRelated { get; set; }
        public int? Rank { get; set; }
        public bool? Budget { get; set; }
        public string SubGroup { get; set; }
    }
}
