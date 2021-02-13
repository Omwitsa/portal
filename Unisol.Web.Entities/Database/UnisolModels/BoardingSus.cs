using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class BoardingSus
    {
        public string AdmnNo { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Reason { get; set; }
    }
}
