using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpTadayProgramDetails
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Type { get; set; }
        public int? Sday { get; set; }
        public DateTime? Stime { get; set; }
        public int? Eday { get; set; }
        public DateTime? Etime { get; set; }
    }
}
