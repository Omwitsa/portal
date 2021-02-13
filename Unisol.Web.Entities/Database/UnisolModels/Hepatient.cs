using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Hepatient
    {
        public int Id { get; set; }
        public string Pid { get; set; }
        public string Pref { get; set; }
        public string Names { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Allergies { get; set; }
        public string MedCondition { get; set; }
        public string SocialHistory { get; set; }
        public string Exercise { get; set; }
        public string Smoker { get; set; }
        public string Notes { get; set; }
        public DateTime? Rdate { get; set; }
        public string Personnel { get; set; }
    }
}
