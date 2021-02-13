using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class UsergroupsCron
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? Lapse { get; set; }
        public DateTime? LastOccurrence { get; set; }
    }
}
