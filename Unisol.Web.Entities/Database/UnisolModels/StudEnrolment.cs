using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class StudEnrolment
    {
        public int Id { get; set; }
        public string AdmnNo { get; set; }
        public string Class { get; set; }
        public string Event { get; set; }
        public string Status { get; set; }
        public string Stay { get; set; }
        public string Specialization { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Hostel { get; set; }
    }
}
