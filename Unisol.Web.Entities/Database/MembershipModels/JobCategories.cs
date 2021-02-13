using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class JobCategories
    {
        public JobCategories()
        {
            HrEmployees = new HashSet<HrEmployees>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<HrEmployees> HrEmployees { get; set; }
    }
}
