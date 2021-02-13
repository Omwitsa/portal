using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Common.ViewModels.Login;
using Unisol.Web.Common.ViewModels.Messages;
using Unisol.Web.Common.ViewModels.News;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IRepository;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly PortalCoreContext _context;
        private IPortalServices _portalServices;
        private readonly TokenValidator _tokenValidator;
		private EmailSender emailSender;
		public NewsController(PortalCoreContext context, IPortalServices portalServices, IConfiguration configuration, IEmailConfiguration emailConfiguration, 
			IHostingEnvironment env, IEmailService emailService)
        {
            _context = context;
            _portalServices = portalServices;
            _tokenValidator = new TokenValidator(_context);
			emailSender = new EmailSender(configuration, context, emailConfiguration, env, emailService);
		}

        [HttpPost]
        [Route("addnews")]
        public JsonResult AddNews(NewsViewModel newsViewModel, string userCode)
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

                if (token.Role == Role.Student)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to perform this action",
                    });

                newsViewModel.DateCreated = DateTime.UtcNow;
                var portalNewsTypes = _context.PortalNewsTypes.Any();
                var message = portalNewsTypes ? "Please select news category" : "Please create news category";
                if (newsViewModel.PortalNewsTypeId == 0)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = message
                    });

                if (string.IsNullOrEmpty(newsViewModel.NewsBody))
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Message can not be empty"
                    });

                var creator = _context.Users.FirstOrDefault(u => u.UserName == userCode);
                var news = new PortalNews
                {
                    NewsBody = newsViewModel.NewsBody,
                    DateCreated = newsViewModel.DateCreated,
                    ExpiryDate = newsViewModel.ExpiryDate,
                    NewsStatus = newsViewModel.NewsStatus,
                    NewsTitle = newsViewModel.NewsTitle,
                    PortalNewsTypeId = newsViewModel.PortalNewsTypeId,
                    SendEmailFlag = newsViewModel.SendEmailFlag,
                    TargetAudience = newsViewModel.TargetAudience,
                    CreatorId = creator.Id,
                    TargetGroups = newsViewModel.TargetGroups
                };

                if (newsViewModel.Id.HasValue && newsViewModel.Id.Value > 0)
                {
                    _context.PortalNews.Update(news);
                }
                else
                {
                    _context.PortalNews.Add(news);
                }

				if (newsViewModel.SendEmailFlag)
				{
					//int[] groupIds = newsViewModel.TargetAudience.Split(',').Select(s => int.TryParse(s, out int n) ? n : 0).ToArray();
					var users = _context.Users.Where(u => u.UserGroupsId == newsViewModel.TargetAudience).ToList();
					foreach(var user in users)
					{
						var emailContent = new MailsViewModel
						{
							UserCode = user.UserName,
							Firstname = "",
							Code = newsViewModel.NewsBody,
							Email = user.Email,
							MailMethod = MailSendMethod.NewsPosting,
							PortalUrl = newsViewModel.portalUrl,
							Subject = newsViewModel.NewsTitle
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

        [HttpPost]
        [Route("editnews")]
        public JsonResult Editnews(NewsViewModel newsViewModel)
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
                if (token.Role == Role.Student || token.Role == Role.Applicant)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to perform this action",
                    });
                }
                var news = _context.PortalNews.FirstOrDefault(p => p.Id == newsViewModel.Id);
                if (news == null)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Could not find the news"
                    });
                }
                news.NewsBody = newsViewModel.NewsBody;
                news.ExpiryDate = newsViewModel.ExpiryDate;
                news.NewsStatus = newsViewModel.NewsStatus;
                news.NewsTitle = newsViewModel.NewsTitle;
                news.PortalNewsTypeId = newsViewModel.PortalNewsTypeId;
                news.TargetAudience = newsViewModel.TargetAudience;
                news.TargetGroups = newsViewModel.TargetGroups;

                _context.Update(news);
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

        [HttpPost]
        [Route("addnewstypes")]
        public JsonResult AddNewsTypes(NewsTypeViewModel newsTypeViewModel)
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
                if (token.Role != Role.Admin)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to perform this action",
                    });
                }
                if (!string.IsNullOrEmpty(newsTypeViewModel.NewsTypeName))
                {
                    var newsType = new PortalNewsType
                    {
                        NewsTypeName = newsTypeViewModel.NewsTypeName,
                        Status = newsTypeViewModel.Status
                    };

                    if (newsTypeViewModel.Id.HasValue && newsTypeViewModel.Id.Value > 0)
                    {
                        newsType.Id = newsType.Id;
                        _context.PortalNewsTypes.Update(newsType);
                    }
                    else
                    {
                        _context.PortalNewsTypes.Add(newsType);
                    }

                    _context.SaveChanges();

                    return Json(new ReturnData<string>
                    {
                        Success = true,
                        Message = "Successful"
                    });
                }

                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "News type name can not be empty"
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

        [Route("editNewsType")]
        public JsonResult EditNewsType(NewsTypeViewModel newsTypeViewModel)
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
                if (token.Role != Role.Admin)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to access this page",
                    });
                }
                var newType = _context.PortalNewsTypes.FirstOrDefault(t => t.Id == newsTypeViewModel.Id);
                if (newType == null)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Could not find news type"
                    });
                }

                newType.NewsTypeName = newsTypeViewModel.NewsTypeName;
                newType.Status = newsTypeViewModel.Status;

                _context.Update(newType);
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
                    Message = "Server Error, Please try again",
                    Error = new Error(ex)
                });
            }
		} 

		[HttpGet("publishNews")]
		public JsonResult PublishNews(int id)
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

				var news = _context.PortalNews.FirstOrDefault(t => t.Id == id);
				news.NewsStatus = true;
				_context.SaveChanges();

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Published Successfully",
				});
			}
			catch(Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Server Error, Please try latter",
					Error = new Error(ex)
				});
			}
		}

		[HttpGet("getNewTypeDetails")]
        public JsonResult GetNewTypeDetails(int id)
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

                var newsType = _context.PortalNewsTypes.FirstOrDefault(t => t.Id == id);
                return Json(new ReturnData<PortalNewsType>
                {
                    Success = true,
                    Data = newsType,
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

        [HttpGet("getnews")]
        public JsonResult GetNews(string searchText, string userCode, int offset = 0)
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
                return Json(_portalServices.GetNews(searchText, userCode, offset));
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

        [HttpGet("getnewsdetails")]
        public JsonResult GetNewsDetails(int id)
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
                var portalNews = _context.PortalNews.Include(n => n.PortalNewsType).FirstOrDefault(n => n.Id == id);
                return Json(new ReturnData<PortalNews>
                {
                    Success = true,
                    Data = portalNews,
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


        [HttpGet("getnewstypes")]
        public JsonResult GetNewsTypes(int? offSet, int? itemsPerPage, string searchText = null)
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
                if (token.Role == Role.Student)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to view this page",
                    });
                }
                var response = new ReturnData<List<PortalNewsType>>();
                var query = new Query
                {
                    SearchText = searchText,
                    EndDate = null,
                    Skip = offSet,
                    StartDate = null,
                    Take = itemsPerPage

                };

                var queryResult = _context.PortalNewsTypes.AsQueryable()
                    .AsNoTracking().Where(WhereClauseNewsType(query)).OrderBy(n => n.Id).ToList();
                response.TotalItems = queryResult.Count;
                if (query.Skip.HasValue && query.Take.HasValue)
                    queryResult = queryResult.Skip(query.Skip.Value).Take(query.Take.Value).ToList();
                response.Data = queryResult;
                response.Success = queryResult.Any();
                response.Message = queryResult.Any() ? "Found" : "Not Found";
                return Json(response);



                //                var portalNewsTypes = _context.PortalNewsTypes.Where(t => t.Status).ToList();
                //                return Json(new ReturnData<List<PortalNewsType>>
                //                {
                //                    Success = true,
                //                    Data = portalNewsTypes,
                //                    Message = "Successful"
                //                });
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

        [HttpGet("deleteNews")]
        public JsonResult DeleteNews(int id)
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

                var news = _context.PortalNews.FirstOrDefault(n => n.Id == id);
                if (news != null)
                {
                    _context.PortalNews.Remove(news);
                    _context.SaveChanges();
                    return Json(new ReturnData<string>
                    {
                        Success = true,
                        Message = "News deleted successfully"
                    });
                }
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Could not delete the News"
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

        [HttpGet("deleteNewsType")]
        public JsonResult DeleteNewsType(int id)
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
                if (token.Role != Role.Admin)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to access this page",
                    });
                }
                var newstype = _context.PortalNewsTypes.FirstOrDefault(t => t.Id == id);
                if (newstype != null)
                {
                    _context.PortalNewsTypes.Remove(newstype);
                    _context.SaveChanges();
                    return Json(new ReturnData<string>
                    {
                        Success = true,
                        Message = "News Type deleted successfully"
                    });
                }
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Could not delete the news type"
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

        [HttpGet("checknewstype")]
        public JsonResult CheckNewsType(string name)
        {
            try
            {
                return Json(new ReturnData<bool>
                {
                    Success = true,
                    Data = _context.PortalNewsTypes.Any(t => t.NewsTypeName == name),
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

        public Expression<Func<PortalNews, bool>> WhereClause(NewsQuery query)
        {
            var predicate = PredicateBuilder.True<PortalNews>();

            if (!string.IsNullOrEmpty(query.SearchText))
            {
                string searchParameter = query.SearchText.ToLower();
                var search = PredicateBuilder.False<PortalNews>();
                search = search.Or(p => p.NewsBody.ToLower().Contains(searchParameter));
                search = search.Or(p => p.NewsTitle.ToLower().Contains(searchParameter));
                search = search.Or(p => p.PortalNewsType.NewsTypeName.ToLower().Contains(searchParameter));
                predicate = predicate.And(search);
            }

            if (query.PortalNewsTypeId.HasValue)
            {
                predicate = predicate.And(p => p.PortalNewsType.Id == query.PortalNewsTypeId.Value);
            }

            if (query.UserGroup.HasValue)
            {
                predicate = predicate.And(p => p.TargetAudience == query.UserGroup.Value);
            }

            return predicate;
        }

        public Expression<Func<PortalNewsType, bool>> WhereClauseNewsType(Query query)
        {
            var predicate = PredicateBuilder.True<PortalNewsType>();

            if (!string.IsNullOrEmpty(query.SearchText))
            {
                string searchParameter = query.SearchText.ToLower();
                var search = PredicateBuilder.False<PortalNewsType>();
                search = search.Or(p => p.NewsTypeName.ToLower().Contains(searchParameter));
                predicate = predicate.And(search);
            }


            return predicate;
        }
    }
}