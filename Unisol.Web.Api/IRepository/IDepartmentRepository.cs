using System.Collections;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.IRepository
{
	public interface IDepartmentRepository : IGenericRepository<Department>
	{
		IEnumerable GetStaffDepartments();
	}
}
