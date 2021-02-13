using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class StudDependant
    {
        public int Id { get; set; }
        public string AdmnNo { get; set; }
        public string Names { get; set; }
        public string Relationship { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public DateTime? Rdate { get; set; }
        public string Notes { get; set; }
        public string Personnel { get; set; }
        public string Occupation { get; set; }
        public string Status { get; set; }
        public string Tel { get; set; }
    }
}
