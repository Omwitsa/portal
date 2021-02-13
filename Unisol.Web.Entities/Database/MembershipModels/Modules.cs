using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class Modules
    {
        public Modules()
        {
            ModuleAction = new HashSet<ModuleAction>();
        }

        public int Id { get; set; }
        public string Active { get; set; }
        public DateTime DateEnabled { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }

        public ICollection<ModuleAction> ModuleAction { get; set; }
    }
}
