using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class McsUsers
    {
        public int Id { get; set; }
        public string UserCode { get; set; }
        public string Names { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Notes { get; set; }
        public bool? Closed { get; set; }
        public bool? Mcsmembers { get; set; }
        public bool? Mcsbarcode { get; set; }
        public bool? McsmemCat { get; set; }
        public bool? Mcsreports { get; set; }
        public bool? McsmealTrack { get; set; }
        public bool? Mcsadmin { get; set; }
    }
}
