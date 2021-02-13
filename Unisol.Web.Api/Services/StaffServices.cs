using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Api.IServices;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Common.ViewModels.Leave;
using Unisol.Web.Common.ViewModels.Payslip;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Services
{
    public class StaffServices : IStaffServices
    {
        private IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;
        private StaffUtilities staffUtilities;
        private Utils utils;
        private readonly UnisolAPIdbContext _context;
        public StaffServices(IUnitOfWork unitOfWork, IConfiguration configuration, UnisolAPIdbContext context)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            staffUtilities = new StaffUtilities();
            utils = new Utils(context);
            _context = context;
        }

        public ReturnData<List<ProcOnlineReq>> GetOnlineRequest(string doctype)
        {
            try
            {
                var onlineRequests = _unitOfWork.ProcOnlineReq.GetWhere(r => r.ReqRef.Contains(doctype)).ToList();
				return new ReturnData<List<ProcOnlineReq>>
                {
                    Success = true,
                    Data = onlineRequests
                };
            }
            catch (Exception ex)
            {
                return new ReturnData<List<ProcOnlineReq>>
                {
                    Success = false,
                    Message = "Sorry, An error occured"
                };
            }
        }

        public ReturnData<dynamic> GetEmployees(string usercode)
        {
            try
            {
                var employee = _unitOfWork.HrpEmployee.GetFirstOrDefault(e => e.EmpNo.ToLower().Equals(usercode.ToLower()));
                if (employee == null)
                    return new ReturnData<dynamic>
                    {
                        Success = false,
                        Message = "Sorry, we could not find your details"
                    };

                var service = _unitOfWork.HrpService
                                        .GetWhere(s => s.EmpNo.ToUpper().Equals(usercode.ToUpper()))
                    .OrderByDescending(s => s.Id).FirstOrDefault();
                var accountNo = _unitOfWork.hrpEmpAccNo.GetFirstOrDefault(n => n.Ref.ToUpper().Equals(service.Id.ToString().ToUpper()));
				var accountBank = accountNo?.Bank ?? "";
				var bank = _unitOfWork.hrpBank.GetFirstOrDefault(b => b.Code.ToUpper().Equals(accountBank.ToUpper()));
                var bankDetails = $"{bank?.Bank}, {bank?.Branch} [ACC. NO. {accountNo?.AccNo}]";
                employee.Supervisor = employee?.Supervisor ?? "";
                var supervisor = _context.HrpEmployee.FirstOrDefault(e => e.EmpNo.ToUpper().Equals(employee.Supervisor.ToUpper()));

                bankDetails = bank?.Bank ?? "";
				var details = new
                {
                    employee.Names,
                    employee.EmpNo,
                    employee.Pin,
                    employee.Idno,
                    employee.Department,
                    employee.Title,
                    employee.Nhif,
                    employee.Nssf,
					employee.Supervisor,
                    employee.JobCat,
                    service.JobTitle,
                    SupervisorName = supervisor?.Names ?? "",
                    Pgrade = service?.Pgrade ?? "",
                    Bank = bankDetails ?? "",
                    employee.LeaveGroup,
                    employee.Cell,
                    employee.County,
                    employee.County2,
                    employee.Country,
                    employee.Address,
                    employee.City,
                    employee.Pemail,
                    employee.Wemail,
                    employee.EmpCat
                };
                return new ReturnData<dynamic>
                {
                    Success = true,
                    Data = details
                };
            }
            catch (Exception ex)
            {
                return new ReturnData<dynamic>
                {
                    Success = false,
                    Message = "Sorry, An error occured"
                };
            }
        }

        public ReturnData<List<HrpLeaveApp>> GetLeaveApplication()
        {
            try
            {
                var leaveApplications = _unitOfWork.HrpLeaveApp.GetAll().ToList();
                if (!leaveApplications.Any())
                    return new ReturnData<List<HrpLeaveApp>>
                    {
                        Success = false,
                        Message = "No current leave applications",
                    };

                return new ReturnData<List<HrpLeaveApp>>
                {
                    Success = true,
                    Message = "Current leave applications",
                    Data = leaveApplications,
                };
            }
            catch (Exception e)
            {
                return new ReturnData<List<HrpLeaveApp>>
                {
                    Success = false,
                    Message = "Sorry, An error occured",
                };
            }
        }

        public ReturnData<HrpIpprofile> GetIpProfile(string userCode)
        {
            var profile = _unitOfWork.HrpIpprofile.GetFirstOrDefault(p => p.EmpNo.ToLower().Equals(userCode.ToLower()));
            if (profile != null)
                return new ReturnData<HrpIpprofile>
                {
                    Success = false,
                    Message = "We could not find employment data"
                };

            return new ReturnData<HrpIpprofile>
            {
                Success = true,
                Data = profile,
                Message = "Employment data found"
            };
        }

        public ReturnData<HrpJobTitles> GetJobTitle(string userCode)
        {
            var service = _unitOfWork.HrpService
                     .GetWhere(s => s.EmpNo.ToLower().Equals(userCode.ToLower()))
                   .FirstOrDefault();
            if (service == null)
            {
                return new ReturnData<HrpJobTitles>
                {
                    Data = new HrpJobTitles(),
                    Message = "No service data found"
                };
            }

            var jobTitle = _context.HrpJobTitles
                .Where(jt => jt.Names.Equals(service.JobTitle))
                .FirstOrDefault();

            return new ReturnData<HrpJobTitles>
            {
                Success = true,
                Data = jobTitle ?? new HrpJobTitles(),
                Message = "Employment data found"
            };
        }

        public double GetTaxCharged(double chargeablePay, string pRef)
        {
            pRef = _context.HrpPayemain.FirstOrDefault(x => x.Edate == null).Id.ToString();
            var highestRate = _context.HrpPaye.OrderByDescending(x => x.Tax).FirstOrDefault(i => i.Ref == pRef);

            if (chargeablePay >= Convert.ToDouble(highestRate.MinAmt)) {
                return chargeablePay * (Convert.ToDouble(highestRate.Tax / 100));
            }

            var payees = _context.HrpPaye.OrderBy(p => p.Tax).Where(p => p.Ref.Equals(pRef)).ToList();
            
            double runningTax = 0;
            foreach (var payee in payees)
            {
                if (chargeablePay <= 0)
                    break;
                var low = Convert.ToDouble(payee.MinAmt);
                if (payee.MaxAmt.Contains("NONE"))
                {
                    var tax = (chargeablePay - low) * (Convert.ToDouble(payee.Tax.Value) / 100);
                    runningTax += tax;
                    break;
                }
                var high = Convert.ToDouble(payee.MaxAmt);
                if (chargeablePay > low)
                {
                    if (chargeablePay < high)
                    {
                        var remTax = (chargeablePay - low) * (Convert.ToDouble(payee.Tax.Value) / 100);
                        runningTax += remTax;
                        break;
                    }
                    var tax = (high - low) * (Convert.ToDouble(payee.Tax.Value) / 100);
                    runningTax += tax;
                }
                else
                {
                    var tax = (chargeablePay - high) * (Convert.ToDouble(payee.Tax.Value) / 100);
                    runningTax += tax;
                }
            }
            return runningTax;
        }

        public ReturnData<List<HrpPayAcc>> GetAccounts()
        {
            try
            {
                var columnAccs = _unitOfWork.HrpPayAcc.GetAll().ToList();
                if (columnAccs.Count < 1)
                    return new ReturnData<List<HrpPayAcc>>
                    {
                        Success = false,
                        Message = "Sorry, No payment account fount"
                    };
                return new ReturnData<List<HrpPayAcc>>
                {
                    Success = true,
                    Data = columnAccs
                };
            }
            catch (Exception ex)
            {
                return new ReturnData<List<HrpPayAcc>>
                {
                    Success = false,
                    Message = "Sorry, An error occured"
                };
            }
        }

        public ActiveAccountMainClass ReturnPayslipActiveColumns(string userCode, string month)
        {
            try
            {
                var columns = _unitOfWork.HrpSalProcess.GetActiveAccounts(_configuration).OrderBy(l => l[0]).ToList();
                var listActiveAmountOnColumns = _unitOfWork.HrpSalProcess.GetAccountsAmount(_configuration, columns, staffUtilities, month, userCode).ToList();
                var accountsAmountList = new List<AccountAmountViewModel>();
                if (listActiveAmountOnColumns.Count < 1)
                    return new ActiveAccountMainClass
                    {
                        AccountAmountViewModel = accountsAmountList,
                        ActiveAccounts = columns
                    };

                var counter = 0;
                columns.ForEach(column =>
                {
                    accountsAmountList.Add(
                        new AccountAmountViewModel
                        {
                            AccountName = column,
                            Amount = listActiveAmountOnColumns[counter],
                        }
                    );
                    counter++;
                });

                return new ActiveAccountMainClass
                {
                    AccountAmountViewModel = accountsAmountList,
                    ActiveAccounts = columns
                };
            }
            catch (Exception ex)
            {
                return new ActiveAccountMainClass();
            }
        }

        public ReturnData<List<HrpSalPeriod>> GetSalaryPeriods()
        {
            try
            {
                var salaryPeriods = _unitOfWork.HrpSalPeriod.GetAll().ToList();
                if (salaryPeriods.Count < 1)
                    return new ReturnData<List<HrpSalPeriod>>
                    {
                        Success = false,
                        Message = "Sorry, Salary periods not found"
                    };

                return new ReturnData<List<HrpSalPeriod>>
                {
                    Success = true,
                    Data = salaryPeriods
                };
            }
            catch (Exception)
            {
                return new ReturnData<List<HrpSalPeriod>>
                {
                    Success = false,
                    Message = "Sorry, An error occured"
                };
            }
        }

        public ReturnData<List<LeaveDaysSum>> GetEmpLeaveDays(string empNo)
        {
            try
            {
                var leaveGroup = GetEmployees(empNo).Data?.LeaveGroup;

                var lvDays = _unitOfWork.HrpEmployee.GetAll()
                    .Select(lvGroupJoin => new { lvGroupJoin.Names, lvGroupJoin.LeaveGroup, lvGroupJoin.EmpNo })
                    .Join(_unitOfWork.HrpLeaveEntit.GetAll(),
                    lvEntitJoin => lvEntitJoin.EmpNo,
                        emp => emp.EmpNo,
                        (lvEntitJoin, emp) =>
                            new
                            {
                                lvEntitJoin.Names,
                                emp.LeaveDays,
                                emp.LeaveType,
                                lvEntitJoin.LeaveGroup,
                                lvEntitJoin.EmpNo
                            })
                    .Join(_unitOfWork.HrpLeaveType.GetAll(),
                    lvTypeJoin => lvTypeJoin.LeaveType,
                    lt => lt.Names, (lvTypeJoin, lt) => new
                    {
                        lt.Names,
                        lvTypeJoin.EmpNo,
                        lvTypeJoin.LeaveDays,
                        lt.Code,
                        lvTypeJoin.LeaveGroup,
                        lvTypeJoin.LeaveType
                    }).Where(res =>
                   res.EmpNo.CaseInsensitiveContains(empNo))
                   .ToList();

                if (!leaveGroup.ToLower().Contains("none") && !string.IsNullOrEmpty(leaveGroup))
                {

                    _unitOfWork.HrpEmployee.GetAll()
                        .Join(_unitOfWork.HrpLeaveGroups.GetAll(),
                         lvGroupJoin => lvGroupJoin.LeaveGroup,
                       lg => lg.Names,
                       (lvGroupJoin, lg) =>
                           new { lvGroupJoin.Names, lvGroupJoin.LeaveGroup, lvGroupJoin.EmpNo })
                        .Join(_unitOfWork.HrpLeaveEntit.GetAll(),
                        lvEntitJoin => lvEntitJoin.EmpNo,
                       emp => emp.EmpNo,
                       (lvEntitJoin, emp) =>
                           new
                           {
                               lvEntitJoin.Names,
                               emp.LeaveDays,
                               emp.LeaveType,
                               lvEntitJoin.LeaveGroup,
                               lvEntitJoin.EmpNo
                           })
                        .Join(_unitOfWork.HrpLeaveType.GetAll(),
                        lvTypeJoin => lvTypeJoin.LeaveType,
                       lt => lt.Names, (lvTypeJoin, lt) => new
                       {
                           lt.Names,
                           lvTypeJoin.EmpNo,
                           lvTypeJoin.LeaveDays,
                           lt.Code,
                           lvTypeJoin.LeaveGroup,
                           lvTypeJoin.LeaveType
                       }).Where(res =>
                      res.EmpNo.CaseInsensitiveContains(empNo))
                      .ToList();
                }

                var daysList = lvDays.Select(x => new LeaveDaysSum
                {
                    LeaveDays = x.LeaveDays,
                    LeaveType = x.LeaveType,
                    LeaveGroup = x.LeaveGroup,
                    Code = x.Code
                }).ToList();

                return new ReturnData<List<LeaveDaysSum>>
                {
                    Success = true,
                    Data = daysList
                };
            }
            catch (Exception ex)
            {
                return new ReturnData<List<LeaveDaysSum>>
                {
                    Success = false,
                    Message = "Sorry, An error occured"
                };
            }
        }

        public ReturnData<List<LeaveDaysSum>> GetEmpLeaveDaysCredit(string empNo)
        {
            try
            {
                var leaveCrdts = new List<LeaveDaysSum>();
                var leaveGroup = _unitOfWork.HrpEmployee.GetFirstOrDefault(e => e.EmpNo.ToLower().Equals(empNo.ToLower())).LeaveGroup ?? "";

                var currentLeavePeriod = _unitOfWork.HrpLeavePeriod.GetAll().OrderByDescending(y => y.EndDate)
                    .FirstOrDefault(l => l.StartDate.Year == DateTime.UtcNow.Year)?.Names ??
                    DateTime.UtcNow.Year.ToString();

                var entitledLeaves = _unitOfWork.HrpLeaveEntit.GetAll().Join(_unitOfWork.HrpLeaveType.GetAll(), le => le.LeaveType.ToUpper(),
                    lt => lt.Names.ToUpper(), (le, lt) => new
                    {
                        le.EmpNo,
                        le.LeaveType,
                        lt.Code,
						lt.Emergency,
                        Closed = Convert.ToBoolean(lt.Closed),
                        le.LeavePeriod
                    })
					.Where(l => !l.Closed && l.EmpNo.ToUpper().Equals(empNo.ToUpper()) && l.LeavePeriod == currentLeavePeriod).ToList();
                var distinctEntitledLvs = entitledLeaves.GroupBy(d => d.LeaveType)
                    .Select(g => g.First()).ToList();
                if (!distinctEntitledLvs.Any())
                    return new ReturnData<List<LeaveDaysSum>>
                    {
                        Success = false,
                        Data = leaveCrdts,
                        Message = "No entitled leaves found"
                    };
                foreach (var lve in distinctEntitledLvs)
                {
					var entitledLeave = GetUserLeavesEntitled(lve.EmpNo, lve.LeaveType);
					var takenLeave = GetUserLeavesTaken(lve.EmpNo, lve.LeaveType);

					var leaveDaySum = new LeaveDaysSum
                    {
                        LeaveType = lve.LeaveType,
                        LeaveDays = entitledLeave - takenLeave,
                        Code = lve.Code,
						Emergency = lve.Emergency,
						LeaveGroup = leaveGroup
                    };
                    leaveCrdts.Add(leaveDaySum);
                }

                return new ReturnData<List<LeaveDaysSum>>
                {
                    Success = true,
                    Data = leaveCrdts,
                    Message = "Entitled leaves found"
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ReturnData<List<LeaveDaysSum>>
                {
                    Success = false,
                    Message = "Sorry, An error occured"
                };
            }
        }

        public decimal GetUserLeavesEntitled(string userCode, string leaveType)
        {
            var currentLeavePeriod = _unitOfWork.HrpLeavePeriod.GetAll().OrderByDescending(y => y.EndDate)
                .FirstOrDefault(l => l.StartDate.Year == DateTime.UtcNow.Year)?.Names;
            var leaveGroup = _unitOfWork.HrpEmployee.GetFirstOrDefault(e => e.EmpNo.ToLower().Equals(userCode.ToLower())).LeaveGroup;
            var leaveDaysEntitled = 0.0m;
            var hasGroup = string.IsNullOrEmpty(leaveGroup) ? false : true;
            if (!hasGroup)
                return 0;
            var leaveRule = _unitOfWork.HrpLeaveRules.GetWhere(x => x.LeaveType.ToUpper().Equals(leaveType.ToUpper()) 
			&& x.LeaveGroup.ToUpper().Equals(leaveGroup.ToUpper())).OrderByDescending(i=>i.Id).FirstOrDefault();

			if (leaveRule == null)
				return 0;

            if (leaveRule.Accrue) {
                leaveDaysEntitled = GetAccumulation(currentLeavePeriod, userCode, leaveType);
            }
            if (!leaveRule.Accrue) {
                var leaveEntitleds = _unitOfWork.HrpLeaveEntit.GetWhere(e => e.LeavePeriod.ToLower().Equals(currentLeavePeriod.ToLower())
            && e.EmpNo.ToLower().Equals(userCode.ToLower()) && e.LeaveType.ToLower().Equals(leaveType.ToLower()) && e.Sdate < DateTime.UtcNow).ToList();
                if (!leaveEntitleds.Any())
                    return 0;
                foreach (var leave in leaveEntitleds)
                {
                    leaveDaysEntitled += Convert.ToDecimal(leave.LeaveDays ?? 0);
                }
            }
            

            return leaveDaysEntitled;
        }

        public decimal GetAccumulation(string currentLeavePeriod, string userCode, string leaveType) {
            var accumulation = 0.0m;
            var period = _unitOfWork.HrpLeavePeriod.GetFirstOrDefault(x => x.Names == currentLeavePeriod);
            if (DateTime.Now < period.StartDate) {
                return accumulation;
            }
            var balance = GetTempOpenningBalance(currentLeavePeriod, userCode, leaveType);
            var timeDiff = GetTimeDifference(period.StartDate);
            accumulation = accumulation + Convert.ToDecimal((timeDiff * 1.75));

            return accumulation + balance;
        }

        public decimal GetTempOpenningBalance(string currentLeavePeriod, string userCode, string leaveType) {
            var balance = _unitOfWork.HrpLeaveEntit.GetWhere(x=>x.EmpNo == userCode && x.LeavePeriod == currentLeavePeriod && 
            x.LeaveType == leaveType).ToList().Sum(i=>i.LeaveDays);

            return Convert.ToDecimal(balance);
        }

        public int GetTimeDifference(DateTime startDate)
        {
            var timeSpan = DateTime.Now - startDate;
            const double daysToMonths = 30.4368499;
            var months = timeSpan.TotalDays / daysToMonths ;

            return Convert.ToInt32(Math.Abs(months));
        }

        private decimal GetUserLeavesTaken(string userCode, string leaveType)
        {

            var currentLeavePeriod = _unitOfWork.HrpLeavePeriod.GetAll().OrderByDescending(y => y.EndDate)
                .FirstOrDefault(l => l.StartDate.Year == DateTime.UtcNow.Year)?.Names;

            var leaveGroup = _unitOfWork.HrpEmployee.GetFirstOrDefault(e => e.EmpNo.ToLower().Equals(userCode.ToLower())).LeaveGroup;
            var leaveDaysTaken = 0.0m;
            var hasGroup = string.IsNullOrEmpty(leaveGroup) ? false : true;
            if (!hasGroup)
                return 0;

            var leaveApps = _unitOfWork.HrpLeaveApp.GetWhere(a => a.EmpNo.ToLower().Equals(userCode.ToLower())
            && a.LeavePeriod.ToLower().Equals(currentLeavePeriod.ToLower()) && a.LeaveType.ToLower().Equals(leaveType.ToLower())
            && a.Status.Contains("Approved")).ToList();
            foreach (var leave in leaveApps)
            {
                leaveDaysTaken += Convert.ToDecimal(leave.LeaveDays ?? 0);
            }
            return leaveDaysTaken;
        }

        public ReturnData<List<Pclaim>> GetStaffClaims(string empNo)
        {
            try
            {
                var claims = _unitOfWork.Pclaim.GetWhere(c => c.PayeeRef.ToLower().Equals(empNo.ToLower())).ToList();

                return new ReturnData<List<Pclaim>>
                {
                    Success = true,
                    Data = claims
                };
            }
            catch (Exception ex)
            {
                return new ReturnData<List<Pclaim>>
                {
                    Success = false,
                    Message = "Sorry, An error occured"
                };
            }
        }

        public ReturnData<Wfrouting> GetWfRouting(string docType)
        {
            try
            {
                var wfRouting = _unitOfWork.Wfrouting.GetFirstOrDefault(r => r.Document.ToUpper().Equals(docType.ToUpper()));
                if (wfRouting == null)
                    return new ReturnData<Wfrouting>
                    {
                        Success = false,
                        Message = "Sorry, " + docType.ToLower() + " not supported at the moment. Please contact the admin"
                    };
                return new ReturnData<Wfrouting>
                {
                    Success = true,
                    Data = wfRouting
                };
            }
            catch
            {
                return new ReturnData<Wfrouting>
                {
                    Success = false,
                    Message = "Sorry, An error occurred"
                };
            }
        }

        public ReturnData<List<string>> GetUnitOfMeasure()
        {
            try
            {
                var uom = _unitOfWork.ItemUom.GetWhere(i => !(bool)i.Closed).Select(i => i.Names).Distinct().ToList();
                return new ReturnData<List<string>>
                {
                    Success = true,
                    Data = uom
                };
            }
            catch (Exception ex)
            {
                return new ReturnData<List<string>>
                {
                    Success = false,
                    Message = "Sorry, an error occurred"
                };
            }
        }

        public ReturnData<dynamic> GetProcItems(string searchText)
        {
            try
            {
                var procItems = _unitOfWork.ProcItems.GetWhere(i => !(bool)i.Closed && i.Description.CaseInsensitiveContains(searchText))
                    .Select(i => new { i.Code, i.Description, i.Uom, }).ToList();

                if (procItems.Count < 1)
                    return new ReturnData<dynamic>
                    {
                        Success = false,
                        Message = "Sorry, Currently, There are no items in the store. Kindly contact admin"
                    };
                return new ReturnData<dynamic>
                {
                    Success = true,
                    Data = procItems
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

        public ReturnData<List<HrpEmployee>> FetchEmployees()
        {
            try
            {
                var employees = _unitOfWork.HrpEmployee.GetAll().ToList();
                return new ReturnData<List<HrpEmployee>>
                {
                    Success = true,
                    Data = employees
                };
            }
            catch (Exception ex)
            {
                return new ReturnData<List<HrpEmployee>>
                {
                    Success = false,
                    Message = "Sorry, An error occurred"
                };
            }
        }

        public ReturnData<List<Eclaim>> GetEClaims(string userCode, string searchText)
        {
            searchText = searchText ?? "";
            try
            {
                var claims = _unitOfWork.Eclaim.GetWhere(e => e.PayeeRef.ToUpper().Equals(userCode.ToUpper())
                && (e.Ecref.ToLower().Contains(searchText.ToLower())
                || e.Ledger.ToLower().Contains(searchText.ToLower())
                || e.Project.ToLower().Contains(searchText.ToLower())
                )).OrderByDescending(e => e.Rdate).ToList();
                return new ReturnData<List<Eclaim>>
                {
                    Success = true,
                    Data = claims
                };
            }
            catch (Exception e)
            {
                return new ReturnData<List<Eclaim>>
                {
                    Success = false,
                    Message = "Sorry, An error occurred"
                };
            }
        }

        public ReturnData<string> AddEClaim(EclaimUnits eclaimUnits, string userCode, string description)
        {
            description = description ?? "";
            try
            {
                var claimRef = GenerateRefNo();
                eclaimUnits.Ecref = claimRef;
                var procOnlineReq = new ProcOnlineReq
                {
                    ReqRef = claimRef,
                    DocType = "IMPREST WARRANT",
                    Rdate = DateTime.UtcNow,
                    Rtime = DateTime.UtcNow,
                    Usercode = userCode,
                    Status = "Pending"
                };

                var docId = _unitOfWork.Wfrouting.GetFirstOrDefault(r => r.Document.ToUpper() == procOnlineReq.DocType.ToUpper())?.Id.ToString();
                if (string.IsNullOrEmpty(docId))
                    return new ReturnData<string>
                    {
                        Success = false,
                        Message = "Sorry, " + procOnlineReq.DocType.ToUpper() + " Not supported at the moment. Please contact the admin"
                    };

                var user = _unitOfWork.HrpEmployee.GetFirstOrDefault(e => e.EmpNo.ToUpper().Equals(userCode.ToUpper()));
                var workFlowStatus = utils.SaveToWorkFlowCenter(procOnlineReq, user, docId);
                if (!workFlowStatus.Success)
                    return workFlowStatus;

                _unitOfWork.EclaimUnits.Add(eclaimUnits);
                _unitOfWork.Eclaim.Add(new Eclaim
                {
                    Ecref = claimRef,
                    PayeeRef = userCode,
                    Description = description.ToUpper(),
                    Status = "Pending",
                    Rdate = DateTime.UtcNow,
                    Personnel = userCode,
                    Amount = eclaimUnits.Amount,
                    Names = $"{user.Title} {user.Names}"
                });

                _unitOfWork.Save();
                return new ReturnData<string>
                {
                    Success = true,
                    Message = "Expense claim added successfully"
                };
            }
            catch (Exception e)
            {
                return new ReturnData<string>
                {
                    Success = false,
                    Message = "Sorry, An error occurred"
                };
            }
        }

        private string GenerateRefNo()
        {
            var eClaims = _unitOfWork.Eclaim.GetAll();
            if (eClaims == null)
                return "EC001";

            var claimsRef = eClaims.OrderByDescending(c => Convert.ToInt32(c.Ecref.Substring(2))).FirstOrDefault();
            if (claimsRef == null)
                return "EC001";

            var count = claimsRef.Ecref.Count();
            var digits = claimsRef.Ecref.Substring(2);
            var sufix = Convert.ToInt32(digits);

            sufix++;

            var RefNo = "EC";
            if (sufix < 10) RefNo += "00" + sufix;

            if ((sufix > 9) && (sufix < 100)) RefNo += "0" + sufix;

            if (sufix > 99) RefNo += "" + sufix;
            return RefNo;
        }

        public ReturnData<HrpSalProcess> GetMonthProcessedSalary(string userCode, string month)
        {
            try
            {
                var salProcess = _unitOfWork.HrpSalProcess.GetFirstOrDefault(p => p.EmpNo.ToUpper().Equals(userCode.ToUpper()) && p.Speriod.ToUpper().Equals(month.ToUpper()));
                return new ReturnData<HrpSalProcess>
                {
                    Success = true,
                    Data = salProcess
                };
            }
            catch (Exception e)
            {
                return new ReturnData<HrpSalProcess>
                {
                    Success = false,
                    Message = "An error occurred"
                };
            }
        }

        public ReturnData<double> GetBalance(string accType, string userCode, string code, string accName, string month)
        {
            try
            {
                var balance = _unitOfWork.HrpSalProcess.GetBalance(accType, userCode, code, _configuration, accName, month);
                return new ReturnData<double>
                {
                    Success = true,
                    Data = balance
                };
            }
            catch (Exception e)
            {
                return new ReturnData<double>
                {
                    Success = false,
                    Message = "An error occurred"
                };
            }
        }
    }
}
