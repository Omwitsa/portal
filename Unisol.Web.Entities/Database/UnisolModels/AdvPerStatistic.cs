using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class AdvPerStatistic
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Layout { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
