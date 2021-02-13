using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpAcademicRank
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public int? RetAge { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
    }
}
