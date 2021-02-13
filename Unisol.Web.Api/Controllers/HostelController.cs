using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.UnisolModels;


namespace Unisol.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class HostelController : Controller
    {
        private readonly UnisolAPIdbContext _context;

        public HostelController(UnisolAPIdbContext context)
        {
            _context = context;
          
        }

        [HttpGet("[action]")]
        public JsonResult GetAvailHostels()
        {
            try
            {
                var hostels = _context.Hostels.ToList();
                return Json(new ReturnData<List<Hostels>>
                {
                    Success = true,
                    Message = "All available hostels",
                    Data = hostels
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Sorry something went wrong while retrieving SORS, please try again"
                });
            }
        }

        [HttpGet("[action]")]
        public JsonResult GetHostelRooms(string hostel, string searchRoom = "")
        {
            try
            {
                searchRoom = string.IsNullOrWhiteSpace(searchRoom) ? "" : searchRoom;
                var hostelsrooms = _context.HostelRooms
                    .Where(h => h.Hostel == hostel)
                    .Where(r => r.Names.CaseInsensitiveContains(searchRoom))
                    .Take(20)
                    .ToList();
                return Json(new ReturnData<List<HostelRooms>>
                {
                    Success = true,
                    Message = "All rooms for " + hostel,
                    Data = hostelsrooms
                });
            }
            catch (Exception ex)
            {
                return Json(new ReturnData<string>
                {
                    Success = false,
                    Message = "Sorry something went wrong while retrieving hostel rooms, please try again"
                });
            }
        }
    }
}