using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Unisol.Web.Api.IServices;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Common.ViewModels.HostelBooking;
using Unisol.Web.Entities.Database.UnisolModels;


namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class HostelBookingController : Controller
	{
		private readonly UnisolAPIdbContext _context;
		private readonly IStudentServices _studentServices;
		private readonly ISystemServices _systemServices;
		private StudentCredential studentCredentials;
		private IConfiguration _configuration;
		public HostelBookingController(UnisolAPIdbContext context, IStudentServices studentServices,
			ISystemServices systemServices, IConfiguration configuration)
		{
			_context = context;
			_systemServices = systemServices;
			_configuration = configuration;
			_studentServices = studentServices;
			studentCredentials = new StudentCredential(_context, studentServices, systemServices);
		}

		[HttpGet("[action]")]
		public JsonResult GetHostelBookingRequests(string usercode, bool fetchLatestHostel, string classStatus)
		{
			try
			{
				var bookingRequests = _context.HostelBooking.Where(r => r.AdmnNo == usercode).
						OrderByDescending(r => r.Id).Take(1).ToList();

				if (!fetchLatestHostel)
				{
					bookingRequests = _context.HostelBooking.Where(r => r.AdmnNo == usercode).ToList();
				}


				if (!bookingRequests.Any())
				{
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "No hostel History"
					});
				}

				bookingRequests.ForEach(r =>
				{
					var hostelRoom = _context.HostelRooms.FirstOrDefault(h => h.Names == r.Hostel)?.Hostel ?? "";
					r.Hostel = hostelRoom + " : " + r.Hostel;
				});
				return Json(new ReturnData<List<HostelBooking>>
				{
					Success = true,
					Message = "My booking history",
					Data = bookingRequests
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry something went wrong while retrieving your booking history, please try again",
					Error = new Error(ex)
				});
			}
		}

		[HttpPost("[action]")]
		public JsonResult BookHostel(HostelBookingModel hostelBookingModel, string classStatus, string hostelRatio)
		{
			try
			{
				var booking = new HostelBooking
				{
					AdmnNo = hostelBookingModel.AdmnNo,
					Notes = null,
					Term = hostelBookingModel.Term,
					Personnel = hostelBookingModel.Personnel,
					Hostel = hostelBookingModel.Hostel,
					Rdate = DateTime.Now.Date
				};
				if (_context.HostelBooking.Any(h => h.AdmnNo.Contains(hostelBookingModel.AdmnNo) && h.Term.Contains(hostelBookingModel.Term)))
					return Json(new ReturnData<List<HostelBooking>>
					{
						Success = false,
						Message = "Your have already booked for this semester"
					});

				var percentages = hostelRatio.Split(")*(");
				var sponsor = _context.Register.FirstOrDefault(r => r.AdmnNo.ToUpper().Equals(hostelBookingModel.AdmnNo.ToUpper()))?.Sponsor;
				int percentage = 0;
				if (percentages.Length > 1)
				{
					if (sponsor.ToUpper().Equals("NYS"))
						int.TryParse(percentages[1], out percentage);
					else
						int.TryParse(percentages[0], out percentage);
				}

				double ratio = percentage * 0.01;
				if (CheckIfRoomIsBookable(hostelBookingModel.Hostel, hostelBookingModel.Term, ratio, hostelBookingModel.AdmnNo))
					return Json(new ReturnData<List<HostelBooking>>
					{
						Success = false,
						Message = "Sorry, maximum occupancy has been reached"
					});

				var inistitutionInitial = _systemServices.GetSystemSetup()?.Data?.SubTitle ?? "";
				if (inistitutionInitial.ToUpper().Equals("UOEM"))
				{
					var studInvoiced = InvoiceStudent(hostelBookingModel, classStatus);
					if (!studInvoiced.Success)
						return Json(new ReturnData<List<HostelBooking>>
						{
							Success = false,
							Message = "Sorry, An error occurred while invoicing"
						});
				}

				_context.HostelBooking.Add(booking);
				_context.SaveChanges();
				return Json(new ReturnData<List<HostelBooking>>
				{
					Success = true,
					Message = "Your hostel booking was submited succesfully"
				});
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "There was a problem while trying to submit your booking"
				});
			}
		}

		private ReturnData<string> InvoiceStudent(HostelBookingModel hostelBookingModel, string classStatus)
		{
			try
			{
				var roomFeeResponse = GetRoomFees(hostelBookingModel.Hostel, hostelBookingModel.AdmnNo);
				if (!roomFeeResponse.Success)
					return new ReturnData<string>
					{
						Success = roomFeeResponse.Success,
						Message = roomFeeResponse.Message
					};

				var enrolment = _studentServices.GetEnrollment(hostelBookingModel.AdmnNo, classStatus);
				if (!enrolment.Success)
					return new ReturnData<string>
					{
						Success = false,
						Message = enrolment.Message
					};

				AdjustInvoice(new StudInvoiceAdj
				{
					AdmnNo = hostelBookingModel.AdmnNo,
					Term = hostelBookingModel.Term,
					Class = enrolment.Data.Class,
					Amount = roomFeeResponse.Data.Amount
				});

				return new ReturnData<string>
				{
					Success = true
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		private void AdjustInvoice(StudInvoiceAdj studInvoiceAdj)
		{
			try
			{
				studInvoiceAdj.Ref = GetInvoiceNo();
				var query = "INSERT INTO StudInvoiceAdj (ref, AdmnNo, term, notes, Class, Amount, rdate) " +
					"VALUES (@ref, @admnno, @term, @notes, @class, @fee, @rdate)";

				string connetionString = DbSetting.ConnectionString(_configuration, "Unisol");
				SqlConnection connection = new SqlConnection(connetionString);
				if (connection.State == ConnectionState.Closed)
					connection.Open();
				var sqlCommand = new SqlCommand(query, connection);
				sqlCommand.Parameters.AddWithValue("@ref", studInvoiceAdj.Ref);
				sqlCommand.Parameters.AddWithValue("@admnno", studInvoiceAdj.AdmnNo.ToUpper());
				sqlCommand.Parameters.AddWithValue("@term", studInvoiceAdj.Term.ToUpper());
				sqlCommand.Parameters.AddWithValue("@notes", "BOARDING FEES");
				sqlCommand.Parameters.AddWithValue("@class", studInvoiceAdj.Class.ToUpper());
				sqlCommand.Parameters.AddWithValue("@fee", studInvoiceAdj.Amount);
				sqlCommand.Parameters.AddWithValue("@rdate", DateTime.UtcNow.Date);
				sqlCommand.ExecuteNonQuery();

				sqlCommand.Dispose();
				connection.Close();
			}
			catch (Exception)
			{

			}
		}

		private ReturnData<FeesPerHostelRoomDetail> GetRoomFees(string hostel, string admnNo)
		{
			var register = _studentServices.GetRegister(admnNo);
			if (!register.Success)
				return new ReturnData<FeesPerHostelRoomDetail>
				{
					Success = register.Success,
					Message = register.Message
				};

			var sponser = register?.Data?.Sponsor ?? "";

			var hostelRoom = _context.FeesPerHostelRoom.FirstOrDefault(h => h.Hostel.ToUpper().Equals(hostel.ToUpper())
				&& (h.Edate == null || h.Edate > DateTime.UtcNow) && h.Sponsor.ToUpper().Equals(sponser.ToUpper()));
			if (hostelRoom == null)
				return new ReturnData<FeesPerHostelRoomDetail>
				{
					Success = false,
					Message = "Sorry, hostel fee not yet set"
				};
			var roomFee = _context.FeesPerHostelRoomDetail.FirstOrDefault(r => r.Ref.ToUpper().Equals(hostelRoom.Id.ToString()));
			if (roomFee == null)
				return new ReturnData<FeesPerHostelRoomDetail>
				{
					Success = false,
					Message = "Sorry, hostel fee not yet set"
				};

			return new ReturnData<FeesPerHostelRoomDetail>
			{
				Success = true,
				Data = roomFee
			};
		}

		private string GetInvoiceNo()
		{
			var invoiceAdj = _context.StudInvoiceAdj.Select(i => new StudInvoiceAdj
			{
				Ref = i.Ref,
				AdmnNo = i.AdmnNo,
				Term = i.Term,
				Class = i.Class
			}).OrderByDescending(t => Convert.ToInt32(t.Ref.Substring(3))).FirstOrDefault();
			var invoiceNo = "SIA001";
			if (invoiceAdj == null)
				return invoiceNo;

			int.TryParse(invoiceAdj.Ref.Substring(3), out var number);
			if (number < 100)
				invoiceNo = $"SIA0{number + 1}";
			if (number < 10)
				invoiceNo = $"SIA00{number + 1}";
			else
				invoiceNo = $"SIA{number + 1}";

			return invoiceNo;
		}

		[HttpGet("[action]")]
		public JsonResult GetOpenHostels(string usercode, string classStatus)
		{
			try
			{
				var user = _context.Register.Select(r => new { r.AdmnNo, r.Gender }).FirstOrDefault(r => r.AdmnNo == usercode);
				if (user != null)
				{
					var hostels = _context.Hostels.Where(h => h.Closed == false && h.Gender == user.Gender).ToList();
					return Json(new ReturnData<List<Hostels>>
					{
						Success = true,
						Message = "All open " + user.Gender + " hostels",
						Data = hostels
					});
				}
				else
				{
					var hostels = _context.Hostels.Where(h => h.Closed == false).ToList();
					return Json(new ReturnData<List<Hostels>>
					{
						Success = true,
						Message = "All open hostels all genders",
						Data = hostels
					});
				}
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry something went wrong while retrieving Hostels, please try again"
				});
			}
		}

		[HttpGet("CheckIfCanBookHostel")]
		public JsonResult CheckIfCanBookHostel(string usercode, string classStatus)
		{
			try
			{
				var userEnrollment = _context.StudEnrolment.Where(s => s.AdmnNo == usercode).FirstOrDefault();
				if (userEnrollment == null)
					return Json(new ReturnData<dynamic>
					{
						Success = false,
						Message = "You are not eligible to book for a hostel",
						Data = new { Status = false }
					});

				var currentTerm = GetCurrectTerm(userEnrollment.Class);
				if (_context.HostelBooking.Any(h => h.AdmnNo == usercode && h.Term == currentTerm))
					return Json(new ReturnData<dynamic>
					{
						Success = false,
						Message = "You already booked a room for this semester (" + currentTerm + ")",
						Data = new { Status = true, currentTerm }
					});

				var boarder = _context.Boarders.FirstOrDefault(b => b.AdmnNo.ToUpper().Equals(usercode.ToUpper()));
				if (boarder != null)
				{
					var hostelRoom = _context.HostelRooms.FirstOrDefault(r => r.Names.ToUpper().Equals(boarder.Hostel.ToUpper()));
					return Json(new ReturnData<dynamic>
					{
						Success = false,
						Message = $"You have been allocated hostel: {hostelRoom?.Hostel ?? ""} - room: {hostelRoom?.Names ?? ""}",
						Data = new { Status = true, currentTerm }
					});
				}

				var bookingRate = GetBookingRate(usercode, classStatus);
				if (!bookingRate.Success)
					return Json(new ReturnData<dynamic>
					{
						Success = false,
						Message = "You are not eligible to book for a hostel",
						Data = new { Status = false }
					});

				if (currentTerm.Equals("default"))
					return Json(new ReturnData<dynamic>
					{
						Success = false,
						Message = "You are not eligible to book for a hostel",
						Data = new { Status = false }
					});

				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Message = "You are eligible to book for a hostel",
					Data = new { Status = true, currentTerm, bookingRate.Data }
				});

			}
			catch (Exception ex)
			{
				return Json(new ReturnData<dynamic>
				{
					Success = false,
					Message = "There was a problem checking eligibility ",
					Data = new { Status = false }
				});
			}
		}

		private ReturnData<dynamic> GetBookingRate(string usercode, string classStatus)
		{
			try
			{
				var gender = _studentServices.GetRegister(usercode)?.Data?.Gender ?? "";
				var genderRooms = _context.HostelRooms.Where(r => r.Gender.ToUpper().Equals(gender.ToUpper()));
				var totalCapacity = 0;

				foreach (var room in genderRooms)
				{
					totalCapacity = totalCapacity + (int)room.Maxacc;
				}

				var yearOfStudy = _studentServices.GetSessionPlannerCurrentDetails(usercode, classStatus)?.Data?.Stage ?? "";
				var plannerId = _studentServices.GetSessionPlanner(usercode, classStatus).Data?.Id.ToString() ?? "";
				var yearClasses = _context.CsplannerDetail.Where(c => c.Stage.ToUpper().Equals(yearOfStudy.ToUpper())
				&& c.Ref.ToUpper().Equals(plannerId.ToUpper())).Select(c => c.Class.ToUpper()).ToList();
				var yearlyStudents = _context.StudEnrolment.Where(s => yearClasses.Contains(s.Class.ToUpper()))
					.Select(s => s.AdmnNo.ToUpper()).ToList();

				var yearlyBooking = _context.HostelBooking.Where(h => yearlyStudents.Contains(h.AdmnNo.ToUpper())).ToList();
				var yearlyAllocation = _context.Boarders.Where(b => yearlyStudents.Contains(b.AdmnNo.ToUpper())).ToList();
				var rate = ((yearlyBooking.Count + yearlyAllocation.Count) * 100) / totalCapacity;
				var yearIndex = 0;
				if (yearOfStudy.ToUpper().Equals("YEAR 2"))
					yearIndex = 1;
				if (yearOfStudy.ToUpper().Equals("YEAR 3"))
					yearIndex = 2;
				if (yearOfStudy.ToUpper().Equals("YEAR 4"))
					yearIndex = 3;
				var inistitutionInitial = _systemServices.GetSystemSetup()?.Data?.SubTitle ?? "";
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						rate,
						yearIndex,
						inistitutionInitial
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Data = 100
				};
			}
		}

		[HttpGet("[action]")]
		public JsonResult GetRoomsWithSpace(string hostel, string usercode, string classStatus, string searchString = "", string hostelRatio = "")
		{
			try
			{
				searchString = string.IsNullOrWhiteSpace(searchString) ? "" : searchString;
				var userEnrollment =_context.StudEnrolment.OrderByDescending(e => e.Sdate).Select(e => new { e.AdmnNo, e.Class }).FirstOrDefault(s => s.AdmnNo == usercode);
				if (userEnrollment != null)
				{
					var hostelrooms = _context.HostelRooms
						.Where(h => h.Hostel == hostel && !h.Suspended.Value)
						.Where(r => r.Names.CaseInsensitiveContains(searchString))
						.ToList();
					if (!hostelrooms.Any())
					{
						return Json(new ReturnData<List<HostelRooms>>
						{
							Success = false,
							Message = $"No available room to Book in {hostel}",
							Data = new List<HostelRooms>()
						});
					}
					var dept = _context.Register.Where(r => r.AdmnNo.Equals(usercode)).Select(e => e.Programme)
						.Join(_context.Programme, rp => rp, p => p.Names, (rp, p) => p.Department).FirstOrDefault();
					var sysDepts = _context.SysSetup.Select(s => s.ExcDept).FirstOrDefault();
					if (!string.IsNullOrEmpty(sysDepts))
					{
						var listDepts = sysDepts.Split("|").ToList();
						if (listDepts.Contains(dept))
						{
							return Json(new ReturnData<List<HostelRooms>>
							{
								Success = false,
								Message = $"Department {dept} is not Allowed to Book",
								Data = new List<HostelRooms>()
							});
						}
					}
					var userClass = userEnrollment.Class;
					var currentTerm = GetCurrectTerm(userClass);

					if (currentTerm.Equals("default"))
						return Json(new ReturnData<string>
						{
							Success = false,
							Message = "You cannot be able to book for a hostel at this time, please contact the system administrator"
						});

					var percentages = hostelRatio.Split(")*(");
					var sponsor = _context.Register.FirstOrDefault(r => r.AdmnNo.ToUpper().Equals(usercode.ToUpper()))?.Sponsor;
					int percentage = 0;
					if(percentages.Length > 1)
                    {
                        if (sponsor.ToUpper().Equals("NYS"))
							int.TryParse(percentages[1], out percentage);
						else
							int.TryParse(percentages[0], out percentage);
					}
					double ratio = percentage * 0.01;

					var avRooms = new List<HostelRooms>();
					foreach (var room in hostelrooms)
					{
						var available = CheckIfRoomAvailable(room, currentTerm, usercode, ratio);
						if (available > 0)
						{
							room.Notes = available.ToString();
							avRooms.Add(room);
						}
					}

					return Json(new ReturnData<List<HostelRooms>>
					{
						Success = true,
						Message = "All rooms with space",
						Data = avRooms
					});
				}

				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry you have to report for the semester first to book a hostel"
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

		public bool CheckHostelForSpace(HostelRooms hostelRoom)
		{
			var bookings = _context.HostelBooking.Where(h => h.Hostel == hostelRoom.Names).ToList();
			return true;
		}

		public string GetCurrectTerm(string studentClass)
		{
			var term = _context.Class
					.Join(_context.Term,
						studentClassJoin => studentClassJoin.Term,
						t => t.Type,
						(studentClassJoin, t) =>
							new { t.Names, t.Starts, t.Ends, t.TermAlias, t.Type, studentClassJoin.Id })
					.FirstOrDefault(c =>
						c.Id.CaseInsensitiveContains(studentClass) &&
						(c.Starts <= DateTime.Now.Date && c.Ends >= DateTime.Now.Date))
				;
			if (term != null)
			{
				return term.Names;
			}

			return "default";
		}

		public int CheckIfRoomAvailable(HostelRooms room, string currentTerm, string usercode, double ratio)
		{
			var bookings = _context.HostelBooking.Count(b => b.Hostel == room.Names && b.Term == currentTerm);
			if (room.Maxacc == null)
				return 0;

			var initials = _context.SysSetup.FirstOrDefault()?.SubTitle;
			if (initials.ToUpper().Equals("PCKTTI"))
            {
				room.Maxacc = room.Maxacc == null ? 0 : room.Maxacc;
				var maxAcc = Math.Round((double)room.Maxacc * ratio, MidpointRounding.AwayFromZero);
				room.Maxacc = (int)maxAcc;

				var sponsor = _context.Register.FirstOrDefault(r => r.AdmnNo.ToUpper().Equals(usercode.ToUpper()))?.Sponsor;
				var students = _context.Register.Where(r => r.Sponsor.ToUpper().Equals(sponsor.ToUpper())).Select(r => r.AdmnNo.ToUpper()).ToList();
				bookings = _context.HostelBooking.Count(b => b.Hostel == room.Names && b.Term == currentTerm && students.Contains(b.AdmnNo.ToUpper()));
			}
				

			return (int)room.Maxacc - bookings;
		}

       

        public bool CheckIfRoomIsBookable(string room, string currentTerm, double ratio, string usercode)
		{
			var bookings = _context.HostelBooking.Count(b => b.Hostel == room && b.Term == currentTerm);
			var roomCapacity = _context.HostelRooms.FirstOrDefault(h => h.Names == room)?.Maxacc ?? 0;

			var initials = _context.SysSetup.FirstOrDefault()?.SubTitle;
			if (initials.ToUpper().Equals("PCKTTI"))
			{
				var maxAcc = Math.Round((double)roomCapacity * ratio, MidpointRounding.AwayFromZero);
				roomCapacity = (int)maxAcc;

				var sponsor = _context.Register.FirstOrDefault(r => r.AdmnNo.ToUpper().Equals(usercode.ToUpper()))?.Sponsor;
				var students = _context.Register.Where(r => r.Sponsor.ToUpper().Equals(sponsor.ToUpper())).Select(r => r.AdmnNo.ToUpper()).ToList();
				bookings = _context.HostelBooking.Count(b => b.Hostel == room && b.Term == currentTerm && students.Contains(b.AdmnNo.ToUpper()));
			}

			return roomCapacity <= bookings;
		}

		[HttpGet("[action]")]
		public JsonResult DeallocateHostel(string classStatus)
		{
			try
			{
				var syssetup = _context.SysSetup.FirstOrDefault()?.SubTitle ?? "";
				if (syssetup.ToUpper().Equals("UOEM"))
				{
					var hostelBookings = _context.HostelBooking.ToList();
					if (hostelBookings.Count > 0)
					{
						var contextChanged = false;
						foreach (var booking in hostelBookings)
						{
							var StudFeesBalances = studentCredentials.GetFeesBalance(booking.AdmnNo, classStatus);
							double.TryParse(StudFeesBalances.Substring(4), out double Balance);
							if (Balance > 0)
							{
								var roomFeeResponse = GetRoomFees(booking.Hostel, booking.AdmnNo);
								var adjustments = _context.StudInvoiceAdj.Select(i => new StudInvoiceAdj
								{
									Ref = i.Ref,
									AdmnNo = i.AdmnNo,
									Amount = i.Amount,
									Term = i.Term,
									Notes = i.Notes,
									Class = i.Class
								}).OrderByDescending(i => Convert.ToInt32(i.Ref.Substring(3)))
								.FirstOrDefault(i => i.AdmnNo.ToUpper().Equals(booking.AdmnNo.ToUpper())
								&& i.Term.ToUpper().Equals(booking.Term.ToUpper()) && i.Notes.ToUpper().Equals("BOARDING FEES"));

								if (adjustments != null)
								{
									adjustments.Amount = -adjustments.Amount;
									AdjustInvoice(adjustments);
									_context.HostelBooking.Remove(booking);
									contextChanged = true;
								}
							}
						}

						if (contextChanged)
							_context.SaveChanges();
					}
				}

				return Json(new ReturnData<string>
				{
					Success = true
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred",
					Error = new Error(ex)
				});
			}
		}

		[HttpGet("getCurrentHostel")]
		public JsonResult GetCurrentHostel(string usercode, string classStatus)
		{
			try
			{
				var termResponse = _studentServices.GetCurrentTerm(usercode, classStatus);
				if (!termResponse.Success)
					return Json(termResponse);
				var term = termResponse.Data?.Names ?? "";

				var hostel = _context.HostelBooking.FirstOrDefault(h => h.AdmnNo.ToUpper().Equals(usercode.ToUpper()) && h.Term.ToUpper().Equals(term.ToUpper()));
				return Json(new ReturnData<HostelBooking>
				{
					Success = true,
					Data = hostel
				});
			}
			catch (Exception)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred",
				});
			}
		}
	}
}