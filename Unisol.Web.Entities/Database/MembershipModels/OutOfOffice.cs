using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class OutOfOffice
	{
		public int Id { get; set; }
		public string EmpNo { get; set; }
		public string Supervisor { get; set; }
		public string Status { get; set; }
		public string Reason { get; set; }
		public DateTime? From { get; set; }
		public DateTime? To { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(3);
	}
}
