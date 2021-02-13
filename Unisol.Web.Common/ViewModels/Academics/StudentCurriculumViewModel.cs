using System;
using System.Collections.Generic;
using System.Text;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Common.ViewModels.Academics
{
    public class StudentCurriculumViewModel
    {
        public string Stage { get; set; }
        public List<Semester> Semesters { get; set; }
    }

    public class Semester
    {
        public int? Id { get; set; }
        public string SemesterName { get; set; }
        public List<CurriculumUnits> CurriculumUnits { get; set; }
    }

    public class CurriculumUnits
    {
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public double CreditUnits { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
		public bool DoneStatus { get; set; }
		public string UnitRegLevel { get; set; }
		public bool DonePreviously { get; set; }
	}

    public class StudentCurriculumViewModelWithStatus
    {
        public List<StudentCurriculumViewModel> StudentCurriculumViewModel { get; set; }
        public bool UnitRegistrationDeadline { get; set; }
        public bool ReportedCurrentSem { get; set; }
    }

	public class CurriculumModel
	{
		public int? Id { get; set; }
		public string GroupType { get; set; }
		public string UnitCode { get; set; }
		public string Term { get; set; }
		public string Stage { get; set; }
		public string Class { get; set; }
		public string Ref { get; set; }
		public string AdmnNo { get; set; }
		public string Status { get; set; }
		public DateTime? Rdate { get; set; }
	}
}