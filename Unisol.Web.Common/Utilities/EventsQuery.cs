using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.Utilities
{
    public class EventsQuery : Query
    {
        public int? PortalEventTypeId { get; set; }
        public int? UserGroup { get; set; }
    }
}
