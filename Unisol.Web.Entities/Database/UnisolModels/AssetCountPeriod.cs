using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class AssetCountPeriod
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public DateTime? DueDate { get; set; }
        public string Notes { get; set; }
    }
}
