using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Api.IServices;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Common.ViewModels.Sor;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class IRController : Controller
	{
		private readonly UnisolAPIdbContext _context;
		private IStaffServices _staffServices;
		private Utils utils;

		public IRController(UnisolAPIdbContext context, IStaffServices staffServices)
		{
			_context = context;
			_staffServices = staffServices;
			utils = new Utils(context);
		}

		[HttpPost("[action]")]
		public JsonResult CreateIR(CreateSorModel createIR, string usercode)
		{
			try
			{
				var RefNo = GenerateRefNo("IRQ");
				var user = _context.HrpEmployee.FirstOrDefault(u => u.EmpNo == usercode);
				
				var procOnlineReq = new ProcOnlineReq
				{
					ReqRef = RefNo,
					DocType = "Internal Requisition",
					Usercode = usercode,
					Reaction = "",
					Notes = createIR.Details.Notes,
					Rdate = DateTime.UtcNow.Date,
					Rtime = DateTime.UtcNow.AddHours(3),
					Status = "Pending"
				};

				var wfRouting = _staffServices.GetWfRouting(procOnlineReq.DocType);
				if (!wfRouting.Success)
				{
					procOnlineReq.DocType = "STORES REQUISITION";
					wfRouting = _staffServices.GetWfRouting(procOnlineReq.DocType);
					if(!wfRouting.Success)
						return Json(wfRouting);
				}

				if (string.IsNullOrEmpty(wfRouting.Data.Id.ToString()))
					return Json(wfRouting);

				var workFlowStatus = utils.SaveToWorkFlowCenter(procOnlineReq, user, wfRouting.Data.Id.ToString());
				if (!workFlowStatus.Success)
					return Json(workFlowStatus);

				_context.ProcOnlineReq.Add(procOnlineReq);

				foreach (var irItem in createIR.Items)
				{
					_context.ProcOnlineReqDetail.Add(new ProcOnlineReqDetail
					{
						Amount = irItem.Totalamount,
						Cost = irItem.Unitamount,
						Qty = irItem.Quantity,
						ReqRef = procOnlineReq.ReqRef,
						UoM = irItem.Unitmeasure,
						Description = irItem.Description
					});
				}

				_context.SaveChanges();

				return Json(new ReturnData<ProcOnlineReq>
				{
					Success = true,
					Message = "Internal Requisition submited successfully"
				});
			}
			catch (Exception e)
			{
				return Json(new ReturnData<ProcOnlineReq>
				{
					Success = false,
					Message = "Sorry. Something went wrong.Please try again"
				});
			}
		}

		[HttpGet("[action]")]
		public JsonResult GetStaffIR(string usercode, string searchText)
		{
			var wfRouting = _staffServices.GetWfRouting("INTERNAL REQUISITION");
			if (!wfRouting.Success)
			{
				wfRouting = _staffServices.GetWfRouting("STORES REQUISITION");
				if(!wfRouting.Success)
					return Json(wfRouting);
			}

			var onlineRequestResponse = _staffServices.GetOnlineRequest("IRQ");
			if (!onlineRequestResponse.Success)
				return Json(onlineRequestResponse);

			var procItems = _staffServices.GetProcItems(searchText);
			if (!procItems.Success)
				return Json(procItems);

			var InternalRequitions = onlineRequestResponse.Data.Where(r => r.Usercode == usercode).OrderByDescending(r => r.Rdate).ToList();
			var requisitions = new List<dynamic>();
			InternalRequitions.ForEach(r => {
				var docCenterDetails = utils.GetDocCenterDetails(r.ReqRef);
				requisitions.Add(new
				{
					r.ReqRef,
					r.DocType,
					r.Usercode,
					r.Rdate,
					r.Rtime,
					r.Reaction,
					r.Reactby,
					r.ReactDate,
					r.ReactTime,
					r.Notes,
					r.Status,
					Reason = docCenterDetails?.Reason ?? ""
				});
			});

			return Json(new ReturnData<dynamic>
			{
				Success = true,
				Data = new
				{
					requisitions,
					procItems = procItems.Data
				}
			});
		}

		private string GenerateRefNo(string docType)
		{
			var onlineRequestResponse = _staffServices.GetOnlineRequest(docType);
			if (!onlineRequestResponse.Success || onlineRequestResponse.Data.Count < 1)
				return "IRQ001";
			
			var onlineRequest = onlineRequestResponse.Data
				.OrderByDescending(i => Convert.ToInt32(i.ReqRef.Substring(3))).FirstOrDefault();

			var count = onlineRequest.ReqRef.Count();
			var digits = onlineRequest.ReqRef.Substring(3, count - 3);
			var sufix = Convert.ToInt32(digits);

			sufix++;

			var RefNo = "IRQ";
			if (sufix < 10) RefNo += "00" + sufix;

			if ((sufix > 9) && (sufix < 100)) RefNo += "0" + sufix;

			if (sufix > 99) RefNo += "" + sufix;
			return RefNo;
		}
	}
}
