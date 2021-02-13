using System;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class PortalMessage
    {
        public int Id { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime DateSent { get; set; } = DateTime.Now;
        public DateTime DateModified { get; set; } = DateTime.Now;
        public bool GroupMessage { get; set; }
        public string Message { get; set; }
        public MessageStatus MessageStatus { get; set; }
        public Guid ReceiverId { get; set; }
        public bool RoleId { get; set; }
        public Guid SenderId { get; set; }
        public string GroupName { get; set; }
        public string Subject { get; set; }
        public bool SenderTrash { get; set; }
        public bool ReceiverTrash { get; set; }
        public bool SenderDelete { get; set; }
        public bool ReceiverDelete{ get; set; }
    }

    public enum MessageStatus
    {
        Inbox = 1,
        Sent = 2,
        Read = 3,
        Trash = 4,
        Delete = 5
    }
}
