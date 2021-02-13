using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class UsergroupsAccess
    {
        public long Id { get; set; }
        public int Element { get; set; }
        public long ElementId { get; set; }
        public string Module { get; set; }
        public string Controller { get; set; }
        public string Permission { get; set; }
    }
}
