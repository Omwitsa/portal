using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Applicant
    {
        public string Ref { get; set; }
        public string AdmnNo { get; set; }
        public string Names { get; set; }
        public string NationalId { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string Marital { get; set; }
        public string Nationality { get; set; }
        public string Telno { get; set; }
        public string County { get; set; }
        public string District { get; set; }
        public string Homeaddress { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Source { get; set; }
        public string Religion { get; set; }
        public string Afrn { get; set; }
        public string Programme { get; set; }
        public string StudyMode { get; set; }
        public string Campus { get; set; }
        public string Ryear { get; set; }
        public string Rmonth { get; set; }
        public string Language { get; set; }
        public string Emname { get; set; }
        public string Emrel { get; set; }
        public string Emtel { get; set; }
        public string Ememail { get; set; }
        public string Emaddress { get; set; }
        public string Emremarks { get; set; }
        public string Special { get; set; }
        public string Activity { get; set; }
        public string Prevadmnno { get; set; }
        public string Notes { get; set; }
        public DateTime? Createdate { get; set; }
        public string Personnel { get; set; }
        public string Sponsor { get; set; }
        public string Disability { get; set; }
        public string IndexNo { get; set; }
        public string Constituency { get; set; }
        public string SubCounty { get; set; }
    }
}
