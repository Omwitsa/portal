using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.LibraryModels
{
	public class Biblio
	{
		[Key]
		public int BiblioNumber { get; set; }
		public string FrameworkCode { get; set; }
		public string Author { get; set; }
		public string Title { get; set; }
		public string UniTitle { get; set; }
		public string Notes { get; set; }
		public int? Serial { get; set; }
		public string SeriesTitle { get; set; }
		public int? CopyRightDate { get; set; }
		public DateTime Timestamp { get; set; }
		public DateTime DateCreated { get; set; }
		public string Abstract { get; set; }
	}
}
