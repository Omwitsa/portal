using Microsoft.AspNetCore.Hosting;
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
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IRepository;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Services
{
    public class UserManagementService : IUserManagementService
	{
		private readonly IUnisolApiProxy _unisolApiProxy;
		private IPortalServices _portalServices;
		private PortalCoreContext _context;
		private InputValidator _validateService;
		private UserCredentials userCredentials;
		private string classStatus;
		private MailSendMethod mailMethod;
		private IHostingEnvironment _env;
		private Logger logger = LogManager.GetLogger("fileLogger");
		private EmailSender emailSender;

		public UserManagementService(PortalCoreContext context, IPortalServices portalServices, IUnisolApiProxy unisolApiProxy, 
			IConfiguration configuration, IEmailConfiguration emailConfiguration, IHostingEnvironment env, IEmailService emailService)
		{
			_context = context;
			_portalServices = portalServices;
			_unisolApiProxy = unisolApiProxy;
			_env = env;
			_validateService = new InputValidator();
			userCredentials = new UserCredentials(context);
			classStatus = _context.Settings.FirstOrDefault()?.ClassStatus ?? "Active";
			emailSender = new EmailSender(configuration, context, emailConfiguration, env, emailService);
		}

		public ReturnData<dynamic> Login(LoginViewModel request)
		{
			request.Username = request.Username ?? "";
			request.Password = request.Password ?? "";
			request.Username = request.Username.Trim();
			var requiredFields = new List<Tuple<string, string, DataType>>
			{
				Tuple.Create("username", request.Username, DataType.Default),
			};

			var validUserInputs = _validateService.Validate(requiredFields);
			if (!validUserInputs.Valid)
			{
				logger.Error($"LoginWrongInputs: \t {validUserInputs.Errors}");
				return new ReturnData<dynamic>
				{
					Message = validUserInputs.Errors,
					Success = validUserInputs.Valid
				};
			}

			try
			{
				var validPortalUser = userCredentials.PortalUserValidation(request);
				if (!validPortalUser.Valid)
				{
					logger.Error($"LoginInvalidUser: \t {validPortalUser.Errors}");
					return new ReturnData<dynamic>
					{
						Success = validPortalUser.Valid,
						Message = validPortalUser.Errors
					};
				}

				var userDetails = _portalServices.GetUserByCode(request.Username);
				if (!userDetails.Success)
				{
					logger.Error($"LoginUserNotFound: \t {userDetails.Message}");
					return new ReturnData<dynamic>
					{
						Success = false,
						Message = userDetails.Message
					};
				}
					
				var portalUser = _portalServices.GetUserByCode(request.Username).Data;
				var hash = SecurePasswordHasher.Hash(Guid.NewGuid().ToString());
				var token = new UserToken()
				{
					Name = "Auth",
					LoginProvider = hash,
					Value = hash,
					UserId = portalUser.Id
				};
				var expiredTokens = _context.UserTokens.Where(t => t.UserId.Equals(portalUser.Id)).ToList();
				if (expiredTokens.Any())
					expiredTokens.ForEach(t => { _context.UserTokens.Remove(t); });

				_context.UserTokens.Add(token);
				_context.SaveChanges();

				var userGroup = _context.UserGroups.FirstOrDefault(k => k.Id == portalUser.UserGroupsId);
				var settings = _context.Settings.FirstOrDefault();
				var portalAdmin = new
				{
					Username = portalUser.UserName,
					Token = token.Value,
					userGroup?.Role,
					GenesisUser = settings.IsGenesis,
					userGroup?.GroupName,
					Allowed = userGroup?.AllowedPrivileges,
					UserRegister = new UserDetails
					{
						Names = portalUser.UserName,
						Wemail = portalUser.Email
					}
				};

				var message = "Login successfull";
				if (userGroup?.Role == Role.Admin)
					return new ReturnData<dynamic>
					{
						Success = true,
						Message = message,
						Data = portalAdmin
					};

				var result = "";

				if (userGroup?.Role == Role.Student)
					result = _unisolApiProxy.CheckStudentExists(portalUser.UserName, classStatus).Result;

				if (userGroup?.Role == Role.Staff)
					result = _unisolApiProxy.CheckEmployeeExists(portalUser.UserName).Result;

				var response = new ProcessJsonReturnResults<UserDetails>(result).UnisolApiData;
				if (response.Data == null)
				{
					logger.Error($"LoginUserDetails: \t {response.Message}");
					return new ReturnData<dynamic>
					{
						Success = false,
						Message = response.Message
					};
				}

				var detailsStudentStaff = new
				{
					Username = portalUser.UserName,
					Token = token.Value,
					userGroup?.Role,
					GenesisUser = settings.IsGenesis,
					userGroup?.GroupName,
					Allowed = userGroup?.AllowedPrivileges,
					UserRegister = response.Data
				};
				return new ReturnData<dynamic>
				{
					Success = true,
					Message = message,
					Data = detailsStudentStaff
				};

			}
			catch (Exception ex)
			{
				logger.Error($"LoginException: \t {ex}");
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry we are unable to log you in at this time, Please try again after some time"
				};
			}
		}

		public ReturnData<bool> Register(RegisterViewModel request, bool isAdmin = false, bool isTest = false)
		{
			try
			{
				var requiredFields = new List<Tuple<string, string, DataType>>
				{
					Tuple.Create("registration number", request.RegNumber, DataType.Default),
				};

				var validUserInputs = _validateService.Validate(requiredFields);
				if (!validUserInputs.Valid)
					return new ReturnData<bool>
					{
						Message = validUserInputs.Errors,
						Success = validUserInputs.Valid
					};

				var userDetails = _context.Users.FirstOrDefault(u => u.UserName == request.RegNumber);
				var message = "You have already registered, please try to reset password in case you have forgotten or contact the admin";

				if (userDetails != null)
				{
					if (!userDetails.EmailConfirmed)
					{
						message = "You have not confirmed the email, check your email";
					}

					return new ReturnData<bool>
					{
						Success = false,
						Message = message
					};
				}

				if (request.Role == Role.Student)
					return CreateStudentUser(request, (bool)isAdmin, isTest);

				if (request.Role == Role.Staff)
					return CreateStaffUser(request, (bool)isAdmin, isTest);

				if (request.Role == Role.Admin)
					return CreateAdminUser(request);

				return new ReturnData<bool>
				{
					Success = false,
					Message = "Sorry, unable to register user"
				};
			}
			catch (Exception ex)
			{
				logger.Error($"UserRegistrationException: \t {ex}");
				return new ReturnData<bool>
				{
					Success = false,
					Message = "An error occured while trying to register, please try again",
					Error = new Error(ex)
				};
			}

		}

		private ReturnData<bool> CreateStudentUser(RegisterViewModel request, bool isAdmin, bool isTest)
		{
			var classStatus = _context.Settings.FirstOrDefault()?.ClassStatus ?? "Active";
			var result = _unisolApiProxy.CheckStudentExists(request.RegNumber, classStatus).Result;
			var jdata = new ProcessJsonReturnResults<Register>(result).UnisolApiData;

			if (!jdata.Success)
				return new ReturnData<bool>
				{
					Success = false,
					Message = jdata.Message
				};

			var defaultStudentGroup = _context.UserGroups.FirstOrDefault(u => u.Status && u.IsDefault && u.Role == Role.Student);
			if (defaultStudentGroup == null)
			{
				logger.Error($"UserRegistrationDefaultStudentGroup: \t Students default group not set");
				return new ReturnData<bool>
				{
					Success = false,
					Message = "There was a problem while creating your account, please contact admin"
				};
			}

			var groupId = request.UserGroup == 0 ? defaultStudentGroup.Id : request.UserGroup;
			var register = jdata.Data;
			var passwordConfirmed = isAdmin ? true : false;
			var user = new User
			{
				UserName = request.RegNumber,
				Email = register.Email,
				UserGroupsId = groupId,
				Code = Guid.NewGuid().ToString(),
				EmailConfirmed = passwordConfirmed,
				Status = passwordConfirmed,
				Role = Role.Student,
				PasswordHash = SecurePasswordHasher.Hash(request.Password)
			};

			if (!isAdmin)
			{
				groupId = defaultStudentGroup.Id;
				mailMethod = MailSendMethod.AccountConfirmation;
				var subject = "Account Creation";
				if (!isTest)
				{
					var emailContent = new MailsViewModel
					{
						UserCode = request.RegNumber,
						Firstname = register.Names,
						Code = user.Code,
						Email = register.Email,
						MailMethod = mailMethod,
						Subject = subject,
						PortalUrl = request.PortalUrl
					};
					var emailResponse = emailSender.SendEmail(emailContent);
					if (!emailResponse)
						return new ReturnData<bool>
						{
							Success = false,
							Message = "Sorry, an error has been encountered while sending an email. Kindly contact admin"
						};
				}
			}

			_context.Users.Add(user);
			_context.SaveChanges();

			return new ReturnData<bool>
			{
				Success = true,
				Message = "Account created successfully"
			};
		}

		private ReturnData<bool> CreateStaffUser(RegisterViewModel request, bool isAdmin, bool isTest)
		{
			var result = _unisolApiProxy.CheckEmployeeExists(request.RegNumber).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<HrpEmployee>>(result);

			if (!jdata.Success)
				return new ReturnData<bool>
				{
					Success = false,
					Message = jdata.Message
				};

			var defaultStaffGroup = _context.UserGroups.FirstOrDefault(u => u.Status && u.IsDefault && u.Role == Role.Staff);
			if (defaultStaffGroup == null)
			{
				logger.Error($"UserRegistrationDefaultStaffGroup: \t Students default group not set");
				return new ReturnData<bool>
				{
					Success = false,
					Message = "There was a problem while creating your account, please contact admin"
				};
			}
			
			var groupId = string.IsNullOrEmpty(request.UserGroup.ToString()) || request.UserGroup < 1 ? defaultStaffGroup.Id : request.UserGroup;
			var register = jdata.Data;
			var user = new User
			{
				UserName = request.RegNumber,
				Email = register.Wemail,
				UserGroupsId = groupId,
				Code = Guid.NewGuid().ToString(),
				EmailConfirmed = isAdmin,
				Role = Role.Staff,
				PasswordHash = SecurePasswordHasher.Hash(request.Password)
			};

			if (!isAdmin)
			{
				groupId = defaultStaffGroup.Id;
				
				mailMethod = MailSendMethod.AccountConfirmation;
				var subject = "Account Creation";
				var emailContent = new MailsViewModel
				{
					UserCode = request.RegNumber,
					Firstname = register.Names,
					Code = user.Code,
					Email = register.Wemail,
					MailMethod = mailMethod,
					Subject = subject,
					PortalUrl = request.PortalUrl
				};
				var success = emailSender.SendEmail(emailContent);
				if (!success)
					return new ReturnData<bool>
					{
						Success = false,
						Message = "A problem occurred while sending an email for account creation, please contact admin"
					};
			}

            _context.Users.Add(user);
			_context.SaveChanges();

			return new ReturnData<bool>
			{
				Success = true,
				Message = "Account created successfully"
			};
		}

		private ReturnData<bool> CreateAdminUser(RegisterViewModel request)
		{
			try
			{
				var adminCheck = _context.Users.FirstOrDefault(u => u.UserName == request.RegNumber);
				if (adminCheck != null)
				{
					if (adminCheck.UserName == request.RegNumber)
						return new ReturnData<bool>
						{
							Success = false,
							Message = "Please user a different username"
						};

					if (adminCheck.Email == request.Email)
						return new ReturnData<bool>
						{
							Success = false,
							Message = "Please user a different email address"
						};
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
					UserCode = request.RegNumber,
					Firstname = request.Email,
					Code = user.Code,
					Email = request.Email,
					MailMethod = mailMethod,
					Subject = subject,
					PortalUrl = request.PortalUrl
				};
				var success = emailSender.SendEmail(emailContent);
				var msg = "Account created successfully. ";
				return new ReturnData<bool>
				{
					Success = success,
					Message = success ? msg + "Check email inbox" : msg
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<bool>
				{
					Success = false,
					Message = ex.Message
				};
			}
		}


	}
}
