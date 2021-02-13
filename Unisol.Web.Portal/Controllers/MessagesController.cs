using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Messages;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IRepository;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
    [Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : Controller
    {
		private readonly PortalCoreContext _context;
        private IPortalServices _portalServices;
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly TokenValidator _tokenValidator;
        public MessagesController(PortalCoreContext context, IPortalServices portalServices, IUnisolApiProxy unisolApiProxy)
		{
			_context = context;
			_portalServices = portalServices;
            _unisolApiProxy = unisolApiProxy;
            _tokenValidator = new TokenValidator(_context);
        }

		[HttpGet("getRecipients")]
		public JsonResult GetRecipients(string userName)
		{
			try
			{
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });
                }

                var results = _unisolApiProxy.GetReciepients(userName).Result;
                var recipientsResults = JsonConvert.DeserializeObject<ReturnData<List<RecipientViewModel>>>(results);
                var admin = _context.Users.Where(u => u.Role == Role.Admin).Select(u => new RecipientViewModel
                {
                    UserName = u.UserName,
                    RecipientName = u.UserName,
                }).ToList();
                var receipients = _context.Users.Join(recipientsResults.Data, u => u.UserName, r => r.UserName,
                    (u, r) => new RecipientViewModel
                    {
                        RecipientName = r.RecipientName,
                        UserName = r.UserName
                    }).Where(r => r.UserName != userName).ToList();
                receipients.AddRange(admin);

                if (!receipients.Any())
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "No recepient found"
					});
				return Json(new ReturnData<List<RecipientViewModel>>
				{
					Success = true,
					Data = receipients,
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Server Error, Please try latter",
					Error = new Error(ex)
				});
			}
		}

		[HttpPost]
		[Route("compose")]
		public JsonResult ComposeMessage(PortalMessage messages, string senter, string receiver)
		{
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });
            }
            if (string.IsNullOrEmpty(receiver))
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Please select message receipient"
				});

			if (string.IsNullOrEmpty(messages.Message))
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Please provide a message"
				});

			try
			{ 
				var msgSenter = _context.Users.FirstOrDefault(u => u.UserName == senter);
				var msgReceipient = _context.Users.FirstOrDefault(u => u.UserName == receiver);

				messages.ReceiverId = msgReceipient.Id;
				messages.SenderId = msgSenter.Id;
				messages.MessageStatus = MessageStatus.Sent;
				_context.PortalMessage.Add(messages);
				_context.SaveChanges();
				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Message sent successfully"
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "An error occurred,please retry : " + ex.Message,
					Error = new Error(ex)
				});
			}
		}

		[HttpGet("getMessages")]
		public JsonResult GetMessages(MessageStatus messageStatus, string userCode, int id)
		{
			try
			{
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });
                }
                var userDetails = _portalServices.GetUsers();
				if (!userDetails.Success)
					return Json(userDetails);

				var user = userDetails.Data.FirstOrDefault(u => u.UserName == userCode);
				if (user == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, user not found"
					});

				var messageDetails = _portalServices.GetMessages();
				if (!messageDetails.Success)
					return Json(messageDetails);

				var messages = messageDetails.Data.ToList();
				var usergroupResponse = _portalServices.GetUserGroups();
				if (!usergroupResponse.Success)
					return Json(usergroupResponse);

				var usergroup = usergroupResponse.Data.FirstOrDefault(g => g.Id == user.UserGroupsId);
				switch (messageStatus)
				{
					case MessageStatus.Sent:
						messages = messages.Where(m => (m.MessageStatus == MessageStatus.Read || m.MessageStatus == MessageStatus.Sent || m.MessageStatus == MessageStatus.Trash)
							&& m.SenderId == user.Id && !m.SenderTrash).ToList();
						break;
					case MessageStatus.Inbox:
						messageStatus = MessageStatus.Sent;
						messages = messages.Where(m => (m.MessageStatus == MessageStatus.Read || m.MessageStatus == MessageStatus.Sent || m.MessageStatus == MessageStatus.Trash)
							&& m.ReceiverId == user.Id  && !m.ReceiverTrash).ToList();
					break;
					case MessageStatus.Read:
						var readMessage = messages.FirstOrDefault(m => m.Id == id);
						if (readMessage != null)
						{
							readMessage.MessageStatus = MessageStatus.Read;
							_context.PortalMessage.Update(readMessage);
							_context.SaveChanges();
						}
						break;
					case MessageStatus.Trash:
                        var trashMessages = new List<PortalMessage>();
						messages = messages.Where(m => (m.MessageStatus == MessageStatus.Trash || m.MessageStatus == MessageStatus.Delete) && (m.SenderId == user.Id || m.ReceiverId == user.Id)).ToList();
                        foreach (var message in messages)
                        {
                            if (message.SenderId == user.Id && message.SenderTrash && !message.SenderDelete)
                                trashMessages.Add(message);

                            if (message.ReceiverId == user.Id && message.ReceiverTrash && !message.ReceiverDelete)
                                trashMessages.Add(message);
                        }
                        messages = trashMessages;
					break;
					default:
					break;
				}
			
				if (messages == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Currently, there is no message available"
					});

				var customizedMessages = new List<MessageViewModel>();
				foreach(var message in messages)
				{
					var sender = _context.Users.FirstOrDefault(u => u.Id == message.SenderId)?.UserName;
					var receiver = _context.Users.FirstOrDefault(u => u.Id == message.ReceiverId)?.UserName;

					customizedMessages.Add(
						new MessageViewModel()
						{
							Id = message.Id,
							From = sender,
							To = receiver,
							Subject = message.Subject,
							Date = message.DateSent,
							MessageStatus = message.MessageStatus,
							Message = message.Message
						}
					);
				}
				
				return Json(new ReturnData<List<MessageViewModel>>
				{
					Success = true,
					Data = customizedMessages,
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Server Error, Please try latter",
					Error = new Error(ex)
				});
			}
		}

		[HttpGet("permanentDelete")]
		public JsonResult PermanentDelete(string userCode, int id)
		{
			try
			{
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });
                }
                var deleteMessage = _context.PortalMessage.FirstOrDefault(m => m.Id == id);
				if (deleteMessage == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Message not deleted"
					});
				_context.Remove(deleteMessage);
				_context.SaveChanges();
				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Message deleted successfully"
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Server Error, Please try latter",
					Error = new Error(ex)
				});
			}
		}
        [HttpPost("trashMessage")]
        public JsonResult TrashMessage(TrashDeleteMessageModel model)
        {
            try
            {
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });
                }
                var message = _context.PortalMessage.FirstOrDefault(pm => pm.Id == model.MessageId);
                if (message == null)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Message not found"
                    });
                
                message.MessageStatus = MessageStatus.Trash;
                if(!message.ReceiverTrash)
                    message.ReceiverTrash = token.UserId == message.ReceiverId;
                if(!message.SenderTrash)
                    message.SenderTrash = token.UserId == message.SenderId;
                _context.SaveChanges();
                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Message moved to trash"
                });
            } 
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Server Error, Please try latter",
                    Error = new Error(ex)
                });
            }
        }
        [HttpPost("deleteMessage")]
        public JsonResult DeleteMessage(TrashDeleteMessageModel model)
        {
            try
            {
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });
                }
                var message = _context.PortalMessage.FirstOrDefault(pm => pm.Id == model.MessageId);
                if (message == null)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Message not found"
                    });
                message.MessageStatus = MessageStatus.Delete;
                if (!message.SenderDelete)
                    message.SenderDelete = token.UserId == message.SenderId;
                if (!message.ReceiverDelete)
                    message.ReceiverDelete = token.UserId == message.ReceiverId;
                _context.SaveChanges();
                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Message deleted"
                });
            } 
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Server Error, Please try latter",
                    Error = new Error(ex)
                });
            }
        }
	}
}