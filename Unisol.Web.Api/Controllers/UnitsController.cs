using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class UnitsController : Controller
    {
        private readonly UnisolAPIdbContext _context;
		private IStudentServices _studentServices;
		private ISystemServices _systemServices;
		private StudentCredential studentCredentials;
		private CampusDetails campusDetails;
		private readonly FinanceController _financeUtilities;
		public UnitsController(UnisolAPIdbContext context, IStudentServices studentServices, ISystemServices systemServices)
        {
            _context = context;
			_studentServices = studentServices;
			_systemServices = systemServices;
			studentCredentials = new StudentCredential(context, studentServices, systemServices);
			campusDetails = new CampusDetails(context);
			_financeUtilities = new FinanceController(context, studentServices, systemServices);
		}

        [HttpGet("[action]")]
        public JsonResult GetCurrentSemUnits(string userCode, string classStatus)
        {
			try
            {
				var validStudentRegister = studentCredentials.GetStudentDetails(userCode, classStatus);
				if (!validStudentRegister.Success)
					Json(validStudentRegister);

				var semisterUnits = _studentServices.GetSemisterSubjects(userCode, classStatus);

				return Json(semisterUnits);
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
        public JsonResult GetStudentCurriculum(string userCode, string classStatus)
        {
			var curriculum = _studentServices.GetStudentCurriculum(userCode, classStatus);
			return Json(curriculum);
        }

        [HttpGet("[action]")]
        public JsonResult GetCurrentSemesterUnits(string userCode, string classStatus, string unitLevel)
        {
			unitLevel = unitLevel ?? "";
			var units = studentCredentials.GetUnits(userCode, classStatus, unitLevel);
			return Json(units);
        }

        [HttpPost("[action]")]
        public bool SaveCurrentSemesterUnits(string userCode)
        {
            return true;
        }

        [HttpPost("[action]")]
        public JsonResult SaveStudentsUnits(CurriculumUnitsModel curriculumUnitsModel, string classStatus)
        {
			var studClass = _studentServices.GetClass(curriculumUnitsModel.UserCode, classStatus);
			if (!studClass.Success)
				return Json(studClass);

			var programme = _studentServices.GetProgramme(curriculumUnitsModel.UserCode, classStatus);
			if (!programme.Success)
				return Json(programme);

			var maxRegUnits = studClass.Data?.MaxUnits == 0 ? programme.Data?.MaxUnits : studClass.Data?.MaxUnits;
			if(curriculumUnitsModel.CurriculumUnits.Count > maxRegUnits)
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = $"Sorry, you can only register a maximum of {maxRegUnits} units for the current semester"
				});
			
			try
            {
                if (_context.SysSetup.Any(s => Convert.ToDateTime(s.UnitRegDeadLine) < DateTime.Now.Date))
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Oops,seems unit registration deadline has passed"
                    });

				var hasReported = studentCredentials.ValidateSessionReporting(curriculumUnitsModel.UserCode, classStatus);
				if (!hasReported.Success)
					return Json(hasReported);

				if(hasReported.Data != null)
				{
					if (hasReported.Data.Status.Equals("Pending"))
						return Json(new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, your reporting status is still pending. Kindly contact admin"
						});
				}

				var feePolicyComplied = studentCredentials.ReturnFeesPolicyCompliance(curriculumUnitsModel.UserCode, classStatus, "UNIT");
				if (!feePolicyComplied.Success)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = $"Sorry! Fees payment is required as per the policy before registering for the units. The policy is {feePolicyComplied.Data}% "
					});

				var termResponse = _studentServices.GetCurrentTerm(curriculumUnitsModel.UserCode, classStatus);
				if (!termResponse.Success)
					return Json(termResponse);

				curriculumUnitsModel.Semester = termResponse.Data?.Names;

				var studEnrolment = _studentServices.GetEnrollment(curriculumUnitsModel.UserCode, classStatus);
				if (!studEnrolment.Success)
					return Json(studEnrolment);

				var studentClass = studEnrolment.Data?.Class;
				var studentRegisteredSession = _context.ProgUnitReg
                    .FirstOrDefault(s => s.Class == studentClass && s.Term == curriculumUnitsModel.Semester 
					&& s.AdmnNo == curriculumUnitsModel.UserCode);

                if (studentRegisteredSession == null)
                {
					var progUnitReg = new ProgUnitReg
					{
						Class = studentClass,
						AdmnNo = curriculumUnitsModel.UserCode,
						Term = curriculumUnitsModel.Semester,
						Rdate = DateTime.UtcNow,
						Personnel = curriculumUnitsModel.UserCode
					};

					_context.ProgUnitReg.AddRange(progUnitReg);
                    _context.SaveChanges();

					if(progUnitReg.Id > 0)
					{
						curriculumUnitsModel.CurriculumUnits.ForEach(u => {
							var subjectSelected = new ProgUnitRegDetail
							{
								Ref = progUnitReg.Id.ToString(),
								UnitCode = u,
								Status = "Pending",
								Audit = false
							};
							_context.ProgUnitRegDetail.Add(subjectSelected);
						});

						_context.SaveChanges();
					}
				
                    return Json(new ReturnData<string>
                    {
                        Success = true,
                        Message = "Unit Registration successful, Pending approval from the Chairman of Department (CoD)"
                    });
                }

				var progUnitRegDetail = _context.ProgUnitRegDetail.Where(u => u.Ref == studentRegisteredSession.Id.ToString());
				var approvedUnits = progUnitRegDetail.Where(u => u.Status.ToLower().Equals("approved")).Select(u => u.UnitCode.ToUpper()).ToList();
				if ((curriculumUnitsModel.CurriculumUnits.Count + approvedUnits.Count) > maxRegUnits)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = $"Sorry, you can only register a maximum of {maxRegUnits} units for the current semester"
					});

				var pendingUnits = progUnitRegDetail.Where(u => u.Status.ToLower().Equals("Pending"));
				_context.ProgUnitRegDetail.RemoveRange(pendingUnits);

				curriculumUnitsModel.CurriculumUnits.ForEach(u => {
					if (!approvedUnits.Contains(u.ToUpper()))
					{
						var subjectSelected = new ProgUnitRegDetail
						{
							Ref = studentRegisteredSession.Id.ToString(),
							UnitCode = u,
							Status = "Pending",
							Audit = false
						};
						_context.ProgUnitRegDetail.Add(subjectSelected);
					}
				});

				_context.SaveChanges();

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Unit Registration successful, Pending approval from the Chairman of Department (CoD)"
				});
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Oops, seems an error has occured on our side.Please contact admin " +
                              ErrorMessangesHandler.ExceptionMessage(ex)
                });
            }
        }

        [HttpGet("[action]")]
        public JsonResult GetStudentRegistereddUnits(string userCode, string classStatus)
        {
			var registeredUnits = _studentServices.GetStudentRegistereddUnits(userCode, classStatus);
			return Json(registeredUnits);
		}

		[HttpGet("[action]")]
		public JsonResult GetUnitLecturer(string usercode)
		{
			try
			{
				var lecturer = _context.Ttlecturer.FirstOrDefault(l => l.EmpNo.ToUpper().Equals(usercode.ToUpper()));
				return Json(new ReturnData<Ttlecturer> {
					Success = true,
					Data = lecturer
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<List<bool>>
				{
					Success = false,
					Message = "Oops,an error occured."
				});
			}
		}
	}
}