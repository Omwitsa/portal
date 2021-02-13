using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class GcsDeviceSetup
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public string AccessType { get; set; }
        public string Notes { get; set; }
        public string Ipaddress { get; set; }
        public string Port { get; set; }
    }
}
