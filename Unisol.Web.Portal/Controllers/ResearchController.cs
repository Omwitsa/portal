using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.Utilities;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Utilities;

namespace Unisol.Web.Portal.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class ResearchController : Controller
	{
		private readonly PortalCoreContext _context;
		IConfiguration _configuration;
		private readonly IUnisolApiProxy _unisolApiProxy;
		IHostingEnvironment _env;
		SystemService systemService;

		public ResearchController(PortalCoreContext context, IConfiguration configuration, IUnisolApiProxy unisolApiProxy, IHostingEnvironment env)
		{
			_context = context;
			_env = env;
			_configuration = configuration;
			_unisolApiProxy = unisolApiProxy;
			systemService = new SystemService(context, env);
		}

		[HttpGet("[action]")]
		public JsonResult GetPublications(string usercode, Role role, DateTime? from, DateTime? to, string type)
		{
			try
			{
				var publication = _context.Publication.Where(c => c.Author.ToUpper().Equals(usercode.ToUpper())).ToList();
				if (role == Role.Admin)
					publication = _context.Publication.Where(c => c.CreatedDate >= from && c.CreatedDate <= to && c.Type.ToUpper().Equals(type.ToUpper())).ToList();

				publication = publication.OrderByDescending(p => p.CreatedDate).ToList();
				var result = _unisolApiProxy.GetStaffs().Result;
				var response = new ProcessJsonReturnResults<List<HrpEmployee>>(result).UnisolApiData;
				var publications = new List<dynamic>();
				publication.ForEach(p =>
				{
					var name = response?.Data?.FirstOrDefault(e => e.EmpNo.ToUpper().Equals(p.Author.ToUpper()))?.Names ?? "";
					publications.Add(new {
						p.Id,
						p.Year,
						p.Author,
						p.Title,
						p.Type,
						p.Url,
						p.CreatedDate,
						p.FileUrl,
						p.ToPage,
						p.FromPage,
						p.PublicationPlace,
						p.Publisher,
						p.BookISBN,
						p.JournalTitle,
						p.BookTitle,
						name
					});
				});

				//var val = response?.Data?.
				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = publications
				});
			}
			catch (Exception)
			{
				return Json(new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpPost("[action]")]
		public JsonResult CreatePublication(Publication publication)
		{
			try
			{
				if (string.IsNullOrEmpty(publication.Title))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide publication title"
					});

				if (string.IsNullOrEmpty(publication.Type))
					return Json(new ReturnData<string> {
						Success = false,
						Message = "Kindly provide publication type"
					});

				if (string.IsNullOrEmpty(publication.Year))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide publication year"
					});

				_context.Publication.Add(publication);
				_context.SaveChanges();

				return Json(new ReturnData<string>
				{
					Success = true,
					Message = "Publication saved successfully"
				});
			}
			catch (Exception)
			{
				return Json(new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpPost("[action]")]
		public JsonResult UploadDocument(string usercode, string operation)
		{
			var fileDetails = Request.Form.Files.FirstOrDefault();
			var response = systemService.UploadDocument(usercode, operation, fileDetails);
			return Json(response);
		}

		[HttpGet("[action]")]
		public JsonResult GetProjects(string usercode, Role role, DateTime? from, DateTime? to)
		{
			try
			{
				var project = _context.Project.Where(c => c.EmpNo.ToUpper().Equals(usercode.ToUpper())).ToList();
				if (role == Role.Admin)
					project = _context.Project.Where(c => c.CreatedDate >= from && c.CreatedDate <= to && c.NeedApproval).ToList();

				project = project.OrderByDescending(p => p.CreatedDate).ToList();
				var result = _unisolApiProxy.GetStaffs().Result;
				var response = new ProcessJsonReturnResults<List<HrpEmployee>>(result).UnisolApiData;
				var projects = new List<dynamic>();

				project.ForEach(p =>
				{
					var staff = response?.Data?.FirstOrDefault(e => e.EmpNo.ToUpper().Equals(p.EmpNo.ToUpper()));
					TimeSpan? duration = p.EndDate - p.StartDate;
					var period = systemService.GetPeriod(duration);
					projects.Add(new
					{
						p.Id,
						p.EmpNo,
						p.Title,
						p.Status,
						p.NeedApproval,
						p.FundingAgency,
						p.Sponsor,
						p.ContactPerson,
						p.Code,
						p.FileUrl,
						period,
						p.Cost,
						p.CreatedDate,
						p.Reason,
						name = staff?.Names ?? ""
					});
				});

				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = projects
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpGet("[action]")]
		public JsonResult GetProjectDetails(int id)
		{
			try
			{
				var project = _context.Project.Include(p => p.ProjectCoReseachers)
					.Include(p => p.ProjectReports).Include(p => p.ProjectDisbursements).ToList().FirstOrDefault(p => p.Id == id);

				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Data = project
				});
			}
			catch (Exception)
			{
				return Json(new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpPost("[action]")]
		public JsonResult CreateProjects(Project project)
		{
			try
			{
				project.Status = "Pending";
				if (string.IsNullOrEmpty(project.Title))
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide project title"
					});

				if(project.StartDate == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide project start date"
					});

				if (project.EndDate == null)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide project end date"
					});

				if(project.StartDate < DateTime.UtcNow)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, start date must be greater than now"
					});

				if(project.EndDate < project.StartDate)
					return Json(new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, end date must be greater than start date"
					});

				var reportCount = 0;
				var refQuery = "SELECT MAX(CAST(ReportNo AS Real)) as NextNo FROM ProjectReport";
				int.TryParse(GetMaxNo(refQuery), out int refNo);

				project.ProjectCoReseachers.ForEach(r =>
				{
					if (!string.IsNullOrEmpty(r.EmpNo))
					{
						var names = r.EmpNo.Split("-(");
						r.EmpNo = names.Count() > 1 ? names[1].Replace(")", "") : names[0];
					}
				});

				project.ProjectReports.ForEach(r => {
					reportCount++;
					r.ReportNo = $"{refNo + reportCount}";
				});

				refQuery = "SELECT MAX(CAST(InstallmentNo AS Real)) as NextNo FROM ProjectDisbursement";
				int.TryParse(GetMaxNo(refQuery), out refNo);

				var disbursementCount = 0;
				project.ProjectDisbursements.ForEach(r => {
					disbursementCount++;
					r.InstallmentNo = $"{refNo + disbursementCount}";
				});

				if(project.Id > 0)
				{
					var coResearcher = _context.ProjectCoReseacher.Where(p => p.ProjectId == project.Id);
					_context.ProjectCoReseacher.RemoveRange(coResearcher);
					var schedule = _context.ProjectReport.Where(p => p.ProjectId == project.Id);
					_context.ProjectReport.RemoveRange(schedule);
					var disbursement = _context.ProjectDisbursement.Where(p => p.ProjectId == project.Id);
					_context.ProjectDisbursement.RemoveRange(disbursement);
					var projects = _context.Project.Where(p => p.Id == project.Id);
					_context.Project.RemoveRange(projects);
					
				}

				_context.Project.Add(project);
				_context.SaveChanges();

				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Message = "Project submitted successfully"
				});
			}
			catch (Exception ex)
			{
				return Json(new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		private string GetMaxNo(string refQuery)
		{
			var connetionString = DbSetting.ConnectionString(_configuration, "Portal");
			SqlConnection connection = new SqlConnection(connetionString);
			if (connection.State == ConnectionState.Closed)
				connection.Open();

			var sqlCommand = new SqlCommand(refQuery, connection);
			var reader = sqlCommand.ExecuteReader();
			var refNo = "";
			while (reader.Read())
			{
				refNo = reader[0]?.ToString() ?? "";
			}
			
			sqlCommand.Dispose();
			connection.Close();

			return refNo;
		}

		[HttpPost("[action]")]
		public JsonResult ApproveDeclineProject(Project approvedProject)
		{
			try
			{
				var project = _context.Project.FirstOrDefault(p => p.Id == approvedProject.Id);
				project.Reason = approvedProject?.Reason ?? "";
				project.Code = approvedProject?.Code ?? "";
				project.Status = approvedProject?.Status ?? "";
				_context.SaveChanges();
				return Json(new ReturnData<string> {
					Success = true,
					Message = "Project status modified"
				});
			}
			catch (Exception)
			{
				return Json(new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}

		[HttpGet("[action]")]
		public JsonResult DeleteProject(int id)
		{
			try
			{
				var coResearcher = _context.ProjectCoReseacher.Where(p => p.ProjectId == id);
				_context.ProjectCoReseacher.RemoveRange(coResearcher);
				var schedule = _context.ProjectReport.Where(p => p.ProjectId == id);
				_context.ProjectReport.RemoveRange(schedule);
				var disbursement = _context.ProjectDisbursement.Where(p => p.ProjectId == id);
				_context.ProjectDisbursement.RemoveRange(disbursement);
				var projects = _context.Project.Where(p => p.Id == id);
				_context.Project.RemoveRange(projects);
				_context.SaveChanges();
				return Json(new ReturnData<dynamic>
				{
					Success = true,
					Message = "Project deleted successfully"
				});
			}
			catch (Exception)
			{
				return Json(new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				});
			}
		}
	}
}
