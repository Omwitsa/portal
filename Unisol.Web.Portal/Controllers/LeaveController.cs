using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Leave;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Models;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly TokenValidator _tokenValidator;
        private readonly PortalCoreContext _context;
		private IHostingEnvironment _hostingEnvironment;
		public LeaveController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context, IHostingEnvironment hostingEnvironment)
        {
            _unisolApiProxy = unisolApiProxy;
            _context = context;
			_hostingEnvironment = hostingEnvironment;
			_tokenValidator = new TokenValidator(_context);
        }

        [HttpGet("[action]")]
        public JsonResult GetLeaveApplications(string status)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });

            if (token.Role != Role.Staff)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = "Sorry, you are not authorized to view this page",
                });

            var applications = _unisolApiProxy.GetLeaveApplications(status).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<List<HrpLeaveApp>>>(applications);
			return Json(jdata);
		}

        [HttpPost("[action]")]
        public JsonResult ApplyLeave(HrpLeaveApp leave)
        {
            try
            {
				var settings = _context.Settings.FirstOrDefault();
				settings.Initials = settings?.Initials ?? "";
				if (string.IsNullOrEmpty(leave.Reliever) && settings.LeaveRelieverMandatory)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly select your reliver"
					});

				leave.Sdate = leave.Sdate.GetValueOrDefault().AddDays(1);
				leave.Edate = leave.Edate.GetValueOrDefault().AddDays(1);
				var daysFromStartDay = (leave.Sdate - DateTime.UtcNow).GetValueOrDefault().TotalDays;
				leave.Emergency = leave.Emergency == null ? false : leave.Emergency;
				if (daysFromStartDay < 14 && settings.Initials.ToUpper().Equals("ABNO") && leave.LeaveType.ToUpper().Equals("ANNUAL LEAVE") && !(bool)leave.Emergency)
				{
					UpdateDocument(leave);
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, leave start date must be atleast two weeks from the application date"
					});
				}

				leave.Rdate = DateTime.UtcNow;
				var token = _tokenValidator.Validate(HttpContext);
				if (!token.Success)
					return Json(new ReturnData<string>
					{
						Success = false,
						NotAuthenticated = true,
						Message = $"Unauthorized:-{token.Message}",
					});

				if (token.Role != Role.Staff)
					return Json(new ReturnData<string>
					{
						Success = false,
						NotAuthenticated = true,
						Message = "Sorry, you are not authorized to perform this action",
					});

				var app = _unisolApiProxy.ApplyLeave(leave, settings.LeaveRelieverMandatory).Result;
				var jdata = JsonConvert.DeserializeObject<ReturnData<HrpLeaveApp>>(app);
				var document = _context.LeaveDocument.Where(d => d.UserName.ToUpper().Equals(leave.EmpNo.ToUpper())).OrderByDescending(d => d.DateCreated).FirstOrDefault();

				if (jdata.Success)
				{
                    if (!string.IsNullOrEmpty(jdata.Data.Reliever))
                    {
						_context.Add(new Obstructor
						{
							LeaveRef = jdata.Data?.Ref ?? "",
							Requestor = leave?.EmpNo ?? "",
							Reliver = jdata.Data?.Reliever ?? "",
							Status = "Pending"
						});

						if (document != null)
							document.LeaveRef = jdata.Data?.Ref ?? "";

						_context.SaveChanges();
					}
				}
				else
				{
					if (document != null)
						UpdateDocument(leave);
				}

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

		private void UpdateDocument(HrpLeaveApp leave)
		{
			var document = _context.LeaveDocument.Where(d => d.UserName.ToUpper().Equals(leave.EmpNo.ToUpper())).OrderByDescending(d => d.DateCreated).FirstOrDefault();
			if(document != null)
			{
				_context.LeaveDocument.Remove(document);
				_context.SaveChanges();
			}
		}

        [HttpGet("[action]")]
        public JsonResult GetByEmployee(string empNo)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });

            if (token.Role != Role.Staff)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = "Sorry, you are not authorized to perform this action",
                });

            var applications = _unisolApiProxy.GetEmpApplications(empNo).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<List<LeaveAppVm>>>(applications);
			if (jdata.Success)
			{
				jdata.Data = jdata.Data == null ? new List<LeaveAppVm>() : jdata.Data;
				jdata.Data.ForEach(l =>
				{
					var obstructor = _context.Obstructor.FirstOrDefault(o => o.LeaveRef.ToUpper().Equals(l.Ref.ToUpper()));
					if(obstructor != null)
						l.ReliverApproval = obstructor.Status;
				});
			}

			return Json(jdata);
		}

        [HttpGet("[action]")]
        public JsonResult GetByRef(string appRef)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });

            if (token.Role != Role.Staff)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = "Sorry, you are not authorized to perform this action",
                });

            var app = _unisolApiProxy.GetByLeaveRef(appRef).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<HrpLeaveApp>>(app);
			return Json(jdata);
		}

        [HttpGet("[action]")]
        public JsonResult GetEmpLeaveDays(string empNo)
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

                if (token.Role != Role.Staff)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to perform this action",
                    });

                var lvDays = _unisolApiProxy.GetEmpLeaveDays(empNo).Result;
				var jdata = JsonConvert.DeserializeObject<ReturnData<List<LeaveDaysSum>>>(lvDays);
				return Json(jdata);
			}
			catch(Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, Server error"
				});
			}
		}
        [HttpGet("[action]")]
        public JsonResult GetLeaveDaysCredit(string empNo)
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
                if (token.Role != Role.Staff)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = "Sorry, you are not authorized to perform this action",
                    });
                var lvDaysCredit = _unisolApiProxy.GetLeaveDaysCredit(empNo).Result;
                var jdata = JsonConvert.DeserializeObject<ReturnData<dynamic>>(lvDaysCredit);
                return Json(jdata);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Sorry, Server error"
                });
            }
        }

        [HttpPost("[action]")]
        public JsonResult GetValidLeaveDates(GetDaysRequest request)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });

            if (token.Role != Role.Staff)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = "Sorry, you are not authorized to perform this action",
                });

            var days = _unisolApiProxy.GetValidLeaveDays(request).Result;
			var jdata = JsonConvert.DeserializeObject<ReturnData<List<string>>>(days);
			return Json(jdata);
		}

		[HttpPost("[action]")]
		public JsonResult UploadDocument(string usercode, string type)
		{
			try
			{
				if(string.IsNullOrEmpty(type))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly select leave type"
					});

				var fileDetails = Request.Form.Files.FirstOrDefault();
				if (fileDetails == null || fileDetails.Length < 1)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Failed to upload the file"
					});

				type = type.Trim().ToUpper();
				usercode = usercode.Trim().ToUpper();
				var fileName = ContentDispositionHeaderValue.Parse(fileDetails.ContentDisposition).FileName.Trim('"');
				var document = _context.LeaveDocument.Any(d => d.Name.ToUpper().Equals(fileName.ToUpper()) && d.Type.Equals(type) 
				&& d.UserName.Equals(usercode));

				if(document)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, a document with similar name already exist"
					});

				var endPoint = $"Documents\\Leave\\{usercode}";
				_context.LeaveDocument.Add(new LeaveDocument
				{
					UserName = usercode,
					Type = type,
					Name = fileName,
					EndPoint = endPoint.Replace("\\", "/").ToLower()
				});

				_context.SaveChanges();
				var folderPath = Path.Combine(_hostingEnvironment.WebRootPath, endPoint);
				if (!Directory.Exists(folderPath))
					Directory.CreateDirectory(folderPath);

				var fullPath = Path.Combine(folderPath, fileName);
				using (var stream = new FileStream(fullPath, FileMode.Create))
				{
					fileDetails.CopyTo(stream);
				}

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Documents uploaded successfully"
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

		[HttpGet("[action]")]
		public JsonResult GetDocuments(string empNo)
		{
			try
			{
				var documents = _context.LeaveDocument.Where(d => d.UserName.ToUpper().Equals(empNo.ToUpper())).OrderByDescending(d => d.DateCreated).ToList();
				if(documents.Count < 1)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, no document found"
					});

				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = documents
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

		[HttpGet("[action]")]
		public JsonResult GetObstructors(string usercode, string searchText)
		{
			try
			{
				var obstructors = _context.Obstructor.Where(o => o.Reliver.ToUpper().Equals(usercode.ToUpper()) && o.Status.ToLower().Equals("pending")).ToList();
				return Json(new ReturnData<dynamic> {
					Success = true,
					Data = obstructors
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
		public JsonResult Approve(LeaveApproveVm leaveApprove)
		{
			try
			{
				if (leaveApprove.Status.ToLower().Equals("declined"))
				{
					UpdateRelieve(leaveApprove);
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "The leave has been declined"
					});
				}

				var approved = _unisolApiProxy.ApproveLeave(leaveApprove).Result;
				var jdata = JsonConvert.DeserializeObject<ReturnData<string>>(approved);
				if (jdata.Success)
					UpdateRelieve(leaveApprove);

				return Json(jdata);
			}
			catch (Exception)
			{
				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Sorry, An error occurred"
				});
			}
		}

		private void UpdateRelieve(LeaveApproveVm leaveApprove)
		{
			var approval = _context.Obstructor.FirstOrDefault(o => o.LeaveRef.ToUpper().Equals(leaveApprove.LeaveRef.ToUpper()));
			approval.Status = leaveApprove.Status;
			_context.SaveChanges();
		}

		private string GetUniqueFileName(string fileName)
		{
			fileName = Path.GetFileName(fileName).Replace(" ", "");
			return Path.GetFileNameWithoutExtension(fileName)
				   + "_"
				   + Guid.NewGuid().ToString().Substring(0, 4)
				   + Path.GetExtension(fileName);
		}
	}
}
