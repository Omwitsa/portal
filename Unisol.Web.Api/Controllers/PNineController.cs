using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Api.IServices;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Employee;
using Unisol.Web.Common.ViewModels.P9;
using Unisol.Web.Common.ViewModels.Payslip;
using Unisol.Web.Entities.Database.UnisolModels;


namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class PNineController : Controller
	{
		private readonly UnisolAPIdbContext _context;
		private readonly double PercentContributionScheme = 0.3;
		private IStaffServices _staffServices;
		private StaffUtilities staffUtilities;
		private IUnitOfWork _unitOfWork;
		private IConfiguration _configuration;

		public PNineController(UnisolAPIdbContext context, IConfiguration configuration, IStaffServices staffServices, IUnitOfWork unitOfWork)
		{
			_context = context;
			_unitOfWork = unitOfWork;
			_configuration = configuration;
			_staffServices = staffServices;
			staffUtilities = new StaffUtilities();
		}

		[HttpGet("[action]")]
		public JsonResult GetP9List(string userCode, int year)
		{
			string[] names = DateTimeFormatInfo.CurrentInfo.MonthNames;
			var p9ViewModelYear = new List<P9ViewModel>();
			try
			{
				var hrpSetup = _context.HrpSetup.FirstOrDefault();
				var mains = _context.HrpPayemain.ToList();
				foreach (var salMonth in names)
				{
					var month = salMonth + " " + year;
					if (!string.IsNullOrEmpty(salMonth))
					{
						var firstMonthDay = DateTime.Parse($"01-{salMonth}-{year}");
						var lastMonthDay = firstMonthDay.AddMonths(1).AddDays(-1);
						var hrpPayemain = mains.FirstOrDefault(m => DateBetweeen(m.Sdate, m.Edate, lastMonthDay));
						var primaryBaseP9 = GetMonthsPayment(userCode, month);
						var p9ViewModel = new P9ViewModel();

						if (primaryBaseP9 != null)
						{
							p9ViewModel.Month = salMonth;
							p9ViewModel.A_BasicSalary = primaryBaseP9.TotalEarning;
							//calculating all benefits
							p9ViewModel.B_Beneficts = primaryBaseP9.Benefits;

							p9ViewModel.C_HousingQuarters = primaryBaseP9.HouseOfQuarter;

							p9ViewModel.D_TotalGrossIncome = primaryBaseP9.GrossIncome;
							p9ViewModel.E1_RetirementScheme = Return_E1_RetirementScheme(p9ViewModel.A_BasicSalary);
							p9ViewModel.E2_RetirementScheme = Math.Round(primaryBaseP9.Pension);
							p9ViewModel.E3_RetirementScheme = primaryBaseP9.GrossIncome > 0
								? Return_E3_RetirementScheme(hrpSetup)
								: 0.0;
							p9ViewModel.F_InterestAmountOnHouse = Return_F_InterestAmountOnHouse(userCode, month);

							var eS = new List<double>
							{
								//p9ViewModel.E1_RetirementScheme,
								p9ViewModel.E2_RetirementScheme,
								//p9ViewModel.E3_RetirementScheme
							};
							p9ViewModel.G_RetirementContribution =
								Return_G_RetirementContribution(eS, p9ViewModel.F_InterestAmountOnHouse);
							p9ViewModel.H_ChargeablePay = Return_H_ChargeablePay
								(p9ViewModel.D_TotalGrossIncome, p9ViewModel.G_RetirementContribution);
							
							p9ViewModel.K_PersonalRelief = primaryBaseP9.GrossIncome > 0 ? Return_K_PersonalRelief(hrpPayemain, primaryBaseP9.IsRegularEmployee) : 0.0;
							var is_ndma = _context.SysSetup.Any(s => s.SubTitle.ToUpper().Equals("NDMA"));
							p9ViewModel.J_TaxCharged = is_ndma ? Math.Round(primaryBaseP9.Tax + p9ViewModel.K_PersonalRelief) : GetTaxCharged(p9ViewModel.H_ChargeablePay, hrpPayemain.Id.ToString());
							
							p9ViewModel.L_PayeTax = p9ViewModel.J_TaxCharged - p9ViewModel.K_PersonalRelief;

							//p9ViewModel.L_PayeTax =Math.Round(p9ViewModel.J_TaxCharged - p9ViewModel.K_PersonalRelief);
							p9ViewModelYear.Add(p9ViewModel);
						}
					}
				}

				if (p9ViewModelYear.Any())
				{
					var pNineMainViewModel = CalculateAnnualTotals(p9ViewModelYear);

					var empDetails = GetP9Details(hrpSetup, userCode);
					empDetails.Year = " TAX DEDUCTION CARD YEAR " + year;
					return Json(new ReturnData<dynamic>
					{
						Success = true,
						Data = new PNineMainViewModel
						{
							AnnualTotals = pNineMainViewModel,
							MonthlyAmounts = p9ViewModelYear,
							P9Details = empDetails
						},
						Message = ""
					});
				}

				return Json(new ReturnData<bool>
				{
					Success = false,
					Message = "Oops,seems like not account types have been set up"
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<bool>
				{
					Success = false,
					Message = "Oops,seems like we had an issue calculating your P9",
					Error = new Error(ex)
				});
			}
		}

		[HttpGet("[action]")]
		public JsonResult TaxCharged(double pay)
		{
			return Json(new { tax = GetTaxCharged(pay, "5") });
		}

		private double GetTaxCharged(double chargeablePay, string pRef)
		{
			var payees = _context.HrpPaye.OrderBy(p => p.Tax).Where(p => p.Ref.Equals(pRef)).ToList();
			double runningTax = 0;
			var val = payees.Select(t => t.Tax).Sum();
			foreach (var payee in payees)
			{
				if (chargeablePay <= 0)
					break;
				var low = Convert.ToDouble(payee.MinAmt);
				if (payee.MaxAmt.Contains("NONE"))
				{
					var tax = (chargeablePay - low) * (Convert.ToDouble(payee.Tax.Value) / 100);
					runningTax += Math.Round(tax);
					break;
				}
				var high = Convert.ToDouble(payee.MaxAmt);
				if (chargeablePay > low)
				{
					if (chargeablePay < high)
					{
						var remTax = (chargeablePay - low) * (Convert.ToDouble(payee.Tax.Value) / 100);
						runningTax += Math.Round(remTax);
						break;
					}
					var tax = (high - low) * (Convert.ToDouble(payee.Tax.Value) / 100);
					runningTax += Math.Round(tax);
				}
				else
				{
					var tax = (chargeablePay - high) * (Convert.ToDouble(payee.Tax.Value) / 100);
					runningTax += Math.Round(tax);
				}
			}

			//return runningTax;
			return 70601;
		}

		public HrpEmployeeDetails GetEmployeeDetails(string userCode)
		{
			return _context.HrpEmployee.Select(s => new HrpEmployeeDetails
			{
				Names = s.Names,
				EmpNo = s.EmpNo,
				Department = s.Department,
				Section = s.Section,
				Idno = s.Idno,
				Pin = s.Pin,
				WEmail = s.Wemail
			}).FirstOrDefault(e => e.EmpNo == userCode);
		}

		private PNineDetailsViewModel GetP9Details(HrpSetup hrpSetup, string userCode)
		{
			var pNineDetailsViewModel = new PNineDetailsViewModel();
			try
			{
				var empDetails = GetEmployeeDetails(userCode);
				var empName = empDetails.Names.Split(" ");
				pNineDetailsViewModel.EmployerPin = hrpSetup?.Pin;
				pNineDetailsViewModel.EmployerName = _context.SysSetup.Select(g => g.OrgName).FirstOrDefault();

				pNineDetailsViewModel.EmployeePin = empDetails.Pin;
				pNineDetailsViewModel.EmployeeName = empName[0];
				if (empName.Length > 1)
				{
					pNineDetailsViewModel.EmployeeOtherNames = empName[1] + " ";
					if (empName.Length >= 2)
					{
						pNineDetailsViewModel.EmployeeOtherNames = empName[2] + " ";
					}
				}
			}
			catch (Exception ex)
			{
			}

			return pNineDetailsViewModel;
		}

		private P9ViewAnnualTotalsViewModel CalculateAnnualTotals(List<P9ViewModel> p9ViewModelYear)
		{
			var p9ViewAnnualTotalsViewModel = new P9ViewAnnualTotalsViewModel();
			try
			{
				p9ViewModelYear.ForEach(e =>
				{
					p9ViewAnnualTotalsViewModel.A_BasicSalary += e.A_BasicSalary;
					p9ViewAnnualTotalsViewModel.B_Beneficts += e.B_Beneficts;
					p9ViewAnnualTotalsViewModel.C_HousingQuarters += e.C_HousingQuarters;
					p9ViewAnnualTotalsViewModel.D_TotalGrossIncome += e.D_TotalGrossIncome;
					p9ViewAnnualTotalsViewModel.E1_RetirementScheme += e.E1_RetirementScheme;
					p9ViewAnnualTotalsViewModel.E2_RetirementScheme += e.E2_RetirementScheme;
					p9ViewAnnualTotalsViewModel.E3_RetirementScheme += e.E3_RetirementScheme;
					p9ViewAnnualTotalsViewModel.F_InterestAmountOnHouse += e.F_InterestAmountOnHouse;
					p9ViewAnnualTotalsViewModel.G_RetirementContribution += e.G_RetirementContribution;
					p9ViewAnnualTotalsViewModel.H_ChargeablePay += e.H_ChargeablePay;
					p9ViewAnnualTotalsViewModel.J_TaxCharged += e.J_TaxCharged;
					p9ViewAnnualTotalsViewModel.K_PersonalRelief += e.K_PersonalRelief;
					p9ViewAnnualTotalsViewModel.L_PayeTax += e.L_PayeTax;
				});
			}
			catch (Exception ex)
			{
			}

			return p9ViewAnnualTotalsViewModel;
		}


		public double Return_A_BasicSalary(string userCode)
		{
			/*the summation of all earning plus allowances*/

			return 0.0;
		}

		public double Return_B_Benefits(string userCode)
		{
			/*all the benefits enjoyed by the emp*/
			return 0.0;
		}

		public double Return_C_HousingQuarters(string userCode)
		{
			/*value of the rent of the house provided by the employer*/
			return 0.0;
		}

		public double ReturnTotalGrossIncome(double basicSalaryA, double benefitsB, double housingQuarterC)
		{
			/*Total gross pay*/
			return basicSalaryA + benefitsB + housingQuarterC;
		}

		public double Return_E1_RetirementScheme(double basicSalaryA)
		{
			return Math.Round(PercentContributionScheme * basicSalaryA, 2);
		}

		public double Return_E2_RetirementScheme(string userCode)
		{
			/*pension contributions (pensions+nssf)*/
			return 0.0;
		}

		public double Return_E3_RetirementScheme(HrpSetup relief)
		{
			/*fixed amount not taxed thats pegged on the penstion scheeme*/
			if (relief != null)
			{
				return Convert.ToDouble(relief.MaxPensionAllowable ?? 0);
			}

			/*calculation of tax relief*/
			return 0.0;
		}


		private bool DateBetweeen(DateTime? sDate, DateTime? eDate, DateTime vDate)
		{
			if (eDate == null)
				eDate = DateTime.Now.AddDays(1);
			var res = sDate <= vDate && vDate <= eDate;
			return res;
		}

		public double Return_F_InterestAmountOnHouse(string code, string userCode)
		{
			return 0.0;
		}

		public double ReturnSmallestOfEs(List<double> eS)
		{
			/*list of defined contribution retirement scheme*/
			return eS.Min();
		}

		public double Return_G_RetirementContribution(List<double> eS, double interestAmountOnHouseF)
		{
			/*lowest of Es added to F (F_InterestAmountOnHouse)*/

			return ReturnSmallestOfEs(eS) + interestAmountOnHouseF;
		}

		public double Return_H_ChargeablePay(double totalGrossIncomeD, double retirementContributionG)
		{
			/*total gross income less less amount og pensions*/
			return totalGrossIncomeD - retirementContributionG;
		}

		public double Return_J_TaxCharged(string userCode)
		{
			/*calculation of tax*/
			return 0.0;
		}

		public double Return_K_PersonalRelief(HrpPayemain relief, bool IsRegularEmployee)
		{
			if (relief == null || !IsRegularEmployee)
				return 0.0;

			return Convert.ToDouble(relief.Prelief ?? 0);
		}

		public double ReturnPayeTax(string userCode)
		{
			/*calculation of net tax ""/tax less relief */

			return 0.0;
		}

		//        [HttpGet("[action]")]
		public EarningCategoryViewModel GetMonthsPayment(string userCode, string month)
		{
			var monthsSalary = GetPaySlip(userCode, month);
			var earningCategory = new EarningCategoryViewModel();
			var salaryPeriod = _context.HrpSalPeriod.FirstOrDefault(p => p.Names.ToUpper().Equals(month.ToUpper()));
			if(salaryPeriod != null)
			{
				var ipEarnings = _context.HrpIpearnings.Join(_context.HrpIpprojects,
				e => e.Project,
				p => p.Names,
				(e, p) => new
				{
					e.Id,
					e.PayAccount,
					e.Amount,
					e.EmpNo,
					e.Cons,
					p.NonTaxable,
					p.DueDate
				})
				.Join(_context.HrpIpprofile,
				e => e.EmpNo,
				f => f.EmpNo,
				(e, f) => new
				{
					e.Id,
					e.PayAccount,
					e.Amount,
					e.EmpNo,
					e.Cons,
					e.NonTaxable,
					e.DueDate,
					f.TaxExempt,
				}).Where(e => e.EmpNo.ToUpper().Equals(userCode.ToUpper()) && !(bool)e.Cons
				&& !(bool)e.NonTaxable && e.DueDate >= salaryPeriod.Sdate && e.DueDate <= salaryPeriod.Edate).Distinct().ToList();

				ipEarnings.ForEach(e =>
				{
					var ipAccount = _context.HrpIppayAcc.FirstOrDefault(a => a.Names.ToUpper().Equals(e.PayAccount.ToUpper()));
					if (!(bool)e.TaxExempt && (bool)ipAccount.Paye)
					{
						var amount = e.Amount ?? 0;
						earningCategory.TotalEarning += (double)amount;
					}
				});
			}

			var payments = new List<PayslipModelView>(monthsSalary.Data);
			earningCategory.IsRegularEmployee = payments.Any();
			earningCategory.Tax += _unitOfWork.HrpSalProcess.GetIpTax(_configuration, salaryPeriod, userCode);

			if (earningCategory.IsRegularEmployee)
			{
				foreach (var payment in payments)
				{
					if (payment.AccountType == "EARNING")
					{
						payment.IndividualAccountType.ForEach(e => { earningCategory.TotalEarning += e.Amount; });
					}

					if (payment.AccountType == "DEDUCTION")
					{
						payment.IndividualAccountType.ForEach(e =>
						{
							if (StripDots(e.Name) == "PAYE")
								earningCategory.Tax += e.Amount;
							
							var deductionAllowed = _unitOfWork.HrpPayAcc.GetFirstOrDefault(a => a.Names.ToUpper().Equals(e.Name.ToUpper())).AllowDed;
							if((bool)deductionAllowed)
								earningCategory.Pension += e.Amount;

							//if (StripDots(e.Name) == "NSSF")
							//	earningCategory.Pension += e.Amount;
						});
					}

					if (payment.AccountType == "PENSION")
					{
						payment.IndividualAccountType.ForEach(e => {
							earningCategory.Pension += e.Amount;
						});
					}

					if (payment.AccountType == "BENEFITS")
					{
						payment.IndividualAccountType.ForEach(e => { earningCategory.Benefits += e.Amount; });
					}
				}
			}

			earningCategory.GrossIncome = earningCategory.Benefits
										  + Return_C_HousingQuarters(userCode)
										  + earningCategory.TotalEarning;

			return earningCategory;
		}

		public string StripDots(string name)
		{
			name = name.Replace(".", "");
			return name;
		}

		public ReturnData<List<PayslipModelView>> GetPaySlip(string userCode, string month)
		{
			try
			{
				var accountTypes = new List<string>
				{
					"EARNING",
					"DEDUCTION",
					"UNION",
					"PENSION",
					"LOAN",
					"BENEFIT",
				};

				var accounts = _staffServices.GetAccounts();
				if (!accounts.Success)
					return new ReturnData<List<PayslipModelView>>
					{
						Success = accounts.Success,
						Message = accounts.Message,
					};

				var indAccountsTypes = accounts.Data.Where(h => h.Closed == false).ToList();

				var payslipViewModelList = new List<PayslipModelView>();
				try
				{
					var earningDeductions = new EarningDeductions();
					var accountsWithAmount = _staffServices.ReturnPayslipActiveColumns(userCode, month);
					if (accountsWithAmount.AccountAmountViewModel.Any())
					{
						foreach (var accType in accountTypes)
						{
							var payslipViewModel = new PayslipModelView
							{
								AccountType = accType,
								TotalAmount = 0.0
							};

							var indvidualAcTypes = indAccountsTypes
								.Where(a => a.Type == accType && accountsWithAmount.ActiveAccounts.Contains(a.Code))
								.ToList();
							if (indvidualAcTypes.Any())
							{
								var individualAccountTypeList = new List<IndividualAccountType>();
								indvidualAcTypes.ForEach(iA =>
								{
									var result = Convert.ToDouble(accountsWithAmount.AccountAmountViewModel
																	  .FirstOrDefault(aA => aA.AccountName == iA.Code)
																	  ?.Amount ?? "0.00");

									if (iA.Names.Replace(".", "").ToUpper().Equals("NSSF"))
									{
										var nssf = _context.HrpSetup.FirstOrDefault()?.Mnssf ?? 0;
										result = (double)nssf;
									}

									if (result > 0)
									{
										payslipViewModel.TotalAmount += result;

										if (staffUtilities.CreateSumAmount(accType))
										{
											earningDeductions.Earnings += result;
										}
										else
										{
											earningDeductions.Deductions += result;
										}

										var individualAccountTypes = new IndividualAccountType
										{
											Name = iA.Names,
											Amount = result
										};
										individualAccountTypeList.Add(individualAccountTypes);
									}
								});
								payslipViewModel.IndividualAccountType = individualAccountTypeList;
								if (individualAccountTypeList.Any())
								{
									payslipViewModelList.Add(payslipViewModel);
								}
							}
						}

						if (payslipViewModelList.Any())
							return (new ReturnData<List<PayslipModelView>>
							{
								Success = true,
								Message = "",
								Data = payslipViewModelList
							});

						return (new ReturnData<List<PayslipModelView>>
						{
							Success = false,
							Message = "Oops,seems like we could find your payslip",
							Data = payslipViewModelList
						});
					}

					return (new ReturnData<List<PayslipModelView>>
					{
						Success = false,
						Message = "Oops,we could not find any pay slip for that periods",
						Data = payslipViewModelList
					});
				}
				catch (Exception ex)
				{
					return (new ReturnData<List<PayslipModelView>>
					{
						Success = false,
						Message = "Oops,seems like an error occurred while processing your request",
						Error = new Error(ex)
					});
				}
			}
			catch (Exception ex)
			{
				return (new ReturnData<List<PayslipModelView>>
				{
					Success = false,
					Message = "Oops,seems like an error occurred while processing your request",
					Error = new Error(ex)
				});
			}
		}
	}
}