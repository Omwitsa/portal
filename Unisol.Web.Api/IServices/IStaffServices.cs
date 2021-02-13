using System.Collections.Generic;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Leave;
using Unisol.Web.Common.ViewModels.Payslip;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.IServices
{
    public interface IStaffServices
    {
        ReturnData<List<ProcOnlineReq>> GetOnlineRequest(string doctype);
        ReturnData<dynamic> GetEmployees(string usercode);
        decimal GetUserLeavesEntitled(string userNo, string leaveType);
        double GetTaxCharged(double chargeablePay, string pRef);
        ReturnData<List<HrpLeaveApp>> GetLeaveApplication();
        ReturnData<HrpIpprofile> GetIpProfile(string userCode);
        ReturnData<HrpJobTitles> GetJobTitle(string userCode);
        ReturnData<List<Eclaim>> GetEClaims(string userCode, string searchText);
        ReturnData<List<HrpPayAcc>> GetAccounts();
        ActiveAccountMainClass ReturnPayslipActiveColumns(string userCode, string month);
        ReturnData<string> AddEClaim(EclaimUnits eclaimUnits, string userCode, string description);
        ReturnData<List<HrpSalPeriod>> GetSalaryPeriods();
        ReturnData<List<LeaveDaysSum>> GetEmpLeaveDays(string empNo);
        ReturnData<List<LeaveDaysSum>> GetEmpLeaveDaysCredit(string empNo);
        ReturnData<List<Pclaim>> GetStaffClaims(string empNo);
        ReturnData<Wfrouting> GetWfRouting(string docType);
        ReturnData<List<string>> GetUnitOfMeasure();
        ReturnData<dynamic> GetProcItems(string searchText);
        ReturnData<List<HrpEmployee>> FetchEmployees();
        ReturnData<HrpSalProcess> GetMonthProcessedSalary(string userCode, string month);
        ReturnData<double> GetBalance(string accType, string userCode, string code, string accName, string month);
    }
}
