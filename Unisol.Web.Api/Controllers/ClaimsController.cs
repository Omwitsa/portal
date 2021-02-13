using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Api.IServices;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Claims;
using Unisol.Web.Entities.Database.UnisolModels;


namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : Controller
    {
        private readonly UnisolAPIdbContext _context;
		private IStaffServices _staffServices;

		public ClaimsController(UnisolAPIdbContext context, IStaffServices staffServices)
        {
            _context = context;
			_staffServices = staffServices;
		}

        [HttpGet("[action]")]
        public JsonResult GetPClaimSummary(string userCode,string searchString)
        {
            try
            {
				searchString = searchString ?? "";
				var claimsSammery = _staffServices.GetStaffClaims(userCode);
				if (!claimsSammery.Success)
					return Json(claimsSammery);

				var claims = claimsSammery.Data
					.Where(p=>p.Pcref.CaseInsensitiveContains(searchString)||p.Term.CaseInsensitiveContains(searchString))
					.OrderByDescending(p => p.Pcref.Substring(3))
					.ToList();

                if (claims.Any())
                {
                    return Json(new ReturnData<List<Pclaim>>
                    {
                        Success = true,
                        Message = "All available claims",
                        Data = claims
                    });
                }

                return Json(new ReturnData<bool>
                {
                    Success = false,
                    Message = "Oops,seems we could not find the required claims rates"
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
        public JsonResult GetPClaimDetails(string claimRef)
        {
            try
            {
                var claimDetails = _context
                    .PclaimDetail
                    .Where(p => p.Pcref == claimRef)
                    .OrderByDescending(p => p.Pcref.Substring(2, 8))
                    .ToList();

                if (claimDetails.Any())
                {
                    return Json(new ReturnData<List<PclaimDetail>>
                    {
                        Success = true,
                        Message = "All available claims",
                        Data = claimDetails
                    });
                }


                return Json(new ReturnData<bool>
                {
                    Success = false,
                    Message = "Oops,seems we could not find the required claims rates"
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
        public JsonResult GetPClaimRates()
        {
            try
            {
                var claimRates = _context.PclaimRates.ToList();

                if (claimRates.Any())
                    return Json(new ReturnData<List<PclaimRates>>
                    {
                        Success = true,
                        Message = "All available  claims rates",
                        Data = claimRates
                    });

                return Json(new ReturnData<bool>
                {
                    Success = false,
                    Message = "Sorry, No claims type found. Kindly contact admin"
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

//
        [HttpGet("[action]")]
        public JsonResult GetUnitsForClaim(string searchString)
        {
            var units = _context.Subjects
                .Where(s => s.Code.Contains(searchString) || s.Names.Contains(searchString))
                .Take(10).ToList();

            if (units.Any())
            {
                return Json(new ReturnData<List<Subjects>>
                {
                    Success = true,
                    Message = "All available  claims rates",
                    Data = units
                });
            }

            return Json(new ReturnData<bool>
            {
                Success = false,
                Message = "Oops,no units registered"
            });
        }
        //
        [HttpGet("[action]")]
        public JsonResult GetTermsForClaim()
        {
            var terms = _context.Term.ToList();

            if (terms.Any())
            {
                return Json(new ReturnData<List<Term>>
                {
                    Success = true,
                    Message = "All availbale terms",
                    Data = terms
                });
            }

            return Json(new ReturnData<bool>
            {
                Success = false,
                Message = "Oops,not units terms available",
            });
        }

        public string GetClaimRef()
        {
            var claims = _context.Pclaim.OrderByDescending(p => p.Pcref.Substring(2, 8))
                .FirstOrDefault();
            var refNumber = "PTC001";
            if (claims != null)
            {
                var substr = Convert.ToInt32(claims.Pcref.Substring(3)) + 1;
                if (substr < 10)
                {
                    return "PTC00" + substr;
                }

                if (substr > 9 && substr <= 99)
                {
                    return "PTC0" + substr;
                }

                if (substr > 99)
                {
                    return "PTC" + substr;
                }
            }


            return refNumber;
        }

//
        public HrpEmployee ReturnUserNames(string username)
        {
            var userObject = _context.HrpEmployee
                .FirstOrDefault(u => u.EmpNo == username);
            if (userObject != null)
                return userObject;


            return new HrpEmployee();
        }

        public bool SaveClaimDetails(PClaimDetailModel saveClaimDetails)
        {
            var saveUnit =
                "INSERT INTO [dbo].[PClaimDetail]([PCRef] ,[PayAccount],[Code],[Rate],[Units],[Qty],[Amount],[Notes])VALUES("
                + "'" + saveClaimDetails.PCRef + "','"
                + saveClaimDetails.PayAccount + "','"
                + saveClaimDetails.Code + "','"
                + saveClaimDetails.Rate + "','"
                + saveClaimDetails.Units + "','"
                + saveClaimDetails.Qty + "','"
                + saveClaimDetails.Amount + "','"
                + saveClaimDetails.Notes + "'"
                + ")";

            _context.Database.ExecuteSqlCommand(saveUnit);
            return true;
        }

        public string ReturnUnitsForClaim(int claimId)
        {
            return _context.PclaimRates.FirstOrDefault()?.Units ?? "UNSPECIFIED";
        }

        [HttpPost("[action]")]
        public JsonResult SaveMainClaim( List<ClaimDetailsViewModel> pmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pcref = GetClaimRef();

                    var pclaimModel = new Pclaim();
                    var userCode = "";
                    var sum =new decimal();
                    foreach (var claim in pmodel)
                    {
                        sum += Convert.ToDecimal(claim.TotalAmount);
                        userCode = claim.UserCode;

                        pclaimModel.Pcref = pcref;
                        pclaimModel.PayeeRef = claim.UserCode;
                        
                        pclaimModel.Term = claim.Semester;
                        pclaimModel.Amount =sum ;
                        pclaimModel.Personnel = claim.UserCode;
                        pclaimModel.Rdate = DateTime.Now;
                        pclaimModel.Notes = claim.Notes;
                        pclaimModel.Status = "Pending";
                    }
                    var emp = ReturnUserNames(userCode);
                    pclaimModel.Names = emp.Names;

                    _context.Pclaim.Add(pclaimModel);
                    _context.SaveChanges();
                    var saveStatus = Json(new { });
                    foreach (var claim in pmodel)
                    {
                        saveStatus = SaveIndiviualMainClaims(claim, pcref);
                    }

                    return Json(new ReturnData<bool>
                    {
                        Success = true,
                        Message = "Claim has been raised successfully "
                    });
                }

                return Json(new ReturnData<bool>
                {
                    Success = false,
                    Message = "A server error occured,please contact the administrator : "
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<bool>
                {
                    Success = false,
                    Error=new Error(ex),
                    Message = "A server error occured,please contact the administrator : " + ex.Message
                });
            }
        }

//
        public JsonResult SaveIndiviualMainClaims(ClaimDetailsViewModel pmodel, string pcref)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emp = ReturnUserNames(pmodel.UserCode);

                    if (!pmodel.RequireUnit)
                    {
                        var saveClaim = new PClaimDetailModel
                        {
                            Amount = Convert.ToDecimal(pmodel.TotalAmount),
                            PCRef = pcref,
                            PayAccount = pmodel.PayAccount,
                            Qty = pmodel.Quantity,
                            Rate = 1,
                            Units = ReturnUnitsForClaim(pmodel.ClaimId), //to fetch units from pclaimrated table 
                            Notes = pmodel.Notes
                        };
                        SaveClaimDetails(saveClaim);
                    }


                    if (pmodel.ClaimRequestUnits?.Count > 0)
                    {
                        foreach (var unit in pmodel.ClaimRequestUnits)
                        {
                            var saveUnit =
                                "INSERT INTO [dbo].[PClaimDetail]([PCRef] ,[PayAccount],[Code],[Rate],[Units],[Qty],[Amount],[Notes])VALUES("
                                + "'" + pcref + "','"
                                + pmodel.PayAccount + "','"
                                + unit.Code + "','"
                                + 1 + "','"
                                + unit.Rate + "','"
                                + unit.Quantity + "','"
                                + unit.Total + "','"
                                + +pmodel.ClaimRequestUnits.Count + " unit(s)/added by user'"
                                + ")";
                            _context.Database.ExecuteSqlCommand(saveUnit);
                        }
                    }

                    try
                    {
                        var wcf = new WfdocCentre
                        {
                            Type = "PART-TIME CLAIM",
                            DocNo = pcref,
                            Description = "AMOUNT : " + pmodel.TotalAmount + " SESSION : " + pmodel.Semester,
                            UserRef = pmodel.UserCode,
                            Names = emp.Names,
                            Department = emp.Department,
                            Rdate = DateTime.Now,
                            Rtime = DateTime.Now.ToLocalTime(),
                            Personnel = pmodel.UserCode,
                            FinalStatus = "Pending"
                        };
                        _context.WfdocCentre.Add(wcf);

                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return Json(new
                        {
                            status = 0,
                            message = "A server error occured,please contact the administrator : " + ex.Message
                        });
                    }

                    return Json(new
                    {
                        status = 1,
                        message = "Claim saved successfully"
                    });
                }
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Success = false,
                    Message = "A server error occured,please contact the administrator ",
                    Error=new Error(e)
                    
                });
            }

            return Json(new
            {
                status = 0,
                message = "Could not save claim,please try again"
            });
        }

//
//       
    }
}