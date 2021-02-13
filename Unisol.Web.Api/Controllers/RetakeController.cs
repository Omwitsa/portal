using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Api.IServices;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class RetakeController : Controller
	{
		private readonly UnisolAPIdbContext _context;
		private IStudentServices _studentServices;
		
		public RetakeController(UnisolAPIdbContext context, IStudentServices studentServices)
		{
			_context = context;
			_studentServices = studentServices;
		}

		[HttpGet("[action]")]
		public JsonResult GetRetakes(string userCode)
		{
			try
			{
				var retakes = _context.RetakeReg.Where(r => r.AdmnNo.ToUpper().Equals(userCode.ToUpper())).ToList();
				return Json(new ReturnData<List<RetakeReg>>
				{
					Success = true,
					Data = retakes
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
		public JsonResult GetRetakeUnits(string userCode, string classStatus)
		{
			try
			{
				var studClass = _studentServices.GetClass(userCode, classStatus);
				if (!studClass.Success)
					return Json(studClass);

				var terms = _context.Term.Where(t => t.Starts >= studClass.Data.Starts && t.Ends <= studClass.Data.Ends)
					.OrderBy(t => t.Starts).ToList();
				var curriculum = _studentServices.GetStudentCurriculum(userCode, classStatus);
				if (!curriculum.Success)
					return Json(curriculum);

				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						terms,
						curriculum = curriculum.Data
					}
				});
			}
			catch(Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpPost("[action]")]
		public JsonResult SaveRetake(RetakeModel retake, string classStatus)
		{
			try
			{
				var retakeReg = _context.RetakeReg.FirstOrDefault(r => r.AdmnNo.ToUpper().Equals(retake.Username.ToUpper())
				&& r.Term.ToUpper().Equals(retake.Term.ToUpper()));
				if(retakeReg == null)
				{
					_context.RetakeReg.Add(new RetakeReg
					{
						AdmnNo = retake.Username,
						Class = _studentServices.GetClass(retake.Username, classStatus)?.Data?.Id ?? "",
						Term = retake.Term,
						Rdate = DateTime.UtcNow,
						Personnel = retake.Username
					});
					_context.SaveChanges();

					retakeReg = _context.RetakeReg.FirstOrDefault(r => r.AdmnNo.ToUpper().Equals(retake.Username.ToUpper())
					&& r.Term.ToUpper().Equals(retake.Term.ToUpper()));
				}
				

				foreach (var unit in retake.Units)
				{
					_context.RetakeRegDetail.Add(new RetakeRegDetail {
						Ref = retakeReg.Id.ToString(),
						UnitCode = unit,
						Notes = retake?.Notes ?? ""
					});
				}

				_context.SaveChanges();
				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Retake applied successfully"
				});
			}
			catch(Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpGet("[action]")]
		public JsonResult GetRetakeDetails(string userCode, int retakeId)
		{
			try
			{
				var retake = _context.RetakeReg.FirstOrDefault(r => r.Id == retakeId);
				var retakeRegDetails = _context.RetakeRegDetail.Where(r => r.Ref == retake.Id.ToString()).ToList();
				var retakeDetails = new List<dynamic>();
				foreach (var retakeDetail in retakeRegDetails)
				{
					retakeDetails.Add(new
					{
						retakeDetail.UnitCode,
						UnitName = _context.Subjects.FirstOrDefault(s => s.Code == retakeDetail.UnitCode)?.Names ?? ""
					});
				}
				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						retake,
						retakeDetails
					}
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
