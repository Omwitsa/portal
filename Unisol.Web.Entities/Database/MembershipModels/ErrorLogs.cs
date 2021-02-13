using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class ErrorLogs
    {
        public int Id { set; get; }
        public string ControllerUrl { set; get; }
        public string Error { set; get; }
        public string UserCode { set; get; }
        public DateTime DateCreated { set; get; } = DateTime.Now;
        public string PossibleReason { set; get; }
    }
}