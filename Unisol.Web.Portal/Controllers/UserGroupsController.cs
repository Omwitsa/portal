using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Common.ViewModels.Users;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class UserGroupsController : Controller
	{
		private readonly PortalCoreContext _context;
        private readonly TokenValidator _tokenValidator;
        public UserGroupsController(PortalCoreContext context)
		{
			_context = context;
            _tokenValidator = new TokenValidator(_context);
        }


		[HttpGet]
		[Route("deleteusergroup")]
		public JsonResult DeleteUserGroup(int id)
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
                var userGroup = _context.UserGroups.FirstOrDefault(u => u.Id == id);
				if (userGroup != null)
				{
					_context.UserGroups.Remove(userGroup);
					_context.SaveChanges();
					return Json(new ReturnData<string>
					{
						Success = true,
						Message = "User group deleted successfully"
					});
				}
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Could not delete user group"
				});

			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Server error occured " + ex.Message
				});
			}
		}
		[HttpGet]
		[Route("disableusergroup")]
		public JsonResult DisableUserGroup(int id)
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
                var userGroup = _context.UserGroups.FirstOrDefault(u => u.Id == id);
				if (userGroup == null)
				{
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Usergroup not found"
					});
				}

				if (userGroup.Role == Role.Admin)
				{
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Not allowed to disable the admin group"
					});
				}

				userGroup.Status = !userGroup.Status;
				_context.UserGroups.Update(userGroup);
				_context.SaveChanges();
				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "User group updated successfully"
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Server error occured " + ex.Message
				});
			}
		}


		[HttpGet]
		[Route("checkusergroup")]
		public JsonResult CheckUserGroup(string name)
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
                if (_context.UserGroups.Any(p => p.GroupName == name))
				{
					return Json(new ReturnData<string>
					{
						Success = true,
						Message = "user group name is in use"
					});
				}

				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "User group name available"
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Server error occured " + ex.Message
				});
			}
		}

		[HttpPost]
		[Route("add")]
		public JsonResult SaveUserGroup(UserGroupViewModel request)
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
                if (string.IsNullOrEmpty(request.GroupName))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "User group name can not be empty"
					});
                if (_context.UserGroups.Any(x=>x.Role == request.Role && x.IsDefault) && request.IsDefault)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "There is already another user group that is set as default."
                    });
                }

                if (_context.UserGroups.Any(u => u.GroupName == request.GroupName))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "User group name exists,please try another"
					});

				var otherPrivileges = _context.UserGroupPrivileges.Where(p => p.Level == ActionLevel.OtherAction)
					.ToList().Select(c => c.Code);

				var strOtherPrivileges = String.Join(",", otherPrivileges);
				var strPrivileges = request.Privileges +","+ strOtherPrivileges;

				var userGroup = new UserGroups
				{
					GroupName = request.GroupName,
					Role = request.Role,
					IsDefault = request.IsDefault,
					Status = request.Status,
					AllowedPrivileges = strPrivileges
				};

				if (request.Id.HasValue && request.Id.Value > 0)
				{
					userGroup.Id = request.Id.Value;
					_context.UserGroups.Update(userGroup);
				}
				else
				{
					_context.UserGroups.Add(userGroup);
				}

				_context.SaveChanges();

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Group added successfully"
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

		[HttpPost]
		[Route("editUserGroup")]
		public JsonResult EditUserGroup(UserGroupViewModel request, string groupName)
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
                var userGroup = _context.UserGroups.FirstOrDefault(g => g.GroupName == groupName);
				if (userGroup == null)
				{
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Could not find the usergroup"
					});
				}
				userGroup.GroupName = request.GroupName;
				userGroup.Role = request.Role;
				userGroup.IsDefault = request.IsDefault;
				userGroup.Status = request.Status;
				userGroup.AllowedPrivileges = request.Privileges;

				_context.Update(userGroup);
				_context.SaveChanges();

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Group updated successfully"
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

		[HttpGet("pages")]
		public JsonResult Pages(string searchText, int? offset = null, int? itemsPerPage = null, int? role = null)
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
                    Message = "Sorry, you are not authorized to access this page",
                });

            var response = new ReturnData<List<UserGroupsViewModelList>>();
			var query = new UserQuery
			{
				SearchText = searchText,
				EndDate = null,
				Skip = offset,
				StartDate = null,
				Take = itemsPerPage

			};
			if (role != null)
				query.Role = (Role)role;

			var queryResult = _context.UserGroups.AsQueryable().AsNoTracking().Where(WhereClause(query));
			var data = queryResult.Select(u => new UserGroupsViewModelList(u)).OrderBy(n => n.Id).ToList();
			response.TotalItems = data.Count;
			if (query.Skip.HasValue && query.Take.HasValue)
				data = data.Skip(query.Skip.Value).Take(query.Take.Value).ToList();
			response.Data = data;
			return Json(response);
		}

		[HttpGet("get/{id}")]
		public JsonResult Get(int id)
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
            var reply = new ReturnData<dynamic>();
			try
			{
				var userGroup = _context.UserGroups.FirstOrDefault(ug => ug.Id == id);
				if(userGroup == null)
				{
					reply.Success = false;
					reply.Message = "Your group not found";
				}
				var privileges = string.IsNullOrEmpty(userGroup.AllowedPrivileges) ? "" : userGroup.AllowedPrivileges;
				
				dynamic group = new
				{
					Id = userGroup.Id,
					GroupName = userGroup.GroupName,
					Role = userGroup.Role,
					IsDefault = userGroup.IsDefault,
					Status = userGroup.Status,
					AllowedPrivileges = privileges
				};
				reply.Data = group;
			}
			catch (Exception ex)
			{
				reply.Success = false;
				reply.Message = ex.Message;
			}

			return Json(reply);
		}

		public Expression<Func<UserGroups, bool>> WhereClause(UserQuery query)
		{
			var predicate = PredicateBuilder.True<UserGroups>();

			if (!string.IsNullOrEmpty(query.SearchText))
			{
				string searchParameter = query.SearchText.ToLower();
				var search = PredicateBuilder.False<UserGroups>();
				search = search.Or(p => p.GroupName.ToLower().Contains(searchParameter));
				predicate = predicate.And(search);
			}

			if (query.Role.HasValue)
			{
				predicate = predicate.And(p => p.Role == (Role)query.Role);
			}

			return predicate;
		}
	}
}