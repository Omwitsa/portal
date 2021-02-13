using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Api.IServices;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Common.ViewModels.Finance;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.StudentUtilities
{
	public class StudentCredential
	{
		private readonly UnisolAPIdbContext _context;
		private IStudentServices _studentServices;
		private ISystemServices _systemServices;
		public StudentCredential(UnisolAPIdbContext context, IStudentServices studentServices, ISystemServices systemServices)
		{
			_context = context;
			_studentServices = studentServices;
			_systemServices = systemServices;
		}
		public ReturnData<string> ReturnFeesPolicyCompliance(string userCode, string classStatus, string names)
		{
			//if (!CheckIfInvoiced(userCode, classStatus))
			//	return new ReturnData<bool>
			//	{
			//		Success = false,
			//		Message = "Sorry, Fee processing is still in progress. Kindly, contact the Administrator"
			//	};

			return CheckFeePolicy(userCode, classStatus, names);
		}

		private ReturnData<string> CheckFeePolicy(string userCode, string classStatus, string names)
		{
			var feePolicy = _studentServices.GetFeePolicy(userCode, names);
			var policy = feePolicy.Data?.Paid?.ToString() ?? ".";
			var policyFormat = policy.Split(".");
			if (!feePolicy.Success)
				return new ReturnData<string>
				{
					Success = feePolicy.Success,
					Data = policyFormat[0]
				};

			var totalCreditDebit = GetTotalCreditDebit(userCode, classStatus);
			var arrears = Convert.ToDecimal(totalCreditDebit.Debit.Substring(4)) - Convert.ToDecimal(totalCreditDebit.Credit.Substring(4));
			if (arrears < 1)
				return new ReturnData<string>
				{
					Success = true,
					Data = policyFormat[0]
				};

			var unitRegistrationOnFullFee = _systemServices.GetSystemSetup().Data?.RegUnitOnFullFee ?? false;
			if (names.ToLower().Contains("unit") && !(bool)unitRegistrationOnFullFee)
				return new ReturnData<string>
				{
					Success = true,
					Data = policyFormat[0]
				};


			var totalInvoicedThisSem = GetTotalInvoicedThisSem(userCode, classStatus);
			if (!totalInvoicedThisSem.Success)
				return new ReturnData<string>
				{
					Success = false,
					Data = policyFormat[0]
				};

			var minRequiredForCurrSem = (totalInvoicedThisSem.Data * feePolicy.Data.Paid) / 100;
			var paidThisSem = totalInvoicedThisSem.Data - arrears;
			if (minRequiredForCurrSem > paidThisSem)
				return new ReturnData<string>
				{
					Success = false,
					Data = policyFormat[0]
				};

			return new ReturnData<string>
			{
				Success = true,
				Data = policyFormat[0]
			};
		}


		public ReturnData<string> MeetsPolicy(string userCode, string classStatus = "Active")
		{
			var policyRes = _studentServices.GetFeeActivePolicy(userCode);
			if (!policyRes.Success)
			{
				return new ReturnData<string>
				{
					Success = false,
					Message = policyRes.Message
				};
			}

			var policy = policyRes.Data;
			var totalCreditDebit = GetTotalCreditDebit(userCode, classStatus);
			var arrears = Convert.ToDecimal(totalCreditDebit.Debit.Substring(4)) - Convert.ToDecimal(totalCreditDebit.Credit.Substring(4));
			var unitRegistrationOnFullFee = _systemServices.GetSystemSetup().Data?.RegUnitOnFullFee;
			if (arrears < 1 || !(bool)unitRegistrationOnFullFee)
				return new ReturnData<string> { Success = true, Message = "Meets policy" };

			var totalInvoicedThisSem = GetTotalInvoicedThisSem(userCode, classStatus);
			if (!totalInvoicedThisSem.Success)
				return new ReturnData<string> { Success = false, Message = $"Does not Meet {policy.Names} policy - {totalInvoicedThisSem.Message}" };

			var minRequiredForCurrSem = (totalInvoicedThisSem.Data * policyRes.Data.Paid) / 100;
			var paidThisSem = totalInvoicedThisSem.Data - arrears;
			if (minRequiredForCurrSem > paidThisSem)
			{
				return new ReturnData<string> { Success = false, Message = $"Does not Meet {policy.Names} policy " };
			}
			return new ReturnData<string> { Success = true, Message = "Meets policy" };
		}

		private ReturnData<decimal> GetTotalInvoicedThisSem(string userCode, string classStatus)
		{
			var studentAccounts = _studentServices.GetAccounts();
			if (!studentAccounts.Success)
				return new ReturnData<decimal>
				{
					Success = studentAccounts.Success,
					Message = studentAccounts.Message
				};

			var currentTerm = _studentServices.GetCurrentTerm(userCode, classStatus).Data?.Names;
			var studentInvoiceCols = GetStudentInvoiceCols(studentAccounts.Data);
			var studentInvoice = _studentServices.GetInvoicedAmount(userCode, studentInvoiceCols);
			if (!studentInvoice.Success)
				return new ReturnData<decimal>
				{
					Success = studentInvoice.Success,
					Message = studentInvoice.Message
				};
			if (studentInvoice.Data.Count > 0)
				studentInvoice.Data = studentInvoice.Data.Where(i => i.Term.ToUpper().Equals(currentTerm.ToUpper())).ToList();

			var invoicedAmount = 0m;
			foreach (var amount in studentInvoice.Data)
			{
				invoicedAmount = (decimal)(invoicedAmount + amount.Debit);
			}

			var invoiceAdj = _studentServices.GetInvoiceAdj(userCode);
			var currentSemInvoiceAdjs = new List<StudInvoiceAdj>();
			if (invoiceAdj.Data.Count > 1)
				currentSemInvoiceAdjs = invoiceAdj.Data.Where(i => i.Term.ToUpper().Equals(currentTerm.ToUpper())).ToList();

			var totalAdjAmount = 0m;
			foreach (var currentSemInvoiceAdj in currentSemInvoiceAdjs)
			{
				currentSemInvoiceAdj.Amount = currentSemInvoiceAdj.Amount ?? 0m;
				totalAdjAmount = Convert.ToDecimal(totalAdjAmount + currentSemInvoiceAdj.Amount);
			}

			return new ReturnData<decimal>
			{
				Success = true,
				Data = invoicedAmount + totalAdjAmount
			};
		}

		private bool CheckIfInvoiced(string userCode, string classStatus)
		{
			var currentTerm = _studentServices.GetCurrentTerm(userCode, classStatus).Data?.Names;
			var invoice = _studentServices.GetInvoice(userCode);
			var currentSemInvoice = new List<StudInvoice>();
			if (invoice.Data.Count > 1)
				currentSemInvoice = invoice.Data.Where(i => i.Term == currentTerm).ToList();

			var invoiceAdj = _studentServices.GetInvoiceAdj(userCode);
			var currentSemInvoiceAdj = new List<StudInvoiceAdj>();
			if (invoiceAdj.Data.Count > 1)
				currentSemInvoiceAdj = invoiceAdj.Data.Where(i => i.Term == currentTerm).ToList();

			if (currentSemInvoice.Count < 1 && currentSemInvoiceAdj.Count < 1)
				return false;

			return true;
		}

		//private GetTotalFeeRequired()
		public ReturnData<Register> GetStudentDetails(string userCode, string classStatus, bool? isCampusApi = false)
		{
			var validStudentRegister = _studentServices.GetRegister(userCode, isCampusApi);
			if (validStudentRegister.Data == null)
				return new ReturnData<Register>
				{
					Success = validStudentRegister.Success,
					Message = validStudentRegister.Message,
				};
			validStudentRegister.Data.Names = validStudentRegister.Data.Names.Replace("’", "");
			var validStudentEnrollmentStatus = _studentServices.GetEnrollment(userCode, classStatus, isCampusApi);
			if (!validStudentEnrollmentStatus.Success)
				return new ReturnData<Register>
				{
					Success = validStudentEnrollmentStatus.Success,
					Message = validStudentEnrollmentStatus.Message,
				};

			return validStudentRegister;
		}
		public ReturnData<OnlineReporting> ValidateSessionReporting(string userCode, string classStatus)
		{
			var currentTerm = _studentServices.GetCurrentTerm(userCode, classStatus);
			if (!currentTerm.Success)
				return new ReturnData<OnlineReporting>
				{
					Success = currentTerm.Success,
					Message = currentTerm.Message,
				};

			var plannerDetails = _studentServices.GetSessionPlannerCurrentDetails(userCode, classStatus);
			if (!plannerDetails.Success)
				return new ReturnData<OnlineReporting>
				{
					Success = plannerDetails.Success,
					Message = plannerDetails.Message,
				};

			var erpReporting = _studentServices.CheckErpReporting(userCode, classStatus);
			if (erpReporting.Success)
				return new ReturnData<OnlineReporting>
				{
					Success = erpReporting.Success,
					Message = erpReporting.Message,
				};

			var onlineReporting = _studentServices.CheckOnlineReporting(userCode, classStatus);
			if (onlineReporting.Success)
				return new ReturnData<OnlineReporting>
				{
					Success = onlineReporting.Success,
					Message = onlineReporting.Message,
					Data = onlineReporting.Data
				};

			var sysSetup = _systemServices.GetSystemSetup();
			if (!sysSetup.Success)
				return new ReturnData<OnlineReporting>
				{
					Success = sysSetup.Success,
					Message = sysSetup.Message,
				};

			if (sysSetup.Data.ReportingDeadline.Date < DateTime.Now.Date)
				return new ReturnData<OnlineReporting>
				{
					Success = sysSetup.Success,
					Message = "Sorry, Your reporting deadline has expired, Please contact School Admin. ",
				};

			return onlineReporting;
		}
		public ReturnData<List<YearWithSemesterViewModel>> GetYearsStudentHasBeenToSchool(string userCode, string classStatus, bool isCampusApi = false)
		{
			var csPlannerDetails = _studentServices.GetSessionPlannerDetails(userCode, classStatus);
			if (!csPlannerDetails.Success)
				return new ReturnData<List<YearWithSemesterViewModel>>
				{
					Success = csPlannerDetails.Success,
					Message = csPlannerDetails.Message,
				};

			var academicYears = csPlannerDetails.Data
					.Where(p => p.Stage != "HOLIDAY")
					.GroupBy(d => d.Stage)
					.Select(grp => grp.First())
					.ToList();

			var classWithSemesters = new List<YearWithSemesterViewModel>();

			var programme = _studentServices.GetProgramme(userCode, classStatus, isCampusApi);
			var isTivet = programme.Data.GradeType.ToUpper().Equals("TIVET");
			var institutionInitial = _systemServices.GetSystemSetup().Data?.SubTitle ?? "";

			var previousSemisterResponse = _studentServices.GetPreviousTerm(userCode, classStatus);
			var previousSemister = previousSemisterResponse.Data?.Names ?? "";

			academicYears.ForEach(y =>
			{
				var semesters = new List<StudentSemesterYear>();
				csPlannerDetails.Data.ForEach(s =>
				{
					if (s.Stage == y.Stage)
					{
						if (!string.IsNullOrEmpty(s.Term))
						{
							semesters.Add(new StudentSemesterYear
							{
								Id = s.Ref,
								YearOfStudy = s.Stage,
								Ref = s.Ref,
								Semester = s.Term
							});
						}
					}
				});

				classWithSemesters.Add(
					new YearWithSemesterViewModel
					{
						Academicyear = y.Stage,
						Semesters = semesters,
						isTivetTranscript = isTivet,
						Institution = institutionInitial,
						PreviousSemister = previousSemister
					}
				);
			});

			return new ReturnData<List<YearWithSemesterViewModel>>
			{
				Success = true,
				Data = classWithSemesters
			};
		}
		public ReturnData<StudentProgramme> FormatStudentProgramme(string userCode, string classStatus)
		{
			var studentProgramme = _studentServices.GetProgramme(userCode, classStatus);
			if (!studentProgramme.Success)
				return new ReturnData<StudentProgramme>
				{
					Success = studentProgramme.Success,
					Message = studentProgramme.Message
				};

			var programme = new StudentProgramme
			{
				Id = studentProgramme.Data.Id.ToString(),
				Programme = studentProgramme.Data.Names,
				ProgCode = studentProgramme.Data.Code,
				Type = studentProgramme.Data.GradeType
			};

			return new ReturnData<StudentProgramme>
			{
				Success = studentProgramme.Success,
				Message = studentProgramme.Message,
				Data = programme
			};
		}

		public ReturnData<dynamic> GetUnits(string userCode, string classStatus, string unitLevel)
		{
			try
			{
				var sysSettings = _context.SysSetup.FirstOrDefault();
				if (sysSettings == null)
					return new ReturnData<dynamic>
					{
						Success = false,
						Message = "Something went wrong, Please try again after sometime"
					};

				var unitRegDeadline = sysSettings.UnitRegDeadLine > DateTime.Now;
				var reportingResponse = ValidateSessionReporting(userCode, classStatus);
				var status = reportingResponse.Data == null ? "" : reportingResponse.Data.Status;
				if (status.ToLower().Equals("pending"))
					reportingResponse.Success = false;

				var semReportAndDeadline = new
				{
					UnitRegistrationDeadline = unitRegDeadline,
					ReportedCurrentSem = reportingResponse.Success
				};

				var sessionCurriculum = GetSesscionCurriculum(userCode, classStatus, unitLevel);
				if (!sessionCurriculum.Success)
					return new ReturnData<dynamic>
					{
						Success = sessionCurriculum.Success,
						Message = sessionCurriculum.Message,
						Data = sessionCurriculum.Data
					};

				var curriculumSubjects = sessionCurriculum.Data;
				if (true)
				{
					var yearlyCurriculum = curriculumSubjects.GroupBy(c => c.Stage).ToList();
					var termResponse = _studentServices.GetCurrentTerm(userCode, classStatus);
					var studentCurriculumViewModelWithStatus = new StudentCurriculumViewModelWithStatus();
					var studentCurriculumViewModel = _studentServices.GetCurriculum(curriculumSubjects, userCode, classStatus, unitLevel);

					studentCurriculumViewModelWithStatus.StudentCurriculumViewModel = studentCurriculumViewModel;
					studentCurriculumViewModelWithStatus.UnitRegistrationDeadline = unitRegDeadline;
					studentCurriculumViewModelWithStatus.ReportedCurrentSem = reportingResponse.Success;
					return new ReturnData<dynamic>
					{
						Success = true,
						Message = studentCurriculumViewModelWithStatus.StudentCurriculumViewModel.Count > 0 ? "" : "We could  not find your curriculum details",
						Data = studentCurriculumViewModelWithStatus
					};
				}
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Oops,an error occured,please contact admin " + ErrorMessangesHandler.ExceptionMessage(ex)
				};
			}
		}

		public ReturnData<List<CurriculumModel>> GetSesscionCurriculum(string userCode, string classStatus, string unitLevel)
		{
			var progCurriculumId = _studentServices.ReturnCurriculumProgRef(userCode, classStatus);
			var curriculumId = progCurriculumId == null ? "" : progCurriculumId.ToString();
			var curriculumSubjects = _context.ProgCurriculumDetail
						.Where(p => p.Ref == curriculumId)
						.Select(p => new CurriculumModel
						{
							Id = p.Id,
							GroupType = p.GroupType,
							UnitCode = p.UnitCode,
							Term = p.Term,
							Stage = p.Stage,
							Ref = p.Ref
						}).OrderBy(p => p.Id).ToList();

			var csPlannerDetailsResponse = _studentServices.GetSessionPlannerCurrentDetails(userCode, classStatus);
			if (!csPlannerDetailsResponse.Success)
				return new ReturnData<List<CurriculumModel>>
				{
					Success = false,
					Message = csPlannerDetailsResponse.Message
				};

			if (unitLevel.Equals("Yearly Units"))
				curriculumSubjects = curriculumSubjects.Where(p => p.Stage.ToUpper().Equals(csPlannerDetailsResponse.Data.Stage.ToUpper())).ToList();
			if (unitLevel.Equals("Session Units"))
				curriculumSubjects = curriculumSubjects.Where(p => p.Stage.ToUpper().Equals(csPlannerDetailsResponse.Data.Stage.ToUpper()) 
				&& p.Term.ToUpper().Equals(csPlannerDetailsResponse.Data.Term.ToUpper())).ToList();

			return new ReturnData<List<CurriculumModel>>
			{
				Success = true,
				Data = curriculumSubjects
			};
		}

		public ReturnData<StudentClass> FormatStudentClass(string userCode, string classStatus, bool isPreviousTermCard = false)
		{
			var studentClass = _studentServices.GetClass(userCode, classStatus);
			if (!studentClass.Success)
				return new ReturnData<StudentClass>
				{
					Success = studentClass.Success,
					Message = studentClass.Message
				};
			var plannerDetails = _studentServices.GetSessionPlannerCurrentDetails(userCode, classStatus, isPreviousTermCard);
			var studClass = new StudentClass
			{
				Id = studentClass.Data.Id,
				ClassName = studentClass.Data.Id,
				Campus = studentClass.Data.Campus,
				YearOfStudy = plannerDetails?.Data?.Stage ?? "",
				AdmissionYear = studentClass.Data.Starts.GetValueOrDefault().Year
			};

			return new ReturnData<StudentClass>
			{
				Success = studentClass.Success,
				Message = studentClass.Message,
				Data = studClass
			};
		}
		public ReturnData<StudentSemesterYear> GetStudentSemesterYear(string userCode, string classStatus, bool isPreviousTermCard = false)
		{
			var currentTerm = _studentServices.GetCurrentTerm(userCode, classStatus);
			if (isPreviousTermCard)
				currentTerm = _studentServices.GetPreviousTerm(userCode, classStatus);
			if (!currentTerm.Success)
				return new ReturnData<StudentSemesterYear>
				{
					Success = currentTerm.Success,
					Message = currentTerm.Message
				};

			var stuRegister = _studentServices.GetRegister(userCode);
			if (!stuRegister.Success)
				return new ReturnData<StudentSemesterYear>
				{
					Success = stuRegister.Success,
					Message = stuRegister.Message
				};

			var plannerdetails = _studentServices.GetSessionPlannerCurrentDetails(userCode, classStatus, isPreviousTermCard);
			if (!plannerdetails.Success)
				return new ReturnData<StudentSemesterYear>
				{
					Success = plannerdetails.Success,
					Message = plannerdetails.Message
				};

			var studentSemesterYear = new StudentSemesterYear
			{
				Id = "",
				SemesterId = currentTerm.Data?.Id.ToString() ?? "",
				RegisterId = stuRegister.Data?.Id.ToString() ?? "",
				Semester = plannerdetails.Data?.Term ?? "",
				YearOfStudy = plannerdetails.Data?.Stage ?? ""
			};

			return new ReturnData<StudentSemesterYear>
			{
				Success = plannerdetails.Success,
				Message = plannerdetails.Message,
				Data = studentSemesterYear
			};
		}
		public ReturnData<StudentDeparment> FormatStudentDeparment(string userCode, string classStatus)
		{
			var studentDepartment = _studentServices.GetDepartment(userCode, classStatus);
			if (!studentDepartment.Success)
				return new ReturnData<StudentDeparment>
				{
					Success = studentDepartment.Success,
					Message = studentDepartment.Message
				};

			var department = new StudentDeparment
			{
				Id = studentDepartment.Data.Id.ToString(),
				Department = studentDepartment.Data.Names,
				School = studentDepartment.Data.School
			};

			return new ReturnData<StudentDeparment>
			{
				Success = studentDepartment.Success,
				Message = studentDepartment.Message,
				Data = department
			};
		}

		public ReturnData<dynamic> GetFeesStatement(string userCode, string classStatus)
		{
			var statement = GenerateFeesStatement(userCode, classStatus);

			if (!statement.Data.Any())
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = statement.Message,
					Data = statement.Data
				};

			var totalDebitCreditViewModel = new TotalDebitCreditViewModel
			{
				Debit = string.Format("KES {0:N2}", 0),
				Credit = string.Format("KES {0:N2}", 0)
			};

			var feeStatement = new List<dynamic>();
			foreach (var studStatement in statement.Data)
			{
				var debit = Convert.ToDecimal(totalDebitCreditViewModel.Debit.Substring(4)) + studStatement.Debit;
				var credit = Convert.ToDecimal(totalDebitCreditViewModel.Credit.Substring(4)) + studStatement.Credit;
				totalDebitCreditViewModel.Debit = string.Format("KES {0:N2}", debit);
				totalDebitCreditViewModel.Credit = string.Format("KES {0:N2}", credit);
				studStatement.Balance = debit - credit;

				feeStatement.Add(new
				{
					studStatement.AdmnNo,
					studStatement.Term,
					Rdate = String.Format("{0:dd/MM/yyyy}", studStatement.Rdate),
					studStatement.Type,
					studStatement.Ref,
					studStatement.Description,
					Debit = string.Format("KES {0:N2}", studStatement.Debit),
					Credit = string.Format("KES {0:N2}", studStatement.Credit),
					Balance = string.Format("KES {0:N2}", studStatement.Balance),
					studStatement.Notes
				});
			}

			return new ReturnData<dynamic>
			{
				Success = true,
				Message = "",
				Data = new { statement = feeStatement, totals = totalDebitCreditViewModel }
			};
		}

		public string GetFeesBalance(string userCode, string classStatus)
		{
			var totalCreditDebit = GetTotalCreditDebit(userCode, classStatus);
			var balance = Convert.ToDecimal(totalCreditDebit.Debit.Substring(4)) - Convert.ToDecimal(totalCreditDebit.Credit.Substring(4));
			return string.Format("KES {0:N2}", balance);
		}

		private TotalDebitCreditViewModel GetTotalCreditDebit(string userCode, string classStatus)
		{
			var totalDebitCreditViewModel = new TotalDebitCreditViewModel
			{
				Debit = string.Format("KES {0:N2}", 0),
				Credit = string.Format("KES {0:N2}", 0)
			};

			var studentStatements = GenerateFeesStatement(userCode, classStatus).Data;
			if (studentStatements.Any())
				foreach (var statement in studentStatements)
				{
					var debit = Convert.ToDecimal(totalDebitCreditViewModel.Debit.Substring(4)) + statement.Debit;
					var credit = Convert.ToDecimal(totalDebitCreditViewModel.Credit.Substring(4)) + statement.Credit;
					totalDebitCreditViewModel.Debit = string.Format("KES {0:N2}", debit);
					totalDebitCreditViewModel.Credit = string.Format("KES {0:N2}", credit);
					statement.Balance = credit - debit;
				}

			return totalDebitCreditViewModel;
		}

		private ReturnData<List<StudentStatement>> GenerateFeesStatement(string userCode, string classStatus)
		{
			var studentAccounts = _studentServices.GetAccounts();
			var studStatementList = new List<StudentStatement>();
			if (!studentAccounts.Success)
				return new ReturnData<List<StudentStatement>>
				{
					Success = studentAccounts.Success,
					Message = studentAccounts.Message,
					Data = studStatementList
				};

			var accountInfo = AddAccountInfoToStatement(studentAccounts.Data, userCode);
			if (accountInfo.Count > 0)
				studStatementList.AddRange(accountInfo);

			var studentInvoiceAdjustments = _studentServices.GetInvoiceAdj(userCode);
			if (!studentInvoiceAdjustments.Success)
				return new ReturnData<List<StudentStatement>>
				{
					Success = studentInvoiceAdjustments.Success,
					Message = studentInvoiceAdjustments.Message,
					Data = studStatementList
				};

			var invoiceAdj = AddInvoiceAdjustmentsToStatement(studentInvoiceAdjustments.Data, userCode);
			if (invoiceAdj.Count > 0)
				studStatementList.AddRange(invoiceAdj);

			var cancelledReceipt = _studentServices.GetReceiptBookCancellations();
			if (!cancelledReceipt.Success)
				return new ReturnData<List<StudentStatement>>
				{
					Success = cancelledReceipt.Success,
					Message = cancelledReceipt.Message,
					Data = studStatementList
				};

			var receiptBook = AddReceiptBooksToStatement(cancelledReceipt.Data, userCode);
			if (receiptBook.Count > 0)
				studStatementList.AddRange(receiptBook);

			var sponserCancellation = _studentServices.GetSponserCancellations();
			if (!sponserCancellation.Success)
				return new ReturnData<List<StudentStatement>>
				{
					Success = sponserCancellation.Success,
					Message = sponserCancellation.Message,
					Data = studStatementList
				};

			var studentHelb = AddHelpToStatement(sponserCancellation.Data, userCode);
			if (studentHelb.Count > 0)
				studStatementList.AddRange(studentHelb);

			var refund = AddRefundToAmount(cancelledReceipt.Data, userCode);
			if (refund.Count > 0)
				studStatementList.AddRange(refund);

			var payments = AddPaymentsToStatement(userCode, classStatus);
			if (payments.Count > 0)
				studStatementList.AddRange(payments);

			var message = "";
			if (studStatementList.Count < 1)
				message = "Sorry, we could not find your fee statement";

			studStatementList = studStatementList.OrderBy(s => s.Rdate).ToList();

			return new ReturnData<List<StudentStatement>>
			{
				Success = true,
				Message = message,
				Data = studStatementList
			};
		}

		private List<StudentStatement> AddAccountInfoToStatement(List<Accounts> studentAccounts, string userCode)
		{
			var studentInvoiceCols = GetStudentInvoiceCols(studentAccounts);
			var studentInvoice = _studentServices.GetInvoicedAmount(userCode, studentInvoiceCols);

			var studStatementList = new List<StudentStatement>();
			foreach (var i in studentInvoice.Data)
			{
				var studentRowInvoice = new StudentStatement
				{
					AdmnNo = userCode,
					Rdate = i.Rdate,
					Type = "INV",
					Term = i.Term.ToUpper(),
					Ref = i.Ref,
					Description = "STANDARD INVOICE",
					Debit = Convert.ToDecimal(i.Debit)
				};
				studStatementList.Add(studentRowInvoice);
			}

			return studStatementList;
		}

		private string GetStudentInvoiceCols(List<Accounts> studentAccounts)
		{
			int studentInvoiceColumnCounter = studentAccounts.Count;
			int columnsLoopCounter = 1;
			var invoiceColumnNames = new List<string>();

			foreach (var studentAccount in studentAccounts)
			{
				var column = "[" + studentAccount.Names + "]";

				if (columnsLoopCounter == studentInvoiceColumnCounter)
					invoiceColumnNames.Add("isNull(" + column + ",0) ");
				else
					invoiceColumnNames.Add("isNull(" + column + ",0) +");

				columnsLoopCounter++;
			}

			var studInvoiceCols = string.Join(" ", invoiceColumnNames.ToList());

			return studInvoiceCols;
		}

		private List<StudentStatement> AddInvoiceAdjustmentsToStatement(List<StudInvoiceAdj> invoiceAdjustments, string userCode)
		{
			var studStatementList = new List<StudentStatement>();
			foreach (var studAdj in invoiceAdjustments)
			{
				if (!studAdj.Amount.HasValue)
				{
					studAdj.Amount = 0;
				}

				var studentRowInvoiceAdjustments = new StudentStatement
				{
					AdmnNo = userCode,
					Rdate = studAdj.Rdate,
					Type = "ADJ",
					Term = studAdj.Term.ToUpper(),
					Ref = studAdj.Ref,
					Description = "INVOICE ADJUSTMENT",
					Debit = (decimal)studAdj.Amount,
					Notes = studAdj.Notes
				};

				if (studAdj.Amount < 0)
					studentRowInvoiceAdjustments = new StudentStatement
					{
						AdmnNo = userCode,
						Rdate = studAdj.Rdate,
						Type = "ADJ",
						Term = studAdj.Term.ToUpper(),
						Ref = studAdj.Ref,
						Description = "INVOICE ADJUSTMENT",
						Credit = -(decimal)studAdj.Amount,
						Notes = studAdj.Notes
					};

				studStatementList.Add(studentRowInvoiceAdjustments);
			}

			return studStatementList;
		}

		private List<StudentStatement> AddReceiptBooksToStatement(List<ReceiptBookCanc> cancelledReceipt, string userCode)
		{
			var studStatementList = new List<StudentStatement>();
			var cancelledRptNos = cancelledReceipt.Select(n => n.ReceiptNumber.ToUpper()).ToList();

			var receiptBooks = _context.ReceiptBook
				.Join(_context.StudEnrolment,
					receiptBook => receiptBook.AdmnNo,
					studEnrolment => studEnrolment.AdmnNo,
					(receiptBook, studEnrolment) =>
						new
						{
							receiptBook.AdmnNo,
							studEnrolment.Class,
							studEnrolment.Id,
							studEnrolment.Edate,
							receiptBook.Amount,
							receiptBook.ReceiptNumber,
							receiptBook.Rdate,
							receiptBook.PaymentMode
						})
				.Where(a => a.AdmnNo == userCode && a.Amount > 0);

			var studentEnrolment = _context.StudEnrolment.Where(e => e.AdmnNo.ToUpper().Equals(userCode.ToUpper()))
				.OrderByDescending(e => e.Sdate).FirstOrDefault();

			receiptBooks = receiptBooks.Where(b => b.Id == studentEnrolment.Id);

			var receiptBookList = receiptBooks
				.Select(a => new StudentFeeStatementClass
				{
					TotalInvoiceAmounts = a.Amount,
					Ref = a.ReceiptNumber,
					StudentClass = a.Class,
					AdmnNo = a.AdmnNo,
					RDate = a.Rdate,
					Notes = a.PaymentMode
				})
				.ToList();

			var cleanedReceptList = receiptBookList.Where(r => !cancelledRptNos.Contains(r.Ref.ToUpper())).ToList();

			foreach (var receiptBook in cleanedReceptList)
			{
				var trm = _studentServices.GetCurrentTermByDate(receiptBook.StudentClass, Convert.ToDateTime(receiptBook.RDate));
				if (!receiptBook.TotalInvoiceAmounts.HasValue)
					receiptBook.TotalInvoiceAmounts = 0;

				var studentReceiptBook = new StudentStatement
				{
					AdmnNo = userCode,
					Rdate = receiptBook.RDate,
					Type = "PAY",
					Term = trm.ToUpper(),
					Ref = receiptBook.Ref,
					Description = receiptBook.Notes,
					Credit = (decimal)receiptBook.TotalInvoiceAmounts
				};
				studStatementList.Add(studentReceiptBook);
			}

			return studStatementList;
		}

		private List<StudentStatement> AddHelpToStatement(List<StudSponsorBdcanc> sponserCanc, string userCode)
		{
			var cancelledHelbRpts = new List<string>();
			sponserCanc.ForEach(c => { cancelledHelbRpts.Add(c.Ref.ToUpper()); });

			var queryInfo =
				" DECLARE @StudSponsorBd TABLE([AdmnNo][varchar](50) NULL,[Term] [varchar] (100) NULL,[Rdate] [datetime] NULL,[Type] [varchar] (100) NULL,[Ref] [varchar] (100) NULL,[Description] [varchar] (500) NULL,[Debit] [decimal](19, 4) NULL,[Credit] [decimal](19, 4) NULL,[Balance] [decimal](19, 4) NULL,[Notes] [varchar] (500) NULL,[Id] [int] IDENTITY(1,1) NOT NULL); INSERT INTO @StudSponsorBd([AdmnNo], [Term], [Rdate], [Type], [Ref], [Description], [Debit], [Credit], [Balance], [Notes]) SELECT AdmnNo,term,rdate,'ALLOc' as type,Ref,SponsorName as Description,0 as debit,Amount as credit,0 as balance,SponsorName as Notes FROM StudSponsorBd where AdmnNo ='" +
				userCode + "' SELECT* FROM @StudSponsorBd";

			var helb = _context.StudentStatementModelVirtual.AsNoTracking().FromSql(queryInfo)
				.Where(r => !cancelledHelbRpts.Contains(r.Ref.ToUpper()))
				.ToList();

			var studStatementList = new List<StudentStatement>();

			foreach (var helbAmountItem in helb)
			{
				if (!helbAmountItem.Credit.HasValue)
				{
					helbAmountItem.Credit = 0;
				}

				var studentHelbAmountItem = new StudentStatement
				{
					AdmnNo = userCode,
					Rdate = helbAmountItem.Rdate,
					Type = "ALLOC",
					Term = helbAmountItem.Term.ToUpper(),
					Ref = helbAmountItem.Ref,
					Description = helbAmountItem.Description,
					Credit = (decimal)helbAmountItem.Credit,
					Notes = helbAmountItem.Notes
				};
				studStatementList.Add(studentHelbAmountItem);
			}
			return studStatementList;
		}

		private List<StudentStatement> AddRefundToAmount(List<ReceiptBookCanc> cancelledReceipt, string userCode)
		{
			var cancelledRptNos = cancelledReceipt.Select(n => n.ReceiptNumber.ToUpper());

			var studRefunds = _context.Refund
			   .Join(_context.StudEnrolment,
				   studEnrolment => studEnrolment.AdmnNo,
				   receiptBook => receiptBook.AdmnNo,
				   (receiptBook, studEnrolment) =>
					   new
					   {
						   receiptBook.AdmnNo,
						   studEnrolment.Class,
						   studEnrolment.Id,
						   studEnrolment.Edate,
						   receiptBook.Amount,
						   receiptBook.ReceiptNumber,
						   receiptBook.Rdate,
						   receiptBook.Notes
					   })
			   .Where(r => r.AdmnNo == userCode);

			var recentEnrolment = _context.StudEnrolment.Where(e => e.AdmnNo.ToUpper().Equals(userCode.ToUpper()))
				.OrderByDescending(e => e.Sdate).FirstOrDefault();
			studRefunds = studRefunds.Where(r => r.Id == recentEnrolment.Id);
			var refundAmountList = studRefunds
				.Select(a => new StudentFeeStatementClass
				{
					TotalInvoiceAmounts = a.Amount,
					Ref = a.ReceiptNumber,
					StudentClass = a.Class,
					AdmnNo = a.AdmnNo,
					RDate = a.Rdate,
					Notes = a.Notes
				})
			   .ToList();

			var cleanRefundAmountList = refundAmountList.Where(r => !cancelledRptNos.Contains(r.Ref.ToUpper())).ToList();

			var studStatementList = new List<StudentStatement>();
			if (cleanRefundAmountList.Count > 0)
			{
				foreach (var refunds in cleanRefundAmountList)
				{
					var trmref = _studentServices.GetCurrentTermByDate(refunds.StudentClass, Convert.ToDateTime(refunds.RDate));
					if (!refunds.TotalInvoiceAmounts.HasValue)
						refunds.TotalInvoiceAmounts = 0;

					var studentRefundAmountItem = new StudentStatement
					{
						AdmnNo = userCode,
						Rdate = refunds.RDate,
						Type = "REF",
						Term = trmref.ToUpper(),
						Ref = refunds.Ref,
						Description = refunds.Description,
						Debit = (decimal)refunds.TotalInvoiceAmounts
					};
					studStatementList.Add(studentRefundAmountItem);
				}
			}

			return studStatementList;
		}

		private List<StudentStatement> AddPaymentsToStatement(string userCode, string classStatus)
		{
			var cancelled = _context.PayRegister
			   .Join(_context.ChqCancelled,
				   payRegister => payRegister.Ledger,
				   chqCancelled => chqCancelled.Ledger,
				   (chqCancelled, payRegister) => new
				   {
					   payRegister.Ledger,
					   CanclledBank = chqCancelled.Bank,
					   CanclledChqNo = chqCancelled.ChequeNo,
					   PaymentChqNo = payRegister.ChequeNo,
					   PaymentBank = payRegister.Bank,
					   chqCancelled.Rdate
				   }
			   )
			   .Where(p => p.CanclledChqNo == p.PaymentChqNo && p.CanclledBank == p.PaymentBank && p.Rdate < DateTime.Now.Date)
			   .ToList();

			var canceledChqs = new List<string>();
			cancelled.ForEach(e => { canceledChqs.Add(e.CanclledChqNo.ToUpper()); });

			var pvoucherAmountList = _context.Payments
				.Join(_context.Ledger,
					payments => payments.Ledger,
					ledger => ledger.Names,
					(payments, ledger) =>
						new { payments.Rdate, payments.VoucherNumber, payments.ModeNumber, payments.Amount, payments.Ref }
				).Where(p => p.Ref.ToUpper().Equals(userCode.ToUpper()) && !p.VoucherNumber.StartsWith("IMP")
				&& !p.VoucherNumber.EndsWith("EC[0-9]") && Convert.ToDateTime(p.Rdate).Date < DateTime.Now.Date
				&& !canceledChqs.Contains(p.ModeNumber.ToUpper())).ToList();

			var studStatementList = new List<StudentStatement>();
			if (pvoucherAmountList.Count > 0)
			{
				foreach (var paymentVoucher in pvoucherAmountList)
				{
					var ctrm = _studentServices.GetCurrentTerm(userCode, classStatus).Data?.Names;
					var studentPaymentVoucherItem = new StudentStatement
					{
						AdmnNo = userCode,
						Rdate = paymentVoucher.Rdate,
						Type = "REF",
						Term = ctrm.ToUpper(),
						Ref = paymentVoucher.VoucherNumber,
						Description = $"REFUND ({paymentVoucher.ModeNumber})",
						Debit = (decimal)paymentVoucher.Amount
					};
					studStatementList.Add(studentPaymentVoucherItem);
				}
			}
			return studStatementList;
		}
		public ReturnData<List<FeeStructureStageViewModel>> GetFeesStructure(FeesStructureFilter feesStructureFilter, string classStatus)
		{
			var programResponse = _studentServices.GetProgramme(feesStructureFilter.UserCode, classStatus);
			var studSponsor = _studentServices.GetRegister(feesStructureFilter.UserCode).Data;
			var studDetails = _studentServices.GetClass(feesStructureFilter.UserCode, classStatus).Data;
			if (!programResponse.Success)
				return new ReturnData<List<FeeStructureStageViewModel>>
				{
					Success = programResponse.Success,
					Message = programResponse.Message
				};

			var feesPerProg = _context.FeesPerProg.Where(p => p.ProgCode.CaseInsensitiveContains(programResponse.Data.Code) &&
			p.Campus.CaseInsensitiveContains(studDetails.Campus) && p.Sponsor.CaseInsensitiveContains(studSponsor.Sponsor))
			.OrderByDescending(p => p.Sdate).FirstOrDefault();

			if (feesPerProg == null)
				return new ReturnData<List<FeeStructureStageViewModel>>
				{
					Success = false,
					Message = "Sorry, Your fee structure not found, Kindly contact School Admin."
				};

			var feesPerProgramDetails = _context.FeesPerProgDetail
						.Where(f => f.Ref == Convert.ToString(feesPerProg.Id) && f.Stage == feesStructureFilter.Stage)
						.ToList();

			if (!feesPerProgramDetails.Any())
				return new ReturnData<List<FeeStructureStageViewModel>>
				{
					Success = false,
					Message = "Sorry,We having trouble generating your fee structure, Please retry again later."
				};

			var feesPerSemester = new List<FeeStructureStageViewModel>();
			var semesters = feesPerProgramDetails
				.GroupBy(d => d.Term)
				.Select(grp => grp.First())
				.ToList();
			semesters.ForEach(s =>
			{
				var sem = new FeeStructureStageViewModel
				{
					Term = s.Term,
					Fees = new List<FeesPerProgDetail>()
				};

				feesPerProgramDetails.ForEach(p =>
				{
					if (s.Term == p.Term)
					{
						sem.Fees.Add(p);
					}
				});
				feesPerSemester.Add(sem);
			}
			);
			return new ReturnData<List<FeeStructureStageViewModel>>
			{
				Success = true,
				Message = "Fee Structure",
				Data = feesPerSemester
			};
		}
		public ReturnData<dynamic> GetYearResults(TranscriptRequestViewModel transcriptModel, string classStatus)
		{
			string institutionInitials = _systemServices.GetSystemSetup().Data?.SubTitle;
			var currentYearResults = _studentServices.GetSelectedYearResults(transcriptModel, classStatus, institutionInitials);
			if (!currentYearResults.Success)
				return new ReturnData<dynamic>
				{
					Success = currentYearResults.Success,
					Message = currentYearResults.Message
				};

			var studentGradeSettings = GetStudentGradeSettings(transcriptModel.Usercode, classStatus);
			if (!studentGradeSettings.Success)
				return new ReturnData<dynamic>
				{
					Success = studentGradeSettings.Success,
					Message = studentGradeSettings.Message
				};

			var year = transcriptModel.AcademicYear.Substring(5);
			var resultRecommendation = _studentServices.GetResultsRecommendation(transcriptModel.Usercode, year);
			var recommendation = "";
			if (resultRecommendation.Success)
			{
				if (string.IsNullOrEmpty(transcriptModel.Semester))
					recommendation = resultRecommendation.Data?.Recommendation;
			}

			var transcriptNote = "";
			if (institutionInitials.ToUpper().Equals("UOEM"))
				transcriptNote = "This is NOT a transcript. University of Embu reserves the right to correct the information given on the result slip, which will be confirmed by issue of a Transcript.";

			var average = 0m;
			var cumulativeAverage = 0m;
			if (institutionInitials.ToUpper().Equals("LU"))
			{
				var cumulativeResults = _studentServices.GetSelectedYearResults(transcriptModel, classStatus, institutionInitials, false, true);
				if (!currentYearResults.Success)
					return new ReturnData<dynamic>
					{
						Success = currentYearResults.Success,
						Message = currentYearResults.Message
					};

				average = GetAverage(currentYearResults.Data);
				cumulativeAverage = GetAverage(cumulativeResults.Data);
			}

			var transcripts = new
			{
				Results = currentYearResults.Data,
				average,
				cumulativeAverage,
				Remarks = recommendation,
				GradeSettings = studentGradeSettings.Data,
				institutionInitials,
				transcriptNote
			};

			return new ReturnData<dynamic>
			{
				Success = currentYearResults.Success,
				Message = currentYearResults.Message,
				Data = transcripts
			};
		}

		private decimal GetAverage(List<YearTranscriptViewModel> Results)
		{
			decimal Scores = 0;
			decimal totalUnitWeight = 0;
			
			foreach (var result in Results)
			{
				foreach (var unit in result.Units)
				{
					decimal.TryParse(unit?.Score ?? "", out decimal marks);
					var creditUnits = (decimal)unit.CreditUnits;
					Scores = Scores + (marks * creditUnits);
					totalUnitWeight = totalUnitWeight + creditUnits;
				};
			}

			totalUnitWeight = totalUnitWeight < 1 ? 1 : totalUnitWeight;
			var average = Math.Round((Scores / totalUnitWeight), 2);
			return average;
		}

		public ReturnData<dynamic> GetStudentGradeSettings(string userCode, string classStatus)
		{
			var gradings = _studentServices.GetGradings(userCode, classStatus);
			if (!gradings.Success)
				return new ReturnData<dynamic>
				{
					Success = gradings.Success,
					Message = gradings.Message,
				};

			var grading = gradings.Data;

			var symbols = _studentServices.GetMarkSymbols();
			if (!symbols.Success)
				return new ReturnData<dynamic>
				{
					Success = symbols.Success,
					Message = symbols.Message,
				};

			var markSymbols = symbols.Data;

			return new ReturnData<dynamic>
			{
				Success = true,
				Data = new { grading, markSymbols }
			};
		}
		public ReturnData<OnlineReporting> ValidateExamCardReporting(string userCode, string classStatus, bool isPreviousTermCard)
		{
			var currentTerm = _studentServices.GetCurrentTerm(userCode, classStatus);
			if (isPreviousTermCard)
				currentTerm = _studentServices.GetPreviousTerm(userCode, classStatus);
			if (!currentTerm.Success)
				return new ReturnData<OnlineReporting>
				{
					Success = currentTerm.Success,
					Message = currentTerm.Message,
				};

			var plannerDetails = _studentServices.GetSessionPlannerCurrentDetails(userCode, classStatus, isPreviousTermCard);
			if (!plannerDetails.Success)
				return new ReturnData<OnlineReporting>
				{
					Success = plannerDetails.Success,
					Message = plannerDetails.Message,
				};

			var erpReporting = _studentServices.CheckErpReporting(userCode, classStatus, isPreviousTermCard);
			if (erpReporting.Success)
				return new ReturnData<OnlineReporting>
				{
					Success = erpReporting.Success,
					Message = erpReporting.Message,
				};

			var onlineReporting = _studentServices.CheckOnlineReporting(userCode, classStatus, isPreviousTermCard);
			return onlineReporting;
		}
	}
}
