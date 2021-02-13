using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Subjects
    {
        public string Code { get; set; }
        public string Names { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public string SubjectType { get; set; }
        public string CreditLevel { get; set; }
        public int? MinEnrol { get; set; }
        public int? Maxenrol { get; set; }
        public int? Nhours { get; set; }
        public decimal? CreditUnits { get; set; }
        public bool? Common { get; set; }
        public string MarkTypes { get; set; }
        public string Campuses { get; set; }
        public decimal? OtherTests { get; set; }
        public decimal? Exam { get; set; }
        public bool? Closed { get; set; }
        public string Notes { get; set; }
        public bool? Thesis { get; set; }
    }
}
