using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class InaccessibiltyLog
	{
		public int Id { get; set; }
		public string Ip { get; set; }
		public string Institution { get; set; }
		public string MailReceiver { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
