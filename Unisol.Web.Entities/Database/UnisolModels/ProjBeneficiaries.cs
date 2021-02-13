using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ProjBeneficiaries
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string BenRef { get; set; }
        public string Type { get; set; }
    }
}
