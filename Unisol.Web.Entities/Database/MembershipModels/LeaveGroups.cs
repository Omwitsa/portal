using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class LeaveGroups
    {
        public LeaveGroups()
        {
            HrEmployees = new HashSet<HrEmployees>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<HrEmployees> HrEmployees { get; set; }
    }
}
