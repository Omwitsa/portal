using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class AppFiles
    {
        public string Ref { get; set; }
        public string Fname { get; set; }
        public string Title { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
