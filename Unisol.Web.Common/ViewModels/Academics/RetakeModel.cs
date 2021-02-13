using System;
using System.Collections.Generic;
using System.Text;

namespace Unisol.Web.Common.ViewModels.Academics
{
	public class RetakeModel
	{
		public string Term { get; set; }
		public string Notes { get; set; }
		public string Username { get; set; }
		public List<string> Units { get; set; }
	}
}
