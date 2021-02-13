using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class UsergroupsUser
    {
        public long Id { get; set; }
        public long? GroupId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Home { get; set; }
        public byte Status { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ActivationCode { get; set; }
        public DateTime? ActivationTime { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? Ban { get; set; }
        public string BanReason { get; set; }
        public string Names { get; set; }

        public UsergroupsGroup Group { get; set; }
    }
}
