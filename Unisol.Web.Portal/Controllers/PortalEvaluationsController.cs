using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Common.ViewModels.Evaluations;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IRepository;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Models;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class PortalEvaluationsController : Controller
    {
        private InputValidator _validateService;
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly IEmailService _emailService;
        private readonly PortalCoreContext _context;
        private readonly IEmailConfiguration _emailConfiguration;
		private IPortalServices _portalServices;
		private readonly TokenValidator _tokenValidator;
        private string classStatus;

        public PortalEvaluationsController(PortalCoreContext context, IUnisolApiProxy unisolApiProxy, IEmailService emailService, 
			IEmailConfiguration emailConfiguration, IPortalServices portalServices)
        {
            _validateService = new InputValidator();
            _unisolApiProxy = unisolApiProxy;
            _context = context;
            _emailService = emailService;
			_portalServices = portalServices;
			_emailConfiguration = emailConfiguration;
            classStatus = _context.Settings.FirstOrDefault()?.ClassStatus;
            _tokenValidator = new TokenValidator(_context);
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
            if (response.Success)
            {
                return Json(response);
            }

            return Json(new ReturnData<SectionSearch>
            {
                Success = false,
                Message = response.Message
            });
        }


        [HttpGet("getPortalActiveEvaluations")]
        public JsonResult GetCurrentActiveEvaluations(string userCode)
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

                var result = _unisolApiProxy.GetStudentInfoWithDepartment(userCode, classStatus).Result;
                var studentDetailsWithDept = new ProcessJsonReturnResults<StudentAcademicViewModel>(result).UnisolApiData;


                var studentSemester = string.IsNullOrEmpty(studentDetailsWithDept.Data?.StudentSemester?.Semester) ?
                    EvaluationStaticMessages.AcrossMultipleYears : studentDetailsWithDept.Data?.StudentSemester?.Semester;
                var yearOfStudy = string.IsNullOrEmpty(studentDetailsWithDept.Data?.StudentSemester?.YearOfStudy) ?
                    EvaluationStaticMessages.AcrossMultipleYears : studentDetailsWithDept.Data?.StudentSemester?.YearOfStudy;

                var currentActive = _context
                    .EvaluationsCurrentActive
                    .Join(_context.EvaluationTargetGroups,
                        evaluationsCurrentActive => evaluationsCurrentActive.Id,
                        evaluationTargetGroups => evaluationTargetGroups.EvaluationsCurrentActiveId,
                        (evalCurrentAct, evalTtGrps) => new
                        {
                            evalCurrentAct.Status,
                            evalCurrentAct.StartDate,
                            evalCurrentAct.EndDate,
                            evalCurrentAct.EvaluationsId,
                            evalCurrentAct.EvaluationsCurrentId,
                            evalCurrentAct.Id,
                            evalTtGrps.Names,
                            evalTtGrps.Year
                        }
                    )
                    //.Where(e => e.Status && e.StartDate.Date <= DateTime.Now && e.EndDate.Date >= DateTime.Now.Date)
                    //.Where(e => (e.Names.Equals(studentDetailsWithDept.Data.StudentDeparment.Department)
                    //    || e.Names.Equals(studentDetailsWithDept.Data.StudentProgramme.Programme)
                    //    || e.Names.Equals(studentDetailsWithDept.Data.StudentClass.ClassName)
                    //    || e.Names == EvaluationStaticMessages.AcrossMultipleYears ? true : e.Names.ToLower().Equals(studentSemester.ToLower())
                    //)
                    //&& e.Year == EvaluationStaticMessages.AcrossMultipleYears ? true : e.Year == yearOfStudy
                    //)
                    .ToList();

                if (currentActive.Any())
                    return Json(new ReturnData<dynamic>
                    {
                        Success = true,
                        Message = "",
                        Data = currentActive
                    });

                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "We could not find an active evaluation",
                });

            }
            catch (Exception ex)
            {
                return Json(new ReturnData<dynamic>
                {
                    Success = false,
                    Message = "An error occured ,please try again",
                    Error = new Error(ex)
                });
            }
        }


        [HttpGet("getEvaluationQuestions")]
        public JsonResult GetEvaluationQuestions(int evaluationsId)
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

                var response = new ReturnData<dynamic>();
                var data = _context
                    .Evaluations.AsQueryable().AsNoTracking()
                    .Where(e => e.Status && e.Id == evaluationsId)
                    .Include(n => n.EvaluationSections)
                    .ThenInclude(se => se.EvaluationQuestions)
                    .OrderBy(n => n.Id)
                    .FirstOrDefault();

				var results = _unisolApiProxy.GetInstitutionInfo().Result;
				var jdata = new ProcessJsonReturnResults<dynamic>(results).UnisolApiData;

				var options = new List<MultipleOptions>();
				var resposeOptions = new string[] { "Strongly Disagree", "Disagree", "Uncertain", "Agree", "Strongly Agree" };
				string institutionInitials = jdata.Data?.subTitle ?? "";
				if (institutionInitials.Equals("MUT"))
					resposeOptions = new string[] { "V. Poor", "Poor", "Fair", "Good", "Excellent" };

				var optionValue = 1;
				resposeOptions.ToList().ForEach(r => {
					options.Add(new MultipleOptions
					{
						OptionName = r,
						OptionValue = optionValue++
					});
				});


				options = options.OrderByDescending(o => o.OptionValue).ToList();

				response.Data = new { data, options };

                if (data == null)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "No evaluation was found",
                    });
                }

                return Json(response);
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "No evaluation was found",
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
            var response = new ReturnData<List<EvaluationsCurrent>>();
            var query = new Query()
            {
                SearchText = searchText,
                EndDate = null,
                Skip = offset,
                StartDate = null,
                Take = itemsPerPage,
            };

            var data = _context
                .EvaluationsCurrents.AsQueryable().AsNoTracking()
                .Where(e => e.Status)
                .Include(n => n.EvaluationsCurrentActive)
                .ThenInclude(se => se.EvaluationTargetGroups)
                .OrderBy(n => n.Id)
                .ToList();


            response.TotalItems = _context.EvaluationsCurrents.Count();
            if (response.TotalItems > 0)
            {
                data.ForEach(cE =>
                {
                    cE.EvaluationsCurrentActive.ToList().ForEach(ea =>
                    {
                        ea.Status = ea.Status
                            ? DateTime.Now.Date <= ea.EndDate.Date && DateTime.Now.Date >= ea.StartDate.Date
                            : ea.Status;
                    });
                });
            }

            if (query.Skip.HasValue && query.Take.HasValue)
                data = data.Skip(query.Skip.Value).Take(query.Take.Value).ToList();
            response.Data = data;
            return Json(response);
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
                .Where(e => e.Status && e.Id == id)
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

        [HttpPost("SaveStudentSubjectResponse")]
        public JsonResult SaveStudentSubjectResponse(EvaluationsCurrentWithSubjectViewModel evaluationsCurrentWithSubject)
        {
			if (string.IsNullOrEmpty(evaluationsCurrentWithSubject.LecturerName))
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Kindly select unit lecturer"
				});
			if (evaluationsCurrentWithSubject.Evaluation.EvaluationSections.Count < 1)
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Please make sure you have answered all the questions",
				});

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

				var studentUnitDetails = _unisolApiProxy.GetStudentUnitDetails(evaluationsCurrentWithSubject.UserCode, evaluationsCurrentWithSubject.UnitCode, classStatus).Result;
				var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(studentUnitDetails);
				if (!jdata.Success)
					return Json(jdata);
				
				var user = _context.Users.FirstOrDefault(u => u.UserName == evaluationsCurrentWithSubject.UserCode);
				var hasRespondedToUnit = _context.EvaluationTakenUnitWiseByUsers.Any(u => u.AspNetUserId == user.Id && u.UnitCode.ToLower().Equals(evaluationsCurrentWithSubject.UnitCode.ToLower()));
				if (hasRespondedToUnit)
					return Json(new ReturnData<string>
					{
						Success = true,
						Message = "Thank you for filling the evaluation.",
					});

				var evaluationTakenUnitWiseByUser = new EvaluationTakenUnitWiseByUser
				{
					UnitCode = evaluationsCurrentWithSubject.UnitCode,
					EvaluationCurrentActiveId = evaluationsCurrentWithSubject.CurrentActiveEvaluationId,
					EvaluationId = evaluationsCurrentWithSubject.Evaluation.Id,
					AspNetUserId = user.Id,
					EvaluationCurrentId = evaluationsCurrentWithSubject.CurrentEvaluationId,
					AcademicYear = jdata.Data.academicYear,
					Semester = jdata.Data.semester,
					Campus = jdata.Data.campus,
					Department = jdata.Data.department,
					Programme = jdata.Data.programme,
					LecturerName = evaluationsCurrentWithSubject.LecturerName,
					Schools = jdata.Data.schools,
					Gender = jdata.Data.gender,
					YearOfStudy = jdata.Data.yearOfStudy,
					CertType = jdata.Data.certType
				};

				_context.EvaluationTakenUnitWiseByUsers.Add(evaluationTakenUnitWiseByUser);
				_context.SaveChanges();

				foreach (var evaluationsCurrentEvaluationSection in evaluationsCurrentWithSubject.Evaluation.EvaluationSections)
				{
					foreach (var evaluationQuestion in evaluationsCurrentEvaluationSection.EvaluationQuestions)
					{
						if(evaluationQuestion.QuestionType == QuestionType.MultipleOptions)
						{
							var responseWeight = Array.FindIndex(evaluationQuestion.MultiAnswers.Split(")*("), x => x.Contains(evaluationQuestion.QuestionResponse)) + 1;
							evaluationQuestion.QuestionResponse = responseWeight.ToString();
						}

						var questionResponse = new EvaluationQuestionResponse
						{
							DateCreated = DateTime.Now,
							EvaluationId = evaluationsCurrentWithSubject.Evaluation.Id,
							EvaluationSectionId = evaluationQuestion.EvaluationSectionId,
							SectionName = evaluationsCurrentEvaluationSection.SectionName,
							QuestionType = evaluationQuestion.QuestionType,
							UnitCode = evaluationsCurrentWithSubject.UnitCode,
							EvaluationQuestionId = evaluationQuestion.Id,
							QuestionResponse = evaluationQuestion.QuestionResponse,
							UserId = user.Id,
							EvaluationsCurrentActiveId = evaluationsCurrentWithSubject.CurrentActiveEvaluationId,
							EvaluationTakenUnitWiseByUserId = evaluationTakenUnitWiseByUser.Id,
						};
						_context.EvaluationQuestionResponses.Add(questionResponse);
					}
					_context.SaveChanges();
				}

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Thank you for filling the evaluation.",
				});
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Oops a server error occured,",
                });
            }
        }

		[HttpGet("GetRegisteredUnits")]
        public JsonResult GetRegisteredUnits(string userCode)
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

			var units = new List<dynamic>();
			var result = _unisolApiProxy.GetRegisteredUnits(userCode, classStatus).Result;
            var response = new ProcessJsonReturnResults<List<dynamic>>(result).UnisolApiData;
			if (!response.Success)
				return Json(response);
				
			var userId = _context.Users.FirstOrDefault(a => a.UserName == userCode)?.Id;
			
			response.Data.ForEach(u =>
				{
					string unitCode = u.code;
					var taken = _context.EvaluationTakenUnitWiseByUsers.Any(s => s.UnitCode == unitCode && s.AspNetUserId == userId);
					var newUnits = new
					{
						u.names,
						u.code,
						u.subjectType,
						u.department,
						u.closed,
						TakenEvaluation = taken,
						u.lecturers,
					};
					units.Add(newUnits);
				}
			);

			return Json(new ReturnData<dynamic>
			{
				Success = true,
				Message = response.Message,
				Data = units
			});
        }

        [HttpGet("GetEvaluationHistory")]
        public JsonResult GetEvaluationHistory(string usercode)
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
                var userId = _context.Users.FirstOrDefault(u => u.UserName == usercode)?.Id;
                if (userId == null)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Oops,seems an error occured retrieving your details"
                    });
                }

                var evaluationAndSubjects = _context.EvaluationTakenUnitWiseByUsers.Where(e => e.AspNetUserId == userId)
                    .ToList();
                if (evaluationAndSubjects.Count == 0)
                {
                    return Json(new ReturnData<SectionSearch>
                    {
                        Success = false,
                        Message = "Oops,seems you have taken an evaluation"
                    });
                }

                var evalHistory = new List<StudentEvaluationHistory>();

                var activeEvaluations = evaluationAndSubjects
                    .GroupBy(g => g.EvaluationCurrentActiveId)
                    .Select(grp => grp.First())
                    .ToList();

                activeEvaluations.ForEach(e =>
                {
                    var targetName = evaluationAndSubjects
                        .Join(_context.EvaluationTargetGroups,
                            evaluationsCurrentActive => evaluationsCurrentActive.EvaluationCurrentActiveId,
                            evaluationTargetGroups => evaluationTargetGroups.EvaluationsCurrentActiveId,
                            (evalCurrentAct, evalTtGrps) => new
                            {
                                evalCurrentAct.AspNetUserId,

                                evalCurrentAct.EvaluationCurrentId,
                                evalTtGrps.Names
                            }
                        )
                        .FirstOrDefault(eu =>
                            eu.AspNetUserId == e.AspNetUserId && eu.EvaluationCurrentId == e.EvaluationCurrentId);

                    var evaluationCurrentName = _context.EvaluationsCurrents
                        .FirstOrDefault(c => c.Id == targetName.EvaluationCurrentId)?
                        .CurrentEvaluationName;
                    var evaluationDetails = new StudentEvaluationHistory
                    {
                        EvaluationCurrentName = evaluationCurrentName ?? "Unspecified",
                        EvaluationCurrentTargetName = targetName?.Names ?? "Unspecified",
                    };
                    var units = new List<RespondedUnits>();

                    var unitResponded = evaluationAndSubjects
                        .Where(unit => unit.EvaluationCurrentActiveId == e.EvaluationCurrentActiveId)
                        .ToList();

                    unitResponded.ForEach(ur =>
                    {
                        units.Add(new RespondedUnits
                        {
                            UnitCode = ur.UnitCode,
                            DateCreated = ur.DateCreated,
                            UnitName = "",
                            TotalQuestions = 0,
                            TotalQuestionsRequired = 0
                        }
                        );
                    });
                    evaluationDetails.RespondedUnits = units;
                    evalHistory.Add(evaluationDetails);
                });


                return Json(new ReturnData<dynamic>
                {
                    Success = true,
                    Message = "Evaluations have been found",
                    Data = evalHistory
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Oops,seems an error occured from our side while fetching the information"
                });
            }
        }
	}
}