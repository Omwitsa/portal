using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Constants;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class StudentNewsController : Controller
    {
        private readonly PortalCoreContext _context;
        private readonly TokenValidator _tokenValidator;
        public StudentNewsController(PortalCoreContext context)
        {
            _context = context;
            _tokenValidator = new TokenValidator(_context);
        }

        [HttpPost]
        [Route("addnews")]
        public JsonResult AddNewsViews()
        {
            try
            {
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });
                }
                return Json(new ReturnData<string>
                {
                    Success = true,
                    Message = "Successful"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occurred,please retry : " + ex.Message
                });
            }
        }


        [HttpPost("getnews")]
        public JsonResult GetNews(string searchText, int offset = 0, int role = 0)
        {
            try
            {
                var token = _tokenValidator.Validate(HttpContext);
                if (!token.Success)
                {
                    return Json(new ReturnData<string>
                    {
                        Success = false,
                        NotAuthenticated = true,
                        Message = $"Unauthorized:-{token.Message}",
                    });
                }
                searchText = string.IsNullOrEmpty(searchText) ? "" : searchText;

                var portalnews = _context.PortalNews
                    .Where(n => (n.NewsBody.CaseInsensitiveContains(searchText) ||
								n.NewsTitle.CaseInsensitiveContains(searchText)) && n.TargetAudience == role)
                    .Skip(offset * UnisolPortalContants.ItemsPerPage)
                    .Take(UnisolPortalContants.ItemsPerPage)
                    .Include(n => n.PortalNewsType)
                    .OrderBy(n => n.Id).ToList();
                var totalItems = _context.PortalNews.Count(n =>
                    n.NewsBody.CaseInsensitiveContains(searchText) || n.NewsTitle.CaseInsensitiveContains(searchText));


                return Json(new ReturnData<List<PortalNews>>
                {
                    Data = portalnews,
                    TotalItems = totalItems,
                    Success = portalnews.Count > 0,
                    Message = portalnews.Count > 0 ? "" : "No news found"
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "An error occurred,please retry : " + ex.Message
                });
            }
        }


        [HttpGet("getnewsdetails")]
        public JsonResult GetNewsDetails(int id)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });
            }
            var portalNews = _context.PortalNews.Include(n => n.PortalNewsType).FirstOrDefault(n => n.Id == id);
            return Json(new ReturnData<PortalNews>
            {
                Success = true,
                Data = portalNews,
                Message = "Successful"
            });
        }


        [HttpGet("getnewstypes")]
        public JsonResult GetNewsTypes()
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });
            }
            var portalNewsTypes = _context.PortalNewsTypes.Where(t => t.Status).ToList();
            return Json(new ReturnData<List<PortalNewsType>>
            {
                Success = true,
                Data = portalNewsTypes,
                Message = "Successful"
            });
        }

        [HttpGet("checknewstype")]
        public JsonResult CheckNewsType(string name)
        {
            var token = _tokenValidator.Validate(HttpContext);
            if (!token.Success)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    NotAuthenticated = true,
                    Message = $"Unauthorized:-{token.Message}",
                });
            }
            return Json(new ReturnData<bool>
            {
                Success = true,
                Data = _context.PortalNewsTypes.Any(t => t.NewsTypeName == name),
                Message = "Successful"
            });
        }
    }
}