using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class ModuleAction
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime DateActivated { get; set; }
        public string Enabled { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }

        public Modules Module { get; set; }
    }
}
