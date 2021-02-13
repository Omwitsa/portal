using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.UnisolModels
{
	public partial class ImprestMemo
	{
		[Key]
		public string Ref { get; set; }
		public string DeptFrom { get; set; }
		public string DeptTo { get; set; }
		public string Subject { get; set; }
		public string Description { get; set; }
		public string Personnel { get; set; }
		public DateTime? Rdate { get; set; } = DateTime.UtcNow;
		public string Status { get; set; }
		public DateTime? Sdate { get; set; }
		public DateTime? Edate { get; set; }
	}
}
