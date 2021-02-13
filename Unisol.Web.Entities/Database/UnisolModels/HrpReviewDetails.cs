using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpReviewDetails
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string PerformanceTarget { get; set; }
        public DateTime? DateWhen { get; set; }
        public decimal? WeightTarget { get; set; }
        public string PerformanceProof { get; set; }
        public decimal? ResultsAchieved { get; set; }
        public decimal? PerformanceRating { get; set; }
    }
}
