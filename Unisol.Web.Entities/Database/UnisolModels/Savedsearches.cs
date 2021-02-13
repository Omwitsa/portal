using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Savedsearches
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Url { get; set; }
        public int? Type { get; set; }
        public string Name { get; set; }
    }
}
