using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Term
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string AcademicYear { get; set; }
        public string Names { get; set; }
        public string TermAlias { get; set; }
        public DateTime? Starts { get; set; }
        public DateTime? Ends { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
    }
}
