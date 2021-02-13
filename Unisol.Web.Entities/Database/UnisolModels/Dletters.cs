using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Dletters
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Salutation { get; set; }
        public string Memo { get; set; }
        public string Cclose { get; set; }
        public string Signature { get; set; }
    }
}
