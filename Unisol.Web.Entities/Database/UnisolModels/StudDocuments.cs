using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class StudDocuments
    {
        public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        public int? AssignId { get; set; }
        public string StudentId { get; set; }
        public string SubjectId { get; set; }
        public string TutorId { get; set; }
    }
}
