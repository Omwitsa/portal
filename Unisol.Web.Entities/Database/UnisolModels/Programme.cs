using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Programme
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Names { get; set; }
        public string Department { get; set; }
        public string GradeType { get; set; }
        public string AdminReq { get; set; }
        public string CertType { get; set; }
        public string Period { get; set; }
        public string Startyear { get; set; }
        public string Notes { get; set; }
        public bool? Closed { get; set; }
        public int? MaxUnits { get; set; }
    }
}
