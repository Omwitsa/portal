using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class Divisions
    {
        public Divisions()
        {
            HrEmployees = new HashSet<HrEmployees>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SectionId { get; set; }

        public Sections Section { get; set; }
        public ICollection<HrEmployees> HrEmployees { get; set; }
    }
}
