using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Evaluations;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IRepository;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class CurrentEvaluationsController : Controller
    {
        private InputValidator _validateService;
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly IEmailService _emailService;
        private readonly PortalCoreContext _context;
        private readonly IEmailConfiguration _emailConfiguration;
		private IPortalServices _portalServices;
        private readonly TokenValidator _tokenValidator;

        public CurrentEvaluationsController(PortalCoreContext context, IUnisolApiProxy unisolApiProxy, IEmailService emailService, 
			IEmailConfiguration emailConfiguration, IPortalServices portalServices)
        {
            _validateService = new InputValidator();
            _unisolApiProxy = unisolApiProxy;
            _context = context;
            _emailService = emailService;
            _emailConfiguration = emailConfiguration;
			_portalServices = portalServices;
            _tokenValidator = new TokenValidator(_context);
        }

        [HttpPost]
        [Route("SearchEvaluationTarget")]
        public JsonResult SearchEvaluationTarget(SectionSearchViewModel evaluationViewModel)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });

            var result = _unisolApiProxy.ReturnEvaluationTargetSearch(evaluationViewModel).Result;
            var response = new ProcessJsonReturnResults<List<SectionSearch>>(result).UnisolApiData;
			return Json(response);
        }

        [HttpGet("GetAcademicYears")]
        public JsonResult GetAcademicYears()
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
            var result = _unisolApiProxy.GetAcademicYears().Result;
            var response = new ProcessJsonReturnResults<List<SectionSearch>>(result).UnisolApiData;
			return Json(response);
		}

        [HttpGet("GetSemester")]
        public JsonResult GetSemester(int yearId)
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
            var result = _unisolApiProxy.GetSemesters(yearId).Result;
            var response = new ProcessJsonReturnResults<List<Term>>(result).UnisolApiData;
			return Json(response);
		}

        [HttpGet("GetStudentYearsOfStudy")]
        public JsonResult GetStudentYearsOfStudy()
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
            var result = _unisolApiProxy.GetStudentYearsOfStudy().Result;
            var response = new ProcessJsonReturnResults<dynamic>(result).UnisolApiData;
			return Json(response);
		}

        [HttpGet("GetStudentAcademicSemstersOfStudy")]
        public JsonResult GetStudentAcademicSemstersOfStudy()
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
            var result = _unisolApiProxy.GetStudentAcademicSemstersOfStudy().Result;
            var response = new ProcessJsonReturnResults<dynamic>(result).UnisolApiData;
			return Json(response);
		}

		[HttpPost]
		[Route("editcurrentevaluation")]
		public JsonResult editcurrentevaluation(CurrentEvaluationViewModel currentEvaluationViewModel, int id)
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

                var currentEvaluation = _context.EvaluationsCurrents.FirstOrDefault(c => c.Id == id);
				currentEvaluation.CurrentEvaluationName = currentEvaluationViewModel.CurrentEvaluationName;
				currentEvaluation.EvaluationId = currentEvaluationViewModel.EvaluationId;
				currentEvaluation.EvaluationTarget = Convert.ToInt32(currentEvaluationViewModel.Level);
				currentEvaluation.YearId = currentEvaluationViewModel.YearId;
				currentEvaluation.Status = currentEvaluationViewModel.Status;
				currentEvaluation.StartDate = currentEvaluationViewModel.StartDate;
				currentEvaluation.EndDate = currentEvaluationViewModel.EndDate;

				_context.EvaluationsCurrents.Update(currentEvaluation);
				_context.SaveChanges();

				var evaluationCurrentActive = _context.EvaluationsCurrentActive.FirstOrDefault(a => a.Id == id);
				evaluationCurrentActive.EvaluationsCurrentId = currentEvaluation.Id;
				evaluationCurrentActive.EvaluationsId = currentEvaluation.EvaluationId;
				evaluationCurrentActive.Status = currentEvaluation.Status;
				evaluationCurrentActive.StartDate = currentEvaluation.StartDate;
				evaluationCurrentActive.EvaluationTarget = currentEvaluation.EvaluationTarget;
				evaluationCurrentActive.EndDate = currentEvaluation.EndDate;
				evaluationCurrentActive.IsMandatory = currentEvaluationViewModel.IsMandatory;
				evaluationCurrentActive.IsElearnigEvaluation = currentEvaluationViewModel.IsElearnigEvaluation;

				_context.EvaluationsCurrentActive.Update(evaluationCurrentActive);
				_context.SaveChanges();

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Current Evaluation has been updated successfully"
				});
			}
			catch(Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "An error occurred,please retry : " + ex.Message
				});
			}
		}

		[HttpPost]
        [Route("savecurrentevaluation")]
        public JsonResult SaveCurrentEvaluation(CurrentEvaluationViewModel currentEvaluationViewModel)
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
                
                if (string.IsNullOrEmpty(currentEvaluationViewModel.CurrentEvaluationName))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Evaluation Name name can not be empty"
					});
                
                var currentEvaluation = new EvaluationsCurrent
                {
                    CurrentEvaluationName = currentEvaluationViewModel.CurrentEvaluationName,
                    EvaluationId = currentEvaluationViewModel.EvaluationId,
                    EvaluationTarget = Convert.ToInt32(currentEvaluationViewModel.Level),
                    //SemesterId = currentEvaluationViewModel.SemesterId,
                    YearId = currentEvaluationViewModel.YearId,
                    Status = currentEvaluationViewModel.Status,
                    StartDate = currentEvaluationViewModel.StartDate,
                    EndDate = currentEvaluationViewModel.EndDate,
                };

                if (ModelState.IsValid)
                {
                    _context.EvaluationsCurrents.Add(currentEvaluation);
                }
				
				if(_context.SaveChanges() < 1)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Current evaluation not found"
					});

				var evaluationCurrentActive = new EvaluationsCurrentActive
				{
					EvaluationsCurrentId = currentEvaluation.Id,
					EvaluationsId = currentEvaluation.EvaluationId,
					Status = currentEvaluation.Status,
					IsElearnigEvaluation = currentEvaluationViewModel.IsElearnigEvaluation,
					StartDate = currentEvaluation.StartDate,
					EvaluationTarget = currentEvaluation.EvaluationTarget,
					EndDate = currentEvaluation.EndDate,
					IsMandatory = currentEvaluationViewModel.IsMandatory,
				};

				var yearOfStudy = "All Years Of Study";
				yearOfStudy = string.IsNullOrEmpty(currentEvaluationViewModel.YearOfStudy) ? yearOfStudy : currentEvaluationViewModel.YearOfStudy;

				if (currentEvaluationViewModel.Levels.Count > 0)
                {
                    var evaluationGroups = new List<EvaluationTargetGroup>();
                    currentEvaluationViewModel.Levels.ForEach(
                        l =>
                        {
                            evaluationGroups.Add(
                                new EvaluationTargetGroup
                                {
                                    EvaluationsCurrentId = currentEvaluation.Id,
                                    TargetType = Convert.ToInt32(l.Level),
                                    ReferenceId = l.Id,
                                    Names = l.Names,
                                    TargetGroupId = Convert.ToInt32(l.Level) == 5 ? 0 : Convert.ToInt32(l.Id),
                                    Year = yearOfStudy
                                }
                            );
                        });
                          
                    evaluationCurrentActive.EvaluationTargetGroups = evaluationGroups;
                }
                else
                {
                    var listEvaluationGroups = new List<EvaluationTargetGroup>();
                    var evaluationGroups = new EvaluationTargetGroup();
                    if (!string.IsNullOrEmpty(currentEvaluationViewModel.Semester))
                    {
                        evaluationGroups = new EvaluationTargetGroup
                        {
                            EvaluationsCurrentId = currentEvaluation.Id,
                            TargetType = 1,
                            ReferenceId = currentEvaluation.SemesterId+"",
                            Names = currentEvaluationViewModel.Semester,
                            Year=yearOfStudy,
                            TargetGroupId = 0
                        };
                    }
                    else
                    {
                        evaluationGroups = new EvaluationTargetGroup
						{
							EvaluationsCurrentId = currentEvaluation.Id,
							TargetType = 0,
							ReferenceId = "Academic Years Target",
							Names = yearOfStudy,
							TargetGroupId = 0,
							Year = yearOfStudy
                        };
                    }
                    listEvaluationGroups.Add(evaluationGroups);
                    evaluationCurrentActive.EvaluationTargetGroups = listEvaluationGroups;
                }

				_context.EvaluationsCurrentActive.Add(evaluationCurrentActive);
				_context.SaveChanges();
				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Current Evaluation has been saved successfully"
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

        [HttpGet("getcurrentevaluations")]
        public JsonResult GetCurrentEvaluations(string searchText, int? offset = null, int? itemsPerPage = null)
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
            return Json(_portalServices.GetCurrentEvaluations(searchText, offset, itemsPerPage));
        }

        [HttpPost("SaveActiveEvaluation")]
        public JsonResult SaveActiveEvaluation(EvaluationsCurrentActive evaluationsCurrentActive)
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
                var checkActive = _context
                    .EvaluationsCurrentActive
                    .Any(
                        a => (a.EndDate.Date >= evaluationsCurrentActive.StartDate.Date &&
                              a.StartDate.Date <= evaluationsCurrentActive.StartDate.Date
                              || a.EndDate.Date >= evaluationsCurrentActive.EndDate.Date &&
                              a.StartDate.Date <= evaluationsCurrentActive.EndDate.Date)
                             && a.EvaluationsCurrentId == evaluationsCurrentActive.EvaluationsCurrentId
                    );
                if (checkActive)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "There is an Evaluation between " + evaluationsCurrentActive.StartDate.Date +
                                  " and " + evaluationsCurrentActive.EndDate.Date
                    });
                }

                /*make this distinct*/
                var targetGroups = _context.EvaluationTargetGroups
                    
                    .Where(g => g.EvaluationsCurrentId == evaluationsCurrentActive.EvaluationsCurrentId)
                    .GroupBy(g => g.EvaluationsCurrentId)
                    .Select(s => s.First())
                    .ToList();
                var targetGroupsClass = new List<EvaluationTargetGroup>();
                targetGroups.ForEach(p =>
                {
                    targetGroupsClass.Add(new EvaluationTargetGroup
                    {
                        Names = p.Names,
                        EvaluationsCurrentId = p.EvaluationsCurrentId,
                        ReferenceId = p.ReferenceId,
                        TargetGroupId = p.TargetGroupId,
                        TargetType = p.TargetType,
                    });
                });

                if (targetGroups.Count > 0)
                    evaluationsCurrentActive.EvaluationTargetGroups = targetGroupsClass;


                _context.EvaluationsCurrentActive.Add(evaluationsCurrentActive);

                _context.SaveChanges();
                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Active Evaluation has been saved successfully"
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


        [HttpGet("GetCurrentEvaluationInfo")]
        public JsonResult GetCurrentEvaluationInfo([FromQuery] int id)
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
            var response = new ReturnData<EvaluationsCurrent>();
            var data = _context
                .EvaluationsCurrents
                .Where(e => e.Id == id)
                .Include(n => n.EvaluationsCurrentActive)
                .ThenInclude(se => se.EvaluationTargetGroups)
                .OrderBy(n => n.Id)
                .FirstOrDefault();


            return Json(new ReturnData<EvaluationsCurrent>
            {
                Data = data,
                Success = data != null,
                Message = data != null ? "Evaluation Found" : "We could not find evaluation you looking for"
            });
        }

        [HttpGet("DeleteCurrentEvaluation")]
        public JsonResult DeleteCurrentEvaluation([FromQuery] int id)
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
                var evaluation = _context.EvaluationsCurrents.FirstOrDefault(e => e.Id == id);
                if (evaluation == null)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "No Current evaluation was found"
                    });
                evaluation.Status = false;
                _context.EvaluationsCurrents.Remove(evaluation);
                _context.SaveChanges();
                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Current Evaluation Removed Successfully"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An Error occured : " + ex.Message
                });
            }
        }
		
        public JsonResult GetUnitsResponded(int currentActiveEvaluationId)
        {
            var units = _context.EvaluationTakenUnitWiseByUsers
                .Where(g=>g.EvaluationCurrentActiveId== currentActiveEvaluationId)
                .ToList();

            if (units.Any())
            {

            }

            return Json(new  { });
        }
    }
}