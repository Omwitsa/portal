using System;
using System.ComponentModel.DataAnnotations;

namespace Unisol.Web.Entities.Database.UnisolModels
{
	public class ESWorkRequest
	{
		[Key]
		public string Ref { get; set; }
		public string EmpNo { get; set; }
		public string Subject { get; set; }
		public string Description { get; set; }
		public string Project { get; set; }
		public string Unit { get; set; }
		public string Location { get; set; }
		public DateTime? RDate { get; set; }
		public DateTime? RTime { get; set; }
		public string Personnel { get; set; }
		public string Status { get; set; }
		public string Reaction { get; set; }
	}
}
