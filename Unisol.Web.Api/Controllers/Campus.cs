using Microsoft.AspNetCore.Mvc;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class Campus: Controller
	{
		private readonly UnisolAPIdbContext _context;
		private CampusDetails campusDetails;
		public Campus(UnisolAPIdbContext context)
		{
			_context = context;
			campusDetails = new CampusDetails(context);
		}
		[HttpGet("[action]")]
		public JsonResult GetUniversityCampus()
		{
			var universityCampuses = campusDetails.GetUniversityCampuses();
			return Json(universityCampuses);
		}

		[HttpGet("[action]")]
		public JsonResult GetUniversityInfo()
		{
			var universityCampuses = campusDetails.GetUniversityInfo();
			return Json(universityCampuses);
		}

		[HttpGet("[action]")]
		public JsonResult GetUniversityDepartment()
		{
			var universityDepartments = campusDetails.GetUniversityDepartments();
			return Json(universityDepartments);
		}

		[HttpGet("[action]")]
		public JsonResult GetUniversityClass()
		{
			var classes = campusDetails.GetUniversityClasses();
			return Json(classes);
		}

		[HttpGet("[action]")]
		public JsonResult GetStudAcademicInfo()
		{
			var academicInfo = campusDetails.GetStudAcademicInfo();
			return Json(academicInfo);
		}
	}
}
