using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class UserLogEvents
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Computer { get; set; }
        public string EventType { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Macaddress { get; set; }
    }
}
