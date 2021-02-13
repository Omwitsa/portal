using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class WorkRequestController : Controller
	{
		private IUnitOfWork _unitOfWork;
		public WorkRequestController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet("[action]")]
		public JsonResult GetWorkOrders(string usercode)
		{
			try
			{
				var workRequests = _unitOfWork.ESWorkRequests.GetWhere(w => w.EmpNo.ToUpper().Equals(usercode.ToUpper())).ToList();
				return Json(new ReturnData<List<ESWorkRequest>> {
					Success = true,
					Data = workRequests
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Opps, An error occured"
				});
			}
		}

		[HttpPost("[action]")]
		public JsonResult OrderWork(ESWorkRequest workRequest, bool isUpdate = false)
		{
			workRequest.RDate = DateTime.UtcNow.Date;
			workRequest.RTime = DateTime.UtcNow.AddHours(3);
			try
			{
				if (string.IsNullOrEmpty(workRequest.Subject))
					return Json(new ReturnData<string> {
						Success = false,
						Message = "Kindly provide the subject"
					});

				if (string.IsNullOrEmpty(workRequest.Description))
					return Json(new ReturnData<string> {
						Success = false,
						Message = "Kindly provide the description"
					});

				var message = "Submitted successfully";
				if (!isUpdate)
				{
					workRequest.Ref = GetRequestRef();
					workRequest.Personnel = workRequest.EmpNo;
					workRequest.Status = "Pending";
					workRequest.Reaction = "";
					_unitOfWork.ESWorkRequests.Add(workRequest);
				}
				else
				{
					message = "Updated successfully";
					var request = _unitOfWork.ESWorkRequests.GetFirstOrDefault(w => w.Ref.ToUpper().Equals(workRequest.Ref.ToUpper()));
					if(request != null)
						request.Reaction = workRequest.Reaction;
				}

				_unitOfWork.Save();
				return Json(new ReturnData<string> {
					Success = true,
					Message = message
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Opps, An error occured"
				});
			}
		}

		private string GetRequestRef()
		{
			var workReqest = _unitOfWork.ESWorkRequests.GetAll().OrderByDescending(r => Convert.ToInt32(r.Ref.Substring(2))).FirstOrDefault();
			if (workReqest == null)
				return "WR001";
			
			var count = workReqest.Ref.Count();
			var digits = workReqest.Ref.Substring(2);
			var sufix = Convert.ToInt32(digits);

			sufix++;

			var RefNo = "WR";
			if (sufix < 10) RefNo += "00" + sufix;

			if ((sufix > 9) && (sufix < 100)) RefNo += "0" + sufix;

			if (sufix > 99) RefNo += "" + sufix;
			return RefNo;
		}

		[HttpGet("[action]")]
		public JsonResult GetUserWorkRequestDetails(string usercode)
		{
			try
			{
				var userDetails = _unitOfWork.HrpEmployee.GetFirstOrDefault(e => e.EmpNo.ToUpper().Equals(usercode.ToUpper()));
				var projects = _unitOfWork.ESProjects.GetAll();
				var projectNames = projects.Select(v => v.Names.ToUpper()).Distinct().ToList();
				var locations = _unitOfWork.ESLocation.GetAll();
				var locationNames = locations.Select(l => l.Names.ToUpper()).Distinct().ToList();
				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						userDetails,
						projectNames,
						locationNames
					}
				});
			}
			catch (Exception e)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Opps, An error occured"
				});
			}
		}

		[HttpGet("[action]")]
		public JsonResult GetWorkOrderDetails(string usercode, string orderRef)
		{
			try
			{
				usercode = usercode ?? "";
				orderRef = orderRef ?? "";
				var workRequests = _unitOfWork.ESWorkOrders.GetFirstOrDefault(w => w.Requestor.ToUpper().Equals(usercode.ToUpper()) 
				&& w.RequestRef.ToUpper().Equals(orderRef.ToUpper()));
				var employeeDetails = _unitOfWork.HrpEmployee.GetFirstOrDefault(e => e.EmpNo.ToUpper().Equals(usercode.ToUpper()));
				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						workRequests,
						employeeDetails
					}
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Opps, An error occured"
				});
			}
		}
	}
}
