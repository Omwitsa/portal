using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.UnisolModels
{
	public class ESProject
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public string Names { get; set; }
		public string Type { get; set; }
		public string Location { get; set; }
		public bool? Closed { get; set; }
		public string Notes { get; set; }
	}
}
