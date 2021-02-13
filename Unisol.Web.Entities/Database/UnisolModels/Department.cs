using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Department
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public bool? Tuition { get; set; }
        public string Notes { get; set; }
        public string School { get; set; }
        public bool? Closed { get; set; }
    }
}
