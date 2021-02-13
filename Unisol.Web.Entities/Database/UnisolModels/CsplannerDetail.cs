using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class CsplannerDetail
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Class { get; set; }
        public DateTime? Odate { get; set; }
        public string Stage { get; set; }
        public string Term { get; set; }
        public string Milestone { get; set; }
    }
}
