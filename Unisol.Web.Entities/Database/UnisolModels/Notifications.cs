using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Notifications
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime? Datec { get; set; }
        public int? IsRead { get; set; }
    }
}
