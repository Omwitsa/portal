using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HevisitVitals
    {
        public int Id { get; set; }
        public string Vid { get; set; }
        public string Vital { get; set; }
        public string Result { get; set; }
    }
}
