using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class EventsUserPreference
    {
        public int UserId { get; set; }
        public string Mobile { get; set; }
        public byte MobileAlert { get; set; }
        public string Email { get; set; }
        public byte EmailAlert { get; set; }
    }
}
