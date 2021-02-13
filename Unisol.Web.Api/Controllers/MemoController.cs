using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Api.IServices;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Entities.Database.UnisolModels;
using System.Linq;
using Unisol.Web.Common.ViewModels.Memo;

namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class MemoController : Controller
	{
		private IUnitOfWork _unitOfWork;
		private IStaffServices _staffServices;
		private IStudentServices _studentServices;
		private Utils utils;
		public MemoController(IUnitOfWork unitOfWork, UnisolAPIdbContext context, IStaffServices staffServices, 
			IStudentServices studentServices)
		{
			_unitOfWork = unitOfWork;
			_studentServices = studentServices;
			utils = new Utils(context);
			_staffServices = staffServices;
		}

		[HttpGet("[action]")]
		public JsonResult GetImprestMemo(string usercode, string searchText)
		{
			try
			{
				var user = _unitOfWork.Users.GetUsersByCode(usercode);
				if(user == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Not allowed to access the resource, kindly contact admin"
					});

				user.UserCode = user.UserCode ?? "";
				var imprestMemos = _unitOfWork.ImprestMemo.GetWhere(m => m.Personnel.ToUpper().Equals(user.UserCode.ToUpper())).ToList();
				var memos = new List<dynamic>();
				imprestMemos.ForEach(m => {
					var docCenterDetails = utils.GetDocCenterDetails(usercode);
					memos.Add(new
					{
						m.Ref,
						m.DeptFrom,
						m.DeptTo,
						m.Subject,
						m.Description,
						m.Personnel,
						m.Rdate,
						m.Status,
						m.Sdate,
						m.Edate,
						Reason = docCenterDetails?.Reason ?? ""
					});
				});

				return Json(new ReturnData<dynamic> {
					Success = true,
					Data = memos
				});
			}
			catch(Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "An error occurred"
				});
			}
		}

		[HttpGet("[action]")]
		public JsonResult GetMemoResources(string usercode)
		{
			try
			{
				var user = _unitOfWork.Users.GetUsersByCode(usercode);
				if(user == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "You are not allowed to create a memo. Kindly contact admin"
					});

				if (!_studentServices.CheckIfGenesis().Data)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, memos not supported at the moment."
					});

				var departments = _unitOfWork.Department.GetStaffDepartments();
				var staffDetails = _staffServices.GetEmployees(usercode)?.Data;
				var participants = _unitOfWork.HrpEmployee.GetWhere(e => e.Terminated == false);

				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						staffDetails,
						departments,
						participants
					}
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "An error occurred"
				});
			}
		}

		[HttpPost("[action]")]
		public JsonResult ReguestMemo(MemoViewModel memoModel, string usercode)
		{
			try
			{
				memoModel.ImprestMemo.Ref = GenerateRefNo();
				memoModel.ImprestMemo.Status = "Pending";
				var erpUser = _unitOfWork.Users.GetUsersByCode(usercode);
				memoModel.ImprestMemo.Personnel = erpUser?.UserCode ?? "";
				memoModel.ImprestMemoDetail.ForEach(d => {
					d.Ref = memoModel.ImprestMemo.Ref;
					_unitOfWork.ImprestMemoDetail.Add(d);
				});

				_unitOfWork.ImprestMemo.Add(memoModel.ImprestMemo);

				var procOnlineReq = new ProcOnlineReq
				{
					ReqRef = memoModel.ImprestMemo.Ref,
					DocType = "ONLINE MEMO",
					Rdate = DateTime.UtcNow,
					Rtime = DateTime.UtcNow,
					Usercode = usercode,
					Status = "Pending"
				};

				var docId = _unitOfWork.Wfrouting.GetFirstOrDefault(r => r.Document.ToUpper() == procOnlineReq.DocType.ToUpper())?.Id.ToString();
				if (string.IsNullOrEmpty(docId))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, " + procOnlineReq.DocType.ToUpper() + " Not supported at the moment. Please contact the admin"
					});

				var user = _unitOfWork.HrpEmployee.GetFirstOrDefault(e => e.EmpNo.ToUpper().Equals(usercode.ToUpper()));
				var workFlowStatus = utils.SaveToWorkFlowCenter(procOnlineReq, user, docId);
				if (!workFlowStatus.Success)
					return Json(workFlowStatus);

				_unitOfWork.Save();
				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Memo saved successifully"
				});
			}
			catch(Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "An error occurred"
				});
			}
		}

		private string GenerateRefNo()
		{
			var memos = _unitOfWork.ImprestMemo.GetAll().ToList();
			if (memos.Count < 1)
				return "MEMO001";

			var memoRef = memos.OrderByDescending(f => Convert.ToInt32(f.Ref.Substring(4))).FirstOrDefault();
			if (memoRef == null)
				return "MEMO001";

			var count = memoRef.Ref.Count();
			var digits = memoRef.Ref.Substring(4);
			var sufix = Convert.ToInt32(digits);

			sufix++;

			var RefNo = "MEMO";
			if (sufix < 10) RefNo += "00" + sufix;

			if ((sufix > 9) && (sufix < 100)) RefNo += "0" + sufix;

			if (sufix > 99) RefNo += "" + sufix;
			return RefNo;
		}
	}
}
