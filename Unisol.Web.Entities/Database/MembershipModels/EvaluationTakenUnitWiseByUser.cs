using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class EvaluationTakenUnitWiseByUser
    {
        public int Id { get; set; }
        public string UnitCode { get; set; }
        public string TargetNames { get; set; }
        public Guid AspNetUserId { get; set; }
        public int EvaluationCurrentActiveId { get; set; }
        public int EvaluationCurrentId { get; set; }
        public DateTime DateCreated { get; set; }=DateTime.Now;
        public virtual Evaluation Evaluation { get; set; }
        public int? EvaluationId { get; set; }
		public string AcademicYear { get; set; }
		public string Semester { get; set; }
		public string Campus { get; set; }
		public string Department { get; set; }
		public string Programme { get; set; }
		public string LecturerName { get; set; }
		public string Schools { get; set; }
		public string Gender { get; set; }
		public string YearOfStudy { get; set; }
		public string CertType { get; set; }
    }
}
