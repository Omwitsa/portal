using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Common.ViewModels.loans;
using Unisol.Web.Common.ViewModels.Payslip;
using Unisol.Web.Entities.Database.UnisolModels;


namespace Unisol.Web.Api.Controllers
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : Controller
    {
        private readonly UnisolAPIdbContext _context;
        private IConfiguration _configuration;

        public LoansController(UnisolAPIdbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpGet("[action]")]
        public JsonResult GetLoansList(string userCode)
        {
			try
            {
                var loans = _context.HrpLoanSetup.Where(l => l.EmpNo == userCode).ToList();
                if (loans.Any())
                {
                    var accNo = _context.HrpService.FirstOrDefault(a => a.EmpNo == userCode)?.AccNo;
                    var userInfor = _context.HrpEmployee
                        .Select(e => new
                        {
                            e.EmpNo,
                            e.Names,
                            e.Idno
                        })
                        .FirstOrDefault(e => e.EmpNo == userCode);

                    return Json(new ReturnData<dynamic>
                    {
                        Success = true,
                        Message = "",
                        Data =
                        new {
                            loans,
                            userInfor=new {
                                accNo,userInfor?.EmpNo,userInfor?.Idno,userInfor?.Names
                        }
                        }
                    });
                }

                return Json(new ReturnData<bool>
                {
                    Success = false,
                    Message = "Oops,we could not find any loans"
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
        public JsonResult GetLoanStatement(string userCode, int refId)
        {
            try
            {
                var loan = _context.HrpLoanSetup.FirstOrDefault(d => d.Id == refId);
                if (loan != null)
                {
                    var loanCode = _context.HrpPayAcc.FirstOrDefault(a => a.Names == loan.Loan);
                    if (loanCode != null)
                    {
                        var payAmount = ReturnPaidLoan(userCode, loanCode.Code);
                        var loanStatementViewModel = new LoanStatementViewModel();
                        var loanSub = GetLoanSubmissionsPlan(refId);
						var balance = loanSub.Data.Sum(l => l.Premium);
                        if (loanSub.Success)
                        {
                            var loanTransactions = new List<LoanTransactions>();
                            loanSub.Data.ForEach(ln =>
                            {
                                var monthPeriod = ProcessDates.ReturnMonthName(Convert.ToDateTime(ln.Rdate).Month) +
                                                  " " +
                                                  Convert.ToDateTime(ln.Rdate).Year;
								balance -= ln.Premium;

								var paidAmount =Convert.ToDouble(
									payAmount.FirstOrDefault(f => f.AccountName == monthPeriod)?.Amount ?? "0.0"
									);
								loanTransactions.Add(new LoanTransactions
                                {
                                    Month = monthPeriod,
                                    Required = (double?) ln.Principal,
									Recovered = paidAmount,
									Balance = (double) balance,
									Interest = (double?) ln.Interest,
									Premium = (double?) ln.Premium
								});
								loanStatementViewModel.TotalRequired += (double)ln.Principal;
								loanStatementViewModel.TotalRecovered += paidAmount;
                            });
                            loanStatementViewModel.LoanTransactions = loanTransactions;
                        }

                        if (loanStatementViewModel.LoanTransactions.Any())
                        {
                            return Json(new ReturnData<dynamic>
                            {
                                Success = true,
                                Message = "",
                                Data = loanStatementViewModel
                            });
                        }

                        return Json(new ReturnData<bool>
                        {
                            Success = false,
                            Message = "Oops,we could not find any the loan information"
                        });
                    }
                }

                return Json(new ReturnData<bool>
                {
                    Success = false,
                    Message = "Oops,we could not find any the loan information"
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


        public ReturnData<List<HrpLoanSub>> GetLoanSubmissionsPlan(int refId)
        {
            try
            {
                var hrpLoanSub = _context.HrpLoanSub.Where(e => e.Ref == refId).OrderBy(m => m.Rdate).ToList();
                if (hrpLoanSub.Any())
                {
                    return new ReturnData<List<HrpLoanSub>>
                    {
                        Success = true,
                        Message = "",
                        Data = hrpLoanSub
                    };
                }

                return new ReturnData<List<HrpLoanSub>>
                {
                    Success = false,
                    Message = "Oops,We could not find the loan submission on this loan",
                    Data = new List<HrpLoanSub>()
                };
            }
            catch (Exception ex)
            {
                return new ReturnData<List<HrpLoanSub>>
                {
                    Success = false,
                    Message = "Oops,We could not find the loan submission on this loan",
                    Data = new List<HrpLoanSub>()
                };
            }
        }


        public List<AccountAmountViewModel> ReturnPaidLoan(string userCode, string loanColumn)
        {
            try
            {
                string connetionString = null;
                SqlConnection connection;
                SqlCommand command;
                string sql = null;

				connetionString = DbSetting.ConnectionString(_configuration, "Unisol");

				connection = new SqlConnection(connetionString);

                connection.Open();

                var getAmountsSql = "SELECT Speriod, ISNULL([" + loanColumn + "],0) as [" + loanColumn +
                                    "] FROM hrpSalProcess WHERE " +
                                    " EmpNo='" + userCode + "'";

                //var nconnection = new SqlConnection(connetionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                var amountCommand = new SqlCommand(getAmountsSql, connection);
                var reader = amountCommand.ExecuteReader();
                var listActiveAmountOnColumns = new List<dynamic>();
                while (reader.Read())
                {
                    listActiveAmountOnColumns.Add(
                        new
                        {
                            loan = Convert.ToString(reader[loanColumn]),
                            Speriod = Convert.ToString(reader["Speriod"])
                        }
                    );
                }

                var accountsAmountList = new List<AccountAmountViewModel>();


                listActiveAmountOnColumns.ForEach(l =>
                {
                    accountsAmountList.Add(
                        new AccountAmountViewModel
                        {
                            AccountName = l.Speriod,
                            Amount = l.loan
                        }
                    );
                });

                amountCommand.Dispose();
                connection.Close();
                return accountsAmountList;
            }
            catch (Exception ex)
            {
                return new List<AccountAmountViewModel>();
            }
        }
 
    }
}