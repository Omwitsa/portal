using System;
using Microsoft.AspNetCore.Mvc;
using Unisol.Web.Common.ViewModels.Login;
using Unisol.Web.Common.Process;
using System.Linq;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Common.ViewModels.Users;
using System.Collections.Generic;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.IRepository;
using Unisol.Web.Portal.Utilities;
using Unisol.Web.Common.ViewModels.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;

namespace Unisol.Web.Portal.Controllers
{
	[Route("api/login")]
    [ApiController]
    public class LoginApiController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
		private IPortalServices _portalServices;
		private IUserManagementService _userManagementService;
		private InputValidator _validateService;
        public PortalCoreContext _context;
        public UserCredentials userCredentials;
        private string classStatus;
		HostingEnvironment _hostingEnvironment;


		public LoginApiController(PortalCoreContext context, IUnisolApiProxy unisolApiProxy, IPortalServices portalServices, 
			IUserManagementService userManagementService, HostingEnvironment hostingEnvironment)
        {
            _context = context;
            _unisolApiProxy = unisolApiProxy;
			_userManagementService = userManagementService;
			_hostingEnvironment = hostingEnvironment;
			_portalServices = portalServices;
            _validateService = new InputValidator();
            userCredentials = new UserCredentials(context);
            classStatus = _context.Settings.FirstOrDefault()?.ClassStatus;
        }

        [HttpPost]
        [Route("user")]
        public JsonResult UserLogin(LoginViewModel request)
        {
			var login = _userManagementService.Login(request);
			return Json(login);
		}
		
		[HttpGet("getSettings")]
        public JsonResult GetSettings()
        {
            try
            {
				var Settings = _context.Settings.Select(e => new PortalSetting
				{
					Address = e.Address,
					IsGenesis = e.IsGenesis,
					Initials = e.Initials,
					Name = e.Name,
					logoImageUrl = e.LogoImageUrl,
					unitsRegLevels = e.UnitsRegLevels,
					ThemeColor = e.ThemeColor,
					SecondaryColor = e.SecondaryColor,
					LogoDataUrl = new UserValidator().ReturnDataUri(e.LogoImageUrl, _hostingEnvironment)
				}).FirstOrDefault();

				if (Settings.IsGenesis == null)
					Settings.IsGenesis = true;
				return Json(new ReturnData<dynamic> {
					Data = new
					{
						Settings
					}
				});
            }
            catch (Exception)
            {
                return Json("");
            }
        }
    }
}