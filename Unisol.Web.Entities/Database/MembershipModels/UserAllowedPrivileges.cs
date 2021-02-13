namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class UserGroups
    {
        public UserGroups()
        {
        }

        public int Id { get; set; }
        public string GroupName { get; set; }

        public Role Role { get; set; }
        public string AllowedPrivileges { get; set; }
        public bool IsDefault { get; set; }
        public bool Status { get; set; }
    }
    public enum Role
    {
        Admin = 1,
        Staff = 2,
        Student = 3,
        Applicant = 4,
        All = 9
    }
}