using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using Unisol.Web.Api.IServices;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers.Elearning
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class CoursesController : Controller
	{
		private readonly IStudentServices _studentServices;
		private readonly StudentCredential _studentCredentials;
		private readonly UnisolAPIdbContext _context;
		private readonly string classStatus = "Active";

		public CoursesController(IStudentServices studentServices, UnisolAPIdbContext context, ISystemServices systemService)
		{
			_studentServices = studentServices;
			_context = context;
			_studentCredentials = new StudentCredential(_context, studentServices, systemService);
		}

		[HttpGet("[action]")]
		public JsonResult GetCourses()
		{
			var courses = _studentServices.GetAllProgrammes();
			return Json(courses);
		}

		[HttpGet("[action]")]
		public JsonResult ValidateStudent(string userCode)
		{
			userCode = userCode ?? "";
			var isStudent = _studentServices.GetRegister(userCode);
			return Json(isStudent);
		}

		[HttpGet("[action]")]
		public JsonResult ValidateUser(string userCode)
		{
			userCode = userCode ?? "";
			var validUser = _studentServices.ValidateUser(userCode);
			return Json(validUser);
		}

		[HttpGet("[action]")]
		public JsonResult RegisteredUnitCodes(string userCode)
		{
			userCode = userCode ?? "";
			var policyRes = _studentCredentials.MeetsPolicy(userCode);
			if (!policyRes.Success)
			{
				return Json(new
				{
					Success = false,
					Message = $"Policy Failed :-{policyRes.Message}",
					NotAuthenticated = true
				});
			}
			var data = _studentServices.RegisteredUnitCodes(userCode, classStatus);
			var code = data.Success ? data.Data.LastOrDefault() : "";
			data.Data.Remove(code);
			return Json(new
			{
				success = data.Success,
				message = data.Message,
				data = data.Data,
				programmeCode = code
			});
		}

		[HttpGet("[action]")]
		public JsonResult StudentFeesBalance(string userCode)
		{
			try
			{
				var credentials = _studentCredentials.GetStudentDetails(userCode, classStatus);
				if (!credentials.Success)
					return Json(credentials);
				var StudFeesBalances = _studentCredentials.GetFeesBalance(userCode, classStatus);
				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Message = "",
					Data = new
					{
						Balance = StudFeesBalances
					}
				});
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "An error occurred while trying to find your balance, Please try again",
				});
			}
		}

		[HttpGet("[action]")]
		public JsonResult GetStudents(int page, int perPage = 500)
		{
			var students = _studentServices.GetActiveStudentsWithEmails(page, perPage);
			return Json(students);
		}

		[HttpGet("[action]")]
		public JsonResult GetStaffs(int page, int perPage = 500)
		{
			var staffs = _studentServices.GetActiveStaffWithEmails(page, perPage);
			return Json(staffs);
		}

		[HttpGet("[action]")]
		public JsonResult StudentCount()
		{
			var data = _studentServices.StudentCount();
			return Json(data);
		}

		[HttpGet("[action]")]
		public JsonResult StaffCount()
		{
			var data = _studentServices.StaffCount();
			return Json(data);
		}
	}
}
