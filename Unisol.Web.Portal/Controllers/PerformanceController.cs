using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Models;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly TokenValidator _tokenValidator;
        private PortalCoreContext _context;
        private IConfiguration _configuration;
        public PerformanceController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context, IConfiguration configuration)
        {
            _context = context;
            _unisolApiProxy = unisolApiProxy;
            _tokenValidator = new TokenValidator(context);
            _configuration = configuration;
        }

        [HttpGet("getPerformanceTemplate")]
        public JsonResult GetPerformanceTemplate()
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

                var performance = _context.StaffPerformance.ToList();
                return Json(new ReturnData<List<StaffPerformance>> { 
                    Success = true,
                    Data = performance
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string> { 
                    Success = false,
                    Message = "Sorry, An error occurred"
                });
            }
        }

        [HttpPost("[action]")]
        public JsonResult AddTemplate([FromBody] StaffPerformance performanceTemplate)
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

                if(performanceTemplate.Id < 1)
                {
                    performanceTemplate.DateCreated = DateTime.UtcNow.AddHours(3);
                    performanceTemplate.DateModified = DateTime.UtcNow.AddHours(3);
                    var nameExists = _context.StaffPerformance.Any(p => p.Name.ToUpper().Equals(performanceTemplate.Name.ToUpper()));
                    if (nameExists)
                        return Json(new ReturnData<string>
                        {
                            Success = false,
                            Message = "Sorry, Template name already exist"
                        });
                }
                else
                {
                    performanceTemplate.DateModified = DateTime.UtcNow.AddHours(3);
                    var template = _context.StaffPerformance.FirstOrDefault(p => p.Id == performanceTemplate.Id);
                    if (template == null)
                        return Json(new ReturnData<string>
                        {
                            Success = false,
                            Message = "Sorry, template not found"
                        });

                    var sections = _context.PerformanceSection.Where(p => p.StaffPerformanceId == template.Id).ToList();
                    _context.PerformanceSection.RemoveRange(sections);

                    var questionnaire = _context.PerformanceQuestionnaire.Where(q => q.StaffPerformanceId == template.Id);
                    _context.PerformanceQuestionnaire.RemoveRange(questionnaire);

                    _context.StaffPerformance.Remove(template);
                }

                _context.StaffPerformance.Add(performanceTemplate);
                _context.SaveChanges();
                return Json(new ReturnData<string> { 
                    Success = true,
                    Message = "Performance template saved Successfully"
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

        [HttpGet("getTemplateById")]
        public JsonResult GetTemplateById(int id)
        {
            try
            {
                var template = _context.StaffPerformance.Where(p => p.Id == id)
                    .Include(p => p.PerformanceQuestionnaire)
                    .Include(p => p.PerformanceSections).FirstOrDefault();
                    
                return Json(new ReturnData<StaffPerformance>
                {
                    Success = true,
                    Data = template
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
        public JsonResult DeleteTemplate([FromBody] StaffPerformance template)
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

                if (template.Id < 1)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Sorry, template not found"
                    });

                var performanceTemplate = _context.StaffPerformance.FirstOrDefault(p => p.Id == template.Id);
                if (performanceTemplate == null)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Sorry, template not found"
                    });

                var sections = _context.PerformanceSection.Where(p => p.StaffPerformanceId == template.Id).ToList();
                _context.PerformanceSection.RemoveRange(sections);

                var questionnaire = _context.PerformanceQuestionnaire.Where(q => q.StaffPerformanceId == template.Id);
                _context.PerformanceQuestionnaire.RemoveRange(questionnaire);

                _context.StaffPerformance.Remove(performanceTemplate);
                _context.SaveChanges();
                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Template Deleted Successfully"
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
        public JsonResult AddGrade([FromBody] PerformanceGrade performanceGrade)
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

                if (string.IsNullOrEmpty(performanceGrade.Range))
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Kindly provide the range"
                    });

                if (performanceGrade.Id < 1)
                    _context.PerformanceGrade.Add(performanceGrade);
                else
                {
                    var grade = _context.PerformanceGrade.FirstOrDefault(p => p.Id == performanceGrade.Id);
                    if (grade == null)
                        return Json(new ReturnData<string>
                        {
                            Success = false,
                            Message = "Sorry, Item not found"
                        });

                    grade.Range = performanceGrade.Range;
                    grade.Description = performanceGrade.Description;
                }

                _context.SaveChanges();
                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Grade saved Successfully"
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
        public JsonResult DeleteGrade([FromBody] PerformanceGrade performanceGrade)
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

                if (performanceGrade.Id < 1)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Sorry, Item not found"
                    });
                
                var grade = _context.PerformanceGrade.FirstOrDefault(p => p.Id == performanceGrade.Id);
                if(grade == null)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Sorry, Item not found"
                    });

                _context.PerformanceGrade.Remove(grade);
                _context.SaveChanges();
                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Grade Deleted Successfully"
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

        [HttpGet("getGrades")]
        public JsonResult GetGrades()
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

                var grades = _context.PerformanceGrade.ToList();
                return Json(new ReturnData<List<PerformanceGrade>>
                {
                    Success = true,
                    Data = grades
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

        [HttpGet("getPerformances")]
        public JsonResult GetPerformances()
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

                var performances = _context.PerformanceSession.ToList();
                return Json(new ReturnData<List<PerformanceSession>>
                {
                    Success = true,
                    Data = performances
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
        public JsonResult AddPerformance([FromBody] PerformanceSession performance)
        {
            try
            {
                performance.StartDate = performance.StartDate.GetValueOrDefault().AddDays(1);
                performance.EndDate = performance.EndDate.GetValueOrDefault().AddDays(1);
                if (string.IsNullOrEmpty(performance.Name))
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Kindly provide performance name"
                    });

                if (string.IsNullOrEmpty(performance.TemplateName))
                    return Json(new ReturnData<string> { 
                        Success = false,
                        Message = "Kindly select template name"
                    });

                if(performance.StartDate == null)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Kindly provide start date"
                    });

                if (performance.EndDate == null)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Kindly provide end date"
                    });

                if (performance.StartDate > performance.EndDate)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Sorry, start date cannot be greater than end date"
                    });

                if (performance.EndDate < DateTime.UtcNow)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "End date must be greater than today"
                    });

                var conflict = _context.PerformanceSession.Any(p => p.EndDate >= performance.StartDate && p.StartDate <= performance.EndDate && p.Id != performance.Id);
                if(conflict)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "There is an eveluation scheduled at this time"
                    });

                if (performance.Id < 1)
                {
                    var performanceExist = _context.PerformanceSession.Any(p => p.Name.ToUpper().Equals(performance.Name.ToUpper()));
                    if(performanceExist)
                        return Json(new ReturnData<string>
                        {
                            Success = false,
                            Message = "Sorry, name already exist"
                        });

                    _context.PerformanceSession.Add(performance);
                }
                else
                {
                    var performanceSession = _context.PerformanceSession.FirstOrDefault(p => p.Id == performance.Id);
                    if (performanceSession == null)
                        return Json(new ReturnData<string>
                        {
                            Success = false,
                            Message = "Sorry, Item not found"
                        });

                    performanceSession.Name = performance.Name;
                    performanceSession.TemplateName = performance.TemplateName;
                    performanceSession.StartDate = performance.StartDate;
                    performanceSession.EndDate = performance.EndDate;
                }
                
                _context.SaveChanges();
                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Performance Saved successfully"
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
        public JsonResult DeletePerformance([FromBody] PerformanceSession performance)
        {
            try
            {
                if (performance.Id < 1)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Sorry, Item not found"
                    });

                var performanceSession = _context.PerformanceSession.FirstOrDefault(p => p.Id == performance.Id);
                if (performanceSession == null)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Sorry, Item not found"
                    });

                _context.PerformanceSession.Remove(performanceSession);
                _context.SaveChanges();
                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Performance session deleted successfully"
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

        [HttpGet("getPerformance")]
        public JsonResult GetPerformance(string usercode)
        {
            try
            {
                usercode = usercode ?? "";
                var performance = _context.PerformanceSession.FirstOrDefault(p => p.StartDate < DateTime.UtcNow.AddHours(3) && p.EndDate > DateTime.UtcNow.AddHours(3));
                var template = _context.StaffPerformance.Where(p => p.Name.ToUpper().Equals(performance.TemplateName.ToUpper()))
                    .Include(p => p.PerformanceQuestionnaire)
                    .Include(p => p.PerformanceSections).FirstOrDefault();

                var performanceResponse = _context.StaffPerformanceResponse
                    .Where(r => r.PerformanceSessionId == performance.Id && r.EmpNo.ToUpper().Equals(usercode.ToUpper()))
                    .Include(r => r.PerformanceActivityResponse)
                    .Include(r => r.PerformanceQuestionnaireResponse)
                    .Include(r => r.PerformanceTraining)
                    .OrderByDescending(r => r.CreatedDate).ToList();

                var totals = GetScores(performanceResponse);
                var response = _unisolApiProxy.GetStaffData(usercode).Result;
                var employeeDetails = JsonConvert.DeserializeObject<ReturnData<dynamic>>(response);
                var target = _context.PerformanceTarget.Where(t => t.EmpNo.ToUpper().Equals(usercode.ToUpper()) && t.PerformanceSessionId == performance.Id)
                    .Include(t => t.PerformanceTargetDetail).FirstOrDefault();

                return Json(new ReturnData<dynamic>
                {
                    Success = true,
                    Data = new
                    {
                        performance,
                        template,
                        employeeDetails = employeeDetails.Data,
                        performanceResponse,
                        scores = totals.Data,
                        target
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

        private ReturnData<dynamic> GetScores(List<StaffPerformanceResponse> performanceResponses)
        {
            var selfScoreTotal = 0.0;
            var finalScoreTotal = 0.0;
            var weightTotal = 0.0;

            var sectionResponses = new List<dynamic>();
            try
            {
                performanceResponses.ForEach(p =>
                {
                    if (p != null)
                    {
                        var groupedResponses = p.PerformanceActivityResponse.GroupBy(r => r.PerformanceSectionId).ToList();
                        groupedResponses.ForEach(s =>
                        {
                            var sectionSelfScore = 0.0;
                            var sectionFinalScore = 0.0;
                            var sectionWeight = 0.0;

                            s.ToList().ForEach(r => {
                                r.FinalScore = r.FinalScore ?? 0;
                                sectionSelfScore = sectionSelfScore + (double)r.SelfScore;
                                sectionFinalScore = sectionFinalScore + (double)r.FinalScore;
                                sectionWeight = sectionWeight + (double)r.Weight;
                            });

                            selfScoreTotal = selfScoreTotal + sectionSelfScore;
                            finalScoreTotal = finalScoreTotal + sectionFinalScore;
                            weightTotal = weightTotal + sectionWeight;

                            var sectionName = _context.PerformanceSection.FirstOrDefault(ps => ps.Id == s.Key)?.Name ?? "";
                            sectionSelfScore = (sectionSelfScore * 100) / sectionWeight;
                            sectionFinalScore = (sectionFinalScore * 100) / sectionWeight;
                            sectionSelfScore = Math.Round(sectionSelfScore, 2);
                            sectionFinalScore = Math.Round(sectionFinalScore, 2);
                            sectionResponses.Add(new
                            {
                                sectionName,
                                sectionSelfScore,
                                sectionFinalScore
                            });

                        });
                    }
                    
                    selfScoreTotal = (selfScoreTotal * 100) / weightTotal;
                    finalScoreTotal = (finalScoreTotal * 100) / weightTotal;
                    selfScoreTotal = Math.Round(selfScoreTotal, 2);
                    finalScoreTotal = Math.Round(finalScoreTotal, 2);
                });

                return new ReturnData<dynamic>
                {
                    Data = new
                    {
                        sectionResponses,
                        totals = new {
                            selfScoreTotal,
                            finalScoreTotal
                        },
                    }
                };
            }
            catch (Exception)
            {
                return new ReturnData<dynamic>
                {
                    Data = new
                    {
                        selfScoreTotal,
                        finalScoreTotal
                    }
                };
            }
        }

        [HttpPost("[action]")]
        public JsonResult Response([FromBody] PerformanceRespVm performanceResp)
        {
            try
            {
                if (!performanceResp.IsSupervisor)
                {
                    var target = _context.PerformanceTarget.FirstOrDefault(t => t.Id == performanceResp.TargetId && t.Status == "FinalEntry");
                    if(target != null)
                    {
                        target.Status = "Accepted";
                        _context.SaveChanges();

                        return Json(new ReturnData<string>
                        {
                            Success = true,
                            Message = "Accepted successfully"
                        });
                    }
                }
                var activityResponses = new List<PerformanceActivityResponse>();
                performanceResp.Template.PerformanceSections.ToList().ForEach(s => {
                    s.PerfomanceActivities.ToList().ForEach(a =>
                    {
                        activityResponses.Add(new PerformanceActivityResponse
                        {
                            PerformanceSectionId = s.Id,
                            PerfomanceActivityId = a.Id,
                            Weight = a.Weight,
                            SelfScore = a.SelfScore,
                            FinalScore = a.FinalScore,
                            Notes = a.Notes
                        });
                    });
                });

                var questionResponses = new List<PerformanceQuestionnaireResponse>();
                performanceResp.Template.PerformanceQuestionnaire.ToList().ForEach(q =>
                {
                    questionResponses.Add(new PerformanceQuestionnaireResponse
                    {
                        PerformanceQuestionnaireId = q.Id,
                        Response = q.Response
                    });
                });

                var performanceTrainings = new List<PerformanceTraining>();
                performanceResp.PerformanceTraining.ToList().ForEach(t =>
                {
                    performanceTrainings.Add(new PerformanceTraining
                    {
                        Training = t.Training,
                        Objectives = t.Objectives,
                        Results = t.Results,
                        Recommendations = t.Recommendations
                    });
                });

                var respondedPerfomance = _context.StaffPerformanceResponse.FirstOrDefault(r => r.PerformanceSessionId == performanceResp.Performance.Id 
                && r.EmpNo.ToUpper().Equals(performanceResp.EmployeeDetails.EmpNo.ToUpper()));

                if(respondedPerfomance != null)
                {
                    var respondedActivities = _context.PerformanceActivityResponse.Where(r => r.StaffPerformanceResponseId == respondedPerfomance.Id);
                    _context.PerformanceActivityResponse.RemoveRange(respondedActivities);
                    var respondedQuestionnaires = _context.PerformanceQuestionnaireResponse.Where(r => r.StaffPerformanceResponseId == respondedPerfomance.Id);
                    _context.PerformanceQuestionnaireResponse.RemoveRange(respondedQuestionnaires);
                    var trainings = _context.PerformanceTraining.Where(t => t.StaffPerformanceResponseId == respondedPerfomance.Id);
                    _context.PerformanceTraining.RemoveRange(trainings);
                    _context.StaffPerformanceResponse.Remove(respondedPerfomance);
                }

                _context.StaffPerformanceResponse.Add(new StaffPerformanceResponse
                {
                    PerformanceSessionId = performanceResp.Performance.Id,
                    EmpNo = performanceResp.EmployeeDetails.EmpNo,
                    Department = performanceResp.EmployeeDetails.Department,
                    JobCat = performanceResp.EmployeeDetails.JobCat,
                    JobTitle = performanceResp.EmployeeDetails.JobTitle,
                    Supervisor = performanceResp.EmployeeDetails.Supervisor,
                    PerformanceActivityResponse = activityResponses,
                    PerformanceQuestionnaireResponse = questionResponses,
                    PerformanceTraining = performanceTrainings
                });

                if (performanceResp.IsSupervisor)
                {
                    var target = _context.PerformanceTarget.FirstOrDefault(t => t.Id == performanceResp.TargetId);
                    target.Status = "FinalEntry";
                }

                _context.SaveChanges();
                return Json(new ReturnData<string> { 
                    Success = true,
                    Message = "Response saved successfully"
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
        public JsonResult SaveGradeLevels([FromBody] PerformanceGradeLevelVm gradeLevelVm)
        {
            try
            {
                var gradeSettings = _context.PerformanceGradeLevelSection.ToList();
                _context.PerformanceGradeLevelSection.RemoveRange(gradeSettings);
                _context.PerformanceGradeLevelSection.AddRange(gradeLevelVm.Sections);
                _context.SaveChanges();

                var columnCodes = new List<string>();
                gradeLevelVm.Sections.ForEach(s =>
                {
                    columnCodes.Add($"[{s.Code}]");
                });

                var gradeValues = new List<string>();
                gradeLevelVm.LevelGradings.ForEach(l =>
                {
                    var values = new List<string>();
                    values.Add($"'{l.grade}'");
                    gradeLevelVm.Sections.ForEach(s =>
                    {
                        values.Add($"'{l[s.Code]}'");
                    });
                    var gradeValue = $"({string.Join(",", values)})";
                    gradeValues.Add(gradeValue);
                });

                gradeLevelVm.Sections.ForEach(s =>
                {
                    s.Code = $"[{s.Code}] varchar(255)";
                });

                var SectionCodes = gradeLevelVm.Sections.Select(s => s.Code).ToList();
                var codes = string.Join(",", SectionCodes);
                var deleteTableQuery = "IF EXISTS (SELECT * FROM sysobjects WHERE NAME = 'PerformanceGradeLevel') DROP TABLE PerformanceGradeLevel";
                _context.Database.ExecuteSqlCommand(deleteTableQuery);
                var createTableQuery = $"CREATE TABLE PerformanceGradeLevel(Grade varchar(255),{codes})";
                _context.Database.ExecuteSqlCommand(createTableQuery);

                var strColumnCodes = string.Join(",", columnCodes);
                var strGradeValues = string.Join(",", gradeValues);
                var insertQuery = $"INSERT INTO PerformanceGradeLevel(Grade,{strColumnCodes}) VALUES {strGradeValues}";
                _context.Database.ExecuteSqlCommand(insertQuery);

                return Json(new ReturnData<string> { 
                    Success = true,
                    Message = "Updated Successifully"
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

        [HttpGet("getGradeLevel")]
        public JsonResult GetGradeLevel()
        {
            try
            {
                var sections = _context.PerformanceGradeLevelSection.ToList();
                var gradeQuery = "IF EXISTS (SELECT * FROM sysobjects WHERE NAME = 'PerformanceGradeLevel') SELECT* FROM PerformanceGradeLevel";
                var levelGradings = ExecuteQuery(gradeQuery);

                var response = _unisolApiProxy.GetEmployeeGrades().Result;
                var employeeGrades = JsonConvert.DeserializeObject<ReturnData<List<string>>>(response);
                if (!employeeGrades.Success)
                    return Json(employeeGrades);

                return Json(new ReturnData<dynamic>
                {
                    Success = true,
                    Data = new
                    {
                        sections,
                        levelGradings = levelGradings.Data,
                        employeeGrades = employeeGrades.Data
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

        private ReturnData<List<dynamic>> ExecuteQuery(string gradeQuery)
        {
            try
            {
                var gradeLevelFields = new List<string>();
                gradeLevelFields.Add("grade");
                var sections = _context.PerformanceGradeLevelSection.Select(s => s.Code).ToList();
                gradeLevelFields.AddRange(sections);
                var dynamicFields = new List<dynamic>();

                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = gradeQuery;
                    _context.Database.OpenConnection();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Hashtable customeFields = new Hashtable();
                            for (var i = 0; i < gradeLevelFields.Count; i++)
                            {
                                customeFields.Add(gradeLevelFields[i], reader[i].ToString());
                            }

                            dynamicFields.Add(customeFields);
                        }
                    }
                }

                return new ReturnData<List<dynamic>>
                {
                    Success = true,
                    Data = dynamicFields
                };
            }
            catch (Exception ex)
            {
                return new ReturnData<List<dynamic>>
                {
                    Success = false,
                    Message = "Sorry, An error occurred"
                };
            }
        }

        [HttpGet("getCurrentTemplate")]
        public JsonResult GetCurrentTemplate(string username)
        {
            try
            {
                var performance = _context.PerformanceSession.FirstOrDefault(p => p.StartDate < DateTime.UtcNow.AddHours(3) && p.EndDate > DateTime.UtcNow.AddHours(3));
                var template = _context.StaffPerformance.Where(p => p.Name.ToUpper().Equals(performance.TemplateName.ToUpper()))
                    .Include(p => p.PerformanceQuestionnaire)
                    .Include(p => p.PerformanceSections).FirstOrDefault();

                var target = _context.PerformanceTarget.Where(t => t.EmpNo.ToUpper().Equals(username.ToUpper()) && t.PerformanceSessionId == performance.Id)
                    .Include(t => t.PerformanceTargetDetail).FirstOrDefault();
                return Json(new ReturnData<dynamic> { 
                    Success = true,
                    Data = new
                    {
                        template,
                        performance,
                        target
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<List<dynamic>>
                {
                    Success = false,
                    Message = "Sorry, An error occurred"
                });
            }
        }

        [HttpPost("[action]")]
        public JsonResult SaveTargets([FromBody] PerformanceTargetVm performanceTarget)
        {
            try
            {
                performanceTarget.TargetId = performanceTarget.TargetId == null ? 0 : performanceTarget.TargetId;
                if (performanceTarget.TargetId > 0)
                {
                    var targets = _context.PerformanceTarget.Where(t => t.EmpNo.ToUpper().Equals(performanceTarget.UserName.ToUpper()) && t.PerformanceSessionId == performanceTarget.SessionId).ToList();
                    targets.ForEach(t =>
                    {
                        var details = _context.PerformanceTargetDetail.Where(d => d.PerformanceTargetId == t.Id);
                        _context.PerformanceTargetDetail.RemoveRange(details);
                    });

                    _context.PerformanceTarget.RemoveRange(targets);
                }

                var targetDetails = new List<PerformanceTargetDetail>();
                performanceTarget.PerformanceSections.ForEach(s =>
                {
                    
                    s.PerformanceTargets.ForEach(t =>
                    {
                        targetDetails.Add(new PerformanceTargetDetail
                        {
                            PerformanceSectionId = s.Id,
                            Activity = t.Activity,
                            Target = t.Target,
                            Indicator = t.Indicator,
                            Achievement = t.Achievement,
                            Weight = t.Weight,
                            SelfScore = t.SelfScore,
                            FinalScore = t.FinalScore,
                            Notes = t.Notes
                        });
                    });
                });

                var response = _unisolApiProxy.GetStaffData(performanceTarget.UserName).Result;
                var employeeDetails = JsonConvert.DeserializeObject<ReturnData<dynamic>>(response);

                _context.PerformanceTarget.Add(new PerformanceTarget
                {
                    DateCreated = DateTime.UtcNow.AddHours(3),
                    DateModified = DateTime.UtcNow.AddHours(3),
                    EmpNo = performanceTarget.UserName,
                    PerformanceSessionId = performanceTarget.SessionId,
                    PerformanceTargetDetail = targetDetails,
                    Status = performanceTarget.IsSupervisor ? "Approved": "Pending",
                    Supervisor = employeeDetails.Data.supervisor
                });

                _context.SaveChanges();

                return Json(new ReturnData<string> { 
                    Success = true,
                    Message = "Targets saved successfully"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<List<dynamic>>
                {
                    Success = false,
                    Message = "Sorry, An error occurred"
                });
            }
        }

        [HttpGet("getReporters")]
        public JsonResult GetReporters(string username)
        {
            try
            {
                var session = _context.PerformanceSession.FirstOrDefault(p => p.StartDate < DateTime.UtcNow.AddHours(3) && p.EndDate > DateTime.UtcNow.AddHours(3));
                session.Id = session == null ? 0 : session.Id;
                var myReporters = _context.PerformanceTarget.Where(t => t.Supervisor.ToUpper().Equals(username.ToUpper()) && t.PerformanceSessionId == session.Id).ToList();
                var reporters = new List<dynamic>();

                var response = _unisolApiProxy.GetEmployees().Result;
                var Employees = JsonConvert.DeserializeObject<ReturnData<List<HrpEmployee>>>(response);
                myReporters.ForEach(r =>
                {
                    var Names = Employees.Data.FirstOrDefault(e => e.EmpNo.ToUpper().Equals(r.EmpNo.ToUpper()))?.Names;
                    reporters.Add(new
                    {
                        performanceId = session.Id,
                        Performance = session.Name,
                        r.EmpNo,
                        r.Status,
                        Names
                    });
                });
                return Json(new ReturnData<dynamic>
                {
                    Success = true,
                    Data = new
                    {
                        reporters
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<List<dynamic>>
                {
                    Success = false,
                    Message = "Sorry, An error occurred"
                });
            }
        }


        [HttpPost("[action]")]
        public JsonResult GetResponse([FromBody] StaffPerformanceResponse filterData)
        {
            try
            {
                filterData.Department = filterData?.Department ?? "";
                filterData.JobCat = filterData?.JobCat ?? "";
                filterData.JobTitle = filterData?.JobTitle ?? "";

                var performance = _context.PerformanceSession.FirstOrDefault(p => p.StartDate < DateTime.UtcNow.AddHours(3) && p.EndDate > DateTime.UtcNow.AddHours(3));
                var performanceResponse = _context.StaffPerformanceResponse
                    .Where(r => r.PerformanceSessionId == performance.Id 
                    && (r.Department.ToUpper().Equals(filterData.Department.ToUpper()) || string.IsNullOrEmpty(filterData.Department))
                    && (r.JobCat.ToUpper().Equals(filterData.JobCat.ToUpper()) || string.IsNullOrEmpty(filterData.JobCat))
                    && (r.JobTitle.ToUpper().Equals(filterData.JobTitle.ToUpper())) || string.IsNullOrEmpty(filterData.JobTitle))
                    .Include(r => r.PerformanceActivityResponse)
                    .Include(r => r.PerformanceQuestionnaireResponse)
                    .Include(r => r.PerformanceTraining).ToList();

                var totals = GetScores(performanceResponse);
                return Json(new ReturnData<dynamic>
                {
                    Success = true,
                    Data = new
                    {
                        scores = totals.Data
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<dynamic>
                {
                    Success = false,
                    Message = "Sorry, An error occurred"
                });
            }
        }

        [HttpGet("getFilterData")]
        public JsonResult GetFilterData()
        {
            try
            {
                var response = _context.StaffPerformanceResponse;
                var departments = response.Select(r => r.Department).Distinct().ToList();
                var categories = response.Select(r => r.JobCat).Distinct().ToList();
                var titles = response.Select(r => r.JobTitle).Distinct().ToList();

                return Json(new ReturnData<dynamic> { 
                    Success = true,
                    Data = new
                    {
                        departments,
                        categories,
                        titles
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

        [HttpGet("deleteLevels")]
        public JsonResult DeleteLevels()
        {
            try
            {
                var deleteTableQuery = "IF EXISTS (SELECT * FROM sysobjects WHERE NAME = 'PerformanceGradeLevel') DROP TABLE PerformanceGradeLevel";
                _context.Database.ExecuteSqlCommand(deleteTableQuery);
                return Json(new ReturnData<List<dynamic>>
                {
                    Success = true,
                    Message = "Levels deleted successfully"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<List<dynamic>>
                {
                    Success = false,
                    Message = "Sorry, An error occurred"
                });
            }
        }
    }
}
