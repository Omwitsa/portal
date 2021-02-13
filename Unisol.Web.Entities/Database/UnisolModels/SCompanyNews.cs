using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class SCompanyNews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public short StatusId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Document { get; set; }
        public string Group { get; set; }
    }
}
