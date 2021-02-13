using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Portal.Utilities
{
	public class SystemService
	{
		IHostingEnvironment _env;
		PortalCoreContext _context;
		public SystemService(PortalCoreContext context, IHostingEnvironment env)
		{
			_env = env;
			_context = context;
		}

		public ReturnData<string> UploadDocument(string usercode, string operation, IFormFile fileDetails)
		{
			try
			{
				usercode = usercode ?? "";
				if (fileDetails == null || fileDetails.Length < 1)
					return new ReturnData<string>
					{
						Success = false,
						Message = "Failed to upload the file"
					};

				var fileName = ContentDispositionHeaderValue.Parse(fileDetails.ContentDisposition).FileName.Trim('"');
				var endPoint = $"Documents\\{operation}\\{usercode}";

				var folderPath = Path.Combine(_env.WebRootPath, endPoint);
				if (!Directory.Exists(folderPath))
					Directory.CreateDirectory(folderPath);

				var fullPath = Path.Combine(folderPath, fileName);
				using (var stream = new FileStream(fullPath, FileMode.Create))
				{
					fileDetails.CopyTo(stream);
				}
				endPoint = Path.Combine(endPoint, fileName);
				if (operation.Equals("publication"))
				{
					var publication = _context.Publication.OrderByDescending(p => p.CreatedDate)
					.FirstOrDefault(p => p.Author.ToUpper().Equals(usercode.ToUpper()));
					publication.FileUrl = endPoint.Replace("\\", "/").ToLower();
				}
				if (operation.Equals("project"))
				{
					var project = _context.Project.OrderByDescending(p => p.CreatedDate)
					.FirstOrDefault(p => p.EmpNo.ToUpper().Equals(usercode.ToUpper()));
					project.FileUrl = endPoint.Replace("\\", "/").ToLower();
				}

				_context.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Documents uploaded successfully"
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public string GetPeriod(TimeSpan? duration)
		{
			var workedHours = duration.GetValueOrDefault().Hours + (duration.GetValueOrDefault().Days * 24);
			var label = workedHours > 1 ? "Hrs" : "Hr";
			var hours = "";
			if (workedHours > 0)
				hours = $"{workedHours} {label}";
			label = duration.GetValueOrDefault().Minutes > 1 ? "Mins" : "Min";
			var minutes = "";
			if (duration.GetValueOrDefault().Minutes > 0)
				minutes = $"{duration.GetValueOrDefault().Minutes} {label}";

			hours = string.IsNullOrEmpty(hours) || string.IsNullOrEmpty(minutes) ? hours : $"{hours} :";
			var period = $"{hours} {minutes}";

			return period;
		}
	}
}
