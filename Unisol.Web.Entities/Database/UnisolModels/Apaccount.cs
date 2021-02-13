using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Apaccount
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public bool? Default { get; set; }
        public string Notes { get; set; }
    }
}
