using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpTatimesheet
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public string InOut { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
        public string DeviceId { get; set; }
    }
}
