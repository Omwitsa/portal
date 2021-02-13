using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Ttbuilding
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Campus { get; set; }
        public string Xcoord { get; set; }
        public string Ycoord { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
    }
}
