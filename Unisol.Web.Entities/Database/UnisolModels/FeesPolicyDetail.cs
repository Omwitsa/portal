using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class FeesPolicyDetail
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Account { get; set; }
        public decimal? Paid { get; set; }
    }
}
