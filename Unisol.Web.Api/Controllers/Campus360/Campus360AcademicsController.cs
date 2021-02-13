using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Api.IServices;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Common.ViewModels.Login;
using Unisol.Web.Common.ViewModels.Timetable;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers.Campus360
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class Campus360AcademicsController : Controller
	{
		private readonly UnisolAPIdbContext _context;
		private IPortalApiProxy _portalProxy;
		private IStudentServices _studentServices;
		private ISystemServices _systemServices;
		private StudentCredential studentCredentials;
		private CampusDetails campusDetails;
		private bool isCampusApi = true;

		public Campus360AcademicsController(UnisolAPIdbContext context, IPortalApiProxy portalProxy, IStudentServices studentServices, ISystemServices systemServices)
		{
			_context = context;
			studentCredentials = new StudentCredential(context, studentServices, systemServices);
			_studentServices = studentServices;
			_systemServices = systemServices;

			campusDetails = new CampusDetails(context);
			_portalProxy = portalProxy;
		}

		[HttpPost("[action]")]
		public JsonResult ReturnStudentDetails([FromBody] RegisterViewModel reg, string classStatus)
		{
			try
			{
				var studentDetails = studentCredentials.GetStudentDetails(reg.RegNumber, classStatus, isCampusApi);
				if (!studentDetails.Success)
					return Json(new ReturnData<string>
					{
						Success = studentDetails.Success,
						Message = studentDetails.Message
					});

				var studentProgramme = _studentServices.GetProgramme(reg.RegNumber, classStatus, isCampusApi);
				if (!studentProgramme.Success)
					return Json(new ReturnData<string>
					{
						Success = studentProgramme.Success,
						Message = studentProgramme.Message
					});

				var studentClass = _studentServices.GetClass(reg.RegNumber, classStatus, isCampusApi);
				if (!studentClass.Success)
					return Json(new ReturnData<string>
					{
						Success = studentClass.Success,
						Message = studentClass.Message
					});

				var sysSetup = _systemServices.GetSystemSetup();
				if (!sysSetup.Success)
					return Json(new ReturnData<string>
					{
						Success = sysSetup.Success,
						Message = sysSetup.Message
					});

				var data = new
				{
					studentDetails.Data.AdmnNo,
					studentDetails.Data.Names,
					studentDetails.Data.Gender,
					DateOfBirth = String.Format("{0:dd/MM/yyyy}", studentDetails.Data.Dob),
					studentDetails.Data.Telno,
					studentDetails.Data.Email,
					studentDetails.Data.Programme,
					ProgrammeCode = studentProgramme.Data.Code,
					studentProgramme.Data.Department,
					StudentClass = studentClass.Data.Id,
					StudentClassStartDate = String.Format("{0:dd/MM/yyyy}", studentClass.Data.Starts),
					EndOfAcademicRecord = String.Format("{0:dd/MM/yyyy}", studentClass.Data.Ends),
					StudentCampus = studentClass.Data.Campus,
					studentDetails.Data.Sponsor,
					studentDetails.Data.Homeaddress,
					studentDetails.Data.Domicile,
					UniversityName = sysSetup.Data.OrgName,
					UniversityInitials = sysSetup.Data.SubTitle
				};

				return Json(new ReturnData<dynamic>
				{
					Success = sysSetup.Success,
					Data = data,
					Message = sysSetup.Message,
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred while accessing a resource. Please contact School admin"
				});
			}
		}

		[HttpPost("[action]")]
		public JsonResult GetStudentsStudyTimetable([FromBody] RegisterViewModel reg, string classStatus)
		{
			try
			{
				reg.RegNumber = reg?.RegNumber ?? "";
				var unitsResponse = studentCredentials.GetUnits(reg.RegNumber, classStatus, "Session Units");
				if (!unitsResponse.Success)
					return Json(unitsResponse);

				var units = new List<TimetableUnitModel>();
				foreach (var yearlyUnits in unitsResponse.Data.StudentCurriculumViewModel)
				{
					foreach (var semesterUnits in yearlyUnits.Semesters)
					{
						foreach(var semesterUnit in semesterUnits.CurriculumUnits)
						{
							string unitCode = semesterUnit?.UnitCode ?? "";
							units.Add(new TimetableUnitModel
							{
								UnitCode = unitCode.ToUpper(),
								UnitName = semesterUnit.UnitName
							});
						}
					}
				}

				var validSemisterUnits = _studentServices.GetSemisterSubjects(reg.RegNumber, classStatus);
				if (validSemisterUnits.Success && validSemisterUnits.Data.Count > 1)
				{
					var registeredUnits = validSemisterUnits.Data.Select(u => u.Code.ToUpper()).ToList();
					units = units.Where(u => registeredUnits.Contains(u.UnitCode.ToUpper())).ToList();
				}

				var studentClass = _studentServices.GetClass(reg.RegNumber, classStatus);
				if (!studentClass.Success)
					return Json(studentClass);

				var campus = studentClass.Data?.Campus ?? "";
				var classType = studentClass.Data?.ClassType ?? "";
				var currentTerm = _studentServices.GetCurrentTerm(reg.RegNumber, classStatus);
				if (!currentTerm.Success)
					return Json(currentTerm);

				var studyMode = _context.Register.FirstOrDefault(r => r.AdmnNo.ToUpper().Equals(reg.RegNumber.ToUpper()))?.StudyMode ?? "";
				var lecturer = "";
				var currentSession = currentTerm.Data?.Names ?? "";
				var timetableResponse = GetStudyTimetable(units, lecturer, currentSession, campus, studyMode);
				return Json(timetableResponse);
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<List<bool>>
				{
					Success = false,
					Message = "Oops,an error occured.Please contact administrator " +
							  ErrorMessangesHandler.ExceptionMessage(ex)
				});
			}
		}
		
		private ReturnData<List<dynamic>> GetStudyTimetable(List<TimetableUnitModel> units, string lecturer, string currentSession, string campus, string studyMode)
		{
			try
			{
				var studyPeriods = _context.TtstudyPeriod.Where(p => p.EndDate > DateTime.Now);
				if (!string.IsNullOrEmpty(currentSession))
					studyPeriods = studyPeriods.Where(p => p.Term.ToUpper().Equals(currentSession.ToUpper()));
				var studyPeriod = studyPeriods.FirstOrDefault();
				if (studyPeriod == null)
					return new ReturnData<List<dynamic>>
					{
						Success = false,
						Message = "Sorry, study period has not yet been set",
					};

				var daysOfTheWeek = new string[]{
					"Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"
				};

				var weeklyLessons = new List<dynamic>();
				foreach (var day in daysOfTheWeek)
				{
					var lessons = _context.TtstudyProcessed
						.Where(e => e.Rday.ToLower() == day.ToLower()
						&& units.Any(s => s.UnitCode.Equals(e.UnitCode))
						&& e.Term.ToUpper().Equals(studyPeriod.Term.ToUpper())
						&& !string.IsNullOrEmpty(e.UnitCode)
						&& (string.IsNullOrEmpty(lecturer) || e.LecturerUsed.ToUpper().Equals(lecturer.ToUpper()))
						).Select(e =>
						new
						{
							UnitName = units.FirstOrDefault(u => u.UnitCode.Equals(e.UnitCode)).UnitName ?? e.UnitCode,
							e.UUCode,
							StartTime = e.Stime.Value.TimeOfDay,
							EndTime = e.Etime.Value.TimeOfDay,
							e.Room,
							e.Campus,
							e.StudyMode,
							LecturerName = _context.HrpEmployee.FirstOrDefault(t => t.EmpNo.Equals(e.LecturerUsed)).Names ?? e.LecturerUsed,
						}).OrderBy(e => e.StartTime)
						.ToList();
					
					if (!string.IsNullOrEmpty(campus))
						lessons = lessons.Where(l => l.Campus.ToUpper().Equals(campus.ToUpper())).ToList();

					if (!string.IsNullOrEmpty(studyMode))
						lessons = lessons.Where(l => l.StudyMode.ToUpper().Equals(studyMode.ToUpper())).ToList();
					
					var lessonPerDay = new
					{
						day,
						lessons,
					};

					weeklyLessons.Add(lessonPerDay);
				}

				return new ReturnData<List<dynamic>>
				{
					Success = true,
					Message = "TimeTable found",
					Data = weeklyLessons
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

		[HttpPost("[action]")]
		public JsonResult GetStudentsExamTimetable([FromBody] RegisterViewModel reg, string classStatus)
		{
			try
			{
				var validStudentRegister = studentCredentials.GetStudentDetails(reg.RegNumber, classStatus);
				if (!validStudentRegister.Success)
					return Json(validStudentRegister);

				var validSemisterUnits = _studentServices.GetSemisterSubjects(reg.RegNumber, classStatus);
				if (!validSemisterUnits.Success)
					return Json(validSemisterUnits);

				var studentClass = _studentServices.GetClass(reg.RegNumber, classStatus);
				if (!studentClass.Success)
					return Json(studentClass);

				var campus = studentClass.Data?.Campus ?? "";
				var currentTerm = _studentServices.GetCurrentTerm(reg.RegNumber, classStatus);
				if (!currentTerm.Success)
					return Json(currentTerm);

				var currentSession = currentTerm.Data?.Names ?? "";
				var examTimetableResponse = GetExamTimetable(validSemisterUnits.Data, currentSession, campus);
				return Json(examTimetableResponse);
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<List<bool>>
				{
					Success = false,
					Message = "Oops,an error occured.Please contact administrator " +
							  ErrorMessangesHandler.ExceptionMessage(ex)
				});
			}
		}

		private ReturnData<dynamic> GetExamTimetable(List<FormattedSubjects> validSemisterUnits, string currentSession, string campus)
		{
			try
			{
				var examPeriods = _context.TtexamPeriod.Where(p => p.EndDate > DateTime.Now);
				if (!string.IsNullOrEmpty(currentSession))
					examPeriods = examPeriods.Where(p => p.Term.ToUpper().Equals(currentSession.ToUpper()));
				var examPeriod = examPeriods.FirstOrDefault();
				if (examPeriod == null)
					return new ReturnData<dynamic>
					{
						Success = false,
						Message = "Sorry, exam period has not yet been set",
					};

				var daysOfTheWeek = new string[]{
					"Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"
				};

				var weeklyExams = new List<dynamic>();
				foreach (var day in daysOfTheWeek)
				{
					var examUnits = _context.TtexamProcessed
						.Where(e => validSemisterUnits.Any(u => u.Code == e.UnitCode)
						&& e.Rdate.Value.DayOfWeek.ToString().ToLower() == day.ToLower()
						&& e.Term.ToUpper().Equals(examPeriod.Term.ToUpper())
						&& !string.IsNullOrEmpty(e.UnitCode)
						).Select(e => new UnitDetails
						{
							UnitName = validSemisterUnits.FirstOrDefault(u => u.Code == e.UnitCode).Names ?? e.UnitCode,
							UnitCode = e.UnitCode,
							StartTime = e.Stime,
							EndTime = e.Etime,
							Room = e.Room,
							Campus = e.Campus,
							LecturerName = _context.HrpEmployee.FirstOrDefault(t => t.EmpNo == e.Invigilator).Names ?? e.Invigilator,
							Date = String.Format("{0:d}", e.Rdate),
						}).OrderBy(e => e.StartTime).ToList();

					if (!string.IsNullOrEmpty(campus))
						examUnits = examUnits.Where(u => u.Campus.ToUpper().Equals(campus.ToUpper())).ToList();

					var ExamsPerDay = new
					{
						day = $"{day}, {examUnits.FirstOrDefault()?.Date}",
						examUnits
					};

					if (examUnits.Any())
						weeklyExams.Add(ExamsPerDay);
				}

				var examTimetable = new
				{
					ExamStartDate = ReturnFormattedDate(examPeriod.StartDate),
					ExamEndDate = ReturnFormattedDate(examPeriod.EndDate),
					UnitExamInfo = weeklyExams
				};

				return new ReturnData<dynamic>
				{
					Success = true,
					Message = "TimeTable found",
					Data = examTimetable
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public string ReturnFormattedDate(DateTime? date,string format= "{0:ddd, MMM d, yyyy}")
		{
			string formattedDate = String.Format(format, date);

			return formattedDate;
		}

		[HttpPost("[action]")]
		public JsonResult ReturnStudentsYearsBeenInSchool([FromBody] RegisterViewModel reg, string classStatus)
		{
			try
			{
				var studentYears = studentCredentials.GetYearsStudentHasBeenToSchool(reg.RegNumber, classStatus);
				return Json(studentYears);
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<List<bool>>
				{
					Success = false,
					Message = "Oops,an error occured.Please contact administrator " +
							  ErrorMessangesHandler.ExceptionMessage(ex)
				});
			}
		}

		[HttpPost("[action]")]
		public JsonResult GetStudentsResults([FromBody] TranscriptRequestViewModel transcriptModel, string classStatus)
		{
			try 
			{
				var currentYearResults = studentCredentials.GetYearResults(transcriptModel, classStatus);
				return Json(currentYearResults);
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<List<bool>>
				{
					Success = false,
					Message = "Oops,an error occured.Please contact administrator " +
							  ErrorMessangesHandler.ExceptionMessage(ex)
				});
			}
		}

		[HttpPost("[action]")]
		public JsonResult GetFeesStatement([FromBody] RegisterViewModel reg, string classStatus)
		{
			try
			{
				var feeStatement = studentCredentials.GetFeesStatement(reg.RegNumber, classStatus);
				return Json(feeStatement);
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<List<bool>>
				{
					Success = false,
					Message = "Oops,an error occured.Please contact administrator " +
							  ErrorMessangesHandler.ExceptionMessage(ex)
				});
			}
		}

		[HttpGet("[action]")]
		public JsonResult GetCourseMaterial(string usercode, string classStatus)
		{
			var studentDetails = studentCredentials.GetStudentDetails(usercode, classStatus);
			if (!studentDetails.Success)
				return Json(studentDetails);

			var response = _portalProxy.ReturnCourseMaterials().Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<List<RepositoryModel>>>(response);

			return Json(jdata);
		}

		[HttpPost("[action]")]
		public JsonResult GetLecturerStudyTimetable([FromBody] RegisterViewModel reg)
		{
			try
			{
				var currentSession = _context.Term.FirstOrDefault(t => t.Starts <= DateTime.UtcNow.Date && t.Ends >= DateTime.UtcNow.Date)?.Names ?? "";
				var unitsResponse = GetLecturerUnits(reg.RegNumber);
				if (!unitsResponse.Success)
					return Json(unitsResponse);

				var studyMode = "";
				var timetableResponse = GetStudyTimetable(unitsResponse.Data, reg.RegNumber, currentSession, "", studyMode);
				return Json(timetableResponse);
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

		private ReturnData<List<TimetableUnitModel>> GetLecturerUnits(string regNumber)
		{
			var lecturer = _context.Ttlecturer.FirstOrDefault(l => l.EmpNo.ToUpper().Equals(regNumber.ToUpper()));
			if (lecturer == null)
				return new ReturnData<List<TimetableUnitModel>>
				{
					Success = false,
					Message = "Sorry, not allowed to access the service"
				};

			var lecturerUnits = _context.TtlecturerUnits.Where(u => u.Ref.Equals(lecturer.Id.ToString())).ToList();
			var units = new List<TimetableUnitModel>();
			foreach (var lecturerUnit in lecturerUnits)
			{
				units.Add(new TimetableUnitModel
				{
					UnitCode = lecturerUnit.Code,
					UnitName = _context.Subjects.FirstOrDefault(s => s.Code.ToUpper().Equals(lecturerUnit.Code.ToUpper()))?.Names ?? ""
				});
			}

			return new ReturnData<List<TimetableUnitModel>>
			{
				Success = true,
				Data = units
			};
		}

		[HttpPost("[action]")]
		public JsonResult GetLecturerExamTimetable([FromBody] RegisterViewModel reg)
		{
			try
			{
				var currentSession = "";
				var units = new List<FormattedSubjects>();
				var processedExams = _context.TtexamProcessed.Where(e => e.Invigilator.ToUpper().Equals(reg.RegNumber.ToUpper())).ToList();
				foreach(var exam in processedExams)
				{
					units.Add(new FormattedSubjects
					{
						Code = exam.UnitCode,
						Names = _context.Subjects.FirstOrDefault(s => s.Code.ToUpper().Equals(exam.UnitCode.ToUpper()))?.Names ?? ""
					});
				}

				var examTimetableResponse = GetExamTimetable(units, currentSession, "");
				return Json(examTimetableResponse);
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
		public JsonResult LecturerAllocationSammary([FromBody] RegisterViewModel reg)
		{
			try
			{
				var lecturer = _context.Ttlecturer.FirstOrDefault(l => l.EmpNo.ToUpper().Equals(reg.RegNumber.ToUpper()));
				if (lecturer == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, not allowed to access the service"
					});
				
				var lecturerUnits = _context.TtlecturerUnits.Where(u => u.Ref.Equals(lecturer.Id.ToString())).ToList();
				var units = new List<TimetableUnitModel>();
				foreach (var lecturerUnit in lecturerUnits)
				{
					units.Add(new TimetableUnitModel
					{
						UnitCode = lecturerUnit.Code,
						UnitName = _context.Subjects.FirstOrDefault(s => s.Code.ToUpper().Equals(lecturerUnit.Code.ToUpper()))?.Names ?? ""
					});
				}
				
				var allocations = new List<dynamic>();
				foreach(var unit in units)
				{
					var currentSession = _context.Term.FirstOrDefault(t => t.Starts <= DateTime.UtcNow.Date && t.Ends >= DateTime.UtcNow.Date)?.Names ?? "";
					var unitAllocation = _context.TtstudyProcessed.FirstOrDefault(t => t.UnitCode.ToUpper().Equals(unit.UnitCode.ToUpper()) 
					&& t.LecturerUsed.ToUpper().Equals(reg.RegNumber.ToUpper()) 
					&& t.Term.ToUpper().Equals(currentSession.ToUpper()));

					if(unitAllocation != null)
					{
						var hourResponse = GetUnitHours(unit.UnitCode, reg.RegNumber);
						allocations.Add(new
						{
							unit.UnitCode,
							unit.UnitName,
							unitAllocation.Programme,
							unitAllocation.Room,
							unitAllocation.StudyMode,
							unitAllocation.Campus,
							unitAllocation.NumOfStudentsUsed,
							unitHours = hourResponse.Data
						});
					}
				}
				
				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = allocations
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

		private ReturnData<double> GetUnitHours(string unitCode, string usercode)
		{
			var currentSession = "";
			var unitsResponse = GetLecturerUnits(usercode);
			if (!unitsResponse.Success)
				return new ReturnData<double>
				{
					Success = false,
					Message = unitsResponse.Message
				};

			var studyMode = "";
			var timetableResponse = GetStudyTimetable(unitsResponse.Data, usercode, currentSession, "", studyMode);
			double duration = 0;
			foreach (var day in timetableResponse.Data)
			{
				foreach (var unit in day.lessons)
				{
					string code = unit?.UnitCode ?? "";
					if (unitCode.ToUpper().Equals(code.ToUpper()))
					{
						string timeDiff = $"{unit.EndTime - unit.StartTime}";
						var timeArr = timeDiff.Split(":");
						double.TryParse(timeArr[1], out double minutes);
						double.TryParse(timeArr[0], out double hours);
						duration = duration + hours + (minutes / 60);
					}
				}
			}

			return new ReturnData<double>
			{
				Success = true,
				Data = duration
			};
		}
	}
}
