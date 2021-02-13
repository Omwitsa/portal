using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Unisol.Web.Api.IServices;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicController : Controller
    {
        private readonly UnisolAPIdbContext _context;
		private readonly StudentCredential _studentCredentials;
		private readonly IStudentServices _studentServices;
		private readonly ISystemServices _systemServices;
		public AcademicController(UnisolAPIdbContext context, IStudentServices studentServices, ISystemServices systemServices)
        {
            _context = context;
			_studentServices = studentServices;
			_systemServices = systemServices;
			_studentCredentials = new StudentCredential(context, studentServices, systemServices);
		}

        [HttpGet("[action]")]
        public JsonResult GetAcademicYears()
        {
            var academicYears = _context.AcademicYear.ToList();
            var message = academicYears.Count > 0 ? "Details Have been found" : "No search records found";
            return Json(new ReturnData<List<AcademicYear>>
            {
                Success = academicYears.Count > 0,
                Data = academicYears,
                Message = message
            });
        }

		[HttpGet("[action]")]
		public JsonResult ReturnClassStatus()
		{
			var isGenesisDetails = _studentServices.CheckIfGenesis();
			if (!isGenesisDetails.Success)
			{
				var classStatus = _context.ClassStatus.ToList();
				var institutionInitial = _systemServices.GetSystemSetup()?.Data?.SubTitle ?? "";
				var status = new
				{
					classStatus,
					institutionInitial
				};

				return Json(new ReturnData<dynamic>
				{
					Success = classStatus.Count > 0,
					Data = status
				});
			}
			return Json(new ReturnData<dynamic>
			{
				Success = true
			});
		}

		[HttpGet("[action]")]
        public JsonResult GetStudyYears()
        {
            var academicYears = _context.CsplannerDetail
                .Select(y =>  new { y.Stage })
                .Distinct()
                .OrderBy(y=>y.Stage)
                .ToList();
            var message = academicYears.Count > 0 ? "Details Have been found" : "No search records found";
            return Json(new ReturnData<dynamic>
            {
                Success = academicYears.Count > 0,
                Data = academicYears,
                Message = message
            });
        }
        [HttpGet("[action]")]
        public JsonResult GetAcademicSemestersOfStudy()
        {
            //
            var academicSemesters = _context.CsplannerDetail
                .Select(y => new { y.Term })
                .Distinct()
                .OrderBy(y => y.Term)
                .ToList();
            var message = academicSemesters.Count > 0 ? "Details Have been found" : "No search records found";
            return Json(new ReturnData<dynamic>
            {
                Success = academicSemesters.Count > 0,
                Data = academicSemesters,
                Message = message
            });
        }


        [HttpGet("[action]")]
        public JsonResult GetSemesters([FromQuery] int yearId)
        {
            //
            var year = _context.AcademicYear.FirstOrDefault(y => y.Id == yearId);
            if (year == null)
            {
                return Json(new ReturnData<List<Term>>
                {
                    Success = false,

                    Message = "NO such year exists"
                });
            }

            var semesters = _context.Term.Where(t => t.AcademicYear == year.Names).ToList();
            var message = semesters.Count > 0 ? "Details Have been found" : "No search records found";
            return Json(new ReturnData<List<Term>>
            {
                Success = semesters.Count > 0,
                Data = semesters,
                Message = message
            });
        }

        [HttpGet("[action]")]
        public JsonResult GetProgram(string regNo, string year, string classStatus)
        {
            var register = _context.Register.FirstOrDefault(r => r.AdmnNo == regNo);
            if (register != null)
            {
                if (string.IsNullOrEmpty(register.Programme))
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "We could not find your programme "
                    });

                var programTypes = GetProgCurriculumDetail(register.Programme, year);

                if (programTypes.Count > 0)
                {
                    return Json(new ReturnData<List<ProgramType>>
                    {
                        Success = true,
                        Data = programTypes,
                        Message = "Program details found"
                    });
                }

                return Json("");
            }

            return Json(new ReturnData<string>
            {
                Success = false,
                Message = "We could not find your registration "
            });
        }

        private List<ProgramType> GetProgCurriculumDetail(string progName, string year)
        {
            var programme = _context.Programme.FirstOrDefault(p => p.Names == progName);
            if (programme != null)
            {
                var progCurriculumDetail = _context.ProgCurriculumDetail
                    .Where(p => Convert.ToInt32(p.Ref) == programme.Id && p.Stage == year).ToList();

                var programTypes = GetSubjects(progCurriculumDetail);

                return programTypes;
            }

            return new List<ProgramType>();
        }

        private List<ProgramType> GetSubjects(List<ProgCurriculumDetail> progCurriculumDetail)
        {
            var programTypes = new List<ProgramType>();

            if (progCurriculumDetail != null)
            {
                foreach (var progDetails in progCurriculumDetail)
                {
                    var subject = _context.Subjects.FirstOrDefault(s => s.Code == progDetails.UnitCode);

                    programTypes.Add(
                        new ProgramType
                        {
                            GroupType = progDetails.GroupType,
                            Subject = new Subjects
                            {
                                Code = subject?.Code,
                                Names = subject?.Names,
                                CreditUnits = subject?.CreditUnits
                            }
                        }
                    );
                }
            }

            return programTypes;
        }

        [HttpGet("[action]")]
        public JsonResult GetYearsOfStudy(string regNo, string classStatus)
        {
            var register = _context.Register.FirstOrDefault(r => r.AdmnNo == regNo);
            if (register != null)
            {
                if (string.IsNullOrEmpty(register.Programme))
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "We could not find your programme "
                    });

                var programme = _context.Programme.FirstOrDefault(p => p.Names == register.Programme);
                if (programme != null)
                {
                    var years = _context.ProgCurriculumDetail
                        .Where(p => Convert.ToInt32(p.Ref) == programme.Id)
                        .GroupBy(p => p.Stage)
                        .Select(y => y.First())
                        .ToList();

                    return Json(new ReturnData<List<ProgCurriculumDetail>>
                    {
                        Success = true,
                        Data = years,
                        Message = "Years of study found"
                    });
                }

                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "We could not find your Program "
                });
            }

            return Json(new ReturnData<string>
            {
                Success = false,
                Message = "We could not find your registration "
            });
        }

        [HttpGet("[action]")]
        public JsonResult GetSemisterUnits(string regNo, string classStatus)
        {
            var register = _context.Register.FirstOrDefault(r => r.AdmnNo == regNo);
            if (register != null)
            {
                var progUnitReg = _context.ProgUnitReg.FirstOrDefault(p => p.AdmnNo == regNo);
                if (progUnitReg != null)

                {
                    if (string.IsNullOrEmpty(register.Programme))
                        return Json(new ReturnData<string>
                        {
                            Success = false,
                            Message = "We could not find your programme "
                        });


                    var programme = _context.Programme.FirstOrDefault(p => p.Names == register.Programme);


                    if (programme != null)
                    {
                        var progCurriculumDetail = _context.ProgCurriculumDetail.Where(p =>
                                Convert.ToInt32(p.Ref) == programme.Id && p.Stage == "YEAR 1" && p.Term == "SEMESTER 2")
                            .ToList();
                        var unitCodes = new List<ProgCurriculumDetail>();

                        if (progCurriculumDetail.Any())
                        {
                            foreach (var progDetail in progCurriculumDetail)
                            {
                                unitCodes.Add(
                                    new ProgCurriculumDetail
                                    {
                                        UnitCode = progDetail.UnitCode,
                                        GroupType = progDetail.GroupType
                                    }
                                );
                            }
                        }

                        return Json(new ReturnData<List<ProgCurriculumDetail>>
                        {
                            Success = true,
                            Data = unitCodes,
                            Message = "Unit codes found"
                        });
                    }
                }
            }

            return Json(new ReturnData<string>
            {
                Success = false,
                Message = "We could not find your Registration Number"
            });
        }

        [HttpPost("unitreg")]
        public JsonResult RegisterUnits(UnitRegistrationViewModel regunits)
        {
            try
            {
                var progUnitReg = _context.ProgUnitReg.FirstOrDefault(p => p.AdmnNo == regunits.UserCode);

                foreach (var unit in regunits.unitCodes)
                {
                    var registeredUnits = new ProgUnitRegDetail
                    {
                        UnitCode = unit.ProgUnitCode,
                        Ref = "" + progUnitReg?.Id,
                        Status = "Pending"
                    };

                    _context.ProgUnitRegDetail.Add(registeredUnits);
                }

                _context.SaveChanges();
                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Items added successfully"
                });
            }
            catch (Exception)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Sorry something went wrong while registering units, please try again"
                });
            }
        }
		
        [HttpGet("[action]")]
        public JsonResult GetStudentAcademicDetails(string userCode, string classStatus, bool isPreviousTermCard)
        {
			try
			{
				var studentProgram = _studentCredentials.FormatStudentProgramme(userCode, classStatus);
				if (!studentProgram.Success)
					return Json(studentProgram);


				var studentClass = _studentCredentials.FormatStudentClass(userCode, classStatus, isPreviousTermCard);
				if (!studentClass.Success)
					return Json(studentClass);

				var semesterYear = _studentCredentials.GetStudentSemesterYear(userCode, classStatus, isPreviousTermCard);
				var department = _studentCredentials.FormatStudentDeparment(userCode, classStatus);
				if (!department.Success)
					return Json(department);

				var register = _context.Register.FirstOrDefault(r => r.AdmnNo.ToUpper().Equals(userCode.ToUpper()));
				var studentAcademicInfo = new StudentAcademicViewModel
				{
					StudentName = register.Names,
                    Sponsor = register.Sponsor,
					StudentProgramme = studentProgram.Data,
					StudentClass = studentClass.Data,
					StudentSemester = semesterYear.Data,
					StudentDeparment = department.Data,
				};

				return Json(new ReturnData<StudentAcademicViewModel>
				{
					Success = true,
					Message = "",
					Data = studentAcademicInfo
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Error = new Error(ex)
				});
			}
        }

        [HttpGet("[action]")]
        public JsonResult ReturnCurrentSemesterFromId(int? semesterId)
        {
            return Json(new ReturnData<string>
            {
                Success = true,
                Message = "",
                Data = _context.Term.FirstOrDefault(t=>t.Id==semesterId)?.Names
            });
        }

        [HttpGet("[action]")]
        public JsonResult GetStudentDetailsWithDepartment(string userCode, string classStatus)
        {
			try
			{
				var studentProgramme = _studentCredentials.FormatStudentProgramme(userCode, classStatus);
				if (!studentProgramme.Success)
					return Json(studentProgramme);

				var studentClass = _studentCredentials.FormatStudentClass(userCode, classStatus);
				if (!studentClass.Success)
					return Json(studentClass);

				var studentSemesterYears = _studentCredentials.GetStudentSemesterYear(userCode, classStatus);
				if (!studentSemesterYears.Success)
					return Json(studentSemesterYears);

				var studentDepartment = _studentCredentials.FormatStudentDeparment(userCode, classStatus);
				if (!studentDepartment.Success)
					return Json(studentDepartment);

				var studentAcademicInfo = new StudentAcademicViewModel
				{
					StudentProgramme = studentProgramme.Data,
					StudentClass = studentClass.Data,
					StudentDeparment = studentDepartment.Data,
					StudentSemester = studentSemesterYears.Data,
				};

				return Json(new ReturnData<StudentAcademicViewModel>
				{
					Success = true,
					Message = "",
					Data = studentAcademicInfo
				});
			}
			catch(Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Error = new Error(ex)
				});
			}
        }

		[HttpGet("[action]")]
		public JsonResult GetStudentFuculty(string userCode, string classStatus)
		{
			var register = _context.Register.FirstOrDefault(r => r.AdmnNo == userCode);
			if(register == null)
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Your registration details not found",
				});

			var programme = _context.Programme.FirstOrDefault(p => p.Names == register.Programme);
			if (programme == null)
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Your programme details not found",
				});

			var department = _context.Department.FirstOrDefault(d => d.Names == programme.Department);
			if (department == null)
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Your department details not found",
				});

			var fucultyViewModel = new FucultyViewModel
			{
				StudentName = register.Names,
				RegNo = userCode,
				Program = register.Programme,
				Fuculty = department.School,
				AcademicYear = "",
				StudyYear = "",
				//AdmissionDate = register.Createdate
			};

			return Json(new ReturnData<FucultyViewModel>
			{
				Success = true,
				Message = "",
				Data = fucultyViewModel
			});
		}

		[HttpGet("[action]")]
		public JsonResult GetStudUnitDetails(string userCode, string unitCode, string classStatus)
		{
			var studentUnitDetails = _studentServices.GetStudentUnitDetails(userCode, unitCode, classStatus);
			return Json(studentUnitDetails);
		}
	}
}