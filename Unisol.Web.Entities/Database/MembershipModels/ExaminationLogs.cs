using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class ExaminationLog
    {
  

        public int Id { get; set; }
        public string AdminNo { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
		public string Action { get; set; } 
        public string Semester { get; set; } 
        public string ActionDescription { get; set; } 
        
    }
}
