using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Api.IServices;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Entities.Database.UnisolModels;


namespace Unisol.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImprestController : Controller
    {
        private readonly UnisolAPIdbContext _context;
		private IStaffServices _staffServices;
		private IStudentServices _studentServices;
		private Utils utils;

		public ImprestController(UnisolAPIdbContext context, IStaffServices staffServices, IStudentServices studentServices)
        {
            _context = context;
			_staffServices = staffServices;
			_studentServices = studentServices;
			utils = new Utils(context);
		}


        [HttpPost("[action]")]
        public JsonResult SaveEmployeeImprest(ImprestReq imprestReq)
        {
            try
            {
				imprestReq.Rdate = DateTime.Today;
				imprestReq.Usercode = imprestReq.EmpNo;
				var user = _context.HrpEmployee.FirstOrDefault(u => u.EmpNo == imprestReq.EmpNo);
				if (_studentServices.CheckIfGenesis().Data)
				{
					var memo = _context.ImprestMemo.Any(m => m.Ref.ToUpper().Equals(imprestReq.MemoRef.ToUpper()) 
					&& m.Status.ToUpper().Equals("APPROVED"));
					if(!memo)
						return Json(new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, Only approved memos can be used to request for an imprest. Kindly contact admin"
						});

					var memoDetails = _context.ImprestMemoDetail.Any(d => d.EmpNo.ToUpper().Equals(imprestReq.EmpNo.ToUpper()) 
					&& d.Ref.ToUpper().Equals(imprestReq.MemoRef.ToUpper()));

					if (!memoDetails)
						return Json(new ReturnData<string>
						{
							Success = false,
							Message = $"{user.Names} is not one of the participants on the Memo reference number entered."
						});
				}

				var message = "";
				if (imprestReq.Amount < 0)
					message = "Amount must be greater than 0";

				if (Convert.ToDateTime(imprestReq.Edate).Date < DateTime.Now.Date)
					message = "Expected date should be greater than today";
				
				var imprestNumber = getImprestNumber();
				
				var procOnlineReq = new ProcOnlineReq
				{
					ReqRef = imprestNumber,
					DocType = "IMPREST WARRANT",
					Rdate = DateTime.Today,
					Rtime = DateTime.UtcNow.AddHours(3),
					Usercode = user.EmpNo,
					Status = "Pending",
				};

				//var wfRouting = _staffServices.GetWfRouting(procOnlineReq.DocType);
				//if (!wfRouting.Success)
				//	return Json(wfRouting);

				//if (string.IsNullOrEmpty(wfRouting.Data.Id.ToString()))
				//	return Json(wfRouting);

				//var workFlowStatus = utils.SaveToWorkFlowCenter(procOnlineReq, user, wfRouting.Data.Id.ToString());
				//if (!workFlowStatus.Success)
				//	return Json(workFlowStatus);
				
				_context.ImprestReq.Add(imprestReq);
				_context.SaveChanges();
                message = "Your imprest has been successfully saved";

                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = message
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<bool>
                {
                    Success = false,
                    Message = "Oops,seems like an error occurred while processing your request",
                    Error = new Error(ex)
                });
            }
        }

		private string getImprestNumber()
		{
			var imprest = _context.Imprest
				.OrderByDescending(i => Convert.ToInt32(i.ImpRef.Substring(3, 10)))
				.FirstOrDefault();
			
			if (imprest == null)
			{
				return "IMP001";
			}

			var count = imprest.ImpRef.Count();
			var digits = imprest.ImpRef.Substring(3, count - 3);
			var sufix = Convert.ToInt32(digits);

			sufix++;

			var impNo = "IMP";
			if (sufix < 10) impNo += "00" + sufix;

			if (sufix < 100) impNo += "0" + sufix;

			if (sufix > 99) impNo += "" + sufix;
			return impNo;
		}

		[HttpGet("[action]")]
        public JsonResult GetImprest(string userCode, string searchString)
        {
            try
            {
                var userImpReq = _context.ImprestReq.Where(i => i.EmpNo.ToUpper().Equals(userCode.ToUpper())).OrderByDescending(i => i.Id).ToList();
				userImpReq = userImpReq.Where(i => i.Description.CaseInsensitiveContains(searchString) || i.Itinerary.CaseInsensitiveContains(searchString)).ToList();
				var imprest = new List<dynamic>();
				userImpReq.ForEach(r => {
					r.Description = r?.Description ?? "";
					var imprestRef = _context.Imprest.FirstOrDefault(i => i.PayeeRef.ToUpper().Equals(r.EmpNo.ToUpper()) && i.Description.CaseInsensitiveContains(r.Description.Trim()));
					var status = "Pending";
					var reason = "";
					if (imprestRef != null)
					{
						imprestRef.ImpRef = imprestRef?.ImpRef ?? "";
						var docCenterDetails = utils.GetDocCenterDetails(imprestRef.ImpRef);
						status = imprestRef?.Status ?? "Pending";
						reason = docCenterDetails?.Reason ?? "";
					}
					
					imprest.Add(new
					{
						r.Id,
						r.Amount,
						r.Description,
						r.Edate,
						r.EmpNo,
						r.ImpDays,
						r.Itinerary,
						r.Rdate,
						r.Reactby,
						r.ReactDate,
						r.Reaction,
						r.Sdate,
						r.Usercode,
						Status = status,
						Reason = reason
					});
				});
				
				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = imprest,
					Message = "All available imprest",
				});
			}
            catch (Exception ex)
            {
                return Json(new ReturnData<bool>
                {
                    Success = false,
                    Message = "Oops,seems like an error occurred while processing your request",
                    Error = new Error(ex)
                });
            }
        }    
    }
}