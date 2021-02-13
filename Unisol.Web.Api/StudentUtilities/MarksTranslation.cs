using System.Linq;
using System.Collections.Generic;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Common.Process;
using Unisol.Web.Api.IRepository;

namespace Unisol.Web.Common.StudentUtilities
{
	public class MarksTranslation
	{
		private IUnitOfWork _unitOfWork;
		public MarksTranslation(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public ReturnData<List<EndstandTranslated>> GetTranslated(string userCode, List<string> yearSemisters)
		{
			var unitsMarked = _unitOfWork.Endstand.GetWhere(m => m.Matrikelnummer.ToLower().Equals(userCode.ToLower()) && yearSemisters.Contains(m.Begriff)).ToList();
			if (unitsMarked.Count() < 1)
				return new ReturnData<List<EndstandTranslated>>
				{
					Success = false,
					Message = "Sorry, we could not find your marks for the selected year, Please contact School Admin.",
				};

			var gradeApprovals = _unitOfWork.GradeApproval.GetWhere(a => a.StudView == true)
				.Select(a => a.Names.ToUpper()).ToList();
			var decryptedMarksList = new List<EndstandTranslated>();
			unitsMarked.ForEach(u =>
			{
				if (u.Klasse == null)
					u.Klasse = "-";
				if (u.Klasse.Equals(""))
					u.Klasse = "I";

				var decryptUnit = new EndstandTranslated
				{
					AdmnNo = DecryptMarks.DecryptMarksColumn(u.Matrikelnummer),
					Semester = DecryptMarks.DecryptMarksColumn(u.Begriff),
					UnitCode = DecryptMarks.DecryptMarksColumn(u.Thema),
					Type = DecryptMarks.DecryptMarksColumn(u.Art),
					TotalMarks = DecryptMarks.DecryptMarksColumn(u.Partitur),
					StudentNames = DecryptMarks.DecryptMarksColumn(u.Benutzer),
					Grade = DecryptMarks.DecryptMarksColumn(u.Klasse),
					DateCreated = u.Datum,
					ApprovalStatus = DecryptMarks.DecryptMarksColumn(u.Ebene)
				};
				
				if(gradeApprovals.Contains(decryptUnit.ApprovalStatus.ToUpper()))
					decryptedMarksList.Add(decryptUnit);
			});

			return new ReturnData<List<EndstandTranslated>>
			{
				Success = true,
				Message = "Session planner details found",
				Data = decryptedMarksList
			};
		}
	}
}
