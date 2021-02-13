using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class AdmnLetters
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public string Salutation { get; set; }
        public string Memo { get; set; }
        public string Cclose { get; set; }
        public string Signature { get; set; }
        public byte[] SignImage { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public bool? Closed { get; set; }
    }
}
