using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Ttlecturer
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public string Dname { get; set; }
        public string Type { get; set; }
        public int? MaxHrs { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
    }
}
