using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ClassStatistics
    {
        public string Class { get; set; }
        public string ClassType { get; set; }
        public int? Male { get; set; }
        public int? Female { get; set; }
        public int? Boarders { get; set; }
        public int? Commuters { get; set; }
    }
}
