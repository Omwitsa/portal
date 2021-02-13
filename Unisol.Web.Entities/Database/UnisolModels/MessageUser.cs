using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class MessageUser
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public string UserId { get; set; }
    }
}
