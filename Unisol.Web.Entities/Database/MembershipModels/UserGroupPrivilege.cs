namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class UserGroupPrivilege
    {
        public int Id { get; set; }
        public string PrivilegeName { get; set; }
        public string Action { get; set; }
        public Role? Role { get; set; }
        public ActionLevel? Level { get; set; }
        public string Code { get; set; }
    }

    public enum ActionLevel
    {
        MenuAction = 1,
        OtherAction = 2
    }
}


