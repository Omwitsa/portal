using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class MatureEntry
    {
        public int Id { get; set; }
        public string AdmnNo { get; set; }
        public int? Stage { get; set; }
        public string Basis { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
