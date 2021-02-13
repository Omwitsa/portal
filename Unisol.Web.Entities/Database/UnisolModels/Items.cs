using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Items
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
    }
}
