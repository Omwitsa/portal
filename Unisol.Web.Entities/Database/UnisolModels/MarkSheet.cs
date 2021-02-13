using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class MarkSheet
    {
        public int Id { get; set; }
        public string AdmnNo { get; set; }
        public string Class { get; set; }
        public string Term { get; set; }
        public string Subject { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public decimal? Att { get; set; }
        public decimal? Exam { get; set; }
        public bool? Mip { get; set; }
		public decimal? Cat { get; set; }
		public decimal? Cat1 { get; set; }
		public decimal? Cat2 { get; set; }
        public string ApprovalStatus { get; set; }
        public string Type { get; set; }
        public decimal? CourseWork { get; set; }
    }
}
