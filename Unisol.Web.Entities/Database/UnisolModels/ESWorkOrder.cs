using System;
using System.ComponentModel.DataAnnotations;

namespace Unisol.Web.Entities.Database.UnisolModels
{
	public class ESWorkOrder
	{
		[Key]
		public string Ref { get; set; }
		public string Subject { get; set; }
		public string Description { get; set; }
		public string Project { get; set; }
		public string Unit { get; set; }
		public string Location { get; set; }
		public string Requestor { get; set; }
		public string Category { get; set; }
		public string DownTime { get; set; }
		public string Assignee { get; set; }
		public DateTime? WDate { get; set; }
		public DateTime? EDate { get; set; }
		public string RequestRef { get; set; }
		public string Notes { get; set; }
		public string Status { get; set; }
		public DateTime? RDate { get; set; }
		public string Personnel { get; set; }
	}
}
