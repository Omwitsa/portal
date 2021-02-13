using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.IRepository
{
	public interface IMarkSheetRepository : IGenericRepository<MarkSheet>
	{
		IEnumerable<MarksheetResults> GetStudentResults(TranscriptRequestViewModel transcriptModel, string institutionInitials, IConfiguration configuration);
	}
}
