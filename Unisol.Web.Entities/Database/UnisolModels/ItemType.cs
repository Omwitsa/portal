using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ItemType
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Notes { get; set; }
        public bool? Closed { get; set; }
    }
}
