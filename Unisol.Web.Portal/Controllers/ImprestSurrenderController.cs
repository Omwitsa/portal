using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImprestSurrenderController : Controller
    {
        private readonly IUnisolApiProxy _unisolApiProxy;
        private readonly PortalCoreContext _context;
        private readonly UnisolAPIdbContext _unisolContext;
        private readonly TokenValidator _tokenValidator;

        public ImprestSurrenderController(IUnisolApiProxy unisolApiProxy, PortalCoreContext context, UnisolAPIdbContext unisolContext)
        {
            _unisolApiProxy = unisolApiProxy;
            _context = context;
            _tokenValidator = new TokenValidator(_context);
            _unisolContext = unisolContext;
        }


        [HttpGet("[action]")]
        public JsonResult GetUserRequests(string userCode, string searchText)
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

            var surrenderReqs = new List<ImprestSurrenderReq>();
            try
            {
                surrenderReqs = _context.ImprestSurrenderReqs.Where(m => m.PayeeRef.Equals(userCode)).OrderByDescending(m => m.DateModified)
                    .ThenBy(m => m.ImpRef).ToList();
                foreach (var surReq in surrenderReqs)
                {
                    if (surReq.Status)
                        continue;
                    if (_unisolContext.ImprestSur.Any(m => m.ImpRef.Equals(surReq.ImpRef)))
                    {
                        surReq.Status = true;
                        _context.SaveChanges();
                    }
                }

                return Json(new ReturnData<List<ImprestSurrenderReq>>
                {
                    Success = true,
                    Data = surrenderReqs,
                    Message = "user surrender requests retrieved"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<List<ImprestSurrenderReq>>
                {
                    Success = false,
                    Data = surrenderReqs,
                    Message = "Error occurred while processing your request"
                });
            }
        }

        [HttpPost("[action]")]
        public JsonResult SaveSurrenderReq(ImprestSurrenderReq surrenderReq)
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
                if (!ModelState.IsValid)
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        Message = "Error occurred while submitting surrender request"
                    });

                _context.ImprestSurrenderReqs.Add(surrenderReq);
                _context.SaveChanges();

                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Imprest Surrender Request submitted successfully"
                });
            }
            catch (Exception)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Error occurred while processing your request"
                });
            }
        }
        [HttpGet("[action]")]
        public JsonResult GetAllSurrenderRequests()
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });
            var surrenderReqs = new List<ImprestSurrenderReq>();
            try
            {
                surrenderReqs = _context.ImprestSurrenderReqs.OrderByDescending(m => m.SurReqDate)
                .ThenBy(m => m.ImpRef).ToList();
                foreach (var surReq in surrenderReqs)
                {
                    if (surReq.Status)
                        continue;
                    if (_unisolContext.ImprestSur.Any(m => m.ImpRef.Equals(surReq.ImpRef)))
                    {
                        surReq.Status = true;
                        _context.SaveChanges();
                    }
                }
                return Json(new ReturnData<dynamic>
                {
                    Success = true,
                    Data = new
                    {
                        ClearedRequests = surrenderReqs.Where(m => m.Status),
                        PendingRequests = surrenderReqs.Where(m => !m.Status)
                    },
                    Message = "user surrender requests retrieved"
                });
            }
            catch (Exception)
            {
                return Json(new ReturnData<List<ImprestSurrenderReq>>
                {
                    Success = false,
                    Data = surrenderReqs,
                    Message = "Error occurred while processing your request"
                });
            }
        }
        [HttpGet("[action]")]
        public JsonResult GetImprestDetails(string userCode)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });
            try
            {
                var approvedImprests = new List<string>();
                var validImprests = _unisolContext.Imprest.Where(v => v.PayeeRef.Equals(userCode) && v.Status.Equals("Approved")).ToList();
                foreach (var validImprest in validImprests)
                {
                    if (!Exists(validImprest.ImpRef))
                        approvedImprests.Add(validImprest.ImpRef);
                }
                var employeeName = _unisolContext.HrpEmployee.FirstOrDefault(e => e.EmpNo.Equals(userCode))?.Names;
                return Json(new ReturnData<dynamic>
                {
                    Success = true,
                    Data = new
                    {
                        ValidImprests = approvedImprests,
                        EmployeeName = employeeName,
                        PayeeRef = userCode
                    },
                    Message = "valid user imprest retrieved"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Error occurred while processing your request"
                });
            }
        }
        private bool Exists(string impref)
        {
            if (_context.ImprestSurrenderReqs.Any(m => m.ImpRef.Equals(impref)))
                return true;
            if (_unisolContext.ImprestSur.Any(m => m.ImpRef.Equals(impref)))
                return true;
            return false;
        }
    }
}