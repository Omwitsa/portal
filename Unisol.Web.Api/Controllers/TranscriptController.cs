using System;
using Microsoft.AspNetCore.Mvc;
using Unisol.Web.Api.IServices;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TranscriptController : Controller
    {
        private readonly UnisolAPIdbContext _context;
		private IStudentServices _studentServices;
		private StudentCredential studentCredential;

		public TranscriptController(UnisolAPIdbContext context, IStudentServices studentServices, ISystemServices systemRepository)
        {
            _context = context;
			studentCredential = new StudentCredential(context, studentServices, systemRepository);
		}

        [HttpPost("[action]")]
        public JsonResult GetSelectedYearResults(TranscriptRequestViewModel transcriptModel, string classStatus)
        {
            try
            {
				var YearResults = studentCredential.GetYearResults(transcriptModel, classStatus);
				return Json(YearResults);
			}
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Oops, something went wrong while retrieving your results, please try again"
                });
            }
        }
	}
}