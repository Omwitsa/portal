using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Common.ViewModels.Evaluations;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Models;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class AdminEvaluationsResponseController : Controller
    {
        private readonly PortalCoreContext _context;
        private readonly TokenValidator _tokenValidator;
		private readonly IUnisolApiProxy _unisolApiProxy;
		public AdminEvaluationsResponseController(PortalCoreContext context, IUnisolApiProxy unisolApiProxy)
        {
            _context = context;
			_unisolApiProxy = unisolApiProxy;
			_tokenValidator = new TokenValidator(_context);
        }

        [HttpPost("GetCurrentActiveEvaluations")]
        public JsonResult GetCurrentActiveEvaluations(EvaluationFilter evaluationFilter)
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
                var currentActive = _context
					.EvaluationsCurrentActive
					.Join(_context.EvaluationsCurrents,
						evaluationsCurrentActive => evaluationsCurrentActive.EvaluationsCurrentId,
						evaluationCurrentEvaluation => evaluationCurrentEvaluation.Id,
						(evalCurrentAct, evalCurrent) => new
						{
							evalCurrentAct.Status,
							evalCurrentAct.StartDate,
							evalCurrentAct.EndDate,
							evalCurrentAct.EvaluationsId,
							evalCurrentAct.EvaluationsCurrentId,
							evalCurrentAct.Id,
							evalCurrentAct.EvaluationTarget,
							TotalUnits = _context
								.EvaluationTakenUnitWiseByUsers
								.Count(c => c.EvaluationCurrentActiveId == evalCurrentAct.Id),
							evalCurrent.CurrentEvaluationName,
						}
					)
					.Where(e => e.Status && e.StartDate.Date >= evaluationFilter.StartDate.Date
										 && evaluationFilter.EndDate == null ||
								e.EndDate.Date <= (evaluationFilter.EndDate ?? DateTime.Now.Date)).ToList();

				if (!string.IsNullOrEmpty(evaluationFilter.SearchText))
				{
					currentActive = currentActive.Where(e => e.CurrentEvaluationName.ToLower().Contains(evaluationFilter.SearchText)
											|| e.EvaluationTarget.Equals(evaluationFilter.SearchText)).ToList();
				}

				if (currentActive.Count > 0)
				{
					var student = new StudentAcademicViewModel();
					currentActive.ForEach(e =>
					{
						/**{  name: 'All', value: 0         },{ name: 'Year', value: 1 },
				         * {name: 'faculty', value: 2
				         },{name: 'department', value: 3 },  { name: 'programme',value: 4},{name: 'class',value: 5}, 
				        {name: 'student',value: 6}
				         */
					});
					return Json(new ReturnData<dynamic>
					{
						Success = true,
						Message = "",
						Data = currentActive
					});
				}

				return Json(new ReturnData<dynamic>
                {
                    Success = false,
                    Message = "Oops,seems you dont have an evaluation periods create between this dates",
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

		[HttpPost("GetEvaluationTargets")]
        public JsonResult GetEvaluationTargets(EvaluationResponseFilters selectedFilter, int currentActiveEvaluationId = 0)
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

				selectedFilter.AcademicYear = selectedFilter.AcademicYear ?? "";
				selectedFilter.Semester = selectedFilter.Semester ?? "";
				selectedFilter.UnitCode = selectedFilter.UnitCode ?? "";
				selectedFilter.LecturerName = selectedFilter.LecturerName ?? "";
				selectedFilter.Programme = selectedFilter.Programme ?? "";
				selectedFilter.Campus = selectedFilter.Campus ?? "";
				selectedFilter.Department = selectedFilter.Department ?? "";
				selectedFilter.LecturerEmpNo = selectedFilter.LecturerEmpNo ?? "";

				if (!string.IsNullOrEmpty(selectedFilter.LecturerEmpNo))
				{
					var result = _unisolApiProxy.GetUnitLecturer(selectedFilter.LecturerEmpNo).Result;
					var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
					selectedFilter.LecturerName = response.Data?.dname ?? "";
				}

				var target = _context.EvaluationTargetGroups
                    .Where(e => e.EvaluationsCurrentActiveId == currentActiveEvaluationId)
                    .ToList();

				var evaluationTaken = _context.EvaluationTakenUnitWiseByUsers.Where(u => u.EvaluationCurrentActiveId == currentActiveEvaluationId 
					&& u.AcademicYear.CaseInsensitiveContains(selectedFilter.AcademicYear) && u.Semester.CaseInsensitiveContains(selectedFilter.Semester) 
					&& u.UnitCode.CaseInsensitiveContains(selectedFilter.UnitCode) && u.LecturerName.CaseInsensitiveContains(selectedFilter.LecturerName) 
					&& u.Programme.CaseInsensitiveContains(selectedFilter.Programme) && u.Campus.CaseInsensitiveContains(selectedFilter.Campus) 
					&& u.Department.CaseInsensitiveContains(selectedFilter.Department)).ToList();

				var evaluationFilters = new
				{
					AcademicYear = evaluationTaken.Select(u => u.AcademicYear).Distinct().ToList(),
					Semester = evaluationTaken.Select(u => u.Semester).Distinct().ToList(),
					Campus = evaluationTaken.Select(u => u.Campus).Distinct().ToList(),
					CertType = evaluationTaken.Select(u => u.CertType).Distinct().ToList(),
					Department = evaluationTaken.Select(u => u.Department).Distinct().ToList(),
					LecturerName = evaluationTaken.Select(u => u.LecturerName).Distinct().ToList(),
					Programme = evaluationTaken.Select(u => u.Programme).Distinct().ToList(),
					Schools = evaluationTaken.Select(u => u.Schools).Distinct().ToList(),
					UnitCode = evaluationTaken.Select(u => u.UnitCode).Distinct().ToList(),
				};
				
				return Json(new ReturnData<dynamic> {
					Success = true,
					Data = new { target, evaluationFilters }
				});
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<dynamic>
                {
                    Success = false,
                    Message = "An error occured ,please try again ",
                    Error = new Error(ex)
                });
            }
        }

        [HttpPost("getEvaluationRespondedUnits")]
        public JsonResult GetEvaluationRespondedUnits(EvaluationResponseFilters selectedFilter, int currentActiveEvaluationId,  int offset = 0,string searchText=null)
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

				selectedFilter.AcademicYear = selectedFilter.AcademicYear ?? "";
				selectedFilter.Semester = selectedFilter.Semester ?? "";
				selectedFilter.UnitCode = selectedFilter.UnitCode ?? "";
				selectedFilter.LecturerName = selectedFilter.LecturerName ?? "";
				selectedFilter.Programme = selectedFilter.Programme ?? "";
				selectedFilter.Campus = selectedFilter.Campus ?? "";
				selectedFilter.Department = selectedFilter.Department ?? "";
				searchText = string.IsNullOrEmpty(searchText) ? "" : searchText;

				if (!string.IsNullOrEmpty(selectedFilter.LecturerEmpNo))
				{
					var result = _unisolApiProxy.GetUnitLecturer(selectedFilter.LecturerEmpNo).Result;
					var response = JsonConvert.DeserializeObject<ReturnData<dynamic>>(result);
					selectedFilter.LecturerName = response.Data?.dname ?? "";
				}

				var sectionWithMean = GetSectionMeans(selectedFilter.AcademicYear, selectedFilter.Semester, selectedFilter.UnitCode, 
					selectedFilter.LecturerName, selectedFilter.Programme, selectedFilter.Campus, selectedFilter.Department, currentActiveEvaluationId);
				var totalItems = _context
                    .EvaluationTakenUnitWiseByUsers.Count(n =>
                    (n.UnitCode.CaseInsensitiveContains(searchText) || n.TargetNames.CaseInsensitiveContains(searchText))&&
                        n.EvaluationCurrentActiveId == currentActiveEvaluationId
                    );

                return Json(sectionWithMean);
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<dynamic>
                {
                    Success = false,
                    Message = "An error occured ,please try again ",
                    Error = new Error(ex)
                });
            }
        }

		private ReturnData<dynamic> GetSectionMeans(string year, string sem, string unit, string lecturer, string programme, 
			string campus, string department, int currentActiveEvaluationId)
		{
			var questionResponse = _context.EvaluationTakenUnitWiseByUsers.Join(_context.EvaluationQuestionResponses,
				u => u.EvaluationCurrentActiveId,
				r => r.EvaluationsCurrentActiveId,
				(u, r) => new
				{
					u.EvaluationCurrentActiveId,
					u.AcademicYear,
					r.UserId,
					u.Semester,
					u.UnitCode,
					RespondedUnit = r.UnitCode,
					u.LecturerName,
					u.AspNetUserId,
					u.Programme,
					u.Campus,
					u.CertType,
					u.Department,
					u.Gender,
					u.Schools,
					r.SectionName,
					r.QuestionType,
					r.QuestionResponse,
					r.EvaluationQuestionId
				})
				.Where(r => r.EvaluationCurrentActiveId == currentActiveEvaluationId && r.AcademicYear.ToLower().Contains(year.ToLower()) 
				&& r.Semester.ToLower().Contains(sem.ToLower()) && r.UnitCode.ToLower().Contains(unit.ToLower()) && r.LecturerName.ToLower().Contains(lecturer.ToLower()) 
				&& r.Programme.ToLower().Contains(programme.ToLower()) && r.Campus.ToLower().Contains(campus.ToLower()) 
				&& r.Department.ToLower().ToLower().Contains(department.ToLower()) && r.UnitCode.ToLower().Equals(r.RespondedUnit.ToLower()) 
				&& r.AspNetUserId == r.UserId).ToList();

			var sectionResponse = questionResponse.GroupBy(s => s.SectionName).ToList();

			var sectionResponseList = new List<EvaluationSectionResponse>();
			sectionResponse.ForEach(s => {
				var questionResponses = new List<QuestionResponse>();
				var questions = s.ToList().GroupBy(q => q.EvaluationQuestionId).ToList();
				questions.ForEach(q => {
					var questionResp = new QuestionResponse();
					questionResp.StronglyAgree = q.Where(r => r.QuestionResponse == "5").Count();
					questionResp.Agree = q.Where(r => r.QuestionResponse == "4").Count();
					questionResp.Uncertain = q.Where(r => r.QuestionResponse == "3").Count();
					questionResp.Disagree = q.Where(r => r.QuestionResponse == "2").Count();
					questionResp.StronglyDisagree = q.Where(r => r.QuestionResponse == "1").Count();
					questionResp.TextResponse = q.Where(r => r.QuestionType == QuestionType.Text).Select(r => r.QuestionResponse).Distinct().ToList();
					questionResp.TotalQuestions = questionResp.StronglyAgree + questionResp.Agree + questionResp.Uncertain + questionResp.Disagree + questionResp.StronglyDisagree;
					questionResp.Students = q.Select(stu => stu.AspNetUserId).Distinct().ToList().Count();
					questionResp.QuestionType = q.FirstOrDefault()?.QuestionType;

					var questionTotalScores = (questionResp.StronglyAgree * 5) + (questionResp.Agree * 4) + (questionResp.Uncertain * 3) + (questionResp.Disagree * 2) + (questionResp.StronglyDisagree * 1);
					var questionMean = (double)questionTotalScores / questionResp.TotalQuestions;
					questionResp.Mean = Math.Round(questionMean, 2);
					questionResp.Question = _context.EvaluationQuestions.FirstOrDefault(e => e.Id == q.Key)?.QuestionDesc;
					
					questionResponses.Add(questionResp);
				});

				var sectionResp = new EvaluationSectionResponse();
				sectionResp.QuestionResponses = questionResponses;

				sectionResp.StronglyAgree = s.Where(r => r.QuestionResponse == "5").Count();
				sectionResp.Agree = s.Where(r => r.QuestionResponse == "4").Count();
				sectionResp.Uncertain = s.Where(r => r.QuestionResponse == "3").Count();
				sectionResp.Disagree = s.Where(r => r.QuestionResponse == "2").Count();
				sectionResp.StronglyDisagree = s.Where(r => r.QuestionResponse == "1").Count();

				sectionResp.Questions = sectionResp.StronglyAgree + sectionResp.Agree + sectionResp.Uncertain + sectionResp.Disagree + sectionResp.StronglyDisagree;
				sectionResp.Students = s.Select(sr => sr.AspNetUserId).Distinct().ToList().Count();
				var sectionTotalScores = (sectionResp.StronglyAgree * 5) + (sectionResp.Agree * 4) + (sectionResp.Uncertain * 3) + (sectionResp.Disagree * 2) + (sectionResp.StronglyDisagree * 1);
				var sectionMean = (double)sectionTotalScores / sectionResp.Questions;
				sectionResp.Mean = Math.Round(sectionMean, 2);
				sectionResp.SectionName = s.Key;
				sectionResponseList.Add(sectionResp);
			});

			var sectionWithMean = sectionResponseList.Where(r => r.Mean > 0).ToList();
			var totalMean = sectionWithMean.Select(r => r.Mean).Sum();
			totalMean = totalMean == 0 ? 1 : totalMean;

			var numberOfSections = sectionWithMean.ToList().Count == 0 ? 1 : sectionWithMean.ToList().Count;
			var overAllMean = Math.Round((totalMean / numberOfSections), 2);

			//response.Sections = sectionWithMean.ToList();
			//return sectionWithMean;

			return new ReturnData<dynamic>
			{
				Success = true,
				Data = new { sectionResponse = sectionResponseList, overAllMean }
			};
		}
	}
}