using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Academics
{
    public class StudentAcademicViewModel
    {
        public StudentProgramme StudentProgramme { get; set; }     
        public StudentDeparment StudentDeparment { get; set; }     
        public StudentClass StudentClass { get; set; } 
        public StudentSemesterYear StudentSemester { get; set; }
	    public string StudentName { get; set; }
        public string Sponsor { get; set; }
    }

    public class StudentDeparment
    {
        public string Id { get; set; }
        public string Department { get; set; }
		public string School { get; set; }
	}

    public class StudentProgramme
    {
        public string Id { get; set; }
        public string Programme { get; set; }
        public string Type { get; set; }
        public string ProgCode { get; set; }
    }
    public class StudentClass
    {
        public string Id { get; set; }
        public string ClassName { get; set; }
		public string Campus { get; set; }
		public string YearOfStudy { get; set; }
		public int AdmissionYear { get; set; }
	}
    public class StudentSemesterYear
    {
        public string Id { get; set; }
        public string Semester { get; set; }
		public string SemesterId { get; set; }
		public string RegisterId { get; set; }
		public string YearOfStudy { get; set; }
        public string Ref { get; set; }
    }
}
