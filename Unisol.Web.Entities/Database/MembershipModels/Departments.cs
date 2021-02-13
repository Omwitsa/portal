using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class Departments
    {
        public Departments()
        {
            Sections = new HashSet<Sections>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Sections> Sections { get; set; }
    }
}
