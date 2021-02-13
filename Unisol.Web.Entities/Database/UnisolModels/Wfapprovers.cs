using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Wfapprovers
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
