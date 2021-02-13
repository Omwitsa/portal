using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.Middleware;
using UrlEncoder = System.Text.Encodings.Web.UrlEncoder;

namespace Unisol.Web.Portal.MiddleWare.Authentication
{
	public class CustomAuthHandler : AuthenticationHandler<CustomAuthOptions>
	{
		private readonly PortalCoreContext _context;
		public CustomAuthHandler(PortalCoreContext context, IOptionsMonitor<CustomAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
			: base(options, logger, encoder, clock)
		{
			_context = context;
		}

		protected override Task<AuthenticateResult> HandleAuthenticateAsync()
		{
			var hasAuthToken = Request.Headers.TryGetValue(HeaderNames.Authorization, out var authorization);
			if (hasAuthToken)
			{
				var validUser = IsValidAuthToken(authorization);
				if (!validUser.Valid)
				{
					dynamic error = new
					{
						Message = "Invalid auth key.",
						Code = StatusCodes.Status401Unauthorized
					};
					var res = new ReturnData<dynamic>()
					{
						Success = false,
						Data = error
					};
					throw new Exception(JsonConvert.SerializeObject(res));
				}

				if (validUser.role != Role.Admin)
				{
					if (string.IsNullOrEmpty(validUser.AllowedPrivileges))
					{
						dynamic error = new
						{
							Message = "The group has not yet been assigned privileges, please contact admin",
							Code = StatusCodes.Status401Unauthorized
						};
						var res = new ReturnData<dynamic>()
						{
							Success = false,
							Data = error

						};

						var exeption = new Exception(JsonConvert.SerializeObject(res));
						throw exeption;
					}

					string userRoute = Request.Path;
					if (userRoute.ToLower().Contains("api"))
					{
						var route = userRoute.Substring(1) != null ? userRoute.Substring(1) : "";
						var rolesSplit = userRoute.Split('/');
						if (userRoute.Contains('/') && userRoute.Split('/').Length > 2) route = rolesSplit[2] + '/' + rolesSplit[3];
						//route = route.Remove(route.Length - 1);
						var action = _context.UserGroupPrivileges.FirstOrDefault(m => m.Action.ToLower() == route.ToLower());
						if (action == null)
						{
							dynamic error = new
							{
								Message = "Rights not found, please contact admin",
								Code = StatusCodes.Status401Unauthorized
							};
							var res = new ReturnData<dynamic>()
							{
								Success = false,
								Data = error
							};
							throw new Exception(JsonConvert.SerializeObject(res));
						}

						var allowedPrivilegesCode = validUser.AllowedPrivileges.Split(",");
						if (!allowedPrivilegesCode.Contains("016")) validUser.AllowedPrivileges += ",016";
						allowedPrivilegesCode = validUser.AllowedPrivileges.Split(",");

						var isAllowed = allowedPrivilegesCode.Contains(action.Code);

						if (!isAllowed)
						{
							dynamic error = new
							{
								Message = "Forbidden request",
								Code = StatusCodes.Status401Unauthorized
							};
							var res = new ReturnData<dynamic>()
							{
								Success = false,
								Data = error
							};
							throw new Exception(JsonConvert.SerializeObject(res));

							//var error = new Exception("The group has not yet been assigned privileges, please contact admin");
							//throw error;
						}
					}
				}
			}

			var identities = new List<ClaimsIdentity> { new ClaimsIdentity("custom auth type") };
			var ticket = new AuthenticationTicket(new ClaimsPrincipal(identities), Options.Scheme);
			var authedicationResults = Task.FromResult(AuthenticateResult.Success(ticket));
			return authedicationResults;
		}

		private ValidUserDto IsValidAuthToken(string auth)
		{
			var token = _context.UserTokens.FirstOrDefault(m => m.Value == auth.Replace("Bearer ", ""));
			var response = new ValidUserDto { Valid = false };
			if (token != null)
			{
				var user = _context.Users.FirstOrDefault(m => m.Id == token.UserId);
				var userGroup = _context.UserGroups.FirstOrDefault(i => i.Id == user.UserGroupsId);
				response = new ValidUserDto
				{
					Valid = true,
					UserId = token.UserId,
					AllowedPrivileges = userGroup.AllowedPrivileges,
					role = userGroup.Role
				};
			}
			return response;
		}
	}
	public class ValidUserDto
	{
		public bool Valid { get; set; }
		public Guid UserId { get; set; }
		public string AllowedPrivileges { get; set; }
		public Role role { get; set; }
	}
}