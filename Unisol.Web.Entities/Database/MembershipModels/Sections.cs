using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class Sections
    {
        public Sections()
        {
            Divisions = new HashSet<Divisions>();
        }

        public int Id { get; set; }
        public int DeptId { get; set; }
        public string Name { get; set; }

        public Departments Dept { get; set; }
        public ICollection<Divisions> Divisions { get; set; }
    }
}
