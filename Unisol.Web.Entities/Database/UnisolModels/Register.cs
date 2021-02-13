using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Register
    {
        public int Id { get; set; }
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
        public string Sponsor { get; set; }
        public string Source { get; set; }
        public string Religion { get; set; }
        public string Programme { get; set; }
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
        public string Faid { get; set; }
        public byte[] FingerTemplate1 { get; set; }
        public byte[] FingerTemplate2 { get; set; }
        public string PortalUn { get; set; }
        public string PortalPwd { get; set; }
        public bool? PortalSusP { get; set; }
        public string Notes { get; set; }
        public DateTime? Createdate { get; set; }
        public string Personnel { get; set; }
        public bool? Closed { get; set; }
        public DateTime? Dateclosed { get; set; }
        public string CloseReason { get; set; }
        public string Disability { get; set; }
        public string Domicile { get; set; }
        public string Constituency { get; set; }
        public string SubCounty { get; set; }
		public string StudyMode { get; set; }
	}
}
