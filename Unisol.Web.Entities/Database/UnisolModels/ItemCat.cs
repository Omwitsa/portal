using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ItemCat
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Notes { get; set; }
        public bool? Closed { get; set; }
        public string Prefix { get; set; }
    }
}
