using System; 

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class UserResetPassword
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public bool Status { get; set; }
        public string ResetCode { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
	}
}
