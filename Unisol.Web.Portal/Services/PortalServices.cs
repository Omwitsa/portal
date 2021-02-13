using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Constants;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Common.ViewModels.Users;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IRepository;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Repository
{
    public class PortalServices : IPortalServices
    {
		private readonly IUnisolApiProxy _unisolApiProxy;
		private PortalCoreContext _context;
        private Filters filters;

        public PortalServices(PortalCoreContext context, IUnisolApiProxy unisolApiProxy)
        {
			_unisolApiProxy = unisolApiProxy;
			_context = context;
            filters = new Filters();
        }

        public ReturnData<List<User>> GetUsers()
        {
            try
            {
				// Expression<Func<T, bool>> predicate
				var portalUsers = _context.Users.ToList();
                if (portalUsers.Count < 1)
                    return new ReturnData<List<User>>
                    {
                        Success = false,
                        Message = "Sorry, No registered user found"
                    };
                return new ReturnData<List<User>>
                {
                    Success = true,
                    Data = portalUsers
                };
            }
            catch (Exception ex)
            {
                return new ReturnData<List<User>>
                {
                    Success = false,
                    Message = "Sorry, Server error"
                };
            }
        }

        public ReturnData<List<UserViewModelList>> FilterUsers(string searchText, int? offset = null, int? itemsPerPage = null, int? role = null, bool unconfirmed = false)
        {
            try
            {
                var response = new ReturnData<List<UserViewModelList>>();
                var query = new UserQuery
                {
                    SearchText = searchText,
                    EndDate = null,
                    Skip = offset,
                    StartDate = null,
                    Take = itemsPerPage,
                };
				
				var data = _context
                    .Users
                     .Include(uG => uG.UserGroup)
                    .AsQueryable()
                    .AsNoTracking()
                    .Where(filters.FilterUsers(query))
                    .Select(u => new UserViewModelList(u)).OrderByDescending(n => n.DateCreated).ToList();

				if (unconfirmed)
				{
					data = _context
				   .Users.Where(u => !u.EmailConfirmed)
					.Include(uG => uG.UserGroup)
				   .AsQueryable()
				   .AsNoTracking()
				   .Where(filters.FilterUsers(query))
				   .Select(u => new UserViewModelList(u)).OrderByDescending(n => n.DateCreated).ToList();
				}

                var total = data.Count;

                if (query.Skip.HasValue)
                    data = data.Skip(query.Skip.Value).ToList();

                if (query.Take.HasValue)
                    data = data.Take(query.Take.Value).ToList();

                //                if (query.Skip.HasValue && query.Take.HasValue)
                //                    data = data.Skip(query.Skip.Value).Take(query.Take.Value).ToList();

                response.TotalItems = total;
                response.Data = data;

                return response;
            }
            catch (Exception ex)
            {
                return new ReturnData<List<UserViewModelList>>
                {
                    Success = false,
                    Message = "Sorry, Server error"
                };
            }
        }

        public ReturnData<List<PortalMessage>> GetMessages()
        {
            try
            {
                var messages = _context.PortalMessage.ToList();
                if (messages.Count < 1)
                    return new ReturnData<List<PortalMessage>>
                    {
                        Success = false,
                        Message = "Sorry, No message found"
                    };
                return new ReturnData<List<PortalMessage>>
                {
                    Success = true,
                    Data = messages
                };
            }
            catch (Exception ex)
            {
                return new ReturnData<List<PortalMessage>>
                {
                    Success = false,
                    Message = "Sorry, Server error"
                };
            }
        }

        public ReturnData<List<UserGroups>> GetUserGroups()
        {
            try
            {
                var userGroups = _context.UserGroups.ToList();
                if (userGroups.Count < 1)
                    return new ReturnData<List<UserGroups>>
                    {
                        Success = false,
                        Message = "Sorry, No usergroup found"
                    };
                return new ReturnData<List<UserGroups>>
                {
                    Success = true,
                    Data = userGroups
                };
            }
            catch (Exception ex)
            {
                return new ReturnData<List<UserGroups>>
                {
                    Success = false,
                    Message = "Sorry, Server error"
                };
            }
        }

        public ReturnData<List<PortalNews>> GetNews(string searchText, string userCode, int offset = 0)
        {
            try
            {

                var user = _context.Users.FirstOrDefault(u => u.UserName == userCode);
                if (user == null)
                    return new ReturnData<List<PortalNews>>
                    {
                        Success = false,
                        Message = "Something went wrong. Please try again later"
                    };

                var userGroup = _context.UserGroups.FirstOrDefault(g => g.Id == user.UserGroupsId);
                searchText = string.IsNullOrEmpty(searchText) ? "" : searchText;
                var userGroupId = userGroup.Id.ToString();
                var portalNews = _context.PortalNews
					.Where(n => (n.NewsStatus || n.CreatorId == user.Id || user.Role == Role.Admin)
					&& (n.NewsBody.CaseInsensitiveContains(searchText) || n.NewsTitle.CaseInsensitiveContains(searchText))
					&& ((n.TargetGroups != null && n.TargetGroups.Contains(userGroupId)) || n.CreatorId == user.Id || user.Role == Role.Admin)
					&& n.ExpiryDate > DateTime.Now
					)
					.Skip(offset * UnisolPortalContants.ItemsPerPage)
					.Take(UnisolPortalContants.ItemsPerPage)
					.Include(n => n.PortalNewsType).OrderByDescending(n => n.Id).ToList();
				var totalItems = portalNews.Count;

                return new ReturnData<List<PortalNews>>
                {
                    Data = portalNews,
                    TotalItems = totalItems,
                    Success = totalItems > 0,
                    Message = totalItems > 0 ? "" : "No news found"
                };
            }
            catch (Exception ex)
            {
                return new ReturnData<List<PortalNews>>
                {
                    Success = false,
                    Message = "An error occurred,please retry : " + ex.Message
                };
            }
        }

        public ReturnData<List<PortalEvents>> GetEvents(string searchText, string tokenString, string userCode, int? offset = null, int? itemsPerPage = null, int? eventsType = null)
        {
            try
            {
				var portalUser = _context.Users.FirstOrDefault(u => u.UserName.ToUpper().Equals(userCode.ToUpper()));
				if (portalUser == null)
                    return new ReturnData<List<PortalEvents>>
                    {
                        Success = false,
                        Message = "Server Error, Please try latter",
                    };

                var userGroup = _context.UserGroups.FirstOrDefault(g => g.Id == portalUser.UserGroupsId);
                var response = new ReturnData<List<PortalEvents>>();
                int? userGroupId = null;
                if (!string.IsNullOrEmpty(tokenString))
                {
                    var token = _context.UserTokens.FirstOrDefault(k => k.Value == tokenString);
                    if (token != null)
                    {
                        var user = _context.Users.FirstOrDefault(l => l.Id == token.UserId);
                        if (user != null)
                            userGroupId = user.UserGroupsId;
                    }
                }

                var query = new EventsQuery
                {
                    SearchText = searchText,
                    EndDate = null,
                    Skip = offset,
                    StartDate = null,
                    Take = itemsPerPage,
                    UserGroup = userGroup.Id,
                    PortalEventTypeId = eventsType
                };

				IQueryable<PortalEvents> queryResult = _context.PortalEvents.OrderByDescending(e => e.Id).Where(e => e.EventEndDate > DateTime.Now).AsQueryable().AsNoTracking();

				if (userGroup.Role == Role.Admin)
                {
                    query.UserGroup = null;
                    queryResult = queryResult.Where(filters.FilterEvents(query));
                }
                else
                {
                    var uId = userGroup.Id.ToString();
                    queryResult = queryResult.Where(e => e.CreatedBy == userCode || (e.TargetGroups.Contains(uId) && e.TargetGroups != null)).Where(filters.FilterEvents(query));
                }

                var data = queryResult
                    .Include(n => n.PortalEventType)
                    .OrderBy(n => n.Id).ToList();

                if (query.Skip.HasValue)
                    data = data.Skip(query.Skip.Value).ToList();

                if (query.Take.HasValue)
                    data = data.Take(query.Take.Value).ToList();

                if (query.Skip.HasValue && query.Take.HasValue)
                    data = data.Skip(query.Skip.Value).Take(query.Take.Value).ToList();


				if (portalUser.Role == Role.Student)
				{
					var classStatus = _context.Settings.FirstOrDefault()?.ClassStatus ?? "Active";
					var result = _unisolApiProxy.GetStudentDetails(userCode, classStatus).Result;
					var jData = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
					string department = jData.Data.studentDeparment.department ?? "";
					string school = jData.Data.studentDeparment.school ?? "";
					string campus = jData.Data.studentClass.campus ?? "";
					string yearOfStudy = jData.Data.studentClass.yearOfStudy ?? "";

					data = data.Where(e => (string.IsNullOrEmpty(e.Department) || e.Department.ToUpper().Contains(department.ToUpper()))
					&& (string.IsNullOrEmpty(e.School) || e.School.ToUpper().Contains(school.ToUpper())) 
					&& (string.IsNullOrEmpty(e.Campus) || e.Campus.ToUpper().Contains(campus.ToUpper()))
					&& (string.IsNullOrEmpty(e.YearOfStudy) || e.YearOfStudy.ToUpper().Contains(yearOfStudy.ToUpper()))).ToList();
				}

				response.Success = data.Count() > 0;
                response.TotalItems = data.Count();
                response.Data = data;

                return response;
            }
            catch (Exception ex)
            {
                return new ReturnData<List<PortalEvents>>
                {
                    Success = false,
                    Message = "Server Error, Please try latter",
                };
            }
        }

        public ReturnData<List<UserGroupPrivilege>> FilterPrivileges(string searchText, Role role, ActionLevel level, int? offset = null, int? itemsPerPage = null)
        {
            try
            {
                var response = new ReturnData<List<UserGroupPrivilege>>();
                var query = new UserQuery
                {
                    SearchText = searchText,
                    EndDate = null,
                    Skip = offset,
                    StartDate = null,
                    Take = itemsPerPage
                };

                var queryResult = _context.UserGroupPrivileges.Where(p => (p.Role == role || p.Role == Role.All) && p.Level == level).AsQueryable().AsNoTracking().Where(filters.FilterPrivileges(query));
                var data = queryResult.OrderBy(n => n.Code).ToList();

                if (query.Skip.HasValue)
                    data = data.Skip(query.Skip.Value).ToList();

                if (query.Take.HasValue)
                    data = data.Take(query.Take.Value).ToList();

                if (query.Skip.HasValue && query.Take.HasValue)
                    data = data.Skip(query.Skip.Value).Take(query.Take.Value).ToList();

                response.TotalItems = data.Count();
                response.Data = data;

                return (response);
            }
            catch (Exception ex)
            {
                return new ReturnData<List<UserGroupPrivilege>>
                {
                    Success = false,
                    Message = "Sorry, Server error"
                };
            }
        }

        public ReturnData<List<PortalConfig>> GetConfigurations()
        {
            try
            {
                var configurations = _context.PortalConfigs.ToList();
                if (configurations.Count < 1)
                    return new ReturnData<List<PortalConfig>>
                    {
                        Success = false,
                        Message = "Online services have been temporarily disabled, please contact admin for assistance"
                    };
                return new ReturnData<List<PortalConfig>>
                {
                    Success = true,
                    Data = configurations
                };
            }
            catch (Exception ex)
            {
                return new ReturnData<List<PortalConfig>>
                {
                    Success = false,
                    Message = "Sorry, Server error"
                };
            }
        }

        public ReturnData<List<EvaluationsCurrent>> GetCurrentEvaluations(string searchText, int? offset = null, int? itemsPerPage = null)
        {
            try
            {
                var response = new ReturnData<List<EvaluationsCurrent>>();
                var query = new Query()
                {
                    SearchText = searchText,
                    EndDate = null,
                    Skip = offset,
                    StartDate = null,
                    Take = itemsPerPage,
                };

                var data = _context
                    .EvaluationsCurrents.AsQueryable().AsNoTracking()
                    .Where(filters.FilterCurrentEvaluations(query))
                    .Include(n => n.EvaluationsCurrentActive)
                    .ThenInclude(se => se.EvaluationTargetGroups)
                    .OrderBy(n => n.Id)
                    .ToList();

                response.TotalItems = _context.EvaluationsCurrents.Count();
                if (response.TotalItems > 0)
                {
                    data.ForEach(cE =>
                    {
                        cE.EvaluationsCurrentActive.ToList().ForEach(ea =>
                        {
                            ea.Status = ea.Status
                                ? DateTime.Now.Date <= ea.EndDate.Date && DateTime.Now.Date >= ea.StartDate.Date
                                : ea.Status;
                        });
                    });
                }

                if (query.Skip.HasValue && query.Take.HasValue)
                    data = data.Skip(query.Skip.Value).Take(query.Take.Value).ToList();
                response.Data = data;

                return response;
            }
            catch (Exception ex)
            {
                return new ReturnData<List<EvaluationsCurrent>>
                {
                    Success = false,
                    Message = "Sorry, No evaluation found"
                };
            }
        }

        public ReturnData<User> GetUserByCode(string userCose)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.UserName == userCose);
                return new ReturnData<User>
                {
                    Success = true,
                    Data = user
                };
            }
            catch (Exception ex)
            {
                return new ReturnData<User>
                {
                    Success = false,
                    Message = "Sorry, we could not find your details"
                };
            }
        }
    }
}
