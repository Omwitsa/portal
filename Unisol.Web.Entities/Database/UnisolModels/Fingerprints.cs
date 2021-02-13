using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Fingerprints
    {
        public int Serial { get; set; }
        public string UserId { get; set; }
        public short? FingerIndex { get; set; }
        public byte[] Template1 { get; set; }
        public byte[] Template2 { get; set; }
        public string Memo { get; set; }
    }
}
