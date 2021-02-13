using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class HrpReview
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public DateTime? RevDate { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
        public string ReviewPeriod { get; set; }
        public string DeptObjectives { get; set; }
        public string EmpSwca { get; set; }
        public string EmpComments { get; set; }
        public string NextObjectives { get; set; }
        public string ReviewAction { get; set; }
        public DateTime? ReviewActionDate { get; set; }
    }
}
