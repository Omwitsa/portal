using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class ClassCourse
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }
        public string Term { get; set; }
        public string TermType { get; set; }
        public string Subject { get; set; }
        public string Tutors { get; set; }
        public decimal? OtherTests { get; set; }
        public decimal? ExamComp { get; set; }
        public decimal? PassMark { get; set; }
        public decimal? Hours { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string MarkType { get; set; }
        public bool? Exam { get; set; }
        //public bool? Cat2 { get; set; }
        public bool? Cat { get; set; }
        //public bool? CourseWork { get; set; }
    }
}
