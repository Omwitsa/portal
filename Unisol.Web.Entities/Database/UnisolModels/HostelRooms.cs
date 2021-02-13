using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HostelRooms
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public int? Maxacc { get; set; }
        public string Gender { get; set; }
        public bool? Suspended { get; set; }
        public string Notes { get; set; }
        public string Hostel { get; set; }
        public string RoomType { get; set; }
        public int? Rank { get; set; }
    }
}
