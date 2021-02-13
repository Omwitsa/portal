using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Repository
    {
        public int Id { get; set; }
        public string Descr { get; set; }
        public string Filename { get; set; }
        public string Filetype { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
