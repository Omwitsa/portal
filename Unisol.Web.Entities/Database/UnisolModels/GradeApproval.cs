using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class GradeApproval
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public bool? StudView { get; set; }
        public string Scope { get; set; }
        public string Bcolor { get; set; }
        public string Fcolor { get; set; }
        public string Notes { get; set; }
        public int? Rank { get; set; }
        public bool? Closed { get; set; }
    }
}
