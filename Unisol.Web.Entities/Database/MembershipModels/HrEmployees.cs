using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class HrEmployees
    {
        public HrEmployees()
        {
            InverseSupervisor = new HashSet<HrEmployees>();
        }

        public int Id { get; set; }
        public string AcademicRank { get; set; }
		public string Idno { get; set; }
		public DateTime Adate { get; set; } 
        public int AddressId { get; set; }
        public int ApplicationUserId { get; set; }
        public int CountryId { get; set; }
        public string Disability { get; set; }
        public int DivisionId { get; set; }
        public DateTime Dob { get; set; }
        public string Educ { get; set; }
        public string EmgName { get; set; }
        public string EmgNotes { get; set; }
        public string EmgRel { get; set; }
        public string EmgTel { get; set; }
        public int EmpCatId { get; set; }
        public string EmplNo { get; set; }
        public string Exp { get; set; }
        public DateTime Hiredate { get; set; }
        public DateTime InsExp { get; set; }
        public bool IsSmoker { get; set; }
        public int JobCatId { get; set; }
        public string KraPin { get; set; }
        public string Lang { get; set; }
        public int LeaveGroupId { get; set; }
        public string LicClass { get; set; }
        public DateTime LicExp { get; set; }
        public string LicNo { get; set; }
        public int Marital { get; set; }
        public string Medical { get; set; }
        public string Nhif { get; set; }
        public string Notes { get; set; }
        public string Nssf { get; set; }
        public string PassportId { get; set; }
        public int? PersonnelId { get; set; }
        public string Ppn { get; set; }
        public DateTime Ppnexp { get; set; }
        public string Race { get; set; }
        public DateTime Rdate { get; set; }
        public string Religion { get; set; }
        public string Skills { get; set; }
        public string SpouseName { get; set; }
        public int? SupervisorId { get; set; }
        public bool Terminated { get; set; }
        public int TerminationId { get; set; }
        public string Title { get; set; }
        public string Visa { get; set; }
        public DateTime VisaExp { get; set; }

        public Addresses Address { get; set; }
        public User ApplicationUser { get; set; }
        public Countries Country { get; set; }
        public Divisions Division { get; set; }
        public EmployeeCategories EmpCat { get; set; }
        public JobCategories JobCat { get; set; }
        public LeaveGroups LeaveGroup { get; set; }
        public User Personnel { get; set; }
        public HrEmployees Supervisor { get; set; }
        public StaffTerminations StaffTerminations { get; set; }
        public ICollection<HrEmployees> InverseSupervisor { get; set; }
    }
}
