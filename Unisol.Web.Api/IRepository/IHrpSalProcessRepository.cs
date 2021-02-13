using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Unisol.Web.Api.StudentUtilities;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.IRepository
{
	public interface IHrpSalProcessRepository : IGenericRepository<HrpSalProcess>
	{
		IEnumerable<string> GetActiveAccounts(IConfiguration configuration);
		IEnumerable<string> GetAccountsAmount(IConfiguration configuration, List<string> activeAccounts, StaffUtilities staffUtilities, string month, string userCode);
		double GetBalance(string accType, string userCode, string code, IConfiguration configuration, string accName, string month);
		double GetIpTax(IConfiguration configuration, HrpSalPeriod salaryPeriod, string userCode);
	}
}
