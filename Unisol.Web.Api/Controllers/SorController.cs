using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Common.ViewModels.Sor;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Api.IServices;

namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SorController : Controller
    {
        private readonly UnisolAPIdbContext _context;
		private IStaffServices _staffServices;
		private Utils utils;
		public SorController(UnisolAPIdbContext context, IStaffServices staffServices)
        {
            _context = context;
			_staffServices = staffServices;
			utils = new Utils(context);
		}

        [HttpGet("[action]")]
        public JsonResult GetSorsRaised(string usercode) {
            try
			{
				var onlineRequests = _staffServices.GetOnlineRequest("SOR");
				if (!onlineRequests.Success)
					return Json(onlineRequests);
				
				var raisedSors = onlineRequests.Data.Where(s => s.Usercode.ToUpper().Equals(usercode.ToUpper())).OrderByDescending(s => s.Rdate).ToList();
				var sors = new List<dynamic>();
				raisedSors.ForEach(s => {
					var docCenterDetails = utils.GetDocCenterDetails(s.ReqRef);
					sors.Add(new {
						s.ReqRef,
						s.DocType,
						s.Usercode,
						s.Rdate,
						s.Rtime,
						s.Reaction,
						s.Reactby,
						s.ReactDate,
						s.ReactTime,
						s.Notes,
						s.Status,
						Reason = docCenterDetails?.Reason ?? ""
					});
				});

				var unitOfMeasure = _staffServices.GetUnitOfMeasure();
				if (!unitOfMeasure.Success)
					return Json(unitOfMeasure);

				return Json(new ReturnData<dynamic>
                {
                    Success = true,
                    Message = "All Sors you have raised",
                    Data = new
					{
						sors,
						Uom = unitOfMeasure.Data
					}
                });
            }
			catch (Exception ex) {
                return Json(new ReturnData<List<ProcOnlineReq>>
                {
                    Success = false,
                    Message = "Sorry something went wrong while retrieving SORS, please try again",
                    Error = new Error(ex)
                });
            }
        }

        [HttpGet("[action]")]
        public JsonResult GetSorDetails(string reqref)
        {
            try
            {
                var sorsitems = _context.ProcOnlineReqDetail.Where(s => s.ReqRef == reqref).ToList();
                return Json(new ReturnData<List<ProcOnlineReqDetail>>
                {
                    Success = true,
                    Message = reqref+" SoR items",
                    Data = sorsitems
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<List<ProcOnlineReq>>
                {
                    Success = false,
                    Message = "Sorry something went wrong while retrieving SOR items, please try again",
                    Error = new Error(ex)
                });
            }
        }

        [HttpPost("[action]")]
        public JsonResult CreateAnSor(CreateSorModel sor)
        {
            try
            {
                var sorNo = GenerateRefNo();
				var user = _context.HrpEmployee.FirstOrDefault(u => u.EmpNo == sor.Details.Usercode);

				var procOnlineReq = new ProcOnlineReq
				{
					ReqRef = sorNo,
					DocType = "SPECIFICATION OF REQUIREMENT",
					Rdate = DateTime.UtcNow.Date,
					Rtime = DateTime.UtcNow.AddHours(3),
					Usercode = sor.Details.Usercode,
					Reaction = "",
					Status = "Pending",
					Notes = sor.Details.Notes
				};

				var wfRouting = _staffServices.GetWfRouting(procOnlineReq.DocType);
				if (!wfRouting.Success)
					return Json(wfRouting);

				if (string.IsNullOrEmpty(wfRouting.Data.Id.ToString()))
					return Json(wfRouting);

				var workFlowStatus = utils.SaveToWorkFlowCenter(procOnlineReq, user, wfRouting.Data.Id.ToString());
				if (!workFlowStatus.Success)
					return Json(workFlowStatus);

				_context.ProcOnlineReq.Add(procOnlineReq);

                foreach (var soritem in sor.Items) {
					_context.ProcOnlineReqDetail.Add(new ProcOnlineReqDetail {
						Amount = soritem.Totalamount,
						Cost = soritem.Unitamount,
						Qty = soritem.Quantity,
						ReqRef = procOnlineReq.ReqRef,
						UoM = soritem.Unitmeasure,
						Description = soritem.Description
					});
                }

				_context.SaveChanges();

				return Json(new ReturnData<CreateSorModel>
                {
                    Success = true,
                    Message = "SOR submited successfully"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<CreateSorModel>
                {
                    Success = false,
                    Message = "Sorry. Something went wrong.Please try again",
                    Error = new Error(ex)
                });
            }
        }

        private string GenerateRefNo()
        {
			var onlineRequests = _staffServices.GetOnlineRequest("SOR");
			if(!onlineRequests.Success)
				return "SOR001";

			var sors = onlineRequests.Data.ToList()
				.OrderByDescending(s => Convert.ToInt32(s.ReqRef.Substring(3)))
                .FirstOrDefault();

            if (sors == null)
                return "SOR001";

            var count = sors.ReqRef.Count();
            var digits = sors.ReqRef.Substring(3, count - 3);
            var sufix = Convert.ToInt32(digits);

            sufix++;

            var RefNo = "SOR";
            if (sufix < 10) RefNo += "00" + sufix;

			if ((sufix > 9) && (sufix < 100)) RefNo += "0" + sufix;

			if (sufix > 99) RefNo += "" + sufix;
            return RefNo;
        }

        [HttpPost("[action]")]
        public JsonResult AddItems(AddItems addItems) {
            try {
                foreach (var item in addItems.Soritems) {
					var proqDetails = new ProcOnlineReqDetail();
                    proqDetails.Amount = item.Totalamount;
                    proqDetails.Cost = item.Unitamount;
                    proqDetails.Qty = item.Quantity;
                    proqDetails.ReqRef = addItems.RefReq;
                    proqDetails.UoM = item.Unitmeasure;
                    proqDetails.Description = item.Description;
                    _context.Add(proqDetails);
                    _context.SaveChanges();
                }
                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Items added successfully"
                });
            }
            catch (Exception ex) {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Sorry something went wrong while adding SOR items, please try again",
                   
                });
            }
            }

    }
}