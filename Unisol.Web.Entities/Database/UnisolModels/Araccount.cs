using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Araccount
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public bool? Student { get; set; }
        public bool? Imprest { get; set; }
        public bool? Default { get; set; }
        public string Notes { get; set; }
    }
}
