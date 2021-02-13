using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IServices;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class ComplaintController : Controller
	{
		private readonly PortalCoreContext _context;
		private readonly IUnisolApiProxy _unisolApiProxy;
		private string classStatus;
		public ComplaintController(PortalCoreContext context, IUnisolApiProxy unisolApiProxy)
		{
			_context = context;
			_unisolApiProxy = unisolApiProxy;
			classStatus = _context.Settings.FirstOrDefault()?.ClassStatus;
		}

		[HttpGet("[action]")]
		public JsonResult GetComplaints(string usercode, Role role, DateTime? from, DateTime? to)
		{
			try
			{
				var complaints = _context.Complaint.Where(c => c.Username.ToUpper().Equals(usercode.ToUpper())).OrderByDescending(c => c.CreatedDate).ToList();
				if (role == Role.Admin)
					complaints = _context.Complaint.Where(c => c.CreatedDate >= from && c.CreatedDate <= to).OrderByDescending(c => c.CreatedDate).ToList();
				if(role == Role.Staff)
					complaints = _context.Complaint.Where(c => c.Assignee.ToUpper().Contains($"-({usercode.ToUpper()})")).OrderByDescending(c => c.CreatedDate).ToList();
				complaints.ForEach(c => {
					if(c.Assignee != null)
					{
						var assignee = c.Assignee.Split("-(");
						c.Assignee = string.IsNullOrEmpty(assignee[0]) ? "" : assignee[0];
					}
				});
				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = complaints
				});
			}
			catch (Exception)
			{
				return Json(new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpPost("[action]")]
		public JsonResult CreateComplaint(Complaint complaint, Role role)
		{
			try
			{
				if(complaint.Id > 0)
				{
					var complain = _context.Complaint.FirstOrDefault(c => c.Id == complaint.Id);
					complain.Assignee = role == Role.Admin ? complaint.Assignee : complain.Assignee;
					complain.Status = role == Role.Admin ? complaint.Status : complain.Status;
					complain.Remarks = role == Role.Admin ? complaint.Remarks : complain.Remarks;
					complain.Action = role == Role.Admin ? complain.Action : complaint.Action;
				}
				else
				{
					complaint.Status = "Pending";
					var createResults = _unisolApiProxy.GetCurrentHostel(complaint.Username, classStatus).Result;
					var jdata = JsonConvert.DeserializeObject<ReturnData<HostelBooking>>(createResults);
					complaint.Hostel = jdata.Data?.Hostel ?? "";
					_context.Complaint.Add(complaint);
				}
				
				_context.SaveChanges();

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Submitted successfully"
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
		public JsonResult GetEmployees()
		{
			try
			{
				var createResults = _unisolApiProxy.GetEmployees().Result;
				var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(createResults);
				return Json(jdata);
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
	}
}
