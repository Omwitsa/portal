using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class GcsSetup
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Bcode { get; set; }
        public bool? Aname { get; set; }
        public bool? PlaySounds { get; set; }
        public string VoiceType { get; set; }
        public string ClassType { get; set; }
        public string ClassStatus { get; set; }
        public decimal? MinArrears { get; set; }
        public bool? Reporting { get; set; }
        public string StaffCat { get; set; }
        public string BiostarHost { get; set; }
        public string BiostarUname { get; set; }
        public string BiostarPwd { get; set; }
        public string BiostarDbname { get; set; }
        public bool? ImportOnlyMembersWithFp { get; set; }
        public bool? OverwriteFp { get; set; }
    }
}
