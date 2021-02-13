using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.Utilities
{
    public class NewsQuery : Query
    {
        public int? PortalNewsTypeId { get; set; }
        public int? UserGroup { get; set; }
    }
}
