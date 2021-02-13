using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Api.IServices;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.UnisolModels;


namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamCardController : Controller
    {
        private readonly UnisolAPIdbContext _context;
		private IStudentServices _studentServices;
		private StudentCredential studentCredentials;
		private readonly FinanceController _financeUtilities;

        public ExamCardController(UnisolAPIdbContext context, IStudentServices studentServices, ISystemServices systemServices)
        {
            _context = context;
			_studentServices = studentServices;
			studentCredentials = new StudentCredential(_context, studentServices, systemServices);
            _financeUtilities = new FinanceController(context, studentServices, systemServices);
        }

        [HttpGet("[action]")]
        public JsonResult GetExamCardUnits(string userCode, string classStatus, bool isPreviousTermCard)
        {
            try
            {
				var termResponse = _studentServices.GetCurrentTerm(userCode, classStatus);
				if (isPreviousTermCard)
					termResponse = _studentServices.GetPreviousTerm(userCode, classStatus);
				if (!termResponse.Success)
					return Json(termResponse);

				var reportingDetails = studentCredentials.ValidateExamCardReporting(userCode, classStatus, isPreviousTermCard);
				if (!reportingDetails.Success)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = reportingDetails.Message
					});

				var feePolicyComplied = studentCredentials.ReturnFeesPolicyCompliance(userCode, classStatus, "EXAM");
				if (!feePolicyComplied.Success)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = $"Sorry! Fees payment is required as per the policy before accessing examcard. The policy is {feePolicyComplied.Data}% "
					});

                    /*----------------End of getting fee balance-------------------*/
                    var registeredUnit = _context.ProgUnitRegDetail
                        .Join(_context.ProgUnitReg,
                            progUnitRegDtl => Convert.ToInt32(progUnitRegDtl.Ref),
                            progUnitReg => progUnitReg.Id,
                            (progUnitRegDtl, progUnitReg) =>
                                new
                                {
                                    progUnitRegDtl.Status,
                                    progUnitReg.Rdate,
                                    progUnitReg.Term,
                                    progUnitReg.Class,
                                    progUnitRegDtl.UnitCode,
                                    progUnitReg.AdmnNo
                                })
                        .Where(uR => uR.AdmnNo == userCode && uR.Term == termResponse.Data.Names 
							).Distinct().ToList();

                    if (!registeredUnit.Any())
                        return Json(new ReturnData<string>
                        {
                            Success = false,
                            Message = "Oops,seems you have not registered for any unit"
                        });

				registeredUnit = registeredUnit.Where(u => u.Status.CaseInsensitiveContains("approved")).ToList();
				if (!registeredUnit.Any())
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, registered units have not yet been approved. Kindly contact admin"
					});

				var unitsWithNames = registeredUnit.Join(
                        _context.Subjects,
                        regUnits => regUnits.UnitCode,
                        sub => sub.Code,
                        (regUnits, sub) => new
                        {
                            regUnits.Term,
                            regUnits.Status,
                            regUnits.UnitCode,
                            regUnits.AdmnNo,
                            sub.Names,
                            sub.CreditUnits
                        }
                    ).ToList();

				var units = new List<dynamic>();
				unitsWithNames.ForEach(u => {
					units.Add(new {
						u.Term, u.Status, u.UnitCode, u.AdmnNo, u.Names, u.CreditUnits
					});
				});

				return Json(new ReturnData<List<dynamic>>
                {
                    Success = true,
                    Message = "",
                    Data = units
				});
                
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Oops,seems you have not not registered for any unit " +
                              ErrorMessangesHandler.ExceptionMessage(ex)
                });
            }
        }
	}
}