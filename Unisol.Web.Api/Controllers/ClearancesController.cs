using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Common.ViewModels.Institution;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClearancesController : Controller
    {
        private readonly UnisolAPIdbContext _context;
        private readonly Utils _utils;

        public ClearancesController(UnisolAPIdbContext context)
        {
            _context = context;
            _utils = new Utils(context);
        }

        [HttpPost("[action]")]
        public JsonResult Apply(StudClearance clearance, Role role)
        {
            try
            {
				if(role == Role.Student)
				{
					var cleared = _context.StudClearances.FirstOrDefault(c => c.AdmnNo.ToUpper().Equals(clearance.AdmnNo.ToUpper()));
					if (cleared != null)
					{
						var message = cleared.Status.ToLower().Equals("approved") ? "You have already cleared" : $"Your clearance is {cleared.Status.ToLower()}";
						return Json(new ReturnData<string>
						{
							Success = false,
							Message = message
						});
					}
				}
				if(role == Role.Staff)
				{
					var cleared = _context.HrpStaffClearance.FirstOrDefault(c => c.EmpNo.ToUpper().Equals(clearance.AdmnNo.ToUpper()));
					if (cleared != null)
					{
						var message = cleared.Status.ToLower().Equals("approved") ? "You have already cleared" : $"Your clearance is {cleared.Status.ToLower()}";
						return Json(new ReturnData<string>
						{
							Success = false,
							Message = message
						});
					}
				}
					
				var docType = role == Role.Student ? "STUDENT CLEARANCE" : "STAFF CLEARANCE";
                var procOnlineReq = new ProcOnlineReq
                {
                    ReqRef = clearance.AdmnNo,
                    DocType = docType.ToUpper(),
                    Rdate = DateTime.Today,
                    Rtime = DateTime.UtcNow,
                    Usercode = clearance.AdmnNo,
                    Status = "Pending"
                };

                var docId = _context.Wfrouting
                    .FirstOrDefault(r => r.Document.ToUpper() == procOnlineReq.DocType.ToUpper())
                    ?.Id.ToString();

                if (string.IsNullOrEmpty(docId))
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Sorry, " + procOnlineReq.DocType.ToUpper() + " " +
                                  "Not supported at the moment. Please contact the admin"
                    });

				var user = new HrpEmployee();
				if (role == Role.Staff)
					user = _context.HrpEmployee.FirstOrDefault(u => u.EmpNo.ToUpper().Equals(clearance.AdmnNo.ToUpper()));
				else
					user = _context.Register.Join(_context.Programme, r => r.Programme, p => p.Names,
					(r, p) => new HrpEmployee
					{
						EmpNo = r.AdmnNo,
						Names = r.Names,
						Department = p.Department
					}).FirstOrDefault(r => r.EmpNo.Equals(clearance.AdmnNo));

				var workFlowStatus = _utils.SaveToWorkFlowCenter(procOnlineReq, user, docId, clearance.Notes);
                if (!workFlowStatus.Success)
                    return Json(workFlowStatus);

				if(role == Role.Student)
					_context.StudClearances.Add(clearance);
				if (role == Role.Staff)
					_context.HrpStaffClearance.Add(new HrpStaffClearance {
						EmpNo = clearance.AdmnNo,
						Status = clearance.Status,
						Personnel = clearance.Personnel,
						Notes = clearance.Notes
					});

				_context.SaveChanges();

                var msg = $"Your clearance application {clearance.AdmnNo} submited succesfully.";
                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = msg,
                    Data = clearance.AdmnNo
				});
            }
            catch (Exception e)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "There was a problem while trying to apply for clearance.",
                    Error = new Error(e)
                });
            }
        }

        [HttpGet("[action]")]
        public JsonResult History(string admnNo, Role role)
        {
            try
            {
                var clearances = _context.HrpStaffClearance
				   .Join(_context.WfdocCentre, sc => sc.EmpNo, dc => dc.DocNo, (sc, dc) => new
				   {
					   Status = dc.FinalStatus,
					   AdmnNo = dc.DocNo,
					   sc.Notes,
					   Comments = dc.LatestApprovalReason,
					   sc.Rdate
				   })
				   .Where(c => c.AdmnNo.Equals(admnNo)).ToList();

				if (role == Role.Student)
					clearances = _context.StudClearances
					.Join(_context.WfdocCentre, sc => sc.AdmnNo, dc => dc.DocNo, (sc, dc) => new
					{
						Status = dc.FinalStatus,
						AdmnNo = dc.DocNo,
						sc.Notes,
						Comments = dc.LatestApprovalReason,
						sc.Rdate
					})
					.Where(c => c.AdmnNo.Equals(admnNo)).ToList();

				var response = new ReturnData<dynamic>
                {
                    Success = clearances.Any(),
                    Data = clearances,
                    Message = clearances.Any() ? "Found" : "Not Found"
                };

                return Json(response);
            }
            catch (Exception e)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "There was a problem while trying to get clearances.",
                    Error = new Error(e)
                });
            }
        }

		[HttpGet("[action]")]
		public JsonResult GetCertificateDetails(string usercode, bool isStudent = false)
		{
			try
			{
				var sysSetup = _context.SysSetup.Select(s => new {
					s.OrgName,
					s.SubTitle
				}).FirstOrDefault();
				var hasCleared = _context.StudClearances.Any(c => c.AdmnNo.ToUpper().Equals(usercode.ToUpper()) && c.Status.ToLower().Equals("approved"));
				var certificateDetails = new CertificateVm();
				if (isStudent)
				{
					var register = _context.Register.FirstOrDefault(r => r.AdmnNo.ToUpper().Equals(usercode.ToUpper()));
					var enrolment = _context.StudEnrolment.FirstOrDefault(e => e.AdmnNo.ToUpper().Equals(usercode.ToUpper()));
					var studClass = _context.Class.FirstOrDefault(c => c.Id.ToUpper().Equals(enrolment.Class.ToUpper()));
					var programmes = _context.Programme.FirstOrDefault(p => p.Names.ToUpper().Equals(studClass.Programme.ToUpper()));
					var department = _context.Department.FirstOrDefault(d => d.Names.ToUpper().Equals(programmes.Department.ToUpper()));

					certificateDetails.UserName = register?.AdmnNo ?? "";
					certificateDetails.NationalId = register?.NationalId ?? "";
					certificateDetails.OrgName = sysSetup?.OrgName ?? "";
					certificateDetails.Initials = sysSetup?.SubTitle ?? "";
					certificateDetails.AdmissionDate = studClass?.Starts ?? DateTime.UtcNow.AddHours(3);
					certificateDetails.FinalDate = studClass?.Ends ?? DateTime.UtcNow.AddHours(3);
					certificateDetails.School = department?.School ?? "";
					certificateDetails.Porgramme = programmes?.Names ?? "";
					certificateDetails.Names = register?.Names ?? "";
				}
				else
				{
					hasCleared = _context.HrpStaffClearance.Any(c => c.EmpNo.ToUpper().Equals(usercode.ToUpper()) && c.Status.ToLower().Equals("approved"));
					var employee = _context.HrpEmployee.FirstOrDefault(e => e.EmpNo.ToUpper().Equals(usercode.ToUpper()));
					var service = _context.HrpService.Where(s => s.EmpNo.ToUpper().Equals(usercode.ToUpper()))
						.OrderByDescending(s => s.Id).FirstOrDefault();
					certificateDetails.UserName = employee?.EmpNo ?? "";
					certificateDetails.NationalId = employee?.Idno ?? "";
					certificateDetails.OrgName = sysSetup?.OrgName ?? "";
					certificateDetails.Initials = sysSetup?.SubTitle ?? "";
					certificateDetails.AdmissionDate = employee?.Hdate ?? DateTime.UtcNow.AddHours(3);
					certificateDetails.FinalDate = employee?.TerminationDate ?? DateTime.UtcNow.AddHours(3);
					certificateDetails.Names = employee?.Names ?? "";
					certificateDetails.EmploymentCategory = employee.EmpCat ?? "";
					certificateDetails.JobTitle = service?.JobTitle ?? "";
					certificateDetails.Rank = service?.Rank ?? "";
					certificateDetails.Department = employee?.Department ?? "";
					certificateDetails.Location = employee?.Location ?? "";
				}

				
				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						certificateDetails,
						hasCleared
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

		[HttpGet("[action]")]
		public JsonResult GetSurveyStatus(string usercode)
		{
			try
			{
				var status = "Clearance before graduation";
				var docCenter = _context.WfdocCentre.FirstOrDefault(d => d.UserRef.ToUpper().Equals(usercode.ToUpper()) && d.Type.ToUpper().Equals(status.ToUpper()));
				status = docCenter == null ? status : "Clearance after graduation";
				return Json(new ReturnData<string> {
					Success = true,
					Data = status
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

		private string GenerateRefNo()
        {
            var count = _context.StudClearances.Count() + 1;
            return "STC" + count.ToString("D5"); ;
        }
    }
}
