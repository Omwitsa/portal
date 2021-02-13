using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Common.ViewModels.Evaluations;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class EvaluationQuestionsController : Controller
    {
        private readonly PortalCoreContext _context;
        private readonly TokenValidator _tokenValidator;
        public EvaluationQuestionsController(PortalCoreContext context)
        {
            _context = context;
            _tokenValidator = new TokenValidator(_context);
        }

        [HttpPost]
        [Route("addquestion")]
        public JsonResult AddEvaluationQuestion(EvaluationQuestionViewModel evaluationQuestionViewModel)
        {
            try
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
                if (!string.IsNullOrEmpty(evaluationQuestionViewModel.QuestionDesc))
                {
                    var evaluation = new EvaluationQuestion()
                    {
                        QuestionDesc = evaluationQuestionViewModel.QuestionDesc,
                        EvaluationSectionId = evaluationQuestionViewModel.EvaluationSectionId,
                        //AllowMultiple = evaluationQuestionViewModel.AllowMultiple,
                       
                        //EvaluationQuestionOptions = evaluationQuestionViewModel.Options
                    };

                    if (evaluationQuestionViewModel.Id.HasValue && evaluationQuestionViewModel.Id.Value > 0)
                    {
                        evaluation.Id = (int) evaluationQuestionViewModel.Id;
                        _context.EvaluationQuestions.Update(evaluation);
                    }
                    else
                    {
                        _context.EvaluationQuestions.Add(evaluation);
                    }

                    _context.SaveChanges();

                    return Json(new ReturnData<string>
                    {
                        Success = true,
                        Message = "EvaluationQuestions saved successfully"
                    });
                }

                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "EvaluationQuestions name can not be empty"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occurred,please retry : " + ex.Message
                });
            }
        }

        [HttpGet("getquestions")]
        public JsonResult GetEvaluationQuestions(string searchText, int sectionId, int? offset = null,
            int? itemsPerPage = null)
        {
            var response = new ReturnData<List<EvaluationQuestion>>();

            var query = new Query()
            {
                SearchText = searchText,
                EndDate = null,
                Skip = offset,
                StartDate = null,
                Take = itemsPerPage,
            };

            var data = _context
                .EvaluationQuestions
                .Where(q => q.EvaluationSectionId == sectionId)
                //.Include(n => n.EvaluationQuestionOptions)
                .OrderBy(n => n.Id)
                .ToList();

            response.TotalItems = data.Count;
            response.Data = data;
            return Json(response);
        }
    }
}