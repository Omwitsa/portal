namespace Unisol.Web.Entities.Database.MembershipModels
{
	public class ClientIp
	{
		public int Id { get; set; }
		public string Ip { get; set; }
		public string Institution { get; set; }
		public int Fails { get; set; }
	}
}
