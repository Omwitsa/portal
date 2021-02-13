using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Evaluations;
using Unisol.Web.Common.ViewModels.Login;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly UnisolAPIdbContext _context;

        public DepartmentController(UnisolAPIdbContext context)
        {
            _context = context;
        }

        [HttpPost("[action]")]
        public JsonResult ReturnEvaluationTargetSearch([FromBody] SectionSearchViewModel searchObject)
        {
            var sectionSearch = new List<SectionSearch>();
            if(searchObject.TargetType == TargetDepartmentLevel.Faculty)
            {
                var faculties = _context.Schools.Where(s => !(bool)s.Closed && s.Names.ToUpper().Contains(searchObject.SearchString.ToUpper())).Take(15);
                if (faculties.Any())
                    faculties.ToList().ForEach(d =>
                    {
                        sectionSearch.Add(new SectionSearch
                        {
                            Id = d.Id,
                            Names = d.Names,
                            Extras = d.Notes
                        });
                    });
            }

            if(searchObject.TargetType == TargetDepartmentLevel.Department)
            {
                var depts = _context.Department.Where(d => (bool)d.Tuition && !(bool)d.Closed && d.Names.ToUpper().Contains(searchObject.SearchString.ToUpper())).Take(15);
                if(depts.Any())
                    depts.ToList().ForEach(d =>
                    {
                        sectionSearch.Add(new SectionSearch
                        {
                            Id = d.Id,
                            Names = d.Names,
                            Extras = d.School
                        });
                    });
            }
            if (searchObject.TargetType == TargetDepartmentLevel.Program)
            {
                var programs = _context.Programme.Where(d => !(bool)d.Closed && d.Names.ToUpper().Contains(searchObject.SearchString.ToUpper())).Take(15);
                if (programs.Any())
                    programs.ToList().ForEach(d =>
                    {
                        sectionSearch.Add(new SectionSearch
                        {
                            Id = d.Id,
                            Names = d.Names,
                            Extras = d.Notes
                        });
                    });
            }

            if (searchObject.TargetType == TargetDepartmentLevel.Class)
            {
                var academicClass = _context.Class
                    .Where(d => d.Starts > DateTime.UtcNow && d.Ends < DateTime.UtcNow && d.Id.ToUpper()
                    .Contains(searchObject.SearchString.ToUpper())).Take(15);
                if (academicClass.Any())
                    academicClass.ToList().ForEach(d =>
                    {
                        sectionSearch.Add(new SectionSearch
                        {
                            Id = 0,
                            Names = d.Id,
                            Extras = d.Notes
                        });
                    });
            }

            if (searchObject.TargetType == TargetDepartmentLevel.Student)
            {
                var academicClass = _context.Register.Where(d => !(bool)d.Closed && d.Names.ToUpper().Contains(searchObject.SearchString.ToUpper())).Take(15);
                if (academicClass.Any())
                    academicClass.ToList().ForEach(d =>
                    {
                        sectionSearch.Add(new SectionSearch
                        {
                            Id = d.Id,
                            Names = d.Names,
                            Extras = d.Email
                        });
                    });
            }

            var message = sectionSearch.Count > 0 ? "Details Have been found" : "No search records found";
            return Json(new ReturnData<List<SectionSearch>>
            {
                Success = sectionSearch.Count > 0,
                Data = sectionSearch,
                Message = message
            });
        }

        
    }
}