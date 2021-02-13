using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Unisol.Web.Api.IServices;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.UnisolModels;


namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class PayslipController : Controller
	{
		private readonly UnisolAPIdbContext _context;
		private IConfiguration _configuration;
		private IStaffServices _staffServices;
		private StaffUtilities staffUtilities;

		public PayslipController(UnisolAPIdbContext context, IConfiguration configuration, IStaffServices staffServices)
		{
			_context = context;
			_configuration = configuration;
			_staffServices = staffServices;
			staffUtilities = new StaffUtilities();
		}


		[HttpGet("[action]")]
		public JsonResult GetPaySlip(string userCode, string month)
		{
			var accountTypes = new List<string>
				{
					"EARNING",
					"DEDUCTION",
					"UNION",
					"PENSION",
					"LOAN",
					"BENEFIT",
				};

			var accounts = _staffServices.GetAccounts();
			if (!accounts.Success)
				return Json(accounts);

			var indAccountsTypes = accounts.Data.Where(h => h.Closed == false).ToList();
			var paySlipDetails = staffUtilities.GetPayslip(_staffServices, accountTypes, indAccountsTypes, userCode, month);
			return Json(paySlipDetails);
		}

		//get unique pay periods
		[HttpGet("[action]")]
		public JsonResult ReturnPayPeriods(string year)
		{
			try
			{
				var periodDetails = _staffServices.GetSalaryPeriods();
				if (!periodDetails.Success)
					return Json(periodDetails);

				var periods = periodDetails.Data.Where(y => y.Ryear == year && y.Cdate <= DateTime.UtcNow.Date)
					  .Select(y => new
					  {
						  y.Names,
						  y.Id
					  }).Distinct().OrderByDescending(y => y.Id).ToList();

				if (!periods.Any())
				{
					return Json(new ReturnData<bool>
					{
						Success = false,
						Message = "Oops,we could not find any pay slip for that periods",
					});
				}
				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Message = "",
					Data = periods
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

		[HttpGet("[action]")]
		public JsonResult ReturnPayYears()
		{
			try
			{
				var periodDetails = _staffServices.GetSalaryPeriods();
				if (!periodDetails.Success)
					return Json(periodDetails);

				var years = periodDetails.Data.Select(y => new
                    {
                        y.Ryear
                    }).Distinct().OrderByDescending(y => y.Ryear).ToList();
                if (!years.Any())

					return Json(new ReturnData<bool>
					{
						Success = false,
						Message = "Oops,we could not find any pay slip for that periods",
					});

				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Message = "",
					Data = years
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