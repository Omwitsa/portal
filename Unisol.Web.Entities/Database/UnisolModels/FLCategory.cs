using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.UnisolModels
{
	public class FLCategory
	{
		public int ID { get; set; }
		public string Names { get; set; }
		public bool? BookingNotAllowed { get; set; }
		public bool? Closed { get; set; }
		public string Notes { get; set; }
	}
}
