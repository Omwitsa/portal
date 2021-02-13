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
    public class DatabaseUtilitiesController : Controller
    {
        private readonly UnisolAPIdbContext _context;
		private IStudentServices _studentServices;
		private StudentCredential studentCredentials;
		public DatabaseUtilitiesController(UnisolAPIdbContext context, IStudentServices studentServices, ISystemServices systemServices)
        {
            _context = context;
			_studentServices = studentServices;
			studentCredentials = new StudentCredential(_context, studentServices, systemServices);
		}
	
        public string GetCurrectTerm(string usercode)
        {
            var userEnrollment = _context.StudEnrolment.FirstOrDefault(s => s.AdmnNo == usercode);
            if (userEnrollment == null)
                return "";

			var studentClass = userEnrollment.Class;
			var term = _context.Class
					.Join(_context.Term,
						studentClassJoin => studentClassJoin.Term,
						t => t.Type,
						(studentClassJoin, t) =>
							new { t.Names, t.Starts, t.Ends, t.TermAlias, t.Type, studentClassJoin.Id })
					.FirstOrDefault(c =>
						c.Id.CaseInsensitiveContains(studentClass) &&
						(c.Starts <= DateTime.Now.Date && c.Ends >= DateTime.Now.Date))
				;
			if (term == null)
				return "";

			return term.Names;
        }

        [HttpGet("[action]")]
        public JsonResult GetCurrectActiveTerm(string usercode, string classStatus)
        {
            try
            {
				var termResponse = _studentServices.GetCurrentTerm(usercode, classStatus);
				if (!termResponse.Success)
					return Json(termResponse);

                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Current Active Term",
                    Data = termResponse.Data?.Names
				});
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Oops!  something went wrong while retrieving the current term, please try again"
                });
            }
        }

        [HttpGet("GetReportStatus")]
        public JsonResult GetReportStatus(string userCode, string classStatus)
        {
			return Json(studentCredentials.ValidateSessionReporting(userCode, classStatus));
        }
       
        [HttpGet("GetStudentTerm")]
        public JsonResult GetStudentTerm(string usercode, string classStatus)
        {
			return Json(_studentServices.GetCurrentTerm(usercode, classStatus));
        }
      
        [HttpGet("[action]")]
        public JsonResult StudentsYearsBeenInSchool(string usercode, string classStatus)
        {
			try
            {
				var studentYears = studentCredentials.GetYearsStudentHasBeenToSchool(usercode, classStatus);
				return Json(studentYears);
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Oops!  something went wrong while retrieving details, please try again"
                });
            }
        }
        [HttpGet("[action]")]
        public JsonResult GetFeesYears(string progCode, string classStatus)
        {
            try
            {
                var feeStructProg = _context.FeesPerProg.FirstOrDefault(f => f.ProgCode == progCode);
				if(feeStructProg == null)
					return Json(new ReturnData<List<YearWithSemesterViewModel>>
					{
						Success = false,
						Message = "Sorry, Your fee structure not found. Kindly contact admin",
					});

				var feeStructProgDetails = _context.FeesPerProgDetail.Where(f => f.Ref == "" + feeStructProg.Id).ToList();

                var academicYears = feeStructProgDetails
                    .GroupBy(d => d.Stage)
                    .Select(grp => grp.First())
                    .ToList();

                var classWithSemesters = new List<YearWithSemesterViewModel>();

                academicYears.ForEach(y =>
                {
                    var semesters = new List<StudentSemesterYear>();
                    feeStructProgDetails.ForEach(s =>
                    {
                        if (s.Stage == y.Stage)
                        {
                            semesters.Add(new StudentSemesterYear
                            {
                                Id = s.Ref,
                                YearOfStudy = s.Stage,
                                Ref = s.Ref,
                                Semester = s.Term
                            });
                        }
                    });


                    classWithSemesters.Add(
                        new YearWithSemesterViewModel
                        {
                            Academicyear = y.Stage,
                            Semesters = semesters
                        }
                    );
                });
                return Json(new ReturnData<List<YearWithSemesterViewModel>>
                {
                    Success = true,
                    Message = "",
                    Data = classWithSemesters
                });

            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Oops!  something went wrong while retrieving data, please try again " +
                              ErrorMessangesHandler.ExceptionMessage(ex)
                });
            }
        }

        public string Field(string contacts, string search)
        {
            var contactArray = contacts.Split("\r\n");
			if (contactArray.Count() < 2)
				contactArray = contactArray[0].Split(":");


			foreach (var item in contactArray)
            {
                if (item.CaseInsensitiveContains(search))
                {
                    return item;
                }
            }
            return search.ToUpper() + " : ";
        }
        [HttpGet("[action]")]
        public dynamic GetInstitutionHeaderDetails()
        {
            try
            {
                var setting = _context.SysSetup.Select(s => new
                {
                    s.OrgName,
					s.SubTitle,
                    s.Contacts,
                    s.EmailUname,
                    s.Smtpserver,
                }).FirstOrDefault();

				if (setting == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Oops!  We could find any system settings"
					});

				dynamic institutionInfo = new {
					setting
				};

				if (!string.IsNullOrEmpty(setting.Contacts))
				{
					var contactArray = setting.Contacts.Split("\r\n");
					if (contactArray.Count() < 2)
						contactArray = contactArray[0].Split(":");

					institutionInfo = new
					{
						setting,
						contactArray
					};
				}

				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Message = "",
					Data = institutionInfo
				});
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Oops!  something went wrong while retrieving data, please try again ",
                    Error = new Error(ex)
                });
            }
        }
    }
}