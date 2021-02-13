using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
	public partial class HrpEmpAccNo
	{
		public int Id { get; set; }
		public string Ref { get; set; }
		public string AccNo { get; set; }
		public decimal? AccPercent { get; set; }
		public string Bank { get; set; }
	}
}
