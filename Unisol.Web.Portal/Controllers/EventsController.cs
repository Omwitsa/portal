using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Events;
using Unisol.Web.Common.ViewModels.Login;
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
    public class EventsController : Controller
    {
		private readonly IUnisolApiProxy _unisolApiProxy;
		private readonly PortalCoreContext _context;
        private IPortalServices _portalServices;
        private readonly TokenValidator _tokenValidator;
		private EmailSender emailSender;

		public EventsController(PortalCoreContext context, IPortalServices portalServices, IConfiguration configuration, IEmailConfiguration emailConfiguration, 
			IHostingEnvironment env, IEmailService emailService, IUnisolApiProxy unisolApiProxy)
        {
            _context = context;
            _portalServices = portalServices;
            _tokenValidator = new TokenValidator(_context);
			_unisolApiProxy = unisolApiProxy;
			emailSender = new EmailSender(configuration, context, emailConfiguration, env, emailService);
		}

        [HttpPost]
        [Route("addEvents")]
        public JsonResult AddEvents(EventsViewModel eventsViewModel)
        {
			eventsViewModel.EventStartDate = eventsViewModel.EventStartDate.AddDays(1);
			eventsViewModel.EventEndDate = eventsViewModel.EventEndDate.AddDays(1);
			var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });

			if (token.Role == Role.Student || token.Role == Role.Applicant)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = "Sorry, you are not authorized to access this page",
                });

            var typeId = eventsViewModel.portalEventsTypeId ?? 0;
            eventsViewModel.DateCreated = DateTime.UtcNow;
            if (typeId == 0)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Please select event category"
                });

            try
            {
                var events = new PortalEvents
                {
                    EventTitle = eventsViewModel?.EventTitle ?? "",
                    EventDesc = eventsViewModel?.EventDesc ?? "",
                    CreatedBy = eventsViewModel.CreatedBy,
                    DateCreated = eventsViewModel.DateCreated,
                    EventStartDate = eventsViewModel.EventStartDate,
                    EventEndDate = eventsViewModel.EventEndDate,
                    SendEmailFlag = eventsViewModel.SendEmailFlag,
                    TargetAudience = eventsViewModel.TargetAudience,
                    PortalEventTypeId = eventsViewModel.portalEventsTypeId,
					EventVenue = eventsViewModel?.EventVenue ?? "",
                    TargetGroups = eventsViewModel?.TargetGroups ?? "",
					Campus = eventsViewModel?.Campus ?? "",
					Department = eventsViewModel?.Department ?? "",
					School = eventsViewModel?.School ?? "",
					YearOfStudy = eventsViewModel?.YearOfStudy ?? ""
				};

                if (eventsViewModel.Id.HasValue && eventsViewModel.Id.Value > 0)
                {
                    events.Id = events.Id;
                    _context.PortalEvents.Update(events);
                }
                else
                {
                    _context.PortalEvents.Add(events);
                }
				
				if (eventsViewModel.SendEmailFlag)
				{
					var users = _context.Users.Where(u => u.UserGroupsId == eventsViewModel.TargetAudience).ToList();
					foreach (var user in users)
					{
						var emailContent = new MailsViewModel
						{
							UserCode = user?.UserName ?? "",
							Firstname = "",
							Code = eventsViewModel?.EventDesc ?? "",
							Email = user.Email,
							MailMethod = MailSendMethod.EventPosting,
							PortalUrl = eventsViewModel?.PortalUrl ?? "",
							Subject = eventsViewModel?.EventTitle ?? ""
						};

						emailSender.SendEmail(emailContent);
					}
				}

				_context.SaveChanges();

                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Successful"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occurred,please retry : " + ex.Message
                });
            }
        }

        [HttpGet("geteventstypes")]
        public JsonResult GetEventsTypes()
        {
            try
            {
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });

                if (token.Role == Role.Student || token.Role == Role.Applicant)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to view this page",
                    });

                var portalEventsTypes = _context.PortalEventTypes.ToList();

                return Json(new ReturnData<List<PortalEventTypes>>
                {
                    Success = true,
                    Data = portalEventsTypes,
                    Message = "Successful"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<List<PortalNewsType>>
                {
                    Success = false,
                    Message = "Server Error, Please try latter",
                    Error = new Error(ex)
                });
            }
        }

		[HttpGet("getStudAcademicInfo")]
		public JsonResult GetStudAcademicInfo()
		{
			try
			{
				var result = _unisolApiProxy.GetStudAcademicInfo().Result;
				var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
				return Json(response);
			}
			catch(Exception e)
			{
				return Json(new ReturnData<string> {
					Success = false,
					Message = "An error occurred"
				});
			}
		}

		[HttpPost]
        [Route("addeventstypes")]
        public JsonResult AddEventsTypes(PortalEventTypes portalEventTypes)
        {
            try
            {
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });

                if (token.Role != Role.Admin)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to perform this action",
                    });

                if (!string.IsNullOrEmpty(portalEventTypes.EventTypeName))
                {
                    var eventsType = new PortalEventTypes
                    {
                        EventTypeName = portalEventTypes.EventTypeName
                    };

                    _context.PortalEventTypes.Add(eventsType);
                    _context.SaveChanges();

                    return Json(new ReturnData<string>
                    {
                        Success = true,
                        Message = "Event type added successfully"
                    });
                }

                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Event type name can not be empty"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occurred,please retry : " + ex.Message
                });
            }
        }

        [HttpGet("getEventTypeDetails")]
        public JsonResult GetEventTypeDetails(int id)
        {
            try
            {
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });

                if (token.Role != Role.Admin)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to access this page",
                    });

                var eventType = _context.PortalEventTypes.FirstOrDefault(t => t.Id == id);
                if (eventType == null)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Item not found"
                    });

                return Json(new ReturnData<PortalEventTypes>
                {
                    Success = true,
                    Data = eventType,
                    Message = "Successful"
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

        [Route("editEventsType")]
        public JsonResult EditEventsType(PortalEventTypes portalEventTypes)
        {
            try
            {
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });

                if (token.Role != Role.Admin)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to access this page",
                    });

                var eventTypes = _context.PortalEventTypes.FirstOrDefault(t => t.Id == portalEventTypes.Id);
                if (eventTypes == null)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Could not find event type"
                    });

                eventTypes.EventTypeName = portalEventTypes.EventTypeName;

                _context.Update(eventTypes);
                _context.SaveChanges();

                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Event updated successfully"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Server Error, Please try again",
                    Error = new Error(ex)
                });
            }
        }

        [HttpPost]
        [Route("editEvents")]
        public JsonResult EditEvents(EventsViewModel eventsViewModel)
        {
			eventsViewModel.EventStartDate = eventsViewModel.EventStartDate.AddDays(1);
			eventsViewModel.EventEndDate = eventsViewModel.EventEndDate.AddDays(1);
			try
            {
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });

                if (token.Role != Role.Admin)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to perform this action",
                    });

                var events = _context.PortalEvents.FirstOrDefault(p => p.Id == eventsViewModel.Id);
                if (events == null)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Could not find the Events"
                    });

                events.EventTitle = eventsViewModel.EventTitle;
				events.EventVenue = eventsViewModel.EventVenue;
				events.EventDesc = eventsViewModel.EventDesc;
                events.CreatedBy = eventsViewModel.CreatedBy;
                events.DateCreated = eventsViewModel.DateCreated;
                events.EventStartDate = eventsViewModel.EventStartDate;
                events.EventEndDate = eventsViewModel.EventEndDate;
                events.SendEmailFlag = eventsViewModel.SendEmailFlag;
                events.TargetGroups = eventsViewModel.TargetGroups;
                events.PortalEventTypeId = eventsViewModel.portalEventsTypeId;

                _context.Update(events);
                _context.SaveChanges();

                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Successful"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occurred,please retry : " + ex.Message
                });
            }
        }

        [HttpGet("deleteEvents")]
        public JsonResult DeleteEvents(int id)
        {
            try
            {
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });

                if (token.Role != Role.Admin)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to access this page",
                    });

                var events = _context.PortalEvents.FirstOrDefault(e => e.Id == id);

                if (events != null)
                {
                    _context.PortalEvents.Remove(events);
                    _context.SaveChanges();
                    return Json(new ReturnData<string>
                    {
                        Success = true,
                        Message = "Events deleted successfully"
                    });
                }
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Could not delete the Event"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<List<PortalNewsType>>
                {
                    Success = false,
                    Message = "Server Error, Please try latter",
                    Error = new Error(ex)
                });
            }
        }

        [HttpGet("deleteEventsType")]
        public JsonResult DeleteEventsType(int id)
        {
            try
            {
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });

                if (token.Role != Role.Admin)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to access this page",
                    });

                var eventTypes = _context.PortalEventTypes.FirstOrDefault(t => t.Id == id);

                if (eventTypes == null)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Could not delete the event type"
                    });

                _context.PortalEventTypes.Remove(eventTypes);
                _context.SaveChanges();
                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Event type deleted successfully"
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

        [HttpGet("getevents")]
        public JsonResult Getevents(string searchText, string tokenString, string userCode, int? offset = null, int? itemsPerPage = null, int? eventsType = null)
        {
            var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});
			var events = _portalServices.GetEvents(searchText, tokenString, userCode, offset, itemsPerPage, eventsType);
			
			return Json(events);
        }

        [HttpGet("geteventdetails")]
        public JsonResult GetEventDetails(int id)
        {
            try
            {
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });

				var targetGroup = token?.UserGroupId.ToString() ?? "";

				var portalEvent = _context.PortalEvents.Include(e => e.PortalEventType).FirstOrDefault(e => e.Id == id && (e.TargetGroups == targetGroup || token.Role == Role.Admin));
                if (portalEvent != null)
                    return Json(new ReturnData<PortalEvents>
                    {
                        Success = true,
                        Data = portalEvent,
                        Message = "Event found"
                    });

                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Event not found"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<PortalEvents>
                {
                    Success = false,
                    Message = "Server Error, Please try latter",
                    Error = new Error(ex)
                });
            }
        }
    }
}