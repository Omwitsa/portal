using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Unisol.Web.Api.IServices;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Profile;
using Unisol.Web.Entities.Database.UnisolModels;
namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly UnisolAPIdbContext _context;
        private IStaffServices _staffServices;
        private IStudentServices _studentServices;

        public ProfileController(UnisolAPIdbContext context, IStaffServices staffServices, IStudentServices studentServices)
        {
            _context = context;
            _staffServices = staffServices;
            _studentServices = studentServices;
        }

        [HttpGet("[action]")]
        public JsonResult GetStudentInfo(string userCode, string classStatus)
        {
			try
			{
				var studRegister = _studentServices.GetRegister(userCode);
				if (!studRegister.Success)
					return Json(new ReturnData<string>
					{
						Success = studRegister.Success,
						Message = studRegister.Message
					});

				var dependants = _context.StudDependant.FirstOrDefault(d => d.AdmnNo.ToUpper().Equals(userCode.ToUpper()));

				var studDetails = new
				{
					register = studRegister.Data,
					dependants
				};

				return Json(new ReturnData<dynamic>
				{
					Success = studRegister.Success,
					Data = studDetails,
				});
			}
			catch(Exception ex) {
				return Json(new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, an error occurred"
				});
			}
        }

        [HttpGet("[action]")]
        public JsonResult GetEmploymentData(string userCode)
        {
            return Json(_staffServices.GetIpProfile(userCode));
        }

        [HttpGet("[action]")]
        public JsonResult GetJobTitle(string userCode)
        {
            return Json(_staffServices.GetJobTitle(userCode));
        }

        [HttpGet("[action]")]
        public JsonResult GetStudentEnrollmentProfile(string userCode, string classStatus)
        {
            return Json(_studentServices.GetAcademicProfile(userCode, classStatus));
        }

        [HttpGet("[action]")]
        public JsonResult GetStaffInfo(string userCode)
        {
            return Json(_staffServices.GetEmployees(userCode));
        }

        [HttpPost]
        [Route("upadateStudentProfile")]
        public JsonResult UpadateStudentProfile(StudentprofileViewModel profileViewModel, string classStatus, ProfileEditor editOperation)
        {
            try
            {
                var register = _context.Register.FirstOrDefault(r => r.AdmnNo.ToUpper().Equals(profileViewModel.AdmnNo.ToUpper()));
				if(editOperation == ProfileEditor.EditContacts)
				{
					register.Telno = profileViewModel?.Telno;
					register.Homeaddress = profileViewModel?.Homeaddress;
					register.Email = profileViewModel?.Email;
				}

				if(editOperation == ProfileEditor.EditOthers)
				{
					register.Language = profileViewModel?.Language;
					register.Special = profileViewModel?.Medical;
					register.Activity = profileViewModel?.Activity;
				}

				if(editOperation == ProfileEditor.EditEmergency)
				{
					register.Emname = profileViewModel?.EmergencyName;
					register.Emrel = profileViewModel?.EmergencyRelationShip;
					register.Emtel = profileViewModel?.EmergencyTelNo;
					register.Ememail = profileViewModel?.EmergencyEmail;
					register.Emaddress = profileViewModel?.EmergencyAddress;
					register.Emremarks = profileViewModel?.EmergencyRemarks;
				}

				if(editOperation == ProfileEditor.EditDependancies)
				{
					var dependant = _context.StudDependant.FirstOrDefault(s => s.AdmnNo.ToUpper().Equals(profileViewModel.AdmnNo.ToUpper()));
					dependant.Names = profileViewModel?.DependantName;
					dependant.Relationship = profileViewModel?.DependantRelationShip;
					dependant.Gender = profileViewModel?.DependantGender;
					dependant.Tel = profileViewModel?.DependantTelNo;
					dependant.Occupation = profileViewModel?.DependantOccupation;
					dependant.Notes = profileViewModel?.DependantNotes;
				}


				_context.SaveChanges();
				return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Profile Updated Successifully"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occurred,please retry : " + ex.Message
                });
            }
        }

        [HttpPost]
        [Route("upadateStaffProfile")]
        public JsonResult UpadateStaffProfile(StaffProfileViewModel profileViewModel)
        {
            try
            {
                var hrpEmployee = _context.HrpEmployee.FirstOrDefault(e => e.EmpNo == profileViewModel.EmpNo);
                if (hrpEmployee != null)
                {
                    hrpEmployee.Cell = profileViewModel.Cell;
                    hrpEmployee.Country = profileViewModel.Country;
                    hrpEmployee.Address = profileViewModel.Address;
                    hrpEmployee.City = profileViewModel.City;
                    hrpEmployee.County = profileViewModel.County;

                    _context.SaveChanges();
                }

                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Profile Updated Successifully"
                });

            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occurred,please retry : " + ex.Message
                });
            }
        }

		[HttpGet("[action]")]
		public JsonResult GetStaffs()
		{
			try
			{
				var staffs = _context.HrpEmployee.Where(e => !(bool)e.Terminated).ToList();
				return Json(new ReturnData<List<HrpEmployee>>
				{
					Success = true,
					Data = staffs
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
        public JsonResult GetEmployeeGrades()
        {
            try
            {
                var grades = _context.HrpPayGrades.Where(g => g.Edate == null || g.Edate > DateTime.UtcNow)
                    .Select(g => g.Names).Distinct().ToList();

                return Json(new ReturnData<List<string>>
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
    }
}