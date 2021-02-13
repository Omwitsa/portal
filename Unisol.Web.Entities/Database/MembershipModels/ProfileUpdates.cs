using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class ProfileUpdates
    {
        public int Id { get; set; }
        public string TelNo { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string UserCode { get; set; }
        public bool Status { get; set; }
        public bool AllowedAdminApproval { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
	}
}
