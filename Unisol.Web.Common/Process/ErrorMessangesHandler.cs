using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;

namespace Unisol.Web.Common.Process
{
    public static class ErrorMessangesHandler
    {
        public static bool Production = false;

        public static IHostingEnvironment Env = new HostingEnvironment();

        public static string ExceptionMessage(Exception ex)
        {
            return Env.IsProduction() ? ex?.Message : "Please contact admin for help";
        }
    }
}