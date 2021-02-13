using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class BaseTable
    {
        public BaseTable()
        {
            Id = Guid.NewGuid();
            DateAdded = DateUpdated = DateTime.UtcNow;
        }
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
