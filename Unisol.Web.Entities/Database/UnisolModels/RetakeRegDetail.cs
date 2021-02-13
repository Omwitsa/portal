using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class RetakeRegDetail
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string UnitCode { get; set; }
        public string Notes { get; set; }
    }
}
