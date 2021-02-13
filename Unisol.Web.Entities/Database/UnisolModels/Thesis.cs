using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Thesis
    {
        public int Id { get; set; }
        public string AdmnNo { get; set; }
        public string Title { get; set; }
        public string Supervisor { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
