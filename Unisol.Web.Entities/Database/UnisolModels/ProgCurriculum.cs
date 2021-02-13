using System;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ProgCurriculum
    {
        public int Id { get; set; }
        public string ProgCode { get; set; }
        public string Specialization { get; set; }
        public decimal? CreditUnits { get; set; }
        public decimal? NoUnits { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string Notes { get; set; }
        public string AwardScheme { get; set; }
        public string Aggregation { get; set; }
        public string DistAggregate { get; set; }
        public string CurriculumCycle { get; set; }
    }
}
