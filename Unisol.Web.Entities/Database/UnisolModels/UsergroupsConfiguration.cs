using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class UsergroupsConfiguration
    {
        public long Id { get; set; }
        public string Rules { get; set; }
        public string Value { get; set; }
        public string Options { get; set; }
        public string Description { get; set; }
    }
}
