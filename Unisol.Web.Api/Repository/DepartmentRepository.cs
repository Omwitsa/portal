using System.Collections;
using System.Linq;
using Unisol.Web.Api.IRepository;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Repository
{
	public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
	{
		private UnisolAPIdbContext _context;
		public DepartmentRepository(UnisolAPIdbContext context) : base(context)
		{
			_context = context;
		}

		public IEnumerable GetStaffDepartments()
		{
			var departments = _context.Department.Where(d => d.Closed == false).Select(d => d.Names).Distinct().ToList();
			return departments;
		}
	}
}
