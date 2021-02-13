using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Api.IServices;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Common.ViewModels.Leave;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers.Leave
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class LeaveController : Controller
	{
		private readonly UnisolAPIdbContext _context;
		private IStaffServices _staffServices;
		private Utils utils;

		public LeaveController(UnisolAPIdbContext context, IStaffServices staffServices)
		{
			_context = context;
			_staffServices = staffServices;
			utils = new Utils(context);
		}

		[HttpGet("[action]")]
		public JsonResult GetForEmployee(string empNo)
		{
			var applicationResponse = _staffServices.GetLeaveApplication();
			if (!applicationResponse.Success)
				return Json(applicationResponse);

			var leaveApplications = applicationResponse.Data.Where(a => a.EmpNo.ToUpper().Equals(empNo.ToUpper())).ToList();
			if (leaveApplications.Count < 1)
				return Json(new ReturnData<List<HrpLeaveApp>>
				{
					Success = true,
					Message = "No current leave applications",
				});

			var appliedLeaves = new List<LeaveAppVm>();
			leaveApplications.ForEach(l => {
				var docCenterDetails = utils.GetDocCenterDetails(l.Ref);
				appliedLeaves.Add(new LeaveAppVm{
					Ref = l.Ref,
					LeavePeriod = l.LeavePeriod,
					EmpNo = l.EmpNo,
					LeaveType = l.LeaveType,
					Sdate = l.Sdate,
					Stime = l.Stime,
					Edate = l.Edate,
					Etime = l.Etime,
					LeaveDays = l.LeaveDays,
					Notes = l.Notes,
					Status = l.Status,
					Rdate = l.Rdate,
					Personnel = l.Personnel,
					Reliever = l.Reliever,
					Emergency = l.Emergency,
					Reason = docCenterDetails?.Reason ?? ""
				});
			});


			return Json(new ReturnData<List<LeaveAppVm>>
			{
				Success = true,
				Message = "Current leave applications",
				Data = appliedLeaves,
				TotalItems = leaveApplications.Count
			});
		}

		[HttpPost("[action]")]
		public JsonResult ApplyLeave(HrpLeaveApp leave, bool leaveRelieverMandatory)
		{
			try
			{
				leave.LeavePeriod = _context.HrpLeavePeriod.OrderByDescending(p => p.EndDate).FirstOrDefault(p => p.StartDate.Year == DateTime.UtcNow.Year)?.Names ?? DateTime.UtcNow.Year.ToString();
				leave.Reliever = leave.Reliever ?? "";
				var reliverDetails = leave.Reliever.Split("-(");
				if(reliverDetails.Count() > 1)
					leave.Reliever = reliverDetails[1] ?? "";
				leave.Reliever = leave.Reliever.Replace(")", "");
				if (leave.LeaveType.ToLower().Equals("maternity leave"))
				{
					if (!CanApplyMaternityLeave(leave.EmpNo, leave.LeaveType))
						return Json(new ReturnData<HrpLeaveApp>
						{
							Success = false,
							Message = "Application failed. Only Female can apply for this leave",
							Data = leave
						});
				}

				var leaveExists = _context.HrpLeaveApp.Any(l => l.Status.Equals("Pending") &&
					 l.LeaveType.Equals(leave.LeaveType) && l.EmpNo.Equals(leave.EmpNo));
				if (leaveExists)
					return Json(new ReturnData<HrpLeaveApp>
					{
						Success = false,
						Message = $"You have a Pending {leave.LeaveType} Application",
						Data = leave
					});

				leave.Ref = GenerateAppNo();
				//var leaveDaysDetails = _staffServices.GetEmpLeaveDays(leave.EmpNo);
				//if (!leaveDaysDetails.Success)
				//	return Json(leaveDaysDetails);

				//var days = leaveDaysDetails.Data.Where(l => l.LeaveType.CaseInsensitiveContains(leave.LeaveType)).Sum(x => x.LeaveDays) ?? 0;
				var days = _staffServices.GetUserLeavesEntitled(leave.EmpNo, leave.LeaveType);
				var procOnlineReq = new ProcOnlineReq
				{
					ReqRef = leave.Ref,
					DocType = "LEAVE APPLICATION",
					Rdate = DateTime.UtcNow.Date,
					Rtime = DateTime.UtcNow.AddHours(3),
					Usercode = leave.EmpNo,
					Status = "Pending"
				};

				var docId = _context.Wfrouting.FirstOrDefault(r => r.Document.ToUpper() == procOnlineReq.DocType.ToUpper())?.Id.ToString();
				if (string.IsNullOrEmpty(docId))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, " + procOnlineReq.DocType.ToUpper() + " Not supported at the moment. Please contact the admin"
					});

				if (days < 1)
					return Json(new ReturnData<HrpLeaveApp>
					{
						Success = false,
						Message = string.Format("Application failed. Your have {0} days for this leave", days),
						Data = leave
					});

                if (!leaveRelieverMandatory)
                {
					var user = _context.HrpEmployee.FirstOrDefault(u => u.EmpNo == leave.EmpNo);
					var description = $"Type of Leave: {leave.LeaveType}; Number of days requested: {leave.LeaveDays}; From: {String.Format("{0:d}", leave.Sdate)} To: {String.Format("{0:d}", leave.Edate)}";
					var workFlowStatus = utils.SaveToWorkFlowCenter(procOnlineReq, user, docId, description);
					if (!workFlowStatus.Success)
						return Json(workFlowStatus);
				}

				_context.HrpLeaveApp.Add(leave);
				_context.SaveChanges();
				return Json(new ReturnData<HrpLeaveApp>
				{
					Success = true,
					Message = "Your leave application was submited succesfully",
					Data = leave
				});

			}
			catch (Exception e)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "There was a problem while trying to apply leave.",
					Error = new Error(e)

				});
			}
		}
		private string GenerateAppNo()
		{
			var applicationDetails = _staffServices.GetLeaveApplication();
			if (!applicationDetails.Success)
				return "LVE001";
			var hrpleaveNo = applicationDetails.Data.OrderByDescending(l => Convert.ToInt32(l.Ref.Substring(3))).FirstOrDefault();
			var count = hrpleaveNo.Ref.Count();
			var digits = hrpleaveNo.Ref.Substring(3, count - 3);
			var sufix = Convert.ToInt32(digits);

			sufix++;

			var leaveNo = "LVE";
			if (sufix < 10) leaveNo += "00" + sufix;

			if (sufix < 100) leaveNo += "0" + sufix;

			if (sufix > 99) leaveNo += "" + sufix;

			return leaveNo;
		}

		[HttpGet("[action]")]
		public JsonResult GetByRef(string appRef)
		{
			var applicationDetails = _staffServices.GetLeaveApplication();
			if (!applicationDetails.Success)
				return Json(applicationDetails);

			var leave = applicationDetails.Data.FirstOrDefault(l => l.Ref == appRef);
			if (leave == null)
				return Json(new ReturnData<HrpLeaveApp>
				{
					Success = false,
					Message = "Leave application not found ."
				});

			return Json(new ReturnData<HrpLeaveApp>
			{
				Success = true,
				Message = "Leave application found",
				Data = leave
			});
		}

		[HttpGet("[action]")]
		public JsonResult GetAll(string status = null)
		{
			var applicationDetails = _staffServices.GetLeaveApplication();
			var apps = status == null ? applicationDetails.Data : applicationDetails.Data.Where(a => a.Status.ToLower().Equals(status.ToLower())).ToList();
			if (apps.Count < 1)
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "No current leave applications",
				});

			return Json(new ReturnData<List<HrpLeaveApp>>
			{
				Success = true,
				Message = "Current leave applications",
				Data = apps,
				TotalItems = apps.Count
			});
		}

		[HttpGet("[action]")]
		public JsonResult GetEmpLeaveDays(string empNo)
		{
			try
			{
				var leaveDaysDetails = _staffServices.GetEmpLeaveDays(empNo);
				if (!leaveDaysDetails.Success)
					return Json(leaveDaysDetails);

				var emp = _context.HrpEmployee.FirstOrDefault(e => e.EmpNo.ToLower().Equals(empNo.ToLower()));
				if (emp == null) return null;

				if (emp.Gender.ToLower().Equals("male"))
				{
					leaveDaysDetails.Data.RemoveAll(x => x.LeaveType.ToLower().Equals("maternity leave"));
				}

				var list = leaveDaysDetails.Data.GroupBy(x => x.LeaveType).Select(grp => grp.First()).ToList();
				var listSum = new List<LeaveDaysSum>();
				foreach (var lv in list)
				{
					var sum = leaveDaysDetails.Data.Where(x => x.LeaveType.Equals(lv.LeaveType)).Sum(s => s.LeaveDays) ?? 0;
					var l = new LeaveDaysSum
					{
						Code = lv.Code,
						LeaveDays = sum,
						LeaveGroup = lv.LeaveGroup,
						LeaveType = lv.LeaveType
					};
					listSum.Add(l);

				}


				if (leaveDaysDetails.Data.Count > 0)
				{
					return Json(new ReturnData<List<LeaveDaysSum>>
					{
						Success = true,
						Message = "Leave days found",
						Data = listSum,
						TotalItems = listSum.Count
					});
				}
				return Json(new ReturnData<List<LeaveDaysSum>>
				{
					Success = false,
					Message = "No Leave days found",
				});
			}
			catch (Exception e)
			{
				return Json(new ReturnData<List<LeaveDaysSum>>
				{
					Success = false,
					Message = "Error getting Leave days",
					Error = new Error(e)
				});
			}
		}
		[HttpGet("[action]")]
		public JsonResult GetLeaveDaysCredit(string empNo)
		{
			try
			{	
				var leaveDaysCrdt = _staffServices.GetEmpLeaveDaysCredit(empNo);
				var employees = _context.HrpEmployee.Where(e => !(bool)e.Terminated && !e.EmpNo.ToUpper().Equals(empNo.ToUpper())).Select(e => new { e.EmpNo, e.Names }).ToList();
				if (leaveDaysCrdt.Success)
					return Json(new ReturnData<dynamic>
					{
						Success = true,
						Data = new {
							leave = leaveDaysCrdt.Data,
							employees
						},
						Message = leaveDaysCrdt.Message,
						NotAuthenticated = false
					});
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = leaveDaysCrdt.Message,
				});
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, an error occurred. Please try again later",
				});
			}
		}
		[HttpPost("[action]")]
		public JsonResult RemoveNonLeaveDays(GetDaysRequest request)
		{
			if (request.Dates.Count > 0)
			{
				var isCalenderDays = _context.HrpLeaveType.Any(t => t.Names.ToUpper().Equals(request.LeaveType.ToUpper()) && (bool)t.CalendarDays);
				if (!isCalenderDays)
				{
					var nonWorkingDays = NonWorkingWeekDays();

					foreach (var day in nonWorkingDays)
					{
						request.Dates.RemoveAll(x => DateTime.Parse(x).ToLongDateString().CaseInsensitiveContains(day));
					}

					var yearHolidays = YearHolidayDays(request.LeavePeriod, request.SDate, request.EDate);
					if (yearHolidays.Count > 0)
					{
						foreach (var holiday in yearHolidays)
						{
							request.Dates.RemoveAll(x => DateTime.Parse(x).Date.Equals(holiday.Hdate));
						}
					}
				}

				return Json(new ReturnData<List<string>>
				{
					Success = true,
					Message = "Valid leave dates",
					Data = request.Dates
				});
			}

			return Json(new ReturnData<string>
			{
				Success = false,
				Message = "Leave dates not valid"
			});
		}

		public bool CanApplyMaternityLeave(string empNo, string leaveType)
		{
			var emp = _context.HrpEmployee.FirstOrDefault(e => e.EmpNo.ToLower().Equals(empNo.ToLower()));
			if (emp == null) return false;

			var gender = emp.Gender;
			if (gender.ToLower().Equals("male") && leaveType.ToLower().Equals("maternity leave"))
				return false;
			return true;
		}

		public List<HrpLeaveHolidays> YearHolidayDays(string leavePeriod, DateTime leaveSDate, DateTime leaveEDate)
		{
			try
			{
				var holidays = _context.HrpLeaveHolidays.Where(h =>
					h.LeavePeriod.Equals(leavePeriod) && (h.Hdate >= leaveSDate && h.Hdate <= leaveEDate)).ToList();

				return holidays;

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return new List<HrpLeaveHolidays>();
			}
		}

		[HttpPost("[action]")]
		public JsonResult ApproveLeave(LeaveApproveVm approveVm)
		{
			try
			{
				var leave = _context.HrpLeaveApp.FirstOrDefault(l => l.Ref.ToUpper().Equals(approveVm.LeaveRef.ToUpper()));
				var procOnlineReq = new ProcOnlineReq
				{
					ReqRef = leave.Ref,
					DocType = "LEAVE APPLICATION",
					Rdate = DateTime.UtcNow.Date,
					Rtime = DateTime.UtcNow.AddHours(3),
					Usercode = leave.EmpNo,
					Status = "Pending"
				};
				var user = _context.HrpEmployee.FirstOrDefault(u => u.EmpNo.ToUpper().Equals(leave.EmpNo.ToUpper()));
				var description = $"Type of Leave: {leave.LeaveType}; Number of days requested: {leave.LeaveDays}; From: {String.Format("{0:d}", leave.Sdate)} To: {String.Format("{0:d}", leave.Edate)}";
				var docId = _context.Wfrouting.FirstOrDefault(r => r.Document.ToUpper() == procOnlineReq.DocType.ToUpper())?.Id.ToString() ?? "";
				var workFlowStatus = utils.SaveToWorkFlowCenter(procOnlineReq, user, docId, description);
				if (!workFlowStatus.Success)
					return Json(workFlowStatus);

				return Json(new ReturnData<string> {
					Success = true,
					Message = "Leave Approved successfully"
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

		public List<string> NonWorkingWeekDays(string type = null)
		{
			try
			{
				var typ = string.IsNullOrEmpty(type) ? "non-working day" : type;
				var days = _context.HrpLeaveWorkWeek.Where(d => d.Type.ToLower().Equals(typ)).ToList();

				var res = days.Select(day => day.Names.Substring(0, 3)).ToList();
				return res;

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return new List<string>();
			}
		}
	}
}
