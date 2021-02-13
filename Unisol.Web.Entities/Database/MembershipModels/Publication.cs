using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class Publication
	{
		public int Id { get; set; }
		public string Year { get; set; }
		public string Author { get; set; }
		public string Title { get; set; }
		public string Type { get; set; }
		public string Url { get; set; }
		public string FileUrl { get; set; }
		public string FromPage { get; set; }
		public string ToPage { get; set; }
		public string Publisher { get; set; }
		public string PublicationPlace { get; set; }
		public string BookISBN { get; set; }
		public string JournalTitle { get; set; }
		public string BookTitle { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(3);
	}
}
