using System;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Common.ViewModels.Messages
{
    public class MessageViewModel
	{
		public int Id { get; set; }
		public string From { get; set; }
		public string To { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public DateTime Date { get; set; }
        public MessageStatus MessageStatus { get; set; }
    }

    public class TrashDeleteMessageModel
    {
        public int MessageId { get; set; }
        public bool SenderTrash { get; set; }
        public bool ReceiverTrash { get; set; }
        public bool SenderDelete { get; set; }
        public bool ReceiverDelete { get; set; }
    }
}
