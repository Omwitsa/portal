using Microsoft.AspNetCore.Mvc;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IRepository;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class DashboardController : Controller
    {
		private IPortalServices _portalServices;
        private readonly TokenValidator _tokenValidator;
        private readonly PortalCoreContext _context;
        public DashboardController(IPortalServices portalServices, PortalCoreContext context)
		{
            _context = context;
            _portalServices = portalServices;
            _tokenValidator = new TokenValidator(_context);
        }

		[HttpGet("getDashboardContent")]
		public JsonResult GetDashboardContent(string searchText, int? offset = null, int? itemsPerPage = null, int? role = null)
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
            switch (3)
			{
				case (int)Role.Admin:
					var admin = "";
					break;

				case (int)Role.Staff:
					var staff = "";
					break;

				case (int)Role.Student:
					var student = "";
					break;

				default:
					var defaultAction = "";
					break;
			}
			var response = _portalServices.FilterUsers(searchText, offset, itemsPerPage, role);
			return Json(response);
		}

	}
}