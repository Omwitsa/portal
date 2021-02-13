using Microsoft.AspNetCore.Mvc;
using Unisol.Web.Api.IServices;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class EClaimsController : Controller
	{
		private IStaffServices _staffServices;

		public EClaimsController( IStaffServices staffServices)
		{
			_staffServices = staffServices;
		}

		[HttpGet("[action]")]
		public JsonResult GetEClaims(string userCode, string searchText)
		{
			var eclaims = _staffServices.GetEClaims(userCode, searchText);
			return Json(eclaims);
		}

		[HttpPost("[action]")]
		public JsonResult AddEClaim(EclaimUnits eclaimUnits, string userCode, string description)
		{
			var eclaims = _staffServices.AddEClaim(eclaimUnits, userCode, description);
			return Json(eclaims);
		}

		[HttpGet("[action]")]
		public JsonResult GetUnitOfMeasure()
		{
			var eclaims = _staffServices.GetUnitOfMeasure();
			return Json(eclaims);
		}

	}
}
