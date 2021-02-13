
using System;
using System.Collections.Generic;
using System.Text;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Common.ViewModels.Finance
{
    public class FeeStructureStageViewModel
    {
        public string Term { get; set; }
        public List<FeesPerProgDetail> Fees { get; set; }
    }

    public class FeesStructureFilter
    {
        public string UserCode { get; set; }
        public string Stage { get; set; }
    }
}
