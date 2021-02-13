using Microsoft.AspNetCore.Mvc;
using System;
using Unisol.Web.Api.IServices;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Login;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers.Elections
{
	[Route("api/[controller]")]
	public class ElectionsController : Controller
	{
		private StudentCredential studentCredentials;
		public ElectionsController(UnisolAPIdbContext context, IStudentServices studentServices, ISystemServices systemServices)
		{
			studentCredentials = new StudentCredential(context, studentServices, systemServices);
		}

		[HttpPost("[action]")]
		public JsonResult GetStudentDetails([FromBody] RegisterViewModel reg, string classStatus)
		{
			try
			{
				var studentDetails = studentCredentials.GetStudentDetails(reg.RegNumber, classStatus);
				if (!studentDetails.Success)
					return Json(studentDetails);

				var programmeDetails = studentCredentials.FormatStudentProgramme(reg.RegNumber, classStatus);
				if (!programmeDetails.Success)
					return Json(programmeDetails);

				var data = new
				{
					RegisterData = studentDetails.Data,
					ProgrammeData = programmeDetails.Data
				};

				return Json(new ReturnData<dynamic> {
					Success = true,
					Data = data
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "An error occoured"
				});
			}
		}
	}
}
