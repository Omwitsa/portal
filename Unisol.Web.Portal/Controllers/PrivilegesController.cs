using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Users;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IRepository;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PrivilegesController : Controller
	{
		private readonly PortalCoreContext _context;
		private IPortalServices _portalServices;
        private readonly TokenValidator _tokenValidator;
        public PrivilegesController(PortalCoreContext context, IPortalServices portalServices)
		{
			_context = context;
			_portalServices = portalServices;
            _tokenValidator = new TokenValidator(_context);
        }

		[Route("add")]
		public JsonResult SaveUserGroupPrivilege(UserGroupPrivilegeViewModel request)
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
                if (!string.IsNullOrEmpty(request.PrivilegeName))
				{
					var userGroupPrivilege = new UserGroupPrivilege
					{
						PrivilegeName = request.PrivilegeName,
						Action = request.Action,
						Role = request.Role
					};
					var privilegeExists = _context.UserGroupPrivileges.Any(p => p.Action == request.Action);
					if (privilegeExists)
					{
						return Json(new ReturnData<string>
						{
							Success = false,
							Message = "Both privilege name and action must be unique"
						});
					}

					var message = "";
					if (request.Id.HasValue && request.Id.Value > 0)
					{
						userGroupPrivilege.Id = request.Id.Value;
						_context.UserGroupPrivileges.Update(userGroupPrivilege);
						message = "User group privilege updated successfully";
					}
					else
					{
						_context.UserGroupPrivileges.Add(userGroupPrivilege);
						message = "User group privilege saved successfully";
					}

					_context.SaveChanges();

					return Json(new ReturnData<string>
					{
						Success = true,
						Message = message
					});
				}

				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Privilege name can not be empty"
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

		[Route("editUserGroupPrivilege")]
		public JsonResult EditUserGroupPrivilege(UserGroupPrivilegeViewModel request)
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
                var privileges = _context.UserGroupPrivileges.FirstOrDefault(p => p.Id == request.Id);
				if (privileges == null)
				{
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Could not find the privilege"
					});
				}
				privileges.Action = request.Action;
				privileges.PrivilegeName = request.PrivilegeName;
				privileges.Role = request.Role;

				_context.Update(privileges);
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


		[HttpGet("pages")]
		public JsonResult Pages(string searchText, Role role, ActionLevel level, int? offset = null, int? itemsPerPage = null)
		{
			return Json(_portalServices.FilterPrivileges(searchText, role, level, offset, itemsPerPage));
		}

		[HttpGet("get/{id}")]
		public JsonResult Get(int id)
		{
			var reply = new ReturnData<UserGroupPrivilege>();
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
                var userGroup = _context.UserGroupPrivileges.FirstOrDefault(ug => ug.Id == id);
				if(userGroup == null)
				{
					reply.Success = false;
					reply.Message = "Usergroup not found";
					return Json(reply);
				}

				reply.Data = userGroup;
			}
			catch (Exception ex)
			{
				reply.Success = false;
				reply.Message = ex.Message;
			}

			return Json(reply);
		}

		[HttpGet("getGroupPrivileges")]
		public JsonResult GetGroupPrivileges(string usercode, ActionLevel level)
		{
			var reply = new ReturnData<List<UserGroupPrivilege>>();
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
                var user = _context.Users.FirstOrDefault(u => u.UserName == usercode);
				if (user == null)
				{
					{
						reply.Success = false;
						reply.Message = "User not found";
						return Json(reply);
					}
				}
				var userGroup = _context.UserGroups.FirstOrDefault(g => g.Id == user.UserGroupsId);
				if (userGroup == null)
				{
					{
						reply.Success = false;
						reply.Message = "Usergroup not found";
						return Json(reply);
					}
				}

				if (string.IsNullOrEmpty(userGroup.AllowedPrivileges))
				{
					{
						reply.Success = false;
						reply.Message = "Group Privileges Not set, Please contact admin";
						return Json(reply);
					}
				}

				var groupPrivileges = new List<UserGroupPrivilege>();
				var privilegeCodeArray = userGroup.AllowedPrivileges.Split(",");

				foreach (var code in privilegeCodeArray)
				{
					var privileges = _context.UserGroupPrivileges.FirstOrDefault(p => p.Code == code && p.Level == level);
					if (privileges != null)
					{
						groupPrivileges.Add(privileges);
					}
				}

				reply.Success = true;
				reply.Data = groupPrivileges;
			}
			catch (Exception ex)
			{
				reply.Success = false;
				reply.Message = ex.Message;
			}

			return Json(reply);
		}
	}
}