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
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class EvaluationSectionsController : Controller
    {
        private readonly PortalCoreContext _context;
        private readonly TokenValidator _tokenValidator;
        public EvaluationSectionsController(PortalCoreContext context)
        {
            _context = context;
            _tokenValidator = new TokenValidator(_context);
        }

        [HttpPost]
        [Route("addsection")]
        public JsonResult AddSection(EvaluationSectionViewModel evaluationSectionViewModel)
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
                if (!string.IsNullOrEmpty(evaluationSectionViewModel.SectionName))
                {
                    var evaluationSection = new EvaluationSection
                    {
                        SectionName = evaluationSectionViewModel.SectionName,
                        EvaluationId = evaluationSectionViewModel.EvaluationId,
                        EvaluationQuestions = evaluationSectionViewModel.EvaluationQuestions
                    };

                    if (evaluationSectionViewModel.Id.HasValue && evaluationSectionViewModel.Id.Value > 0)
                    {
                        evaluationSection.Id = (int)evaluationSectionViewModel.Id;
                        _context.EvaluationSections.Update(evaluationSection);
                    }
                    else
                    {
                        _context.EvaluationSections.Add(evaluationSection);
                    }
                    _context.SaveChangesAsync();

                    return Json(new ReturnData<string>
                    {
                        Success = true,
                        Message = "Section name saved successfully"
                    });
                }
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Section name cannot be empty"
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

        [HttpGet("getsections")]
        public JsonResult GetSections(string searchText, int evaluationId, int? offset = null, int? itemsPerPage = null)
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
            var response = new ReturnData<List<EvaluationSection>>();

            var query = new Query()
            {
                SearchText = searchText,
                EndDate = null,
                Skip = offset,
                StartDate = null,
                Take = itemsPerPage,
            };

            var data = _context
                .EvaluationSections.AsQueryable().AsNoTracking()
                .Where(s => s.EvaluationId == evaluationId)
                .Where(WhereClause(query))
                .Include(n => n.EvaluationQuestions)
                //.ThenInclude(se => se.EvaluationQuestionOptions)
                .OrderBy(n => n.Id)
                .ToList();


            response.TotalItems = data.Count;
            if (query.Skip.HasValue && query.Take.HasValue)
                data = data.Skip(query.Skip.Value).Take(query.Take.Value).ToList();
            response.Data = data;
            return Json(response);
        }

        public Expression<Func<EvaluationSection, bool>> WhereClause(Query query)
        {
            var predicate = PredicateBuilder.True<EvaluationSection>();

            if (!string.IsNullOrEmpty(query.SearchText))
            {
                string searchParameter = query.SearchText.ToLower();
                var search = PredicateBuilder.False<EvaluationSection>();
                search = search.Or(p => p.SectionName.ToLower().Contains(searchParameter));
                search = search.Or(p =>
                    p.EvaluationQuestions.Any(s => s.QuestionDesc.ToLower().Contains(searchParameter)));
                predicate = predicate.And(search);
            }

            return predicate;
        }


        // GET: api/PortalEvaluations
    }
}