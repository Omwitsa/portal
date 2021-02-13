using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Unisol.Web.Api.IServices;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Finance;
using Unisol.Web.Entities.Database.UnisolModels;


namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : Controller
    {
        private readonly UnisolAPIdbContext _context;
		private StudentCredential studentCredentials;
		public FinanceController(UnisolAPIdbContext context, IStudentServices studentServices, ISystemServices systemServices)
        {
            _context = context;
			studentCredentials = new StudentCredential(_context, studentServices, systemServices);
        }


        public double GetTotalFeesPaid(string userCode)
        {
            return 0.0;
        }

        public double GetTotalFeesRequired(string userCode)
        {
            return 0.0;
        }

        [HttpGet("[action]")]
        public JsonResult GetFeesInfo(string usercode, string classStatus)
        {
            try
            {
				var credentials = studentCredentials.GetStudentDetails(usercode, classStatus);
				if (!credentials.Success)
					return Json(credentials);
				var StudFeesBalances = studentCredentials.GetFeesBalance(usercode, classStatus);
				return Json(new ReturnData<dynamic>
                {
                    Success = true,
                    Message = "",
                    Data = new
					{
						Balance = StudFeesBalances
					}
				});
            }
            catch (Exception e)
            {
                return Json(new ReturnData<dynamic>
                {
                    Success = false,
                    Message = "An error occurred while trying to find your balance, Please try again",
                });
            }
        }

        public Array StudentInvoiceColumnNames()
        {
            var accounts = _context.Accounts.Where(a => a.StudentRelated == true)
                .OrderBy(p => p.Names)
                .ToList();
            var columns = new List<string>();
            accounts.ForEach(c => { columns.Add(c.Names); });
            return columns.ToArray();
        }

        [HttpGet("[action]")]
        public JsonResult GetFeesStatement(string userCode, string classStatus)
        {
			var statement = studentCredentials.GetFeesStatement(userCode, classStatus);
			return Json(statement);
        }

        [HttpPost("[action]")]
        public JsonResult GetFeesStructure(FeesStructureFilter feesStructureFilter, string classStatus)
        {
            try
            {
				var structure = studentCredentials.GetFeesStructure(feesStructureFilter, classStatus);
				if (!structure.Success)
					return Json(structure);

				return Json(new ReturnData<List<FeeStructureStageViewModel>>
				{
					Success = structure.Success,
					Message = structure.Message,
					Data = structure.Data
				});
			}
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Oops,seems and error occured while fetching fee statement " +
                              ErrorMessangesHandler.ExceptionMessage(ex)
                });
            }
        }
    }
}