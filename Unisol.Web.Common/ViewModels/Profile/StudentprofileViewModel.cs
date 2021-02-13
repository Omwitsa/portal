using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Profile
{
    public class StudentprofileViewModel
    {
        public string AdmnNo { get; set; }
        public string Telno { get; set; }
        public string Homeaddress { get; set; }
        public string Email { get; set; }
        public string County { get; set; }
        public string Domicile { get; set; }
        public string SubCounty { get; set; }
        public string Constituency { get; set; }
		public string Language { get; set; }
		public string Medical { get; set; }
		public string Activity { get; set; }
		public string DependantName { get; set; }
		public string DependantRelationShip { get; set; }
		public string DependantGender { get; set; }
		public string DependantTelNo { get; set; }
		public string DependantOccupation { get; set; }
		public string DependantNotes { get; set; }
		public string EmergencyName { get; set; }
		public string EmergencyRelationShip { get; set; }
		public string EmergencyTelNo { get; set; }
		public string EmergencyEmail { get; set; }
		public string EmergencyAddress { get; set; }
		public string EmergencyRemarks { get; set; }
	}

	public enum ProfileEditor
	{
		EditContacts = 1,
		EditDependancies = 2,
		EditOthers = 3,
		EditEmergency = 4
	}
}
