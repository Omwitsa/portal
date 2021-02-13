using System;
using System.ComponentModel.DataAnnotations;

namespace Unisol.Web.Entities.Database.UnisolModels
{
	public class HrpStaffClearance
	{
		[Key]
		public string EmpNo { get; set; }
		public string Status { get; set; }
		public DateTime Rdate { get; set; } = DateTime.Today;
		public string Personnel { get; set; }
		public string Notes { get; set; }
	}
}
