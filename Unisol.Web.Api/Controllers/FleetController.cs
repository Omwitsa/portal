using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Api.IServices;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class FleetController : Controller
	{
		private IUnitOfWork _unitOfWork;
		private Utils utils;
		public FleetController(IUnitOfWork unitOfWork, UnisolAPIdbContext context)
		{
			_unitOfWork = unitOfWork;
			utils = new Utils(context);
		}

		[HttpGet("[action]")]
		public JsonResult GetFleetBookings(string usercode, string searchText)
		{
			searchText = searchText ?? "";
			try
			{
				var bookedFleets = _unitOfWork.FLBooking.GetWhere(b => b.EmpNo.ToUpper().Equals(usercode.ToUpper()) 
				&& (b.Ref.ToUpper().Contains(searchText.ToUpper()) || b.Purpose.ToLower().Contains(searchText.ToLower())))
				.OrderByDescending(b => b.RDate).ToList();

				var fleetBookings = new List<dynamic>();
				bookedFleets.ForEach(b => {
					var docCenterDetails = utils.GetDocCenterDetails(b.Ref);
					fleetBookings.Add(new
					{
						b.Ref,
						b.EmpNo,
						b.DDate,
						b.DTime,
						b.RetDate,
						b.RetTime,
						b.Purpose,
						b.VehicleType,
						b.Passengers,
						b.Location,
						b.Destination,
						b.RDate,
						b.RTime,
						b.Personnel,
						b.Status,
						Reason = docCenterDetails?.Reason ?? ""
					});
				});

				var userDetails = _unitOfWork.HrpEmployee.GetFirstOrDefault(e => e.EmpNo.ToUpper().Equals(usercode.ToUpper()));

				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						fleetBookings,
						userDetails
					}
				});
			}
			catch(Exception e)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Opps, An error occured"
				});
			}
		}

		[HttpGet("[action]")]
		public JsonResult GetUserFleetDetails(string usercode)
		{
			try
			{
				var userDetails = _unitOfWork.HrpEmployee.GetFirstOrDefault(e => e.EmpNo.ToUpper().Equals(usercode.ToUpper()));
				var vehicles = _unitOfWork.FLVehicle.GetAll().ToList();
				var vehicleTypes = vehicles.Select(v => v.VehicleType.ToUpper()).Distinct().ToList();
				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						userDetails,
						vehicleTypes
					}
				});
			}
			catch(Exception e)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Opps, An error occured"
				});
			}
		} 

		[HttpGet("[action]")]
		public JsonResult GetAssignedVehicles(string usercode, string searchText)
		{
			searchText = searchText ?? "";
			try
			{
				var bookingRefs = _unitOfWork.FLBooking.GetWhere(b => b.EmpNo.ToUpper().Equals(usercode.ToUpper()))
					.Select(b => b.Ref.ToUpper()).ToList();
				var trips = _unitOfWork.FLTrips.GetWhere(v => bookingRefs.Contains(v.BookingRef.ToUpper()) 
				&& (v.PlateNo.ToUpper().Contains(searchText.ToUpper())
				)).OrderByDescending(t => t.RDate).ToList();
				var employee = _unitOfWork.HrpEmployee.GetFirstOrDefault(e => e.EmpNo.ToUpper().Equals(usercode.ToUpper()));
				var details = new List<dynamic>();
				foreach (var trip in trips)
				{
					details.Add(new
					{
						DriverNo = trip.Driver,
						DriverName = _unitOfWork.HrpEmployee.GetFirstOrDefault(e => e.EmpNo.ToUpper().Equals(trip.Driver))?.Names,
						trip.PlateNo,
						trip.ID,
						trip.Destination,
						trip.LeadPassenger,
						trip.Purpose,
						trip.DepLocation,
						trip.Personnel,
						ApplicantName = employee.Names
					});
				}

				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = details
				});
			}
			catch (Exception e)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Opps, An error occured"
				});
			}
		}

		[HttpPost("[action]")]
		public JsonResult BookVehicle(FLBooking booking)
		{
			try
			{
				booking.Ref = GenerateRefNo();
				booking.Status = "Pending";
				booking.Personnel = booking.EmpNo;
				var procOnlineReq = new ProcOnlineReq
				{
					ReqRef = booking.Ref,
					DocType = "VEHICLE BOOKING",
					Rdate = DateTime.UtcNow.Date,
					Rtime = DateTime.UtcNow,
					Usercode = booking.EmpNo,
					Status = "Pending"
				};

				var docId = _unitOfWork.Wfrouting.GetFirstOrDefault(r => r.Document.ToUpper() == procOnlineReq.DocType.ToUpper())?.Id.ToString();
				if (string.IsNullOrEmpty(docId))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, " + procOnlineReq.DocType.ToUpper() + " Not supported at the moment. Please contact the admin"
					});

				var user = _unitOfWork.HrpEmployee.GetFirstOrDefault(e => e.EmpNo.ToUpper().Equals(booking.EmpNo.ToUpper()));
				var workFlowStatus = utils.SaveToWorkFlowCenter(procOnlineReq, user, docId);
				if (!workFlowStatus.Success)
					return Json(workFlowStatus);

				booking.DDate = booking.DDate.GetValueOrDefault().Date;
				booking.RetDate = booking.RetDate.GetValueOrDefault().Date;
				booking.RDate = booking.RDate.GetValueOrDefault().Date;
				_unitOfWork.FLBooking.Add(booking);
				_unitOfWork.Save();

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Applied Successfully"
				});
			}
			catch(Exception e)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Opps, An error occured"
				});
			}
		}

		private string GenerateRefNo()
		{
			var fleets = _unitOfWork.FLBooking.GetAll().ToList();
			if (fleets.Count < 1)
				return "VREQ001";

			var fleetRef = fleets.OrderByDescending(f => Convert.ToInt32(f.Ref.Substring(4))).FirstOrDefault();
			if (fleetRef == null)
				return "VREQ001";

			var count = fleetRef.Ref.Count();
			var digits = fleetRef.Ref.Substring(4);
			var sufix = Convert.ToInt32(digits);

			sufix++;

			var RefNo = "VREQ";
			if (sufix < 10) RefNo += "00" + sufix;

			if ((sufix > 9) && (sufix < 100)) RefNo += "0" + sufix;

			if (sufix > 99) RefNo += "" + sufix;
			return RefNo;
		}
	}
}
