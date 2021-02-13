using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class TtstudyScheduleLecturer
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string EmpNo { get; set; }
        public double? Load { get; set; }
    }
}
