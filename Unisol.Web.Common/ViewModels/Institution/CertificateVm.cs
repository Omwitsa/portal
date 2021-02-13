using System;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Common.ViewModels.Institution
{
	public class CertificateVm
	{
		public string UserName { get; set; }
		public string NationalId { get; set; }
		public string OrgName { get; set; }
		public string Initials { get; set; }
		public DateTime? AdmissionDate { get; set; }
		public DateTime? FinalDate { get; set; }
		public string School { get; set; }
		public string Porgramme { get; set; }
		public string Names { get; set; }
		public string EmploymentCategory { get; set; }
		public string JobTitle { get; set; }
		public string Rank { get; set; }
		public string Department { get; set; }
		public string Location { get; set; }
    }
}
