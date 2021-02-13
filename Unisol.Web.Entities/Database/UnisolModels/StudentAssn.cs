using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class StudentAssn
    {
        public int AssignId { get; set; }
        public string SubjectCode { get; set; }
        public DateTime DurationStart { get; set; }
        public DateTime DurationEnd { get; set; }
        public string AssignContent { get; set; }
    }
}
