using System;
using System.Collections.Generic;
using System.Text;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Common.Utilities
{
    public class Query
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
		public int UserRole { get; set; }
		public string SearchText { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class UserQuery : Query
    {
        public Role? Role { get; set; }
		public ActionLevel? Level { get; set; }
	}
}
