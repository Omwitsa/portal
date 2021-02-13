using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamCardController : Controller
    {
        private readonly TokenValidator _tokenValidator;
		private IAcademicsServices _academicsServices;
		public ExamCardController(IAcademicsServices academicsServices, PortalCoreContext context)
        {
			_academicsServices = academicsServices;
			_tokenValidator = new TokenValidator(context);
        }

        [HttpGet("GetStudentExamCard")]
        public JsonResult GetStudentExamCard(string userCode, bool isPreviousTermCard = false)
        {
			var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });

			var examCard = _academicsServices.GetStudentExamCard(userCode, isPreviousTermCard);
			return Json(examCard);
		}
	}
}