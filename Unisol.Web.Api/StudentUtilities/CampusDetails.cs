using System;
using System.Collections.Generic;
using System.Linq;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Common.ViewModels.Institution;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.StudentUtilities
{
	public class CampusDetails
	{
		private readonly UnisolAPIdbContext _context;
		public CampusDetails(UnisolAPIdbContext context)
		{
			_context = context;
		}
		public ReturnData<List<CampusesViewModel>> GetUniversityCampuses()
		{
			var universityCampuses = _context.Campuses.Where(c => c.Closed == false).ToList();
			if (universityCampuses == null)
				return new ReturnData<List<CampusesViewModel>>
				{
					Success = false,
					Message = "Sorry, We could not find university campuses",
				};

			var campuses = new List<CampusesViewModel>();
			foreach(var campus in universityCampuses)
			{
				campuses.Add(new CampusesViewModel {
					CampusId = _context.Campuses.FirstOrDefault(c => c.Names == campus.Names).Id,
					CampusName = campus.Names
				});
			}
			
			return new ReturnData<List<CampusesViewModel>>
			{
				Success = true,
				Message = "University campuses found",
				Data = campuses
			};
		} 
		public ReturnData<InstitutionViewModel> GetUniversityInfo()
		{
			var universityInfo = _context.SysSetup.FirstOrDefault();
			if (universityInfo == null)
				return new ReturnData<InstitutionViewModel>
				{
					Success = false,
					Message = "Sorry, We could not find your university details, Please contact School Admin.",
				};
			
			return new ReturnData<InstitutionViewModel>
			{
				Success = true,
				Message = "University details found",
				Data = new InstitutionViewModel
				{
					UniversityName = universityInfo.OrgName,
					UniversityInitials = universityInfo.SubTitle,
					Location = universityInfo.Location,
					Address = universityInfo.Contacts.Replace("\r\n", ", ")
				}
			};
		}

		public ReturnData<dynamic> GetStudAcademicInfo()
		{
			try
			{
				var universityCampuses = GetUniversityCampuses().Data.Select(c => c.CampusName).Distinct().ToList();
				var universityDepartments = GetUniversityDepartments().Data.Select(d => d.Name).Distinct().ToList();
				var schools = _context.Schools.Select(s => s.Names).ToList();
				var years = _context.CsplannerDetail.OrderBy(p => p.Id).Select(p => p.Stage).Distinct().ToList();
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						universityCampuses,
						universityDepartments,
						schools,
						years
					}
				};
			}
			catch (Exception e)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "An error occurred"
				};
			}
		}

		public ReturnData<List<DepartmentsViewModel>> GetUniversityDepartments()
		{
			
			var universityDepartments = _context.Department.Where(p => p.Tuition == true && p.Closed == false).Select(p => p.Names).Distinct().ToList();
			if (universityDepartments == null)
				return new ReturnData<List<DepartmentsViewModel>>
				{
					Success = false,
					Message = "Sorry, No university departments found, Please contact School Admin.",
				};
			var departments = new List<DepartmentsViewModel>();
			foreach(var department in universityDepartments)
			{
				var DepartmentProgrammes = _context.Programme.Where(p => p.Department == department).ToList();
				DepartmentProgrammes = DepartmentProgrammes ?? new List<Programme>();
				var programmes = new List<ProgrammesViewModel>();
				foreach (var programme in DepartmentProgrammes)
				{
					programmes.Add(new ProgrammesViewModel
					{
						Code = programme.Code ?? "",
						Name = programme.Names ?? "",
						GradeType = programme.GradeType ?? "",
						CertType = programme.CertType ?? "",
						Period = programme.Period ?? ""
					});
				}
				var departmentId = _context.Department.FirstOrDefault(d => d.Names == department).Id;
				departments.Add(new DepartmentsViewModel {
					DepartmentId = departmentId,
					Name = department,
					Programmes = programmes
				});
			}

			return new ReturnData<List<DepartmentsViewModel>>
			{
				Success = true,
				Message = "University departments found",
				Data = departments
			};
		}
		public ReturnData<List<ClassViewModel>> GetUniversityClasses()
		{
			var universityClasses = _context.Class.Where(c => c.Ends > DateTime.Now).ToList();
			if (universityClasses == null)
				return new ReturnData<List<ClassViewModel>>
				{
					Success = false,
					Message = "Sorry, No classes found. Please contact School Admin.",
				};

			var classModels = new List<ClassViewModel>();

			foreach (var universityClass in universityClasses)
			{
				var progCode = _context.Programme.FirstOrDefault(p => p.Names == universityClass.Programme)?.Code;
				classModels.Add(new ClassViewModel {
					Name = universityClass.Id,
					Programme = universityClass.Programme,
					ProgrammeCode = progCode
				});
			}

			return new ReturnData<List<ClassViewModel>>
			{
				Success = true,
				Message = "University classes found",
				Data = classModels
			};
		}
	}
}
