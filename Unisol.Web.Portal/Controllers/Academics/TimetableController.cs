using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Login;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers.Academics
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class TimetableController : Controller
	{
		private readonly IUnisolApiProxy _unisolApiProxy;
		private readonly PortalCoreContext _context;
		private readonly TokenValidator _tokenValidator;
		private UserValidator userValidator;
		private string classStatus;
		public TimetableController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
		{
			_unisolApiProxy = unisolApiProxy;
			_context = context;
			_tokenValidator = new TokenValidator(_context);
			userValidator = new UserValidator();
			classStatus = context.Settings.FirstOrDefault()?.ClassStatus;
		}

		[HttpPost("getStudyTimetable")]
		public JsonResult GetStudyTimetable([FromBody] RegisterViewModel reg)
		{
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var result = _unisolApiProxy.GetStudyTimetable(reg, classStatus).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
			return Json(response);
		}

		[HttpPost("getExamTimetable")]
		public JsonResult GetExamTimetable([FromBody] RegisterViewModel reg)
		{
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var result = _unisolApiProxy.GetExamTimetable(reg, classStatus).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
			return Json(response);
		}

		[HttpPost("getLecturerStudyTimetable")]
		public JsonResult GetLecturerStudyTimetable([FromBody] RegisterViewModel reg)
		{
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var result = _unisolApiProxy.GetLecturerStudyTimetable(reg).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
			return Json(response);
		}

		[HttpPost("getLecturerExamTimetable")]
		public JsonResult GetLecturerExamTimetable([FromBody] RegisterViewModel reg)
		{
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var result = _unisolApiProxy.GetLecturerExamTimetable(reg).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
			return Json(response);
		}

		[HttpPost("lecturerAllocationSammary")]
		public JsonResult LecturerAllocationSammary([FromBody] RegisterViewModel reg)
		{
			var token = _tokenValidator.Validate(HttpContext);
			if (!token.Success)
				return Json(new ReturnData<string>
				{
					Success = false,
					NotAuthenticated = true,
					Message = $"Unauthorized:-{token.Message}",
				});

			var result = _unisolApiProxy.LecturerAllocationSammary(reg).Result;
			var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
			return Json(response);
		}

		
	}
}
