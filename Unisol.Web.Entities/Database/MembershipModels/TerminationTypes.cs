using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class TerminationTypes
    {
        public TerminationTypes()
        {
            StaffTerminations = new HashSet<StaffTerminations>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<StaffTerminations> StaffTerminations { get; set; }
    }
}
