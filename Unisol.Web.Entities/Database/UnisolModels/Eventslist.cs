using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Eventslist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public int? Type { get; set; }
        public short? AllDay { get; set; }
        public int? Start { get; set; }
        public int? End { get; set; }
        public byte? Editable { get; set; }
        public DateTime? TimeCreated { get; set; }
        public string Name { get; set; }
    }
}
