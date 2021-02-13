using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class AppointmentDiary
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SomeImportantKey { get; set; }
        public DateTime DateTimeScheduled { get; set; }
        public int AppointmentLength { get; set; }
        public int StatusEnum { get; set; }
    }
}
