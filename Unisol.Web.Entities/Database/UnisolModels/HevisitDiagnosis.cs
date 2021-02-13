using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HevisitDiagnosis
    {
        public int Id { get; set; }
        public string Vid { get; set; }
        public string Diagnosis { get; set; }
        public string Result { get; set; }
        public string Notes { get; set; }
    }
}
