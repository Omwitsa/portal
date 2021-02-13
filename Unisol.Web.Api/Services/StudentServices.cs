using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Api.IServices;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.StudentUtilities;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Common.ViewModels.Users;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Services
{
	public class StudentServices : IStudentServices
	{
		private IUnitOfWork _unitOfWork;
		private IConfiguration _configuration;
		public StudentServices(IUnitOfWork unitOfWork, IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_configuration = configuration;
		}

		public ReturnData<bool> CheckIfGenesis()
		{
			try
			{
				var hasStudent = _unitOfWork.Register.GetAny();
				if (hasStudent)
					return new ReturnData<bool>
					{
						Success = false,
						Data = false
					};
				return new ReturnData<bool>
				{
					Success = true,
					Data = true
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<bool>
				{
					Success = true,
					Data = true
				};
			}
		}

		public ReturnData<Register> GetRegister(string userCode, bool? isCampusApi = false)
		{
			try
			{
				var register = _unitOfWork.Register.GetFirstOrDefault(r => r.AdmnNo.ToLower().Equals(userCode.ToLower()));
				if (register == null)
					return new ReturnData<Register>
					{
						Success = false,
						Message = "Sorry, the student number you entered is not valid. Kindly contact admin",
					};

				var campusApiRequest = Convert.ToBoolean(isCampusApi);
				if (!campusApiRequest)
				{
					if (!_unitOfWork.SysSetup.GetAny(s => s.SubTitle.ToUpper().Equals("NTTI")))
					{
						bool registerStatus = register.Closed != null && (!(bool)register.Closed);
						if (!registerStatus)
							return new ReturnData<Register>
							{
								Success = false,
								Message = "Sorry, Your Registration Number has been temporarily  deactivated, Please contact School Admin.",
							};
					}

					if (string.IsNullOrEmpty(register.Email))
						return new ReturnData<Register>
						{
							Success = false,
							Message = "Sorry, Your Email Address has not been updated by the School Admin.",
						};
				}

				return new ReturnData<Register>
				{
					Success = true,
					Message = "Congratulations, Your Student details have been confirmed.",
					Data = register
				};
			}
			catch (Exception)
			{
				return new ReturnData<Register>
				{
					Success = false,
					Message = "Sorry, Server error",
				};
			}
		}

		public ReturnData<StudEnrolment> GetEnrollment(string userCode, string classStatus, bool? isCampusApi = false)
		{
			try
			{
				var register = GetRegister(userCode, isCampusApi);
				if (!register.Success)
					return new ReturnData<StudEnrolment>
					{
						Success = register.Success,
						Message = register.Message,
					};

				var arrayOfSelectedClassStatus = classStatus != null ? classStatus.Split(",") : new string[0];

				var studentEnrollment = _unitOfWork.StudEnrolment.GetWhere(e => e.AdmnNo.ToUpper().Equals(userCode.ToUpper())).OrderByDescending(e => e.Id).FirstOrDefault();

				if (studentEnrollment == null)
					return new ReturnData<StudEnrolment>
					{
						Success = !register.Success,
						Message = "There was a particular problem with your account creation. Please contact School Admin.",
					};

				var isCampus360Request = Convert.ToBoolean(isCampusApi);
				if (!isCampus360Request)
				{
					if (!arrayOfSelectedClassStatus.Contains(studentEnrollment.Status))
						return new ReturnData<StudEnrolment>
						{
							Success = !register.Success,
							Message = "Sorry,access denied for your class status, please contact admin",
						};
				}

				return new ReturnData<StudEnrolment>
				{
					Success = register.Success,
					Message = "Congratulations, Your Student details have been confirmed.",
					Data = studentEnrollment
				};
			}
			catch (Exception)
			{
				return new ReturnData<StudEnrolment>
				{
					Success = false,
					Message = "Sorry, Server error",
				};
			}
		}

		public ReturnData<Class> GetClass(string userCode, string classStatus, bool? isCampusApi = false)
		{
			try
			{
				var studentEnrollment = GetEnrollment(userCode, classStatus, isCampusApi);
				if (!studentEnrollment.Success)
					return new ReturnData<Class>
					{
						Success = studentEnrollment.Success,
						Message = studentEnrollment.Message,
					};

				var studentClass = _unitOfWork.Class.GetFirstOrDefault(c => c.Id.ToUpper().Equals(studentEnrollment.Data.Class.ToUpper()));
				if (studentClass == null)
					return new ReturnData<Class>
					{
						Success = !studentEnrollment.Success,
						Message = "Sorry, We could not find your class details, Please contact your School Admin.",
					};

				return new ReturnData<Class>
				{
					Success = studentEnrollment.Success,
					Message = "Student class found",
					Data = studentClass
				};
			}
			catch (Exception)
			{
				return new ReturnData<Class>
				{
					Success = false,
					Message = "Sorry, Server error",
				};
			}
		}

		public ReturnData<Term> GetPreviousTerm(string userCode, string classStatus)
		{
			try
			{
				var studentClass = GetClass(userCode, classStatus);
				if (!studentClass.Success)
					return new ReturnData<Term>
					{
						Success = studentClass.Success,
						Message = studentClass.Message,
					};

				//var unitReg = _unitOfWork.ProgUnitReg.GetAll().OrderByDescending(u => u.Id).FirstOrDefault();
				var termName = "SEMESTER 2 2019/2020";
				var term = _unitOfWork.Term.GetWhere(t => t.Names.ToUpper().Equals(termName.ToUpper())).FirstOrDefault();
				if (term == null)
					return new ReturnData<Term>
					{
						Success = !studentClass.Success,
						Message = "Sorry, The date provided for the semester has already expired. Please contact School Admin.",
					};

				return new ReturnData<Term>
				{
					Success = studentClass.Success,
					Message = "Student Current term found",
					Data = term
				};
			}
			catch (Exception)
			{
				return new ReturnData<Term>
				{
					Success = false,
					Message = "Sorry, Server error",
				};
			}
		}

		public ReturnData<Term> GetCurrentTerm(string userCode, string classStatus)
		{
			try
			{
				var studentClass = GetClass(userCode, classStatus);
				if (!studentClass.Success)
					return new ReturnData<Term>
					{
						Success = studentClass.Success,
						Message = studentClass.Message,
					};

				var term = _unitOfWork.Term.GetFirstOrDefault(t => t.Type.ToUpper().Equals(studentClass.Data.Term.ToUpper())
				&& t.Starts <= DateTime.Now.Date && t.Ends >= DateTime.Now.Date);

				if (term == null)
					return new ReturnData<Term>
					{
						Success = !studentClass.Success,
						Message = "Sorry, The date provided for the semester has already expired. Please contact School Admin.",
					};

				return new ReturnData<Term>
				{
					Success = studentClass.Success,
					Message = "Student Current term found",
					Data = term
				};
			}
			catch (Exception)
			{
				return new ReturnData<Term>
				{
					Success = false,
					Message = "Sorry, Server error",
				};
			}
		}

		public string GetCurrentTermByDate(string studentclass, DateTime serverdate)
		{
			try
			{
				var term = _unitOfWork.Term.GetTermByDate(studentclass, serverdate);
				return term;
			}
			catch (Exception)
			{
				return "";
			}
		}

		public ReturnData<Csplanner> GetSessionPlanner(string userCode, string classStatus, bool isPreviousTermCard = false)
		{
			try
			{
				var currentTerm = GetCurrentTerm(userCode, classStatus);
				if (isPreviousTermCard)
					currentTerm = GetPreviousTerm(userCode, classStatus);
				if (!currentTerm.Success)
					return new ReturnData<Csplanner>
					{
						Success = currentTerm.Success,
						Message = currentTerm.Message,
					};

				var csPlanner = _unitOfWork.Csplanner.GetFirstOrDefault(p => p.Term.ToLower().Equals(currentTerm.Data.Names.ToLower()));
				if (csPlanner == null)
					return new ReturnData<Csplanner>
					{
						Success = !currentTerm.Success,
						Message = "Sorry, Your current semester (" + currentTerm.Data.Names + ") has not been updated, Please contact School Admin.",
					};

				return new ReturnData<Csplanner>
				{
					Success = currentTerm.Success,
					Message = "Session planner found",
					Data = csPlanner
				};
			}
			catch (Exception)
			{
				return new ReturnData<Csplanner>
				{
					Success = false,
					Message = "Sorry, Server error",
				};
			}
		}

		public ReturnData<List<CsplannerDetail>> GetSessionPlannerDetails(string userCode, string classStatus)
		{
			try
			{
				var studentClass = GetClass(userCode, classStatus);
				if (!studentClass.Success)
					return new ReturnData<List<CsplannerDetail>>
					{
						Success = studentClass.Success,
						Message = studentClass.Message,
					};

				var csPlannerDetails = _unitOfWork.CsplannerDetail.GetWhere(p => p.Class.ToLower().Equals(studentClass.Data.Id)).ToList();

				return new ReturnData<List<CsplannerDetail>>
				{
					Success = studentClass.Success,
					Message = "Session planner details found",
					Data = csPlannerDetails
				};
			}
			catch (Exception)
			{
				return new ReturnData<List<CsplannerDetail>>
				{
					Success = false,
					Message = "Sorry, Server error",
				};
			}
		}

		public ReturnData<CsplannerDetail> GetSessionPlannerCurrentDetails(string userCode, string classStatus, bool isPreviousTermCard = false)
		{
			try
			{
				var studentClass = GetClass(userCode, classStatus);
				if (!studentClass.Success)
					return new ReturnData<CsplannerDetail>
					{
						Success = studentClass.Success,
						Message = studentClass.Message,
					};

				var currentTerm = GetCurrentTerm(userCode, classStatus);
				if (isPreviousTermCard)
					currentTerm = GetPreviousTerm(userCode, classStatus);
				if (!currentTerm.Success)
					return new ReturnData<CsplannerDetail>
					{
						Success = currentTerm.Success,
						Message = currentTerm.Message,
					};

				var csPlanner = GetSessionPlanner(userCode, classStatus, isPreviousTermCard);
				if (!csPlanner.Success)
					return new ReturnData<CsplannerDetail>
					{
						Success = csPlanner.Success,
						Message = csPlanner.Message,
					};

				var csPlannerDetails = _unitOfWork.CsplannerDetail.GetFirstOrDefault(p => p.Class.ToLower().Equals(studentClass.Data.Id.ToLower())
				&& p.Ref.ToLower().Equals(csPlanner.Data.Id.ToString().ToLower()) && !string.IsNullOrEmpty(p.Stage) && !string.IsNullOrEmpty(p.Term));
				if (csPlannerDetails == null)
					return new ReturnData<CsplannerDetail>
					{
						Success = !csPlanner.Success,
						Message = "Sorry, Your current semester (" + currentTerm.Data.Names + ") details has not been updated (cohort planner not set), Please contact School Admin.",
					};

				return new ReturnData<CsplannerDetail>
				{
					Success = csPlanner.Success,
					Message = "Session planner details found",
					Data = csPlannerDetails
				};
			}
			catch (Exception)
			{
				return new ReturnData<CsplannerDetail>
				{
					Success = false,
					Message = "Sorry, Server error",
				};
			}
		}

		public ReturnData<OnlineReporting> CheckOnlineReporting(string userCode, string classStatus, bool isPreviousTermCard = false)
		{
			try
			{
				var currentTerm = GetCurrentTerm(userCode, classStatus);
				if (isPreviousTermCard)
					currentTerm = GetPreviousTerm(userCode, classStatus);
				if (!currentTerm.Success)
					return new ReturnData<OnlineReporting>
					{
						Success = currentTerm.Success,
						Message = currentTerm.Message,
					};

				var onlineReporting = _unitOfWork.OnlineReporting.GetFirstOrDefault(r => r.AdmnNo.ToLower().Equals(userCode.ToLower())
				&& r.Term.ToLower().Equals(currentTerm.Data.Names.ToLower()));
				var hasReported = onlineReporting != null;
				if (!hasReported)
					return new ReturnData<OnlineReporting>
					{
						Success = hasReported,
						Message = "Allowed to report for session (" + currentTerm.Data.Names + ")",
					};

				return new ReturnData<OnlineReporting>
				{
					Success = hasReported,
					Message = "You have already reported for this session (" + currentTerm.Data.Names + ")",
					Data = onlineReporting
				};
			}
			catch (Exception)
			{
				return new ReturnData<OnlineReporting>
				{
					Success = false,
					Message = "Sorry, Server error",
				};
			}
		}

		public ReturnData<Reporting> CheckErpReporting(string userCode, string classStatus, bool isPreviousTermCard = false)
		{
			try
			{
				var currentTerm = GetCurrentTerm(userCode, classStatus);
				if (isPreviousTermCard)
					currentTerm = GetPreviousTerm(userCode, classStatus);
				if (!currentTerm.Success)
					return new ReturnData<Reporting>
					{
						Success = currentTerm.Success,
						Message = currentTerm.Message,
					};


				var hasReported = _unitOfWork.Reporting.GetAny(r => r.AdmnNo.ToLower().Equals(userCode.ToLower())
				&& r.Term.ToLower().Equals(currentTerm.Data.Names.ToLower()));
				if (!hasReported)
					return new ReturnData<Reporting>
					{
						Success = hasReported,
						Message = "Allowed to report",
					};

				return new ReturnData<Reporting>
				{
					Success = hasReported,
					Message = "Sorry, you already reported for this semester via the ERP (" + currentTerm.Data.Names + ")",
				};
			}
			catch (Exception)
			{
				return new ReturnData<Reporting>
				{
					Success = false,
					Message = "Sorry, Server error",
				};
			}
		}

		public ReturnData<Programme> GetProgramme(string userCode, string classStatus, bool? isCampusApi = false)
		{
			try
			{
				var studentClass = GetClass(userCode, classStatus, isCampusApi);
				if (!studentClass.Success)
					return new ReturnData<Programme>
					{
						Success = studentClass.Success,
						Message = studentClass.Message,
					};

				var programme = _unitOfWork.Programme.GetFirstOrDefault(p => p.Names.ToLower().Equals(studentClass.Data.Programme.ToLower()));
				if (programme == null)
					return new ReturnData<Programme>
					{
						Success = !studentClass.Success,
						Message = "Sorry, we could not find your programme details. Please contact the School Admin.",
					};

				return new ReturnData<Programme>
				{
					Success = studentClass.Success,
					Message = "Programme found successfully",
					Data = programme
				};
			}
			catch (Exception)
			{
				return new ReturnData<Programme>
				{
					Success = false,
					Message = "Sorry, Server error",
				};
			}
		}

		public ReturnData<Department> GetDepartment(string userCode, string classStatus)
		{
			try
			{
				var studentProgramme = GetProgramme(userCode, classStatus);
				if (!studentProgramme.Success)
					return new ReturnData<Department>
					{
						Success = studentProgramme.Success,
						Message = studentProgramme.Message,
					};

				var department = _unitOfWork.Department.GetFirstOrDefault(d => d.Names.ToLower().Equals(studentProgramme.Data.Department.ToLower()));
				if (department == null)
					return new ReturnData<Department>
					{
						Success = !studentProgramme.Success,
						Message = "Sorry, Your department details have not been updated, Please contact School Admin.",
					};

				return new ReturnData<Department>
				{
					Success = studentProgramme.Success,
					Message = "Department found",
					Data = department
				};
			}
			catch (Exception)
			{
				return new ReturnData<Department>
				{
					Success = false,
					Message = "Sorry, Server error",
				};
			}
		}

		public ReturnData<ProgUnitReg> GetCurrentUnitRegistration(string userCode, string classStatus)
		{
			try
			{
				var term = GetCurrentTerm(userCode, classStatus);
				if (!term.Success)
					return new ReturnData<ProgUnitReg>
					{
						Success = term.Success,
						Message = term.Message,
					};

				var progUnitReg = _unitOfWork.ProgUnitReg.GetFirstOrDefault(p => p.Term.ToLower().Equals(term.Data.Names.ToLower())
				&& p.AdmnNo.ToLower().Equals(userCode.ToLower()));
				if (progUnitReg == null)
					return new ReturnData<ProgUnitReg>
					{
						Success = false,
						Message = "Sorry, You have not registered for any unit this semester, Please register for units."
					};

				return new ReturnData<ProgUnitReg>
				{
					Success = term.Success,
					Message = "Unit registration found",
					Data = progUnitReg
				};
			}
			catch (Exception)
			{
				return new ReturnData<ProgUnitReg>
				{
					Success = false,
					Message = "Sorry, Server error",
				};
			}
		}

		public ReturnData<List<ProgUnitRegDetail>> GetCurrentUnitRegistrationDetails(string userCode, string classStatus)
		{
			try
			{
				var progUnitReg = GetCurrentUnitRegistration(userCode, classStatus);
				if (!progUnitReg.Success)
					return new ReturnData<List<ProgUnitRegDetail>>
					{
						Success = progUnitReg.Success,
						Message = progUnitReg.Message,
					};

				var unitRegDetail = _unitOfWork.ProgUnitRegDetail.GetWhere(r => r.Ref.ToLower().Equals(progUnitReg.Data.Id.ToString().ToString())).ToList();
				if (unitRegDetail.Count < 1)
					return new ReturnData<List<ProgUnitRegDetail>>
					{
						Success = !progUnitReg.Success,
						Message = "Sorry but we could not find your registered units, Kindly update."
					};

				return new ReturnData<List<ProgUnitRegDetail>>
				{
					Success = progUnitReg.Success,
					Message = "Unit registration found",
					Data = unitRegDetail
				};
			}
			catch (Exception)
			{
				return new ReturnData<List<ProgUnitRegDetail>>
				{
					Success = false,
					Message = "Sorry, Server error"
				};
			}
		}

		public ReturnData<List<FormattedSubjects>> GetSemisterSubjects(string userCode, string classStatus)
		{
			try
			{
				var unitRegDetails = GetCurrentUnitRegistrationDetails(userCode, classStatus);
				if (!unitRegDetails.Success)
					return new ReturnData<List<FormattedSubjects>>
					{
						Success = unitRegDetails.Success,
						Message = unitRegDetails.Message,
					};

				var registeredUnits = new List<string>();
				unitRegDetails.Data.ForEach(u => { registeredUnits.Add(u.UnitCode.ToUpper()); });

				var subjects = _unitOfWork.Subjects.GetWhere(s => registeredUnits.Contains(s.Code.ToUpper())).ToList();
				var units = new List<FormattedSubjects>();

				foreach (var subject in subjects)
				{
					units.Add(new FormattedSubjects
					{
						Code = subject.Code,
						Names = subject.Names,
						Department = subject.Department,
						CreditLevel = subject.CreditLevel,
						CreditUnits = subject.CreditUnits,
						Nhours = subject.Nhours,
						Common = subject.Common,
						Closed = subject.Closed,
						Thesis = subject.Thesis,
						Status = unitRegDetails.Data.FirstOrDefault(r => r.UnitCode == subject.Code)?.Status,
						Lecturers = GetUnitLecturer(subject.Code).Data,
					});
				}

				if (subjects.Count == 0)
					return new ReturnData<List<FormattedSubjects>>
					{
						Success = !unitRegDetails.Success,
						Message = "Sorry, Your have registered for units that are not for this semester, Please contact School Admin.",
						Data = units
					};

				return new ReturnData<List<FormattedSubjects>>
				{
					Success = unitRegDetails.Success,
					Message = "Subjects for this semester found",
					Data = units
				};
			}
			catch (Exception)
			{
				return new ReturnData<List<FormattedSubjects>>
				{
					Success = false,
					Message = "Sorry, Server error",
				};
			}
		}

		private ReturnData<List<string>> GetUnitLecturer(string unitCode)
		{
			var lecturers = _unitOfWork.Ttlecturer.GetAll().Join(
				_unitOfWork.TtlecturerUnits.GetWhere(u => u.Code.ToLower().Equals(unitCode.ToLower())),
				l => l.Id.ToString(),
				u => u.Ref,
				(l, u) => l.Dname
				).ToList();
			return new ReturnData<List<string>>
			{
				Success = true,
				Data = lecturers
			};
		}

		public ReturnData<List<YearTranscriptViewModel>> GetSelectedYearResults(TranscriptRequestViewModel transcriptModel,
			string classStatus, string institutionInitials, bool? isCampusApi = false, bool isCumulative = false)
		{
			institutionInitials = institutionInitials ?? "";
			try
			{
				var cumulativeMarks = new List<EndstandTranslated>();
				var selectedMarks = new List<EndstandTranslated>();
				var programme = GetProgramme(transcriptModel.Usercode, classStatus, isCampusApi);
				var yearlyTranscripts = new List<YearTranscriptViewModel>();
				var isTivet = _unitOfWork.SysSetup.GetFirstOrDefault()?.IsTVET;
				if ((bool)isTivet)
					return GetTvetResults(transcriptModel, classStatus, institutionInitials, true);
				else
				{
					var selectedTranslated = GetTranslateMarks(transcriptModel, classStatus, isCumulative);
					if (!selectedTranslated.Success)
						return new ReturnData<List<YearTranscriptViewModel>>
						{
							Success = false,
							Message = selectedTranslated.Message
						};

					selectedMarks = selectedTranslated.Data;
					selectedMarks.ForEach(m =>
					{
						var sup = _unitOfWork.Sup.GetWhere(s => s.AdmnNo.ToUpper().Equals(m.AdmnNo.ToUpper())
						&& s.Subject.ToUpper().Equals(m.UnitCode.ToUpper())).OrderByDescending(s => s.Rdate).FirstOrDefault();
						if (sup != null)
						{
							sup.ApprovalStatus = sup?.ApprovalStatus ?? "";
							var approved = _unitOfWork.GradeApproval.GetAny(a => a.Names.ToUpper().Equals(sup.ApprovalStatus.ToUpper()) && (bool)a.StudView);
							if (approved)
							{
								m.TotalMarks = sup?.Marks?.ToString() ?? "";
								decimal.TryParse(m.TotalMarks, out decimal total);
								m.Grade = GetGrade(total, transcriptModel.Usercode);
							}
						}
					});

					var yearSemisterMarks = selectedMarks.GroupBy(m => m.Semester).ToList();
					var unitWithMarks = new List<TranscriptUnitViewModel>();

					foreach (var semUnits in yearSemisterMarks)
					{
						foreach (var unit in semUnits)
						{
							var subject = _unitOfWork.Subjects.GetFirstOrDefault(s => s.Code.ToLower().Equals(unit.UnitCode.ToLower()));
							unitWithMarks.Add(new TranscriptUnitViewModel
							{
								UnitCode = unit.UnitCode,
								UnitName = subject?.Names,
								Grade = unit.Grade,
								CreditUnits = subject?.CreditUnits,
								Score = unit.TotalMarks,
								UnitHours = subject.Nhours,
								//Status = status
							});
						}

						yearlyTranscripts.Add(new YearTranscriptViewModel
						{
							Semister = semUnits.Key,
							Units = unitWithMarks
						});

						unitWithMarks = new List<TranscriptUnitViewModel>();
					}
				}

				return new ReturnData<List<YearTranscriptViewModel>>
				{
					Success = true,
					Data = yearlyTranscripts
				};
			}
			catch (Exception e)
			{
				return new ReturnData<List<YearTranscriptViewModel>>
				{
					Success = false,
					Message = "Sorry, Server error"
				};
			}
		}

		private ReturnData<List<EndstandTranslated>> GetTranslateMarks(TranscriptRequestViewModel transcriptModel, string classStatus, bool isCumulative = false)
		{
			try
			{
				var selectedYearSemisters = GetSelectedYearSemisters(transcriptModel, classStatus, isCumulative);
				if (!selectedYearSemisters.Success)
					return new ReturnData<List<EndstandTranslated>>
					{
						Success = selectedYearSemisters.Success,
						Message = selectedYearSemisters.Message
					};

				var semisterNames = selectedYearSemisters.Data.Select(t => t.Names).ToList();
				var translateMarks = new MarksTranslation(_unitOfWork).GetTranslated(transcriptModel.Usercode, semisterNames);
				if (!translateMarks.Success)
					return new ReturnData<List<EndstandTranslated>>
					{
						Success = translateMarks.Success,
						Message = translateMarks.Message
					};

				var translatedMarks = translateMarks.Data.ToList();

				// ---NOTE: --- To filter results for only registered units, uncomment this code----
				//var selectedYearRegisteredUnits = GetSelectedYearRegisteredUnits(transcriptModel, classStatus, isCumulative);
				//if (selectedYearRegisteredUnits?.Data != null)
				//{
				//	var listOfUnits = selectedYearRegisteredUnits.Data.Select(u => u.UnitCode.ToUpper()).ToList();
				//	translatedMarks = translateMarks.Data.Where(m => listOfUnits.Contains(m.UnitCode.ToUpper())).ToList();
				//}

				return new ReturnData<List<EndstandTranslated>>
				{
					Success = true,
					Data = translatedMarks
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<List<EndstandTranslated>>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		private ReturnData<List<YearTranscriptViewModel>> GetTvetResults(TranscriptRequestViewModel transcriptModel,
			string classStatus, string institutionInitials, bool isTivet = false)
		{
			try
			{
				var selectedYearSemisters = GetSelectedYearSemisters(transcriptModel, classStatus);
				if (!selectedYearSemisters.Success)
					return new ReturnData<List<YearTranscriptViewModel>>
					{
						Success = selectedYearSemisters.Success,
						Message = selectedYearSemisters.Message
					};

				var semisterNames = selectedYearSemisters.Data.Select(t => t.Names.ToUpper()).ToList();
				var studentResults = _unitOfWork.MarkSheet.GetStudentResults(transcriptModel, institutionInitials, _configuration);
				var yearlyResults = studentResults.Where(r => semisterNames.Contains(r.Term.ToUpper()))
					.GroupBy(r => r.Term).ToList();

				var transcript = new List<YearTranscriptViewModel>();
				foreach (var semResults in yearlyResults)
				{
					var semTranscript = new List<TranscriptUnitViewModel>();
					foreach (var results in semResults)
					{
						var exam = results.Exam ?? 0;
						var cat = results.Cat ?? 0;
						var total = exam + cat;
						if (total > 0)
							semTranscript.Add(new TranscriptUnitViewModel
							{
								UnitCode = results.Code,
								UnitName = results.Title,
								Exam = exam,
								Cat = cat,
								Total = total,
								Grade = GetGrade(total, transcriptModel.Usercode)
							});
					}

					transcript.Add(new YearTranscriptViewModel
					{
						Semister = semResults.Key,
						Units = semTranscript,
						isTivetTranscript = isTivet
					});
				}

				if (transcript.Count < 1)
					return new ReturnData<List<YearTranscriptViewModel>>
					{
						Success = false,
						Message = "Sorry, Results not found"
					};

				return new ReturnData<List<YearTranscriptViewModel>>
				{
					Success = true,
					Data = transcript
				};
			}
			catch (Exception e)
			{
				return new ReturnData<List<YearTranscriptViewModel>>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public string GetGrade(decimal total, string admnno)
		{
			var register = _unitOfWork.Register.GetFirstOrDefault(r => r.AdmnNo.ToUpper().Equals(admnno.ToUpper()));
			register.Programme = register?.Programme ?? "";
			var program = _unitOfWork.Programme.GetFirstOrDefault(p => p.Names.ToUpper().Equals(register.Programme.ToUpper()));
			program.GradeType = program?.GradeType ?? "";

			var range = GetRange(total, program.GradeType);
			var grades = _unitOfWork.Grading.GetFirstOrDefault(g => g.Range.ToLower().Equals(range.ToLower())
			&& g.GradeType.ToLower().Equals(program.GradeType.ToLower()))?.Points;
			return grades;
		}

		private string GetRange(decimal marks, string gradeType)
		{
			string connetionString = DbSetting.ConnectionString(_configuration, "Unisol");
			SqlConnection connection = new SqlConnection(connetionString);
			connection.Open();
			var rangeQuery = $"SELECT Range FROM Grading WHERE GradeType = '{gradeType}' AND CONVERT(decimal(9, 2), LEFT(Range, (CHARINDEX('-', Range)) - 1)) <= {marks} AND  CONVERT(decimal(9, 2), RIGHT(Range, (CHARINDEX('-', REVERSE(Range)) - 1))) >= {marks}";
			var sqlCommand = new SqlCommand(rangeQuery, connection);
			var reader = sqlCommand.ExecuteReader();

			var range = "";
			while (reader.Read())
			{
				range = reader[0].ToString();
			}

			sqlCommand.Dispose();
			connection.Close();
			return range;
		}

		public ReturnData<List<Term>> GetSelectedYearSemisters(TranscriptRequestViewModel transcriptModel, string classStatus, bool isCumulative = false)
		{
			try
			{
				var studClass = GetClass(transcriptModel.Usercode, classStatus);
				if (!studClass.Success)
					return new ReturnData<List<Term>>
					{
						Success = studClass.Success,
						Message = studClass.Message
					};

				var yearlyPlannerDetail = _unitOfWork.CsplannerDetail.GetWhere(d => d.Stage.ToLower().Equals(transcriptModel.AcademicYear.ToLower())
				&& d.Class.ToLower().Equals(studClass.Data.Id.ToLower())).ToList();
				if (!string.IsNullOrEmpty(transcriptModel.Semester))
					yearlyPlannerDetail = yearlyPlannerDetail.Where(d => d.Term.ToUpper().Equals(transcriptModel.Semester.ToUpper())).ToList();

				var lastSemOpeningDate = yearlyPlannerDetail.OrderByDescending(d => d.Odate).FirstOrDefault()?.Odate;
				if (isCumulative)
					yearlyPlannerDetail = _unitOfWork.CsplannerDetail.GetWhere(d => d.Class.ToLower().Equals(studClass.Data.Id.ToLower())
					&& !d.Milestone.ToUpper().Equals("HOLIDAY") && d.Odate <= lastSemOpeningDate).ToList();

				if (yearlyPlannerDetail.Count < 1)
					return new ReturnData<List<Term>>
					{
						Success = false,
						Message = "Sorry, We could not find any details for the selected year. Please contact School Admin"
					};

				var selectedYearPlannerDetailRefs = yearlyPlannerDetail.Select(d => d.Ref.ToUpper()).ToList();

				// Get the selected year terms
				var csPlanners = _unitOfWork.Csplanner.GetWhere(p => selectedYearPlannerDetailRefs.Contains(p.Id.ToString().ToUpper())).ToList();
				var selectedYearSemisters = csPlanners.Select(p => p.Term.ToUpper()).ToList();

				if (selectedYearSemisters.Count() < 1)
					return new ReturnData<List<Term>>
					{
						Success = false,
						Message = "Sorry, We could not find any details for the selected year. Please contact School Admin"
					};

				var selectedYearTerms = _unitOfWork.Term.GetWhere(t => selectedYearSemisters.Contains(t.Names.ToUpper())).ToList();
				if (selectedYearTerms.Count < 1)
					return new ReturnData<List<Term>>
					{
						Success = false,
						Message = "Sorry, We could not find any details for the selected year. Please contact School Admin"
					};

				return new ReturnData<List<Term>>
				{
					Success = true,
					Data = selectedYearTerms
				};
			}
			catch (Exception)
			{
				return new ReturnData<List<Term>>
				{
					Success = false,
					Message = "Sorry, Server error"
				};
			}
		}

		private ReturnData<List<RegisteredUnitsModel>> GetSelectedYearRegisteredUnits(TranscriptRequestViewModel transcriptModel,
			string classStatus, bool isCumulative = false)
		{
			try
			{
				var selectedYearSemisters = GetSelectedYearSemisters(transcriptModel, classStatus, isCumulative);
				if (!selectedYearSemisters.Success)
					return new ReturnData<List<RegisteredUnitsModel>>
					{
						Success = selectedYearSemisters.Success,
						Message = selectedYearSemisters.Message
					};

				var semisterNames = selectedYearSemisters.Data.Select(t => t.Names.ToUpper()).ToList();

				var unitRegistrationRefIds = _unitOfWork.ProgUnitReg.GetWhere(r => semisterNames.Contains(r.Term.ToUpper())
				&& r.AdmnNo.ToLower().Equals(transcriptModel.Usercode.ToLower())).Select(r => r.Id).ToList();

				if (unitRegistrationRefIds.Count() < 1)
					return new ReturnData<List<RegisteredUnitsModel>>
					{
						Success = false,
						Message = "Sorry, We could not find your registered unit for the selected year. Please contact School Admin"
					};

				var registeredUnits = _unitOfWork.ProgUnitRegDetail.GetAll().Join(_unitOfWork.Subjects.GetAll(),
					progUnitRegDetail => progUnitRegDetail.UnitCode,
						subject => subject.Code,
						(progUnitRegDetail, sub) =>
							new RegisteredUnitsModel
							{
								UnitCode = progUnitRegDetail.UnitCode,
								Ref = progUnitRegDetail.Ref,
								Status = progUnitRegDetail.Status,
								Names = sub.Names,
								CreditUnits = sub.CreditUnits,
								Nhours = sub.Nhours
							})
					.Where(u => unitRegistrationRefIds.Contains(Convert.ToInt32(u.Ref)))
					.ToList();

				if (!registeredUnits.Any())
					return new ReturnData<List<RegisteredUnitsModel>>
					{
						Success = false,
						Message = "Sorry, We could not find your registered units for the selected year, Please contact School Admin."
					};

				return new ReturnData<List<RegisteredUnitsModel>>
				{
					Success = true,
					Data = registeredUnits
				};
			}
			catch (Exception)
			{
				return new ReturnData<List<RegisteredUnitsModel>>
				{
					Success = false,
					Message = "Sorry, Server error"
				};
			}
		}

		public ReturnData<List<Accounts>> GetAccounts()
		{
			try
			{
				var account = _unitOfWork.Accounts.GetWhere(a => a.StudentRelated == true).OrderBy(a => a.Names).ToList();
				return new ReturnData<List<Accounts>>
				{
					Success = true,
					Message = "Acccount data found",
					Data = account
				};
			}
			catch (Exception)
			{
				return new ReturnData<List<Accounts>>
				{
					Success = false,
					Message = "Sorry, Server error"
				};
			}
		}

		public ReturnData<List<StudInvoice>> GetInvoice(string userCode)
		{
			try
			{
				var invoice = _unitOfWork.StudInvoice.GetWhere(i => i.AdmnNo.ToLower().Equals(userCode.ToLower())).ToList();
				if (invoice.Count < 1)
					return new ReturnData<List<StudInvoice>>
					{
						Success = false,
						Message = "Sorry, You have not yet been invoiced"
					};
				return new ReturnData<List<StudInvoice>>
				{
					Success = true,
					Data = invoice
				};
			}
			catch (Exception e)
			{
				return new ReturnData<List<StudInvoice>>
				{
					Success = false,
					Message = "Sorry, Server error"
				};
			}
		}

		public ReturnData<List<StudInvoiceAdj>> GetInvoiceAdj(string userCode)
		{
			try
			{
				var invoiceAdj = _unitOfWork.StudInvoiceAdj.GetStudInvoiceAdj(userCode).ToList();
				return new ReturnData<List<StudInvoiceAdj>>
				{
					Success = true,
					Message = "Invoice adjustment data found",
					Data = invoiceAdj
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<List<StudInvoiceAdj>>
				{
					Success = false,
					Message = "Sorry, Server error"
				};
			}
		}

		public ReturnData<List<ReceiptBookCanc>> GetReceiptBookCancellations()
		{
			try
			{
				var cancelledReceipts = _unitOfWork.ReceiptBookCanc.GetAll().ToList();

				return new ReturnData<List<ReceiptBookCanc>>
				{
					Success = true,
					Message = "Cancelled receipts found",
					Data = cancelledReceipts
				};
			}
			catch (Exception)
			{
				return new ReturnData<List<ReceiptBookCanc>>
				{
					Success = false,
					Message = "Sorry, Server error"
				};
			}
		}

		public ReturnData<List<ReceiptBook>> GetReceiptBook(string userCode)
		{
			try
			{
				var receiptBook = _unitOfWork.ReceiptBook.GetWhere(r => r.AdmnNo.ToLower().Equals(userCode.ToLower())).ToList();
				return new ReturnData<List<ReceiptBook>>
				{
					Success = true,
					Message = "Cancelled receipts found",
					Data = receiptBook
				};
			}
			catch (Exception)
			{
				return new ReturnData<List<ReceiptBook>>
				{
					Success = false,
					Message = "Sorry, Server error"
				};
			}
		}

		public ReturnData<List<StudSponsorBdcanc>> GetSponserCancellations()
		{
			try
			{
				var sponserCancellations = _unitOfWork.StudSponsorBdcanc.GetWhere(h => Convert.ToDateTime(h.Rdate).Date <= DateTime.Now.Date).ToList();
				return new ReturnData<List<StudSponsorBdcanc>>
				{
					Success = true,
					Message = "Sponser cancellation data found",
					Data = sponserCancellations
				};
			}
			catch (Exception)
			{
				return new ReturnData<List<StudSponsorBdcanc>>
				{
					Success = false,
					Message = "Sorry, Server error"
				};
			}
		}

		public ReturnData<List<Grading>> GetGradings(string userCode, string classStatus)
		{
			try
			{
				var programme = GetProgramme(userCode, classStatus);
				if (!programme.Success)
					return new ReturnData<List<Grading>>
					{
						Success = false,
						Message = programme.Message
					};

				var grading = _unitOfWork.Grading.GetWhere(g => g.GradeType.ToLower().Equals(programme.Data.GradeType.ToLower())).ToList();
				if (grading.Count < 1)
					return new ReturnData<List<Grading>>
					{
						Success = false,
						Message = "Oops,seems like no grading available"
					};

				return new ReturnData<List<Grading>>
				{
					Success = true,
					Data = grading
				};
			}
			catch (Exception)
			{
				return new ReturnData<List<Grading>>
				{
					Success = false,
					Message = "Sorry, Server error"
				};
			}
		}

		public ReturnData<List<MarkSymbols>> GetMarkSymbols()
		{
			try
			{
				var markSymbols = _unitOfWork.MarkSymbols.GetAll().ToList();
				if (markSymbols.Count() < 1)
					return new ReturnData<List<MarkSymbols>>
					{
						Success = false,
						Message = "Oops,seems like no mark symbol available"
					};

				return new ReturnData<List<MarkSymbols>>
				{
					Success = true,
					Data = markSymbols
				};
			}
			catch (Exception)
			{
				return new ReturnData<List<MarkSymbols>>
				{
					Success = false,
					Message = "Sorry, Server error"
				};
			}
		}

		public ReturnData<StudTranscriptsPortalResults> GetResultsRecommendation(string usercode, string year)
		{
			try
			{
				var resultRecommendation = _unitOfWork.StudTranscriptsPortalResults
					.GetFirstOrDefault(r => r.AdmnNo.ToLower().Equals(usercode.ToLower()) && r.YearOfStudy.Equals(year));
				if (resultRecommendation == null)
					return new ReturnData<StudTranscriptsPortalResults>
					{
						Success = false,
						Message = ""
					};

				return new ReturnData<StudTranscriptsPortalResults>
				{
					Success = true,
					Data = resultRecommendation
				};
			}
			catch (Exception)
			{
				return new ReturnData<StudTranscriptsPortalResults>
				{
					Success = false,
					Message = "Sorry, Server error"
				};
			}
		}

		public ReturnData<FeesPolicy> GetFeePolicy(string userCode, string names)
		{
			var register = GetRegister(userCode);
			if (!register.Success)
				return new ReturnData<FeesPolicy>
				{
					Success = register.Success,
					Message = register.Message
				};

			var sponser = register.Data.Sponsor ?? "";
			var feePolicy = _unitOfWork.FeesPolicy.GetAll().OrderByDescending(f => f.Sdate)
				.FirstOrDefault(f => (f.Edate > DateTime.UtcNow || f.Edate == null) && f.Names.ToUpper().Contains(names.ToUpper())
				&& f.Sponsor.ToUpper().Contains("UNSPECIFIED") || f.Sponsor.ToUpper().Contains(sponser.ToUpper()));

			if (feePolicy == null)
				feePolicy = _unitOfWork.FeesPolicy.GetAll().OrderByDescending(f => f.Sdate)
				.FirstOrDefault(f => (f.Edate > DateTime.UtcNow || f.Edate == null)
				&& f.Sponsor.ToUpper().Contains("UNSPECIFIED") || f.Sponsor.ToUpper().Contains(sponser.ToUpper()));

			return new ReturnData<FeesPolicy>
			{
				Success = true,
				Data = feePolicy ?? new FeesPolicy()
			};
		}

		public ReturnData<List<StudentStatementModelVirtual>> GetInvoicedAmount(string userCode, string finalStudentInvoiceCols)
		{
			var studentInvoice = _unitOfWork.StudentStatementModelVirtual.GetInvoicedAmount(userCode, finalStudentInvoiceCols).ToList();
			return new ReturnData<List<StudentStatementModelVirtual>>
			{
				Success = true,
				Data = studentInvoice
			};
		}

		public ReturnData<dynamic> GetAllProgrammes()
		{
			try
			{
				var isTvet = _unitOfWork.SysSetup.GetFirstOrDefault().IsTVET;
				if (isTvet.Value)
				{
					var res = _unitOfWork.Class.GetAll()
						.Join(_unitOfWork.ClassCourse.GetAll(), c => c.Id, cc => cc.Class, (c, cc) => new
						{
							cc.Subject,
							//cc.Term,
							c.Programme
						}).Join(_unitOfWork.Subjects.GetAll(), cs => cs.Subject, sb => sb.Code, (cs, sb) => new
						{
							sb.Code,
							sb.Names,
							//cs.Term,
							cs.Programme
						}).Join(_unitOfWork.Programme.GetAll(), cp => cp.Programme, p => p.Names, (cp, p) => new
						{
							programmeCode = p.Code,
							programmeName = p.Names,
							p.Department,
							Specialization = p.CertType,
							UnitCode = cp.Code,
							UnitName = cp.Names,
							Stage = "",
							//cp.Term
							Term = ""
						}).OrderBy(r => r.programmeCode)
						.Distinct()
						.ToList();
					return new ReturnData<dynamic>
					{
						Success = true,
						Data = res
					};
				}

				var units = _unitOfWork.Programme.GetAll()
					.Join(_unitOfWork.ProgCurriculum.GetAll(),
					p => p.Code,
					c => c.ProgCode,
					(p, c) => new { p.Code, p.Names, p.Department, c.Id, c.Specialization })
					.Join(_unitOfWork.ProgCurriculumDetail.GetAll(),
					pc => pc.Id.ToString(),
					d => d.Ref,
					(pc, d) => new { pc.Code, pc.Names, pc.Department, pc.Specialization, d.UnitCode, d.Stage, d.Term })
					.Join(_unitOfWork.Subjects.GetAll(),
					pd => pd.UnitCode,
					s => s.Code,
					(pd, s) => new
					{
						programmeCode = pd.Code,
						programmeName = pd.Names,
						pd.Department,
						pd.Specialization,
						pd.UnitCode,
						UnitName = s.Names,
						//pd.Stage,
						//pd.Term
						Stage = "",
						Term = ""
					}
					).Distinct().ToList();

				return new ReturnData<dynamic>
				{
					Success = true,
					Data = units
				};
			}
			catch (Exception)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
				};
			}
		}

		public ReturnData<dynamic> GetStudentUnitDetails(string userCode, string unitCode, string classStatus)
		{
			var programme = GetProgramme(userCode, classStatus);
			if (!programme.Success)
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = programme.Message
				};

			var stuClass = GetClass(userCode, classStatus);
			if (!stuClass.Success)
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = stuClass.Message
				};

			var register = GetRegister(userCode);
			if (!register.Success)
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = register.Message
				};

			var semister = GetCurrentTerm(userCode, classStatus);
			if (!semister.Success)
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = register.Message
				};

			var subject = GetSemisterSubjects(userCode, classStatus);
			if (!subject.Success)
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = subject.Message
				};

			var plannerDetails = GetSessionPlannerCurrentDetails(userCode, classStatus);
			if (!plannerDetails.Success)
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = plannerDetails.Message
				};

			var department = GetDepartment(userCode, classStatus);
			if (!department.Success)
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = department.Message
				};

			return new ReturnData<dynamic>
			{
				Success = true,
				Data = new
				{
					semister.Data.AcademicYear,
					Semester = semister.Data.Names,
					stuClass.Data.Campus,
					programme.Data.Department,
					stuClass.Data.Programme,
					UnitTitle = subject.Data.FirstOrDefault(s => s.Code == unitCode)?.Names,
					Schools = department.Data?.School,
					register.Data.Gender,
					YearOfStudy = plannerDetails.Data?.Stage,
					programme.Data.CertType,
				}
			};
		}

		public ReturnData<List<StudentCurriculumViewModel>> GetStudentCurriculum(string userCode, string classStatus)
		{
			try
			{
				var progCurriculumId = ReturnCurriculumProgRef(userCode, classStatus);
				if (progCurriculumId == null)
					return new ReturnData<List<StudentCurriculumViewModel>>
					{
						Success = false,
						Message = "Oops,We could not find your curriculum, please contact the admin"
					};

				var curriculumSubjects = _unitOfWork.ProgCurriculumDetail
					.GetWhere(p => p.Ref.Equals(progCurriculumId.ToString())).Select(p =>
					new CurriculumModel
					{
						GroupType = p.GroupType,
						UnitCode = p.UnitCode,
						Term = p.Term,
						Stage = p.Stage,
						Ref = p.Ref
					}).ToList();

				var studentCurriculumViewModel = GetCurriculum(curriculumSubjects, userCode, classStatus);
				return new ReturnData<List<StudentCurriculumViewModel>>
				{
					Success = studentCurriculumViewModel.Count > 0,
					Message = studentCurriculumViewModel.Count > 0 ? "" : "We could  not find your curriculum details",
					Data = studentCurriculumViewModel
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<List<StudentCurriculumViewModel>>
				{
					Success = false,
					Message = "Sorry, an error occurred"
				};
			}

		}

		public List<StudentCurriculumViewModel> GetCurriculum(List<CurriculumModel> curriculumSubjects, string userCode, string classStatus, string unitLevel = "")
		{
			var studentCurriculumViewModel = new List<StudentCurriculumViewModel>();
			try
			{
				var curriculumHYears = curriculumSubjects.GroupBy(d => d.Stage).Select(grp => grp.First()).ToList();
				var unitsStatus = _unitOfWork.ProgUnitRegDetail.GetAll()
					.Join(_unitOfWork.ProgUnitReg.GetAll(),
						progUnitRegDtl => progUnitRegDtl.Ref,
						progUnitReg => progUnitReg.Id.ToString(),
						(progUnitRegDtl, progUnitReg) => new
						{
							progUnitReg.Id,
							progUnitRegDtl.Status,
							progUnitRegDtl.UnitCode,
							progUnitReg.AdmnNo,
							progUnitReg.Term
						}
					).Where(c => c.AdmnNo.ToUpper().Equals(userCode.ToUpper())).ToList();

				var curriculumDoneStatus = new List<CurriculumModel>();
				curriculumSubjects.ForEach(c =>
				{
					var status = unitsStatus.FirstOrDefault(s => s.UnitCode.ToUpper().Equals(c.UnitCode.ToUpper()))?.Status ?? "";
					curriculumDoneStatus.Add(new CurriculumModel
					{
						Id = c.Id,
						GroupType = c.GroupType,
						UnitCode = c.UnitCode,
						Term = c.Term,
						Stage = c.Stage,
						Ref = c.Ref,
						AdmnNo = c.AdmnNo,
						Rdate = c.Rdate,
						Status = status
					});
				});

				var term = GetCurrentTerm(userCode, classStatus)?.Data?.Names ?? "";
				curriculumHYears.ForEach(e =>
				{
					var semesters = curriculumSubjects.Where(s => s.Stage == e.Stage)
					.GroupBy(d => d.Term).Select(grp => grp.First()).ToList();

					var sems = new List<Semester>();
					semesters.ForEach(s =>
					{
						var semisterUnits = curriculumDoneStatus.Where(u => u.Stage == e.Stage && u.Term == s.Term).ToList();
						var curriclulumUnits = new List<CurriculumUnits>();
						if (semisterUnits.Count > 0)
						{
							semisterUnits.ForEach(cu =>
							{
								cu.Status = cu.Status ?? "";
								var doneStatus = DoneStatus.Pending;
								if (string.IsNullOrEmpty(cu.Status))
									doneStatus = DoneStatus.NotRegistered;
								if (cu.Status.ToLower().Equals("approved"))
									doneStatus = DoneStatus.DonePreviously;
								if (cu.Status.ToLower().Equals("approved") && cu.Term.ToLower().Equals(term.ToLower()))
									doneStatus = DoneStatus.Approved;

								curriclulumUnits.Add(new CurriculumUnits
								{
									Type = cu.GroupType,
									UnitCode = cu.UnitCode,
									UnitName = _unitOfWork.Subjects.GetFirstOrDefault(sub => sub.Code == cu.UnitCode)?.Names,
									DoneStatus = doneStatus == DoneStatus.Approved || doneStatus == DoneStatus.Pending,
									Status = cu.Status,
									CreditUnits = 0.0,
									DonePreviously = (doneStatus == DoneStatus.DonePreviously),
									UnitRegLevel = unitLevel,
								});
							});
						}

						sems.Add(new Semester
						{
							SemesterName = s.Term,
							CurriculumUnits = curriclulumUnits
						});
					});

					studentCurriculumViewModel.Add(new StudentCurriculumViewModel
					{
						Stage = e.Stage,
						Semesters = sems
					});
				});

				return studentCurriculumViewModel;
			}
			catch (Exception ex)
			{
				return studentCurriculumViewModel;
			}
		}

		public ReturnData<List<StudentCurriculumViewModel>> GetStudentRegistereddUnits(string userCode, string classStatus)
		{
			try
			{
				var progCurRefId = ReturnCurriculumProgRef(userCode, classStatus);
				if (progCurRefId == null)
					return new ReturnData<List<StudentCurriculumViewModel>>
					{
						Success = false,
						Message = "Oops,seems there is a problem with unit settings"
					};

				var studentClass = GetEnrollment(userCode, classStatus);
				if (!studentClass.Success)
					return new ReturnData<List<StudentCurriculumViewModel>>
					{
						Success = false,
						Message = studentClass.Message
					};

				var curriculumSubjects = _unitOfWork.ProgUnitRegDetail.GetAll()
					.Join(_unitOfWork.ProgUnitReg.GetAll(),
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
							}).Join(_unitOfWork.ProgCurriculumDetail.GetAll(),
							units => units.UnitCode,
							currilum => currilum.UnitCode,
							(units, currilum) => new CurriculumModel
							{
								GroupType = currilum.GroupType,
								Term = currilum.Term,
								Stage = currilum.Stage,
								Ref = currilum.Ref,
								UnitCode = units.UnitCode,
								AdmnNo = units.AdmnNo,
								Status = units.Status,
								Rdate = units.Rdate,
								Class = units.Class
							}).Where(c => c.Class == studentClass.Data.Class && c.AdmnNo == userCode && c.Ref == progCurRefId.ToString()).ToList();

				if (!curriculumSubjects.Any())
					return new ReturnData<List<StudentCurriculumViewModel>>
					{
						Success = false,
						Message = "Oops,We couldnt find any curriculum on your profile"
					};

				var curriculumHYears = curriculumSubjects.GroupBy(d => d.Stage).Select(grp => grp.First()).ToList();
				var studentCurriculumViewModel = GetCurriculum(curriculumSubjects, userCode, classStatus);
				return new ReturnData<List<StudentCurriculumViewModel>>
				{
					Success = studentCurriculumViewModel.Count > 0,
					Message = studentCurriculumViewModel.Count > 0 ? "Enrolled Units" : "We could  not find your curriculum details",
					Data = studentCurriculumViewModel
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<List<StudentCurriculumViewModel>>
				{
					Success = false,
					Message = "Oops, seems an error has occured on our side.Please contact admin " +
							  ErrorMessangesHandler.ExceptionMessage(ex)
				};
			}
		}

		public int? ReturnCurriculumProgRef(string userCode, string classStatus)
		{
			var programme = GetProgramme(userCode, classStatus);
			if (!programme.Success)
				return null;

			var enrolment = GetEnrollment(userCode, classStatus);
			if (!enrolment.Success)
				return null;

			var studClass = GetClass(userCode, classStatus);
			if (!studClass.Success)
				return null;

			var progCurriculum = _unitOfWork.ProgCurriculum.GetWhere(c => c.ProgCode == programme.Data.Code && c.CurriculumCycle.Contains(studClass.Data.CurriculumCycle));
			var progCurriculumId = string.IsNullOrEmpty(enrolment.Data.Specialization) ? progCurriculum.FirstOrDefault()?.Id :
				progCurriculum.FirstOrDefault(c => c.Specialization.Contains(enrolment.Data.Specialization))?.Id;

			return progCurriculumId;
		}

		public DoneStatus ReturnDoneStatus(string userCode, string unitCode, string currentTerm = "")
		{
			var doneStatus = _unitOfWork.ProgUnitRegDetail.GetAll()
				.Join(_unitOfWork.ProgUnitReg.GetAll(),
					progUnitRegDtl => progUnitRegDtl.Ref,
					progUnitReg => progUnitReg.Id.ToString(),
					(progUnitRegDtl, progUnitReg) => new
					{
						progUnitReg.Id,
						progUnitRegDtl.Status,
						progUnitRegDtl.UnitCode,
						progUnitReg.AdmnNo,
						progUnitReg.Term
					}).OrderByDescending(u => u.Id).FirstOrDefault(don => don.UnitCode == unitCode && don.AdmnNo == userCode);

			if (doneStatus == null)
				return DoneStatus.NotRegistered;

			if (doneStatus.Status.ToLower().Equals("approved"))
				return DoneStatus.DonePreviously;

			if (doneStatus.Term.ToLower().Equals(currentTerm.ToLower()) && doneStatus.Status.ToLower().Equals("approved"))
				return DoneStatus.Approved;

			return DoneStatus.Pending;
		}

		public ReturnData<List<Register>> GetActiveStudents()
		{
			try
			{
				var students = _unitOfWork.Register.GetWhere(r => !(bool)r.Closed && !string.IsNullOrEmpty(r.Email))
					.Select(r => new Register
					{
						Names = r?.Names ?? "",
						AdmnNo = r?.AdmnNo ?? "",
						Email = r?.Email ?? "",
						Nationality = r?.Nationality ?? "",
						NationalId = r?.NationalId ?? "",
						Telno = r?.Telno ?? "",
						Homeaddress = r?.Homeaddress ?? ""
					}).ToList();

				return new ReturnData<List<Register>>
				{
					Success = true,
					Data = students
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<List<Register>>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<List<string>> RegisteredUnitCodes(string userCode, string classStatus)
		{
			try
			{
				var enrollment = GetEnrollment(userCode, classStatus);
				if (!enrollment.Success)
				{
					return new ReturnData<List<string>>
					{
						Success = false,
						Message = $"Failed to get enrollment :- {enrollment.Message}"
					};
				}
				var _class = enrollment.Data.Class;
				var code = _unitOfWork.Class.GetWhere(c => c.Id.Equals(_class))
					.Join(_unitOfWork.Programme.GetAll(), c => c.Programme, p => p.Names, (c, p)
					=> p.Code).FirstOrDefault();
				var term = GetCurrentTerm(userCode, classStatus);
				if (!term.Success)
				{
					return new ReturnData<List<string>>
					{
						Success = false,
						Message = $"Failed to get term :- {term.Message}"
					};
				}
				var _term = term.Data.Names;
				var isTvet = _unitOfWork.SysSetup.GetFirstOrDefault().IsTVET;
				if (isTvet.Value)
				{
					var subjectCodes = _unitOfWork.ClassCourse
						.GetWhere(c => c.Class.Equals(_class) && c.Term.Equals(_term))
						.Select(c => c.Subject).ToList();

					var resSub = new ReturnData<List<string>>
					{
						Success = true,
						Message = subjectCodes.Any() ? $"Found" : $"No unit code found : {_class} - {_term}",
						Data = subjectCodes
					};
					subjectCodes.Add(code);
					return resSub;
				}

				var unitCodes = _unitOfWork.ProgUnitReg
					.GetWhere(p => p.AdmnNo.Equals(userCode) && p.Class.Equals(_class) && p.Term.Equals(_term))
					.Join(_unitOfWork.ProgUnitRegDetail.GetWhere(d => d.Status.Equals("Approved")), r => r.Id.ToString(), rd => rd.Ref, (r, rd)
					=> rd.UnitCode).ToList();
				var resUnit = new ReturnData<List<string>>
				{
					Success = true,
					Message = unitCodes.Any() ? $"Found" : $"No unit code found : {_class} - {_term}",
					Data = unitCodes
				};
				resUnit.Data.Add(code);
				return resUnit;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return new ReturnData<List<string>>
				{
					Success = false,
					Message = "Error occured. Try later"
				};
			}
		}

		public ReturnData<UserViewModel> ValidateUser(string userCode)
		{
			try
			{
				if (_unitOfWork.HrpEmployee.GetAny(u => u.EmpNo.Contains(userCode)))
				{
					var employee = _unitOfWork.HrpEmployee.GetFirstOrDefault(e => e.EmpNo.Equals(userCode));
					if (employee == null)
					{
						return new ReturnData<UserViewModel>
						{
							Success = false,
							Message = "User not Found"
						};
					}
					return new ReturnData<UserViewModel>
					{
						Success = true,
						Message = "Employee Found",
						Data = new UserViewModel(employee)
					};
				}

				var student = _unitOfWork.Register.GetFirstOrDefault(e => e.AdmnNo.Equals(userCode));
				if (student == null)
				{
					return new ReturnData<UserViewModel>
					{
						Success = false,
						Message = "User not Found"
					};
				}
				return new ReturnData<UserViewModel>
				{
					Success = true,
					Message = "Student Found",
					Data = new UserViewModel(student)
				};
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return new ReturnData<UserViewModel>
				{
					Success = false,
					Message = "User not Found. Error occurred"
				};
			}
		}

		public ReturnData<FeesPolicy> GetFeeActivePolicy(string userCode)
		{
			var register = GetRegister(userCode);
			if (!register.Success)
				return new ReturnData<FeesPolicy>
				{
					Success = register.Success,
					Message = register.Message
				};

			if (register.Data.Closed.Value)
			{
				return new ReturnData<FeesPolicy>
				{
					Success = false,
					Message = "Student account is Closed"
				};
			}

			var studentEnrollment = _unitOfWork.StudEnrolment
				.GetWhere(e => e.AdmnNo.ToUpper().Equals(userCode.ToUpper())
				&& (e.Edate > DateTime.UtcNow || e.Edate == null)
				&& e.Status.Equals("Active"))
				.OrderByDescending(e => e.Id).FirstOrDefault();

			if (studentEnrollment == null)
			{
				return new ReturnData<FeesPolicy>
				{
					Success = false,
					Message = "Student has no active profile"
				};
			}
			var sponser = register.Data.Sponsor ?? "";
			var feePolicy = _unitOfWork.FeesPolicy.GetAll().OrderByDescending(f => f.Sdate)
				.FirstOrDefault(f => (f.Edate > DateTime.UtcNow || f.Edate == null)
				&& f.Sponsor.ToUpper().Contains("UNSPECIFIED") || f.Sponsor.ToUpper().Contains(sponser.ToUpper()));

			return new ReturnData<FeesPolicy>
			{
				Success = true,
				Data = feePolicy ?? new FeesPolicy()
			};
		}

		public ReturnData<dynamic> GetAcademicProfile(string userCode, string classStatus)
		{
			try
			{
				var enrolment = GetEnrollment(userCode, classStatus);
				if (!enrolment.Success)
					return new ReturnData<dynamic>
					{
						Success = false,
						Message = enrolment.Message
					};

				var studEnrolment = enrolment.Data;
				var school = _unitOfWork.StudSchools.GetFirstOrDefault(s => s.AdmnNo.ToUpper().Equals(userCode.ToUpper()));
				var studSchools = new
				{
					studEnrolment,
					school
				};

				return new ReturnData<dynamic>
				{
					Success = true,
					Data = studSchools
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<List<UserViewModel>> GetActiveStudentsWithEmails(int page, int perPage)
		{
			try
			{
				var skip = (page - 1) * perPage;
				var students = _unitOfWork.Register
					.GetWhere(r => !(bool)r.Closed && r.Email.Contains("@"))
					.Select(r => new UserViewModel(r))
					.Skip(skip)
					.Take(perPage)
					.ToList();
				return new ReturnData<List<UserViewModel>>
				{
					Success = true,
					Data = students,
					Message = "Found"
				};
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error getting students : {ex}");
				return new ReturnData<List<UserViewModel>>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<List<UserViewModel>> GetActiveStaffWithEmails(int page, int perPage)
		{
			try
			{
				var skip = (page - 1) * perPage;
				var staffs = _unitOfWork.HrpEmployee
					.GetWhere(r => !(bool)r.Terminated && r.Wemail.Contains("@"))
					.Select(r => new UserViewModel(r))
					.Skip(skip)
					.Take(perPage)
					.ToList();
				return new ReturnData<List<UserViewModel>>
				{
					Success = true,
					Data = staffs,
					Message = "Found"
				};
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error getting staffs : {ex}");
				return new ReturnData<List<UserViewModel>>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<int> StudentCount()
		{
			try
			{
				var students = _unitOfWork.Register
				.GetWhere(r => !(bool)r.Closed && r.Email.Contains("@"))
				.Count();
				return new ReturnData<int>
				{
					Success = true,
					Data = students,
					Message = "Found"
				};
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error getting students count : {ex}");
				return new ReturnData<int>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<int> StaffCount()
		{
			try
			{
				var staffs = _unitOfWork.HrpEmployee
					.GetWhere(r => !(bool)r.Terminated && r.Wemail.Contains("@"))
					.Count();
				return new ReturnData<int>
				{
					Success = true,
					Data = staffs,
					Message = "Found"
				};
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error getting staffs count : {ex}");
				return new ReturnData<int>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}
	}
}
