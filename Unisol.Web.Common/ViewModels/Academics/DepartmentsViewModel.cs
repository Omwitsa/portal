using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Academics
{
	public class DepartmentsViewModel
	{
		public int DepartmentId { get; set; }
		public string Name { get; set; }
		public List<ProgrammesViewModel> Programmes { get; set; }
	}
}
