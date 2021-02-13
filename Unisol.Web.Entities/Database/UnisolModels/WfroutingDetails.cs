using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class WfroutingDetails
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Approver { get; set; }
        public int? Level { get; set; }
        public string Action { get; set; }
    }
}
