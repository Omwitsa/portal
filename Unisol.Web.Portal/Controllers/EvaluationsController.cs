using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Common.ViewModels.Evaluations;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class EvaluationsController : Controller
    {
        private readonly PortalCoreContext _context;
        private readonly TokenValidator _tokenValidator;
		private readonly IUnisolApiProxy _unisolApiProxy;
		public EvaluationsController(PortalCoreContext context, IUnisolApiProxy unisolApiProxy)
        {
            _context = context;
			_unisolApiProxy = unisolApiProxy;
			_tokenValidator = new TokenValidator(_context);
        }


        [HttpPost]
        [Route("addevaluation")]
        public JsonResult AddEvaluation(EvaluationViewModel evaluationViewModel)
        {
            try
            {
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });

                if (string.IsNullOrEmpty(evaluationViewModel.Evaluation.EvaluationName))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Evaluation name can not be empty"
					});

				var results = _unisolApiProxy.GetInstitutionInfo().Result;
				var jdata = new ProcessJsonReturnResults<dynamic>(results).UnisolApiData;
				string institutionInitials = jdata.Data?.subTitle ?? "";

				var multipleAnswers = "";
                var sections = new List<EvaluationSection>();
                foreach (var sec in evaluationViewModel.Sections)
                {
                    var question = new List<EvaluationQuestion>();
					sec.Questions.ForEach(q => {
						if(q.QuestionType == QuestionType.MultipleAnswers)
						{
							multipleAnswers = string.Join(")*(", q.MultiAnswers.Split(","));
						}

						if(q.QuestionType == QuestionType.MultipleOptions)
						{
							multipleAnswers = "Strongly Disagree)*(Disagree)*(Uncertain)*(Agree)*(Strongly Agree";
							if (institutionInitials.Equals("MUT"))
								multipleAnswers = "V. Poor)*(Poor)*(Fair)*(Good)*(Excellent";
						}
						if (q.QuestionType == QuestionType.YesNo)
							multipleAnswers = "Yes)*(No";
						question.Add(
							new EvaluationQuestion
							{
								QuestionDesc = q.Question,
								QuestionType = q.QuestionType,
								MultiAnswers = multipleAnswers,
							}
						);
					} );

                    sections.Add(new EvaluationSection
                    {
                        SectionName = sec.SectionName,
                        SectionDesc = sec.SectionDesc,
                        EvaluationQuestions = question
                    });
                }

                var evaluation = new Evaluation()
                {
                    EvaluationName = evaluationViewModel.Evaluation.EvaluationName,
                    EvaluationDesc = evaluationViewModel.Evaluation.EvaluationDesc,
                    EvaluationSections = sections
                };
                if (evaluationViewModel.Id.HasValue && evaluationViewModel.Id.Value > 0)
                {
                    var id = (int) evaluationViewModel.Id;
                    var eval = _context.Evaluations.FirstOrDefault(e => e.Id == id);
                    if (eval != null)
                    {
                        _context.Evaluations.Remove(eval);
                        _context.SaveChanges();
                    }

                    _context.Evaluations.Add(evaluation);
                    _context.SaveChanges();

                    return Json(new ReturnData<string>
                    {
                        Success = true,
                        Message = "Evaluation has been updated successfully"
                    });
                }
                else
                {
                    if (_context.Evaluations.Any(e => e.EvaluationName == evaluation.EvaluationName))
                    {
                        return Json(new ReturnData<string>
                        {
                            Success = false,
                            Message = "Sorry, Evaluation name exist. kindly use a different name"
						});
                    }

                    _context.Evaluations.Add(evaluation);
                }

                _context.SaveChanges();

                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Evaluation saved successfully"
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

		[HttpGet("getevaluations")]
        public JsonResult GetEvaluations(string searchText, int? offset = null, int? itemsPerPage = null)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });
			
			var response = new ReturnData<dynamic>();

            var query = new Query()
            {
                SearchText = searchText,
                EndDate = null,
                Skip = offset,
                StartDate = null,
                Take = itemsPerPage,
            };

            var data = _context
                .Evaluations.AsQueryable().AsNoTracking()
                .Where(WhereClause(query))
                .Where(e => e.Status)
                .Include(n => n.EvaluationSections)
                .ThenInclude(se => se.EvaluationQuestions)
                //.ThenInclude(op => op.EvaluationQuestionOptions)
                .OrderBy(n => n.Id)
                .ToList();

            response.TotalItems = data.Count;
            if (query.Skip.HasValue && query.Take.HasValue)
                data = data.Skip(query.Skip.Value).Take(query.Take.Value).ToList();

			var questionTypes = Enum.GetNames(typeof(QuestionType));
			response.Data = new { data, questionTypes };

			return Json(response);
        }

        [HttpGet("GetEvaluationInfo")]
        public JsonResult GetEvaluationInfo(int id)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });
            
            var response = new ReturnData<Evaluation>();
            var data = _context
                .Evaluations.AsQueryable().AsNoTracking()
                .Where(e => e.Id == id && e.Status)
                .Include(n => n.EvaluationSections)
                .ThenInclude(se => se.EvaluationQuestions)
                //.ThenInclude(op => op.EvaluationQuestionOptions)
                .OrderBy(n => n.Id)
                .FirstOrDefault();
            response.Data = data;
            return Json(response);
        }

        [HttpGet("deleteEvaluation")]
        public JsonResult DeleteEvaluation(int id)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });

            var evaluation = _context.Evaluations.FirstOrDefault(e => e.Id == id);
            if (evaluation == null)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "No evaluation was found"
                });
			var response = _context.EvaluationQuestionResponses.Any(r => r.EvaluationId == id);
			if (response)
				evaluation.Status = false;
			else
				_context.Remove(evaluation);

			_context.SaveChanges();
            return Json(new ReturnData<string>
            {
                Success = true,
                Message = "Evaluation deleted successfully"
            });

        }
        public Expression<Func<Evaluation, bool>> WhereClause(Query query)
        {
            var predicate = PredicateBuilder.True<Evaluation>();

            if (!string.IsNullOrEmpty(query.SearchText))
            {
                string searchParameter = query.SearchText.ToLower();
                var search = PredicateBuilder.False<Evaluation>();
                search = search.Or(p => p.EvaluationName.ToLower().Contains(searchParameter));
                search = search.Or(
                    p => p.EvaluationSections.Any(s => s.SectionName.ToLower().Contains(searchParameter)));
                predicate = predicate.And(search);
            }

            return predicate;
        }
        // GET: api/PortalEvaluations
    }
}