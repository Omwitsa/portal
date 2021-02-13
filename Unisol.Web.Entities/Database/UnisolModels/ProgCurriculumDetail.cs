using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ProgCurriculumDetail
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string UnitCode { get; set; }
        public string Stage { get; set; }
        public string Term { get; set; }
        public string GroupType { get; set; }
        public string GrpMinChoice { get; set; }
        public string GrpMaxChoice { get; set; }
        public string Prerequisite { get; set; }
        public string Grading { get; set; }
    }
}
