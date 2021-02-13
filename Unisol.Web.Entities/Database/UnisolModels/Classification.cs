using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Classification
    {
        public int Id { get; set; }
        public string Scheme { get; set; }
        public string Range { get; set; }
        public string Names { get; set; }
        public string Notes { get; set; }
        public string RepeatCase { get; set; }
    }
}
