using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class SupPreq
    {
        public int Ref { get; set; }
        public string Fyear { get; set; }
        public string SupRef { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
    }
}
