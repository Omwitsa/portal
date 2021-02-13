using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Ttatype
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Bcolor { get; set; }
        public bool? Closed { get; set; }
        public bool? Break { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
