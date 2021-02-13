using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ProgUnitRegDetail
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string UnitCode { get; set; }
        public string Status { get; set; }
        public bool? Audit { get; set; }
        public string Notes { get; set; }
    }
}
