using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Studentattendance
    {
        public int Id { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public string StudentId { get; set; }
        public string Reason { get; set; }
        public short IsHalfDay { get; set; }
    }
}
