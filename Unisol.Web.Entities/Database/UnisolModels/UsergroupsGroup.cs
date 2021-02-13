using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class UsergroupsGroup
    {
        public UsergroupsGroup()
        {
            UsergroupsUser = new HashSet<UsergroupsUser>();
        }

        public long Id { get; set; }
        public string Groupname { get; set; }
        public int? Level { get; set; }
        public string Home { get; set; }

        public ICollection<UsergroupsUser> UsergroupsUser { get; set; }
    }
}
