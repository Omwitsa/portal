using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class TtstudyScheduleDetails
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string StudyType { get; set; }
        public double? NumHours { get; set; }
        public string RoomPref { get; set; }
        public string TimePref { get; set; }
        public string Notes { get; set; }
    }
}
