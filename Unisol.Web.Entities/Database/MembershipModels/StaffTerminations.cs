using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class StaffTerminations
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
		public string Notes { get; set; }
        public int StaffId { get; set; }
        public int TypeId { get; set; }

        public HrEmployees Staff { get; set; }
        public TerminationTypes Type { get; set; }
    }
}
