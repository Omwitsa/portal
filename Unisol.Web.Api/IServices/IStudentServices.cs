using System;
using System.Collections.Generic;
using Unisol.Web.Common.Process;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Common.ViewModels.Users;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.IServices
{
	public interface IStudentServices
	{
		ReturnData<bool> CheckIfGenesis();
		ReturnData<Register> GetRegister(string userCode, bool? isCampusApi = false);
		ReturnData<List<Register>> GetActiveStudents();
		ReturnData<StudEnrolment> GetEnrollment(string userCode, string classStatus, bool? isCampusApi = false);
		ReturnData<Class> GetClass(string userCode, string classStatus, bool? isCampusApi = false);
		ReturnData<Term> GetCurrentTerm(string userCode, string classStatus);
		ReturnData<Term> GetPreviousTerm(string userCode, string classStatus);
		string GetCurrentTermByDate(string studentclass, DateTime serverdate);
		ReturnData<Csplanner> GetSessionPlanner(string userCode, string classStatus, bool isPreviousTermCard = false);
		ReturnData<List<CsplannerDetail>> GetSessionPlannerDetails(string userCode, string classStatus);
		ReturnData<CsplannerDetail> GetSessionPlannerCurrentDetails(string userCode, string classStatus, bool isPreviousTermCard = false);
		ReturnData<OnlineReporting> CheckOnlineReporting(string userCode, string classStatus, bool isPreviousTermCard = false);
		ReturnData<Reporting> CheckErpReporting(string userCode, string classStatus, bool isPreviousTermCard = false);
		ReturnData<Programme> GetProgramme(string userCode, string classStatus, bool? isCampusApi = false);
		ReturnData<Department> GetDepartment(string userCode, string classStatus);
		ReturnData<ProgUnitReg> GetCurrentUnitRegistration(string userCode, string classStatus);
		ReturnData<List<ProgUnitRegDetail>> GetCurrentUnitRegistrationDetails(string userCode, string classStatus);
		ReturnData<dynamic> GetAcademicProfile(string userCode, string classStatus);
		ReturnData<List<FormattedSubjects>> GetSemisterSubjects(string userCode, string classStatus);
		ReturnData<List<Term>> GetSelectedYearSemisters(TranscriptRequestViewModel transcriptModel, string classStatus, bool isCumulative = false);
		ReturnData<List<Accounts>> GetAccounts();
		ReturnData<List<StudInvoice>> GetInvoice(string userCode);
		ReturnData<List<StudInvoiceAdj>> GetInvoiceAdj(string userCode);
		ReturnData<List<ReceiptBookCanc>> GetReceiptBookCancellations();
		ReturnData<List<ReceiptBook>> GetReceiptBook(string userCode);
		ReturnData<List<StudSponsorBdcanc>> GetSponserCancellations();
		ReturnData<List<Grading>> GetGradings(string userCode, string classStatus);
		ReturnData<List<StudentCurriculumViewModel>> GetStudentCurriculum(string userCode, string classStatus);
		ReturnData<List<MarkSymbols>> GetMarkSymbols();
		ReturnData<StudTranscriptsPortalResults> GetResultsRecommendation(string usercode, string year);
		ReturnData<FeesPolicy> GetFeePolicy(string userCode, string names);
		ReturnData<FeesPolicy> GetFeeActivePolicy(string userCode);
		ReturnData<List<StudentStatementModelVirtual>> GetInvoicedAmount(string userCode, string finalStudentInvoiceCols);
		ReturnData<dynamic> GetAllProgrammes();
		ReturnData<dynamic> GetStudentUnitDetails(string userCode, string unitCode, string classStatus);
		ReturnData<List<YearTranscriptViewModel>> GetSelectedYearResults(TranscriptRequestViewModel transcriptModel, string classStatus, string institutionInitials, bool? isCampusApi = false, bool isCumulative = false);
		ReturnData<List<StudentCurriculumViewModel>> GetStudentRegistereddUnits(string userCode, string classStatus);
		DoneStatus ReturnDoneStatus(string userCode, string unitCode, string names);
		List<StudentCurriculumViewModel> GetCurriculum(List<CurriculumModel> curriculumSubjects, string userCode, string classStatus, string unitLevel);
		int? ReturnCurriculumProgRef(string userCode, string classStatus);
		ReturnData<List<string>> RegisteredUnitCodes(string userCode, string classStatus);
		ReturnData<UserViewModel> ValidateUser(string userCode);
		ReturnData<List<UserViewModel>> GetActiveStudentsWithEmails(int page, int perPage);
		ReturnData<List<UserViewModel>> GetActiveStaffWithEmails(int page, int perPage);
		ReturnData<int> StudentCount();
		ReturnData<int> StaffCount();
	}
}
