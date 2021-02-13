using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Hostels
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public string Amenities { get; set; }
        public string Contact { get; set; }
        public string Notes { get; set; }
        public bool? Closed { get; set; }
        public string HostelType { get; set; }
    }
}
