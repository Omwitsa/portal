using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Reminder
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public string Notes { get; set; }
        public DateTime? Duedate { get; set; }
        public DateTime? Duetime { get; set; }
        public string Personnel { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
