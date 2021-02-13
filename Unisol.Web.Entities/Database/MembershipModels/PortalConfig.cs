using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class PortalConfig
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
        public int? AspNetUserId { get; set; }
    }
}
