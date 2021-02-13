using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Tutors
    {
        public string Ref { get; set; }
        public string Tscno { get; set; }
        public string Names { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string Teld { get; set; }
        public string Tele { get; set; }
        public string Telm { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Subjects { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
    }
}
