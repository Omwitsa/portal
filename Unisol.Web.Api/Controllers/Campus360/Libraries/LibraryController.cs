using Microsoft.AspNetCore.Mvc;
using Unisol.Web.Api.IServices;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.LibraryModels;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers.Campus360.Libraries
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class LibraryController: Controller
	{
		private LibraryAPIdbContext _libraryContext;
		private Library library;
		private StudentCredential studentCredentials;
		private bool isCampusApi = true;
		public LibraryController(LibraryAPIdbContext libraryContext, UnisolAPIdbContext context, IStudentServices studentServices, ISystemServices systemServices)
		{
			_libraryContext = libraryContext;
			studentCredentials = new StudentCredential(context, studentServices, systemServices);
			library = new Library(libraryContext);
		}

		[HttpGet("[action]")]
		public JsonResult GetCurrentIssues(string usercode, string classStatus)
		{
			var studentDetails = studentCredentials.GetStudentDetails(usercode, classStatus, isCampusApi);
			if (!studentDetails.Success)
				return Json(new ReturnData<string>
				{
					Success = studentDetails.Success,
					Message = studentDetails.Message
				});

			return Json(library.GetCurrentIssues(usercode));
		} 

		[HttpGet("[action]")]
		public JsonResult GetOldIssues(string usercode, string classStatus)
		{
			var studentDetails = studentCredentials.GetStudentDetails(usercode, classStatus, isCampusApi);
			if (!studentDetails.Success)
				return Json(new ReturnData<string>
				{
					Success = studentDetails.Success,
					Message = studentDetails.Message
				});

			return Json(library.GetOldIssues(usercode));
		}
	}
}
