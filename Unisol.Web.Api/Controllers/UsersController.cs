using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Api.IServices;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Login;
using Unisol.Web.Common.ViewModels.Users;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.OldMembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers
{
    [Route("api/[controller]")]
	public class UsersController : Controller
	{
		private readonly UnisolAPIdbContext _context;
		private StudentCredential studentCredentials;
		private IStudentServices _studentServices;
		private ISystemServices _systemServices;
		private IStaffServices _staffServices;
		public UsersController(UnisolAPIdbContext context, IStudentServices studentServices, ISystemServices systemServices, 
			IStaffServices staffServices)
		{
			_context = context;
			_studentServices = studentServices;
			_systemServices = systemServices;
			_staffServices = staffServices;
			studentCredentials = new StudentCredential(context, studentServices, systemServices);
		}

		[HttpGet("[action]")]
		public JsonResult CheckIfGenesis()
		{
			return Json(_studentServices.CheckIfGenesis());
		}

		[HttpPost("[action]")]
		public JsonResult CheckStudentExists([FromBody] RegisterViewModel reg, string classStatus)
		{
			try
			{
				var studentDetails = studentCredentials.GetStudentDetails(reg.RegNumber, classStatus);
				return Json(studentDetails);
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "An error occoured"
				});
			}
		}

		[HttpPost("[action]")]
		public JsonResult ReturnStudentDetails([FromBody] RegisterViewModel reg, string classStatus)
		{
			try
			{
				var studentDetails = studentCredentials.GetStudentDetails(reg.RegNumber, classStatus);
				if (!studentDetails.Success)
					return Json(new ReturnData<string>
					{
						Success = studentDetails.Success,
						Message = studentDetails.Message
					});

				var studentProgramme = _studentServices.GetProgramme(reg.RegNumber, classStatus);
				if (!studentProgramme.Success)
					return Json(new ReturnData<string>
					{
						Success = studentProgramme.Success,
						Message = studentProgramme.Message
					});

				var studentClass = _studentServices.GetClass(reg.RegNumber, classStatus);
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
					studentDetails.Data.Telno,
					studentDetails.Data.Email,
					studentDetails.Data.Programme,
					ProgrammeCode = studentProgramme.Data.Code,
					studentProgramme.Data.Department,
					StudentClass = studentClass.Data.Id,
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
		public HrpEmployee ReturnStaffDetails([FromBody] RegisterViewModel reg)
		{
			return _context.HrpEmployee.FirstOrDefault(s => s.EmpNo == reg.RegNumber);

		}

		[HttpPost("[action]")]
		public JsonResult CheckEmployeeExists([FromBody] RegisterViewModel reg)
		{
			try
			{
				var register = _context.HrpEmployee.FirstOrDefault(s => s.EmpNo.ToUpper().Equals(reg.RegNumber.ToUpper()) && !(bool)s.Terminated);
				if (register == null)
					return Json(new ReturnData<HrpEmployee>
					{
						Success = false,
						Message = "Your employee number is invalid"
					});
				
				if (string.IsNullOrEmpty(register.Wemail))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Your email is invalid"
					});

				return Json(new ReturnData<HrpEmployee>
				{
					Data = register,
					Message = "Found"
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = ex.Message
				});
			}
		}

		[HttpGet("[action]")]
		public JsonResult GetBunchUsers(Role role)
		{
			try
			{
				var sysSetup = _systemServices.GetSystemSetup();
				if (!sysSetup.Success)
					return Json(new ReturnData<string>
					{
						Success = sysSetup.Success,
						Message = sysSetup.Message
					});

				var members = new List<Membership>();
				if (sysSetup.Data.SubTitle.ToUpper().Equals("TKNP"))
				{
					if (Role.Student == role)
					{
						members = _context.Register.Where(r => !string.IsNullOrEmpty(r.Email)).Select(r => new Membership
						{
							UserName = r.AdmnNo,
							Email = r.Email
						}).ToList();
					}

					if (Role.Staff == role)
					{
						members = _context.HrpEmployee.Where(e => !string.IsNullOrEmpty(e.Wemail)).Select(e => new Membership
						{
							UserName = e.EmpNo,
							Email = e.Wemail
						}).ToList();
					}
				}

				if (members.Count < 1)
					return Json(new ReturnData<List<Membership>>
					{
						Success = false,
						Message = "Sorry, No user found. Kindly ensure emails have been configured in the ERP"
					});

				return Json(new ReturnData<List<Membership>>
				{
					Success = true,
					Data = members
				});
			}
			catch (Exception e)
			{
				return Json(new ReturnData<List<Membership>>
				{
					Success = false,
					Message = "An error occurred"
				});
			}
		}

		[HttpGet("[action]")]
		public JsonResult FetchEmployees()
		{
			var employees = _staffServices.FetchEmployees();
			return Json(employees);
		}

        [HttpGet("[action]")]
        public JsonResult GetMessageRecepients(string username)
        {
            var recipients = _systemServices.GetMessageRecepients(username);
            return Json(recipients);
        }

		[HttpGet("[action]")]
		public JsonResult GetActiveStudents()
		{
			var students = _studentServices.GetActiveStudents();
			return Json(students);
		}

		[HttpGet("[action]")]
		public JsonResult UpdatePortalEmails()
		{
			try
			{
				
				var students = _context.Register.Select(r => new ErpEmailVm
				{
					Username = r.AdmnNo.ToUpper(),
					Email = r.Email
				}).ToList();

				var employees = _context.HrpEmployee.Select(e => new ErpEmailVm
				{
					Username = e.EmpNo.ToUpper(),
					Email = e.Wemail
				}).ToList();

				var erpEmails = new List<ErpEmailVm>();
				erpEmails.AddRange(students);
				erpEmails.AddRange(employees);
				erpEmails = erpEmails.ToList();

				return Json(new ReturnData<List<ErpEmailVm>>
				{
					Success = true,
					Message = "emails updated successfully",
					Data = erpEmails
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
	}
}