using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Models;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class AttendanceController : Controller
	{
		private readonly PortalCoreContext _context;
		private readonly TokenValidator _tokenValidator;
		private readonly IUnisolApiProxy _unisolApiProxy;
		SystemService systemService;
		public AttendanceController(PortalCoreContext context, IUnisolApiProxy unisolApiProxy, IHostingEnvironment env)
		{
			_context = context;
			_unisolApiProxy = unisolApiProxy;
			_tokenValidator = new TokenValidator(context);
			systemService = new SystemService(context, env);
		}

		[HttpGet("getAttendance")]
		public JsonResult GetAttendance(string usercode, string searchText, Role role)
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

				var attendance = GetAttendanceDetails(usercode, searchText, role);
				return Json(attendance);
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

		private ReturnData<dynamic> GetAttendanceDetails(string usercode, string searchText, Role role)
		{
			try
			{
				var attendances = _context.TimeAttendance.Where(t => t.EmpNo.ToUpper().Equals(usercode.ToUpper()));
				if (role == Role.Admin)
					attendances = _context.TimeAttendance;

				var attendance = attendances.Where(t => t.Date.GetValueOrDefault().Year == DateTime.UtcNow.Year)
					.GroupBy(t => new { t.Date, t.EmpNo }).ToList();
				var myAttendance = new List<dynamic>();
				attendance.ForEach(a => {
					var In = a.OrderBy(t => t.Id).FirstOrDefault()?.Time;
					var Out = a.OrderByDescending(t => t.Id).FirstOrDefault()?.Time;
					var workedHours = Out - In;
					workedHours = workedHours > TimeSpan.FromHours(6) ? workedHours - TimeSpan.FromHours(1) : workedHours;

					myAttendance.Add(new
					{
						a.Key.EmpNo,
						a.Key.Date,
						In,
						Out,
						workedHours = systemService.GetPeriod(workedHours)
					});
				});

				myAttendance = myAttendance.OrderByDescending(t => t.Date).ToList();
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = myAttendance
				};
			}
			catch (Exception)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		[HttpPost("[action]")]
		public JsonResult MissedPunch(MissedPunch punch)
		{
			try
			{
				punch.Status = "Pending";
				if (punch.PunchDate == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly, pick the missed punch"
					});

				var missesPatchExist = _context.MissedPunch.Any(m => m.EmpNo.ToUpper().Equals(punch.EmpNo.ToUpper()) && m.PunchDate == punch.PunchDate);
				if(missesPatchExist)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, missed punch already exist"
					});

				var result = _unisolApiProxy.GetStaffData(punch.EmpNo).Result;
				var response = new ProcessJsonReturnResults<dynamic>(result).UnisolApiData;
				punch.Supervisor = response.Data?.supervisor ?? "";

				_context.MissedPunch.Add(punch);
				_context.SaveChanges();

				if (string.IsNullOrEmpty(punch.Reason))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide the reason"
					});

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Submitted successfully"
				});
			}
			catch (Exception)
			{
				return Json(new ReturnData<string> {
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpGet("getMissedPunch")]
		public JsonResult GetMissedPunch(string usercode, string searchText, Role role, bool isApproval = false)
		{
			try
			{
				var missedPunch = _context.MissedPunch.Where(m => m.EmpNo.ToUpper().Equals(usercode.ToUpper())).OrderByDescending(m => m.CreatedDate);
				if(isApproval)
					missedPunch = _context.MissedPunch.Where(m => m.Supervisor.ToUpper().Equals(usercode.ToUpper())).OrderByDescending(m => m.CreatedDate);
				if (role == Role.Admin)
					missedPunch = _context.MissedPunch.OrderByDescending(m => m.CreatedDate);

				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = missedPunch
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

		[HttpGet("getOfficeOuts")]
		public JsonResult GetOfficeOuts(string usercode, string searchText, Role role, bool isApproval = false)
		{
			try
			{
				var officeOuts = _context.OutOfOffice.Where(o => o.EmpNo.ToUpper().Equals(usercode.ToUpper())).OrderByDescending(o => o.CreatedDate);
				if(isApproval)
					officeOuts = _context.OutOfOffice.Where(o => o.Supervisor.ToUpper().Equals(usercode.ToUpper())).OrderByDescending(o => o.CreatedDate);
				if (role == Role.Admin)
					officeOuts = _context.OutOfOffice.OrderByDescending(o => o.CreatedDate);
				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = officeOuts
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
		public JsonResult OutOfOffice(OutOfOffice outOfOffice)
		{
			try
			{
				if(string.IsNullOrEmpty(outOfOffice.Reason))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide the reason"
					});
				
				if(outOfOffice.From == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly select start date"
					});

				if (outOfOffice.To == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly select end date"
					});

				if(outOfOffice.From < DateTime.UtcNow.AddHours(3))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Start date must be greater than today"
					});

				if(outOfOffice.To < outOfOffice.From)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "end date must be greater than start"
					});

				outOfOffice.Status = "Pending";
				var result = _unisolApiProxy.GetStaffData(outOfOffice.EmpNo).Result;
				var response = new ProcessJsonReturnResults<dynamic>(result).UnisolApiData;
				outOfOffice.Supervisor = response.Data?.supervisor ?? "";

				_context.OutOfOffice.Add(outOfOffice);
				_context.SaveChanges();
				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Submitted sucessfully"
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
		public JsonResult ApproveMissedPunch(MissedPunch punch){
			try
			{
				var missedPunch = _context.MissedPunch.FirstOrDefault(p => p.EmpNo.ToUpper().Equals(punch.EmpNo.ToUpper())
				&& p.PunchDate == punch.PunchDate);

				if(missedPunch != null)
				{
					missedPunch.Status = "Approved";
					_context.SaveChanges();
				}

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Approved sucessfully"
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
		public JsonResult ApproveOutOfOffice(OutOfOffice outOfOffice)
		{
			try
			{
				var officeOut = _context.OutOfOffice.FirstOrDefault(o => o.Id == outOfOffice.Id);
				if(officeOut != null)
				{
					officeOut.Status = "Approved";
					_context.SaveChanges();
				}

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Approved sucessfully"
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

		[HttpGet("getAttendanceSummery")]
		public JsonResult GetAttendanceSummery(DateTime? from,  DateTime? to, string empNo)
		{
			try
			{
				empNo = empNo ?? "";
				if (from == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide from date"
					});

				if(to == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide to date"
					});

				if(from > to)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "To date must be greater than from date"
					});
				
				var attendaceSummery = _context.TimeAttendance.Where(t => t.DateTime >= from && t.DateTime <= to 
				&& (t.EmpNo.ToUpper().Contains(empNo.ToUpper()))).OrderByDescending(t => t.DateTime).GroupBy(t => t.EmpNo).ToList();
				var summery = new List<dynamic>();
				attendaceSummery.ForEach(s => {
					TimeSpan? totalWorkedHours = TimeSpan.FromHours(0);
					TimeSpan? overtime = TimeSpan.FromHours(0);
					TimeSpan? losthours = TimeSpan.FromHours(0);
					var myAttendance = s.GroupBy(t => t.Date).ToList();
					myAttendance.ForEach(t =>
					{
						var In = t.OrderBy(a => a.Id).FirstOrDefault()?.Time;
						var Out = t.OrderByDescending(a => a.Id).FirstOrDefault()?.Time;
						var workedHours = (Out - In);
						workedHours = workedHours > TimeSpan.FromHours(6) ? workedHours - TimeSpan.FromHours(1) : workedHours;

						if (t.Key.GetValueOrDefault().DayOfWeek != DayOfWeek.Saturday && t.Key.GetValueOrDefault().DayOfWeek != DayOfWeek.Sunday)
						{
							totalWorkedHours = totalWorkedHours + workedHours;
							overtime = workedHours > TimeSpan.FromHours(8) ? overtime + workedHours - TimeSpan.FromHours(8) : overtime;
							losthours = workedHours < TimeSpan.FromHours(8) ? losthours + TimeSpan.FromHours(8) - workedHours : losthours;
						}
					});

					var hoursWorked = systemService.GetPeriod(totalWorkedHours);
					var overTime = systemService.GetPeriod(overtime);
					var lostHours = systemService.GetPeriod(losthours);
					summery.Add(new
					{
						EmpNo = s.Key,
						s.FirstOrDefault().Names,
						hoursWorked,
						overTime,
						lostHours
					});
				});

				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = summery
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
