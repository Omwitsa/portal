using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Portal.Middleware
{
    public class CustomAuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "custom auth";
        public string Scheme => DefaultScheme;
        public string AuthKey { get; set; }
    }
}
