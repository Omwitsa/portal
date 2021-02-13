using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Grading
    {
        public int Id { get; set; }
        public string GradeType { get; set; }
        public string Range { get; set; }
        public string Names { get; set; }
        public string Points { get; set; }
        public string Notes { get; set; }
        public decimal? Gpa { get; set; }
    }
}
