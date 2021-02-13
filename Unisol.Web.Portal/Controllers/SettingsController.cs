using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Common.ViewModels.Users;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class SettingsController : Controller
	{
		private InputValidator _validateService;
		private PortalCoreContext _context;
		private IConfiguration _configuration;
		private IHostingEnvironment _hostingEnvironment;
		private readonly TokenValidator _tokenValidator;
		public SettingsController(PortalCoreContext context, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
		{
			_validateService = new InputValidator();
			_configuration = configuration;
			_hostingEnvironment = hostingEnvironment;
			_context = context;
			_tokenValidator = new TokenValidator(_context);
		}

		[HttpPost("add")]
		public JsonResult Create(Settings request)
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
				var requiredFields = new List<Tuple<string, string, DataType>>
				{
					Tuple.Create("name", request.Name, DataType.Default),
					Tuple.Create("address", request.Name, DataType.Default),
					Tuple.Create("themeColor", request.ThemeColor, DataType.Default),
				};

				var validation = _validateService.Validate(requiredFields);
				if (!validation.Valid)
				{
					return Json(new ReturnData<string>
					{
						Message = validation.Errors,
						Success = false
					});
				}

				if (request.Id > 0)
				{
					_context.Settings.Update(request);
				}
				else
				{
					_context.Settings.Add(request);
				}

				_context.SaveChanges();

				return Json(new ReturnData<string>
				{
					Success = true,
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "An error occured, please try again",
					Error = new Error(ex)
				});
			}
		}

		[HttpGet("encrypt")]
		public JsonResult Encrypt(string value)
		{
			value = value ?? "";
			var encryptValue = Encrypter.Encrypt(value);
			return Json(new ReturnData<string>
			{
				Success = true,
				Data = encryptValue
			});
		}


		[HttpGet("get")]
		public JsonResult Get()
		{
			var reply = new ReturnData<Settings>();
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

				var settings = _context.Settings.FirstOrDefault();
				return Json(new ReturnData<Settings>
				{
					Data = settings,
					Success = true
				});

			}
			catch (Exception ex)
			{
				reply.Success = false;
				reply.Message = ex.Message;
			}

			return Json(reply);
		}
		[HttpPost("updateSettings")]
		public JsonResult UpdateSettings(Settings emailConfigurations, bool isSystemSettings = false)
		{
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var requiredFields = new List<Tuple<string, string, DataType>>
			{
				Tuple.Create("Email", emailConfigurations.EmailUserName, DataType.Email),
				Tuple.Create("SmtpClient", emailConfigurations.SmtpClient, DataType.Default),
				Tuple.Create("Password", emailConfigurations.Password, DataType.Default),
				Tuple.Create("Port", emailConfigurations.Port, DataType.Default),
			};

			var validation = _validateService.Validate(requiredFields);
			if (!validation.Valid)
			{
				return Json(new ReturnData<string>
				{
					Message = validation.Errors,
					Success = false
				});
			}
			try
			{
				var settings = _context.Settings.FirstOrDefault();
                if (isSystemSettings)
                {
					settings.LeaveRelieverMandatory = emailConfigurations.LeaveRelieverMandatory;
				}
                else
                {
					settings.EmailUserName = emailConfigurations.EmailUserName;
					settings.SmtpClient = emailConfigurations.SmtpClient;
					settings.Password = emailConfigurations.Password;
					settings.Port = emailConfigurations.Port;
					settings.SocketOption = emailConfigurations.SocketOption;
				}

				_context.SaveChanges();
				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Settings Updated Successfully",
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "An error occured, please try again",
					Error = new Error(ex)

				});
			}
		}

		[HttpPost("uploadContent")]
		public async Task<JsonResult> Create(string imageName)
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
			var reply = new ReturnData<string>();
			var settings = _context.Settings.FirstOrDefault();
			var errors = "";
			try
			{
				if (Request.Form.Files == null)
				{
					reply.Success = false;
					reply.Message = "Failed to add product : " + errors;
					return Json(reply);
				}

				var file = Request.Form.Files.FirstOrDefault();

				string folderName = @"assets\images";
				string webRootPath = _hostingEnvironment.WebRootPath;
				string newPath = Path.Combine(webRootPath, folderName);
				if (!Directory.Exists(newPath))
				{
					Directory.CreateDirectory(newPath);
				}
				if (file != null && file.Length > 0)
				{
					var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
					var uniqueFileName = GetUniqueFileName(fileName);
					var fullPath = Path.Combine(newPath, uniqueFileName);
					using (var stream = new FileStream(fullPath, FileMode.Create))
					{
						file.CopyTo(stream);
					}

					var imageUrl = @"/assets/images/" + uniqueFileName;

					if (imageName == "logoImage") settings.LogoImageUrl = imageUrl;
					if (imageName == "loginImage") settings.loginImageUrl = imageUrl;

					_context.Settings.Update(settings);
					_context.SaveChanges();
					reply.Data = imageUrl;
				}
			}

			catch (Exception e)
			{
				reply.Success = false;
				reply.Message = "Failed to add product : " + errors;
				return Json(reply);
			}
			return Json(reply);
		}
		private string GetUniqueFileName(string fileName)
		{
			fileName = Path.GetFileName(fileName).Replace(" ", "");
			return Path.GetFileNameWithoutExtension(fileName)
				   + "_"
				   + Guid.NewGuid().ToString().Substring(0, 4)
				   + Path.GetExtension(fileName);
		}
	}
}