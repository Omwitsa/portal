using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class PortalEventTypes
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
		public string EventTypeName { get; set; }
    }
}
