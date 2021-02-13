using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class FleetController : Controller
    {
		private readonly IUnisolApiProxy _unisolApiProxy;
		private readonly TokenValidator _tokenValidator;
		public FleetController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
		{
			_unisolApiProxy = unisolApiProxy;
			_tokenValidator = new TokenValidator(context);
		}

		[HttpGet("[action]")]
		public JsonResult GetFleetBookings(string usercode, string searchText)
		{
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var result = _unisolApiProxy.GetFleetBookings(usercode, searchText).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
			return Json(response);
		}

		[HttpGet("[action]")]
		public JsonResult GetUserFleetDetails(string usercode)
		{
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var result = _unisolApiProxy.GetUserFleetDetails(usercode).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
			return Json(response);
		} 

		[HttpGet("[action]")]
		public JsonResult GetAssignedVehicles(string usercode, string searchText)
		{
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var result = _unisolApiProxy.GetAssignedVehicles(usercode, searchText).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
			return Json(response);
		}

		[HttpPost("[action]")]
		public JsonResult BookVehicle([FromBody] FLBooking booking)
		{
			booking.DDate = booking.DDate.GetValueOrDefault().AddDays(1);
			booking.RetDate = booking.RetDate.GetValueOrDefault().AddDays(1);
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			if(string.IsNullOrEmpty(booking.Purpose))
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Kindly, provide the purpose for booking",
				});

			var result = _unisolApiProxy.BookVehicle(booking).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
			return Json(response);
		}
	}
}