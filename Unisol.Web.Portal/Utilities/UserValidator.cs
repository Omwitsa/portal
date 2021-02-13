using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using System;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Portal.Utilities
{
	public class UserValidator
	{
		public ReturnData<string> Validate(TokenValidator tokenValidator, HttpContext httpContext, Role role)
		{
			var token = tokenValidator.Validate(httpContext);
			if (!token.Success)
				return new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				};

			if (token.Role != role)
				return new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = "Sorry, you are not authorized to perform this action",
				};

			return new ReturnData<string>
			{
				Success = true
			};
		}

		public string ReturnDataUri(string imageUrl, HostingEnvironment _hostingEnvironment)
		{
			string webRootPath = _hostingEnvironment.WebRootPath;
			string contentRootPath = _hostingEnvironment.ContentRootPath;
			var imgPath = webRootPath + imageUrl;
			var bytes = System.IO.File.ReadAllBytes(imgPath);
			var b64String = Convert.ToBase64String(bytes);
			var dataUrl = "data:image/png;base64," + b64String;

			return dataUrl;
		}
	}
}
