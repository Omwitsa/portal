using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Academics
{
	public class TranscriptRequestViewModel
	{
		public string Usercode { get; set; }
		public string AcademicYear { get; set; }
		public string Semester { get; set; }
		public string Ref { get; set; }
	}

	public class RegisteredUnitsModel {
		public string UnitCode { get; set; }
		public string Ref { get; set; }
		public string Status { get; set; }
		public string Names { get; set; }
		public decimal? CreditUnits { get; set; }
		public int? Nhours { get; set; }
	}

    public class YearWithSemesterViewModel
    {
        public string Academicyear { get; set; }
        public List<StudentSemesterYear> Semesters { get; set; }
		public bool isTivetTranscript { get; set; }
		public string Institution { get; set; }
		public string PreviousSemister { get; set; }
	}

	public class YearTranscriptViewModel
	{
		public string Semister { get; set; }
		public List<TranscriptUnitViewModel> Units { get; set; }
		public bool isTivetTranscript { get; set; }
	}

	public class TranscriptUnitViewModel
    {
        public string UnitCode { get; set; } // cat, exam, total
		public string UnitName { get; set; }
		public int? UnitHours { get; set; }
		public decimal? CreditUnits { get; set; }
        public string Grade { get; set; }
        public string Score { get; set; }
		public decimal Exam { get; set; }
		public decimal Cat { get; set; }
		public decimal Total { get; set; }
		public string Status { get; set; }
	}

    public class UnitMarks
    {
        public decimal Exam { get; set; }
        public decimal Cat { get; set; }
        public string Klasse { get; set; }
        public string ApprovalStatus { get; set; }
        public string CompleteStatus { get; set; }
        public string UnitCode { get; set; }
        public string Grade { get; set; }
    }

    public class ExamMarksGroup
    {
        public decimal TotalCatMark { get; set; }
        public decimal TotalExamMark { get; set; }
    }


    public class EndstandTranslated
    {
        //    "id": 7,
        [Description("This is the description of Space Key.")]
        public string AdmnNo { get; set; } /* "matrikelnummer": "BIS-1-0315-1/2017",*/
        public string Semester { get; set; } /*  "begriff": "TRIMESTER 1 2018",*/                   
        public string UnitCode { get; set; }/*"thema": "BSIS 211",*/                    
        public string Type { get; set; }/*   "art": "Regular",*/                    
        public string TotalMarks { get; set; }/*  "partitur": "69", */                    
        public string Grade { get; set; }/* "klasse": "B+",   */      
        public string ApprovalStatus { get; set; }/*"ebene": "Departmental Board", */    
        public DateTime? DateCreated { get; set; }/*  "datum": "2018-05-18T00:00:00",  */      
        public string ApprovalDate { get; set; }/*"zeit": "1900-01-01T12:22:30",  */  
        public string StudentNames { get; set; }/*"benutzer": "Catherine Mueni Nzioka",*/  					
        public string Ref { get; set; }/*"ref": "15256" */
    }

	public class MarksheetResults
	{
		public string AdmnNo { get; set; }
		public string Term { get; set; }
		public string Code { get; set; }
		public string Title { get; set; }
		public decimal? Exam { get; set; }
		public decimal? Cat { get; set; }
	}
}