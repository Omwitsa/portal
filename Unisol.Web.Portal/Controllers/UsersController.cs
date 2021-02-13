using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Login;
using Unisol.Web.Common.ViewModels.Messages;
using Unisol.Web.Common.ViewModels.Users;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.OldMembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IRepository;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : Controller
	{
		private InputValidator _validateService;
		private readonly IUnisolApiProxy _unisolApiProxy;
		private IPortalServices _portalServices;
		private readonly IEmailService _emailService;
		private readonly PortalCoreContext _context;
		private readonly IEmailConfiguration _emailConfiguration;
		private IConfiguration _configuration { get; }
		private MailSendMethod mailMethod;
		private IHostingEnvironment _env;
		private UserCredentials _userCredentials;
		private IUserManagementService _userManagementService;
		private readonly OldMembershipContext _oldMembershipContext;
		private readonly TokenValidator _tokenValidator;
		private Logger logger = LogManager.GetLogger("fileLogger");
		private EmailSender emailSender;

		public UsersController(PortalCoreContext context, IUserManagementService userManagementService, IUnisolApiProxy unisolApiProxy, IEmailService emailService,
			IEmailConfiguration emailConfiguration, IConfiguration configuration, IHostingEnvironment env, IPortalServices portalServices,
			OldMembershipContext oldMembershipContext)
		{
			_validateService = new InputValidator();
			_unisolApiProxy = unisolApiProxy;
			_context = context;
			_oldMembershipContext = oldMembershipContext;
			_emailService = emailService;
			_emailConfiguration = emailConfiguration;
			_userManagementService = userManagementService;
			_configuration = configuration;
			_env = env;
			_portalServices = portalServices;
			_userCredentials = new UserCredentials(context);
			_tokenValidator = new TokenValidator(context);
			emailSender = new EmailSender(configuration, context, emailConfiguration, env, emailService);
		}

		[HttpPost("register")]
		public JsonResult Register(RegisterViewModel request, bool isAdmin = false)
		{
			request.Password = request.Password ?? "";
			if (!isAdmin)
			{
				var isValidPassword = ValidatePassword(request);
				if (!isValidPassword.Success)
					return Json(isValidPassword);
			}
			else
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
			}

			var registered = _userManagementService.Register(request, isAdmin);
			return Json(registered);
		}

		private ReturnData<string> ValidatePassword(RegisterViewModel request)
		{
			if (string.IsNullOrEmpty(request.Password))
				return new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, Password cannot be empty"
				};

			if (request.Password.Length < 6)
				return new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, Password length cannot be less than 6 characters"
				};

			if (!request.Password.Equals(request.PasswordConfirm))
				return new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, Password and confirm password do not match"
				};
			return new ReturnData<string>
			{
				Success = true,
			};
		}

		[HttpPost("reset")]
		public JsonResult ResetPassword(RegisterViewModel request)
		{
			request.Password = request.Password ?? "";
			var requiredFields = new List<Tuple<string, string, DataType>>
			{
				Tuple.Create("username", request.RegNumber, DataType.Default),
			};

			var validUserInputs = _validateService.Validate(requiredFields);
			if (!validUserInputs.Valid)
				return Json(new ReturnData<string>
				{
					Message = validUserInputs.Errors,
					Success = validUserInputs.Valid
				});

			try
			{
				var registeredUser = _context.Users.FirstOrDefault(u => (u.UserName.ToUpper().Equals(request.RegNumber.ToUpper())) || (u.Code.ToString() == request.RegNumber) || (u.Id.ToString() == request.RegNumber));
				if (registeredUser == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Username not found"
					});

				if (string.IsNullOrEmpty(registeredUser.UserName))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Username not found"
					});

				registeredUser.PasswordHash = registeredUser.PasswordHash ?? "";
				var hashedNewPassword = SecurePasswordHasher.Hash(request.Password);
				if(hashedNewPassword.ToUpper().Equals(registeredUser.PasswordHash.ToUpper()))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly use a different password from the previous"
					});

				var userResetPassword = new UserResetPassword();

				if ((request.Role == Role.Admin) || (request.Role == Role.All))
				{
					userResetPassword = _context.UserResetPasswords.FirstOrDefault(u => u.UserId == registeredUser.Id && u.Status == false);
					registeredUser.PasswordHash = SecurePasswordHasher.Hash(request.Password);
					registeredUser.EmailConfirmed = true;
					registeredUser.Status = true;
					if (userResetPassword != null)
					{
						userResetPassword.Status = true;
						_context.Update(userResetPassword);
					}

					_context.Update(registeredUser);
					_context.SaveChanges();

					return Json(new ReturnData<string>
					{
						Success = true,
						Message = "Password reset successful"
					});
				}

				userResetPassword = new UserResetPassword
				{
					UserId = registeredUser.Id,
					ResetCode = Guid.NewGuid().ToString(),
					DateCreated = DateTime.Now,
					Status = false
				};
				var success = false;

				var userGroup = _context.UserGroups.FirstOrDefault(u => u.Id == registeredUser.UserGroupsId);

				mailMethod = MailSendMethod.PasswordReset;
				var subject = "Reset Account Password";
				if (userGroup?.Role == Role.Student)
				{
					var classStatus = _context.Settings.FirstOrDefault()?.ClassStatus;
					var result = _unisolApiProxy.CheckStudentExists(request.RegNumber, classStatus).Result;
					var jdata = new ProcessJsonReturnResults<UserDetails>(result).UnisolApiData;
					var emailContent = new MailsViewModel {
						UserCode = request.RegNumber,
						Firstname = jdata.Data.Names,
						Code = userResetPassword.ResetCode,
						Email = registeredUser.Email,
						MailMethod = mailMethod,
						PortalUrl = request.PortalUrl,
						Subject = subject
					};
					success = emailSender.SendEmail(emailContent);
				}
				if (userGroup?.Role == Role.Staff)
				{
					var result = _unisolApiProxy.CheckEmployeeExists(request.RegNumber).Result;
					var jdata = JsonConvert.DeserializeObject<ReturnData<HrpEmployee>>(result);
					var emailContent = new MailsViewModel
					{
						UserCode = request.RegNumber,
						Firstname = jdata.Data.Names,
						PortalUrl = request.PortalUrl,
						Code = userResetPassword.ResetCode,
						Email = registeredUser.Email,
						MailMethod = mailMethod,
						Subject = subject
					};
					success = emailSender.SendEmail(emailContent);
				}

				if (success)
				{
					registeredUser.Code = userResetPassword.ResetCode;
					_context.SaveChanges();

					var email = registeredUser.Email.Split('@');
					return Json(new ReturnData<bool>
					{
						Success = true,
						Message = $"We have sent a link to reset your password, please check your email ({email[0].Substring(0, 1)}*****{email[0].Substring(email[0].Length - 2)}@{email[1]})."
					});
				}
				return Json(new ReturnData<bool>
				{
					Success = false,
					Message = "There was a problem while trying reset your password, please contact admin"
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Something went wrong, please try again after sometime.",
					Error = new Error(ex)
				});
			}
		}

		[HttpGet("updateUsersStatus")]
		public JsonResult UpdateUsersStatus(Guid id)
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
			var user = _context.Users.FirstOrDefault(u => u.Id == id);
			if (user == null)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "User not found"
				});
			}

			if (user.UserGroupsId == (int)Role.Admin)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Not allowed to disable the admin"
				});
			}

			user.Status = !user.Status;
			_context.Users.Update(user);
			_context.SaveChanges();

			var message = user.Status ? "Account activated successfully" : "Account disabled successfully";
			return Json(new ReturnData<string>
			{
				Success = true,
				Message = message
			});
		}

		[HttpGet("adminconfirmpassword")]
		public JsonResult AdminConfirmPassword(string usercode)
		{
			try
			{
				if (string.IsNullOrEmpty(usercode))
				{
					var users = _context.Users.Where(u => !u.EmailConfirmed).ToList();
					foreach (var user in users)
					{
						user.EmailConfirmed = true;
						user.Status = true;
					}
					_context.SaveChanges();

					return Json(new ReturnData<string>
					{
						Success = true,
						Message = "All accounts confirmed successifully"
					});
				}

				var registeredUser = _context.Users.FirstOrDefault(u => u.UserName == usercode);
				if (registeredUser == null)
				{
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Registration Number not found"
					});
				}

				if (registeredUser.EmailConfirmed)
				{
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Account already confirmed"
					});
				}

				registeredUser.EmailConfirmed = true;
				registeredUser.Status = true;
				_context.SaveChanges();

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Password confirmation successful"
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Password confirmation failed",
					Error = new Error(ex)
				});
			}
		}

		
		public JsonResult GetEmailDetails()
		{
			try
			{
				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Your account has been verified"
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Could not Email Details,please retry...",
					Error = new Error(ex)
				});
			}
		}
		
		[HttpGet("confirm")]
		public ActionResult SaveUserPassword(string code)
		{
			try 
			{
				var user = _context.Users.FirstOrDefault(u => u.Code == code);
				if (user == null)
				{
					logger.Error($": \t AccountConfirmation: \t User not found");
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Invalid validation URL,Please recheck email"
					});
				}
				
				user.EmailConfirmed = true;
				user.Status = true;
				_context.SaveChanges();

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Your account has been verified"
				});
			}
			catch (Exception ex)
			{
				logger.Error($": \t AccountConfirmationError: \t {ex}");
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Could not validate errors,please retry...",
					Error = new Error(ex)
				});
			}
		}

		private JsonResult CreateAdminUser(RegisterViewModel request)
		{
			try
			{
				var adminCheck = _context.Users.FirstOrDefault(u => u.UserName == request.RegNumber);
				if (adminCheck != null)
				{
					if (adminCheck.UserName == request.RegNumber)
						return Json(new ReturnData<HrpEmployee>
						{
							Success = false,
							Message = "Please user a different username"
						});

					if (adminCheck.Email == request.Email)
						return Json(new ReturnData<HrpEmployee>
						{
							Success = false,
							Message = "Please user a different email address"
						});
				}

				var user = new User
				{
					Email = request.Email,
					UserName = request.RegNumber,
					Code = Guid.NewGuid().ToString(),
					UserGroupsId = request.UserGroup,
					Role = Role.Admin
				};

				_context.Users.Add(user);
				_context.SaveChanges();

				mailMethod = MailSendMethod.AccountConfirmation;
				var subject = "Account Creation";
				var emailContent = new MailsViewModel
				{
					UserCode = user.UserName,
					Firstname = request.Email,
					Code = user.Code,
					Email = request.Email,
					PortalUrl = request.PortalUrl,
					MailMethod = mailMethod,
					Subject = subject
				};
				var success = emailSender.SendEmail(emailContent);
				var msg = "Account created successfully. ";
				return Json(new ReturnData<bool>
				{
					Success = success,
					Message = success ? msg + "Check email inbox" : msg
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<bool>
				{
					Success = false,
					Message = ex.Message
				});
			}
		}

		[HttpGet("pages")]
		public JsonResult Pages(string searchText, int? offset = null, int? itemsPerPage = null, int? role = null, bool unconfirmed = false)

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
			var response = _portalServices.FilterUsers(searchText, offset, itemsPerPage, role, unconfirmed);
			return Json(response);
		}

		[HttpGet("[action]")]
		public JsonResult GetRoles()
		{
			var result = _unisolApiProxy.GetGenesisStatus().Result;
			var response = new ProcessJsonReturnResults<List<Register>>(result).UnisolApiData;
			return Json(_userCredentials.GetRoles(response.Success));
		}

		[HttpGet("[action]")]
		public JsonResult ChangePassword(string newPassword, string oldPassword, string userName)
		{
			newPassword = newPassword == "undefined" ? "" : newPassword;
			oldPassword = oldPassword == "undefined" ? "" : oldPassword;
			var requiredFields = new List<Tuple<string, string, DataType>>
			{
				Tuple.Create("New password", newPassword, DataType.Password),
			};

			var validUserInputs = _validateService.Validate(requiredFields);
			if (!validUserInputs.Valid)
			{
				return Json(new ReturnData<string>
				{
					Message = validUserInputs.Errors,
					Success = validUserInputs.Valid
				});
			}

			try
			{
				var user = _context.Users.FirstOrDefault(u => SecurePasswordHasher.Verify(oldPassword, u.PasswordHash) && u.UserName == userName);
				if (user == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, We could not recognize your old password",
					});
				
				if (SecurePasswordHasher.Verify(newPassword, user.PasswordHash))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly use another password",
					});

				user.PasswordHash = SecurePasswordHasher.Hash(newPassword);

				_context.Users.Update(user);
				_context.SaveChanges();

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Password updated Successfully",
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Error occured",
					Error = new Error(ex)
				});
			}
		}

		[HttpGet("[action]")]
		public JsonResult DeleteUser(Guid id)
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
				var user = _context.Users.FirstOrDefault(u => u.Id == id);
				if (user == null)
				{
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "User not found"
					});
				}

				if (user.UserGroupsId == (int)Role.Admin)
				{
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Not allowed to delete the admin"
					});
				}

				_context.Users.Remove(user);
				_context.SaveChanges();
				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "User deleted successfully"
				});


			}
			catch (Exception ex)
			{
				return Json(new ReturnData<bool>
				{
					Success = false,
					Message = "Server error occured",
					Error = new Error(ex)
				});
			}
		}

		[HttpGet("createBunchUsers")]
		public JsonResult CreateBunchUsers(Role bunchRole)
		{
			var UsersFromErp = ImportFromErp(bunchRole); // This imports users from the ERP
			if (UsersFromErp.Success)
				return Json(UsersFromErp);
			var roles = GetBunchRoles(bunchRole);
			if (!roles.Success)
				return Json(roles);

			var userRoles = GetBunchUserRoles(roles.Data);
			if (!userRoles.Success)
				return Json(userRoles);

			var oldUsers = GetOldUsers(userRoles.Data);
			if (!oldUsers.Success)
				return Json(oldUsers);

			var users = AddToNewMembership(oldUsers.Data, bunchRole);
			return Json(users);
		}

		private ReturnData<string> ImportFromErp(Role bunchRole)
		{
			var result = _unisolApiProxy.GetErpUsers(bunchRole).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<List<Membership>>>(result);
			if (!jdata.Success)
				return new ReturnData<string>
				{
					Success = false,
					Message = jdata.Message
				};

			var users = AddToNewMembership(jdata.Data, bunchRole);
			return users;
		}

		private ReturnData<string> AddToNewMembership(List<Membership> oldMembers, Role bunchRole)
		{ //willy
			try
			{
				var result = _unisolApiProxy.GetEmployees().Result;
				var employees = JsonConvert.DeserializeObject<ReturnData<List<HrpEmployee>>>(result);
				var userGroup = _context.UserGroups.FirstOrDefault(g => g.Role == bunchRole && g.IsDefault && g.Status);
				foreach (var user in oldMembers)
				{
					if (!_context.Users.Any(u => u.UserName.ToLower().Equals(user.UserName.ToLower())))
					{
						var password = user.UserName;
						if (bunchRole == Role.Staff)
							password = employees.Data.FirstOrDefault(e => e.EmpNo.ToLower().Equals(user.UserName.ToLower()))?.Idno ?? "";

						_context.Users.Add(new User
						{
							AccessFailedCount = 0,
							AccountType = 0,
							DateCreated = DateTime.UtcNow,
							Email = user.Email,
							EmailConfirmed = true,
							LockoutEnabled = false,
							PasswordHash = SecurePasswordHasher.Hash(password),
							PhoneNumberConfirmed = false,
							TwoFactorEnabled = false,
							UserName = user.UserName,
							Code = "8a5ef81b-abf8-4f72-9969-6f46f5d441e3",
							UserGroupsId = userGroup.Id,
							Status = true,
							Role = bunchRole
						});

						_context.SaveChanges();
					}
				}

				return new ReturnData<string>
				{
					Success = true,
					Message = "Users Imported successfully"
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		private ReturnData<List<Membership>> GetOldUsers(List<UserRoles> userRoles)
		{
			try
			{
				var oldUsers = new List<Membership>();
				foreach (var userRole in userRoles)
				{
					var user = _oldMembershipContext.AspNetUsers.FirstOrDefault(u => u.Id == userRole.UserId);
					if (user != null)
						oldUsers.Add(user);
				}

				return new ReturnData<List<Membership>>
				{
					Success = true,
					Data = oldUsers
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<List<Membership>>
				{
					Success = false,
					Message = ex.Message
				};
			}
		}

		private ReturnData<List<UserRoles>> GetBunchUserRoles(Roles roles)
		{
			if (string.IsNullOrEmpty(roles.Name))
				return new ReturnData<List<UserRoles>>
				{
					Success = false,
					Message = "Sorry, No such role found in the old membership"
				};

			try
			{
				var userRoles = _oldMembershipContext.AspNetUserRoles.Where(u => u.RoleId == roles.Id).ToList();
				return new ReturnData<List<UserRoles>>
				{
					Success = true,
					Data = userRoles
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<List<UserRoles>>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		private ReturnData<Roles> GetBunchRoles(Role bunchRole)
		{
			if (bunchRole == 0)
				return new ReturnData<Roles>
				{
					Success = false,
					Message = "Kindly select user role"
				};

			try
			{
				var roles = new Roles();
				if (bunchRole == Role.Admin)
					roles = _oldMembershipContext.AspNetRoles.FirstOrDefault(r => r.Name.Equals("Admin"));
				if (bunchRole == Role.Staff)
					roles = _oldMembershipContext.AspNetRoles.FirstOrDefault(r => r.Name.Equals("Employee"));
				if (bunchRole == Role.Student)
					roles = _oldMembershipContext.AspNetRoles.FirstOrDefault(r => r.Name.Equals("Student"));

				return new ReturnData<Roles>
				{
					Success = true,
					Data = roles
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<Roles>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		[HttpGet("[action]")]
		public JsonResult UpdatePortalEmails()
		{
			var result = _unisolApiProxy.UpdatePortalEmails().Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<List<ErpEmailVm>>>(result);
			if(!jdata.Success)
				return Json(jdata);

			_context.Users.ToList().ForEach(u =>
			{
				if(u.Role != Role.Admin)
					u.Email = jdata.Data.FirstOrDefault(e => e.Username.ToUpper().Equals(u.UserName.ToUpper()))?.Email ?? "";
			});

			_context.SaveChanges();
			return Json(jdata);
		}
	}
}