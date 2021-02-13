using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Settings;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Models;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly PortalCoreContext _context;
        private IConfiguration _configuration;
        private HostingEnvironment _hostingEnvironment;
		private readonly IUnisolApiProxy _unisolApiProxy;

		public HomeController(IConfiguration configuration, PortalCoreContext context, IUnisolApiProxy unisolApiProxy, 
			HostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
			_unisolApiProxy = unisolApiProxy;
			_context = context;
        }

        public IActionResult Index()
		{
            var selectedSettings = _context.Settings.Select(e => new PortalSetting
			{
				Address = e.Address,
				IsGenesis = e.IsGenesis,
				Initials = e.Initials,
				Name = e.Name,
				logoImageUrl = e.loginImageUrl,
				unitsRegLevels = e.UnitsRegLevels,
				ThemeColor = e.ThemeColor,
				SecondaryColor = e.SecondaryColor,
				LogoDataUrl = new UserValidator().ReturnDataUri(e.LogoImageUrl, _hostingEnvironment)
			}).FirstOrDefault();

            var name = "";
            var theme = selectedSettings == null ? "#003472" : selectedSettings.ThemeColor;
            var secondary = selectedSettings == null ? "#003472" : selectedSettings.SecondaryColor;
            ViewBag.Name = name;
            ViewBag.Settings = JsonConvert.SerializeObject(selectedSettings);
            ViewBag.CustomStyles = CustomCss.GenerateStyle(theme, secondary);
            return View(selectedSettings);
        }

        public string ReturnDataUri(string imageUrl)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var imgPath = webRootPath  + imageUrl;
            var bytes = System.IO.File.ReadAllBytes(imgPath);
            var b64String = Convert.ToBase64String(bytes);
            var dataUrl = "data:image/png;base64," + b64String;

            return dataUrl;
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}