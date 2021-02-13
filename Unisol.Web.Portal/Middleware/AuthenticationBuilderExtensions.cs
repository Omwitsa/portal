using Microsoft.AspNetCore.Authentication;
using System;
using Unisol.Web.Common.Process;
using Unisol.Web.Portal.MiddleWare.Authentication;

namespace Unisol.Web.Portal.Middleware
{
	public static class AuthenticationBuilderExtension
	{
		//Custom authentication extension method
		public static AuthenticationBuilder AddCustomAuth(this AuthenticationBuilder builder, Action<CustomAuthOptions> configureOptions)
		{
			// Add custom authentication scheme with custom options and custom handler
			return builder.AddScheme<CustomAuthOptions, CustomAuthHandler>(CustomAuthOptions.DefaultScheme, configureOptions);
		}
	}
}
