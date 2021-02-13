using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Api.IServices;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Payslip;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.StudentUtilities
{
	public class StaffUtilities
	{
        private readonly static UnisolAPIdbContext _context = new UnisolAPIdbContext();
        public string GetColumnTypes(List<string> empAccountColumnNames)
		{
			int studentInvoiceColumnCounter = empAccountColumnNames.Count();
			int columnsLoopCounter = 1;

			var empAccountJoinedColumns = new List<string>();
			foreach (var items in empAccountColumnNames.ToArray())
			{
				var column = "[" + items + "]";
				if (columnsLoopCounter == studentInvoiceColumnCounter)
					empAccountJoinedColumns.Add("isNull(" + column + ",0) as " + column + " ");
				else
					empAccountJoinedColumns.Add("isNull(" + column + ",0) as " + column + ",");

				columnsLoopCounter++;
			}

			return string.Join(" ", empAccountJoinedColumns.ToList());
		}

		public ReturnData<dynamic> GetPayslip(IStaffServices _staffServices, List<string> accountTypes, List<HrpPayAcc> indAccountsTypes, string userCode, string month)
		{
			var payslipViewModelList = new List<PayslipModelView>();
			var earningDeductions = new EarningDeductions();
			var accountsWithAmount = _staffServices.ReturnPayslipActiveColumns(userCode, month);
			if (!accountsWithAmount.AccountAmountViewModel.Any())
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Oops,we could not find any pay slip for that periods",
				};

			foreach (var accType in accountTypes)
			{
				var payslipViewModel = new PayslipModelView
				{
					AccountType = accType,
					TotalAmount = 0.0
				};

				var indvidualAcTypes = indAccountsTypes
					.Where(a => a.Type == accType && accountsWithAmount.ActiveAccounts.Contains(a.Code)).ToList();

				if (indvidualAcTypes.Any())
				{
					var individualAccountTypeList = new List<IndividualAccountType>();
					indvidualAcTypes.ForEach(iA =>
					{
						var result = Convert.ToDouble(accountsWithAmount.AccountAmountViewModel
															.FirstOrDefault(aA => aA.AccountName == iA.Code)
															?.Amount ?? "0.00");
						if (result > 0)
						{
							payslipViewModel.TotalAmount += result;
							if (CreateSumAmount(accType))
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
								Amount = result,
								Balance = _staffServices.GetBalance(accType, userCode, iA.Code, iA.Names, month).Data
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

			if (!payslipViewModelList.Any())
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Oops,seems like we could find your payslip"
				};

			var sortedPayments = SortPaymentsPerDeductions(payslipViewModelList);
			var processings = _staffServices.GetMonthProcessedSalary(userCode, month);

			return new ReturnData<dynamic>
			{
				Success = true,
				Message = "",
				Data = new
				{
					sortedPayments,
					earningDeductions,
					RDate = processings.Data?.RDate ?? DateTime.UtcNow
				}
			};
		}
		
		public bool CreateSumAmount(string accType)
		{
			if (AccountTypeImpact.EarningsList.Contains(accType))
			{
				return true;
			}

			return false;
		}

		private PaymentPerDeductionEarning SortPaymentsPerDeductions(List<PayslipModelView> payslipViewModelList)
		{
			if (payslipViewModelList.Any())
			{
				var earnings = new List<IndividualAccountType>();
				var deductions = new List<IndividualAccountType>();
				payslipViewModelList.ForEach(a =>
				{
					if (AccountTypeImpact.EarningsList.Contains(a.AccountType))
					{
						earnings.AddRange(a.IndividualAccountType);
					}
					if (AccountTypeImpact.DeductionsList.Contains(a.AccountType))
					{
						deductions.AddRange(a.IndividualAccountType);
					}
				});
				return new PaymentPerDeductionEarning
				{
					Earnings = earnings,
					Deductions = deductions,
				};
			}

			return new PaymentPerDeductionEarning();
		}
    }
}
