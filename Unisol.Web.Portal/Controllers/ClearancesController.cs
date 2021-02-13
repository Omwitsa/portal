using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClearancesController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly TokenValidator _tokenValidator;
        private readonly PortalCoreContext _context;

        public ClearancesController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context)
        {
            _unisolApiProxy = unisolApiProxy;
            _context = context;
            _tokenValidator = new TokenValidator(_context);
        }

        [HttpPost("[action]")]
        public async Task<JsonResult> Apply(StudClearance clearance, Role role)
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

				if (string.IsNullOrEmpty(clearance.Notes))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly, provide clearance reason"
					});
				
				clearance.Personnel = clearance.AdmnNo;
				clearance.Rdate = DateTime.UtcNow.Date;
				clearance.Status = "Pending";
				var app = await _unisolApiProxy.ApplyClearance(clearance, role);
				var jdata = JsonConvert.DeserializeObject<ReturnData<string>>(app);
				return Json(jdata);
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred",
				});
			}
        }

        [HttpGet("[action]")]
        public async Task<JsonResult> GetHistory(string admnNo, Role role)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });

            var applications = await _unisolApiProxy.GetClearances(admnNo, role);
            var jdata = JsonConvert.DeserializeObject<ReturnData<List<StudClearance>>>(applications);
            return Json(jdata);
        }

		[HttpPost("[action]")]
		public async Task<JsonResult> CreateQuestionnaireTemplate(ClearanceQuestionnaireTemplate clearance)
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
				
				if(clearance.Id > 0)
				{
					var template = _context.ClearanceQuestionnaireTemplate.FirstOrDefault(t => t.Id == clearance.Id);
					var sections = _context.ClearanceQuestionSection
						.Where(s => s.ClearanceQuestionnaireTemplateId == clearance.Id).ToList();
					sections.ForEach(s =>
					{
						var questions = _context.ClearanceQuestion.Where(q => q.ClearanceQuestionSectionId == s.Id);
						_context.ClearanceQuestion.RemoveRange(questions);
					});

					_context.ClearanceQuestionSection.RemoveRange(sections);
					_context.ClearanceQuestionnaireTemplate.Remove(template);
				}

				_context.ClearanceQuestionnaireTemplate.Add(clearance);
				_context.SaveChanges();

				return Json(new ReturnData<string>{
					Success = true,
					Message = "Survey template saved successfully"
				});
			}
			catch (Exception ex)
			{
				return Json("");
			}
		}

		[HttpGet("[action]")]
		public async Task<JsonResult> GetSurveyTemplates()
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

				var surveyTemplates = _context.ClearanceQuestionnaireTemplate.ToList();
				var surveys = _context.ClearanceSurvey.ToList();
				var surveyStatus = new string[] { "Clearance before graduation", "Clearance after graduation" };
				return Json(new ReturnData<dynamic> {
					Success = true,
					Data = new
					{
						surveyTemplates,
						surveys,
						surveyStatus
					}
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpPost("[action]")]
		public async Task<JsonResult> CreateSurvey(ClearanceSurvey survey)
		{
			try
			{
				if (string.IsNullOrEmpty(survey.Name))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly enter evaluation name"
					});

				if (string.IsNullOrEmpty(survey.TempleteName))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly select evaluation template"
					});

				if (survey.StartTime == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly select start date"
					});
				
				if (survey.StartTime > survey.EndTime || survey.EndTime == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "End date must be grater than start date"
					});
				
				foreach(var clearanceSurvey in _context.ClearanceSurvey.ToList())
				{
					if (clearanceSurvey.Name.ToUpper().Equals(survey.Name.ToUpper()))
						return Json(new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, survey name already exist"
						});
				}

				_context.ClearanceSurvey.Add(survey);
				_context.SaveChanges();
				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Survey saved successfully"
				});
			}
			catch (Exception)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpGet("[action]")]
		public async Task<JsonResult> GetSurveys()
		{
			try
			{
				var survey = _context.ClearanceSurvey.OrderByDescending(c => c.Id).FirstOrDefault();
				var surveyTemplate = _context.ClearanceQuestionnaireTemplate
					.Where(t => t.Name.ToUpper().Equals(survey.TempleteName.ToUpper()))
					.Include(t => t.QuestionSections).ThenInclude(s => s.Questions).FirstOrDefault();

				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						survey.Name,
						surveyTemplate
					}
				});
			}
			catch (Exception)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpPost("[action]")]
		public async Task<JsonResult> ResponseToSurvey(ClearanceSurveyResponse response)
		{
			try
			{
				var survayResponse = _context.ClearanceSurveyResponse.Any(r => r.Admnno.ToUpper().Equals(response.Admnno.ToUpper()) && r.SurveyName.ToUpper().Equals(response.SurveyName.ToUpper()));
				if(survayResponse)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, you have already responded to this survey"
					});

				var survey = _context.ClearanceSurvey.FirstOrDefault(s => s.Name.ToUpper().Equals(response.SurveyName) 
				&& s.StartTime < DateTime.UtcNow.AddHours(3) && s.EndTime > DateTime.UtcNow.AddHours(3));
				//response.ClearanceStatus = survey?.Status ?? "";

				_context.ClearanceSurveyResponse.Add(response);
				_context.SaveChanges();
				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Survey submitted successfully"
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpGet("[action]")]
		public async Task<JsonResult> GetSurveyResponse(string usercode)
		{
			try
			{
				if (!_context.ClearanceSurveyResponse.Any(r => r.Admnno.ToUpper().Equals(usercode.ToUpper())))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly fill clearance survey first"
					});

				var surveyStatus = await _unisolApiProxy.GetSurveyStatus(usercode);
				var jdata = JsonConvert.DeserializeObject<ReturnData<string>>(surveyStatus);
				return Json(jdata);
			}
			catch (Exception)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpGet("[action]")]
		public async Task<JsonResult> GetCertificateDetails(string usercode, bool isStudent)
		{
			try
			{
				var certificateDetails = await _unisolApiProxy.GetCertificateDetails(usercode, isStudent);
				var usersDetails = JsonConvert.DeserializeObject<ReturnData<dynamic>>(certificateDetails);
				if (!usersDetails.Success)
					return Json(usersDetails);
				var certificateType = "CLEARANCE CERTIFICATE";
				var initial = $"{usersDetails.Data?.certificateDetails?.initials}";
				if (initial.ToUpper().Equals("KIBU"))
					certificateType = "Certificate of Clearance";

				return Json(new {
					certificateType = certificateType.ToUpper(),
					usersDetails = usersDetails.Data
				}); 
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpGet("[action]")]
		public async Task<JsonResult> GetSelectedTemplateDetails(int id)
		{
			try
			{
				var survey = _context.ClearanceQuestionnaireTemplate
					.Where(t => t.Id == id).Include(t => t.QuestionSections).ThenInclude(t => t.Questions).FirstOrDefault();
				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = survey
				});
			}
			catch (Exception)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpPost("[action]")]
		public async Task<JsonResult> CreateClearanceReason(ClearanceReason reason)
		{
			try
			{
				if(string.IsNullOrEmpty(reason.Reason))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly enter clearance reason"
					});

				if(_context.ClearanceReason.Any(r => r.Reason.ToUpper().Equals(reason.Reason.ToUpper())))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Reason already exist"
					});

				_context.ClearanceReason.Add(reason);
				_context.SaveChanges();

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Reason saved successfully"
				});
			}
			catch (Exception)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpGet("[action]")]
		public async Task<JsonResult> GetReasons()
		{
			try
			{
				var reasons = _context.ClearanceReason.ToList();
				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = reasons
				});
			}
			catch (Exception)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}
	}
}

