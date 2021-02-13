using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpPayGradesSub
    {
        public int Id { get; set; }
        public string PayGrade { get; set; }
        public string Rank { get; set; }
        public decimal? MinSal { get; set; }
        public decimal? MaxSal { get; set; }
        public decimal? StepInc { get; set; }
        public string Ref { get; set; }
    }
}
