using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Reporting
{
    public class ReportingViewModel
    {
        public string AdmnNo { get; set; }
        public string Term { get; set; }
        public DateTime? Rdate { get; set; }
        public DateTime? Rtime { get; set; }
        public string Personnel { get; set; }
        public string Type { get; set; }
    }

    public class ReportOnlineViewModel
    {
        public string UserCode { get; set; }
    }
}
