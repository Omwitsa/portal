using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class UsergroupsLookup
    {
        public long Id { get; set; }
        public string Element { get; set; }
        public int? Value { get; set; }
        public string Text { get; set; }
    }
}
