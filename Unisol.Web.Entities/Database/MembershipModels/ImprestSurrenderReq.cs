using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class ImprestSurrenderReq
    {
        public Guid Id { get; set; }
        public string ImpRef { get; set; }
        public string PayeeRef { get; set; }
        public string EmployeeName { get; set; }
        public DateTime SurReqDate { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime DateModified { get; set; }
        public string ClearedStatus => Status ? "Cleared" : "Pending";
    }
}
