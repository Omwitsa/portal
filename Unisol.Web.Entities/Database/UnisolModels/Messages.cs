using System;
using System.Collections.Generic;

namespace Unisol.Web.Entities.Database.UnisolModels
{
    public partial class Messages
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool? IsRead { get; set; }
        public string DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsDraft { get; set; }
        public bool? IsSpam { get; set; }
        public bool? IsImportant { get; set; }
    }
}
