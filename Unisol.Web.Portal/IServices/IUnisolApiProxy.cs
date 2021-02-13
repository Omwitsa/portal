using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unisol.Web.Common.ViewModels.Academics;
using Unisol.Web.Common.ViewModels.Claims;
using Unisol.Web.Common.ViewModels.Evaluations;
using Unisol.Web.Common.ViewModels.Finance;
using Unisol.Web.Common.ViewModels.HostelBooking;
using Unisol.Web.Common.ViewModels.Leave;
using Unisol.Web.Common.ViewModels.Login;
using Unisol.Web.Common.ViewModels.Memo;
using Unisol.Web.Common.ViewModels.Profile;
using Unisol.Web.Common.ViewModels.Reporting;
using Unisol.Web.Common.ViewModels.Sor;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Entities.Database.UnisolModels;
using Unisol.Web.Portal.Models;

namespace Unisol.Web.Portal.IServices
{
    public interface IUnisolApiProxy
    {
        Task<string> CheckStudentExists(string admNo, string classStatus);
        Task<string> CheckEmployeeExists(string empNo);
        Task<string> GetEmployees();
        Task<string> CreateAnSor(CreateSorModel createSorModel);
        Task<string> GetSors(string usercode);
		Task<string> GetRetakes(string userCode);
		Task<string> GetSorItems(string reqref);
        Task<string> GetImprestMemo(string usercode, string searchText);
        Task<string> AddSorItems(AddItems addItems);
        Task<string> GetStudentProgram(string registrationNumber, string year, string classStatus);
		Task<string> GetStaffs();
		Task<string> GetIpPaySlip(string userCode, string project);
		Task<string> GetRetakeUnits(string userCode, string classStatus);
		Task<string> GetIpProjects(string userCode);
		Task<string> GetAcademicYears();
        Task<string> GetFleetBookings(string usercode, string searchText);
        Task<string> GetEClaims(string userCode, string searchText);
        Task<string> GetSemesters(int yearId);
        Task<string> GetHostels();
        Task<string> CreateIR(CreateSorModel createIR, string usercode);
        Task<string> GetMemoResources(string usercode);
        Task<string> GetMyBookings(string usercode, bool fetchLatestHostel, string classStatus);
        Task<string> GetHostelRooms(string hostel, string searchRoom);
		Task<string> SaveRetake(RetakeModel retake, string classStatus);
		Task<string> GetReciepients(string userName);
        Task<string> GetUserFleetDetails(string usercode);
        Task<string> SubmitBooking(HostelBookingModel hostelBookingModel, string classStatus, string hostelRatio);
        Task<string> GetBookableHostels(string usercode, string classStatus);
        Task<string> GetRoomsForBooking(string hostel, string usercode, string searchString, string classStatus, string hostelRatio);
        Task<string> CheckBookingEligibility(string usercode, string classStatus);
		Task<string> ReguestMemo(MemoViewModel memoModel, string usercode);
		Task<string> GetRetakeDetails(string userCode, int retakeId);
		Task<string> GetUnitOfMeasure();
        Task<string> AddEClaim(EclaimUnits claimUnits, string userCode, string description);
        Task<string> ReturnEvaluationTargetSearch(SectionSearchViewModel searchObject);
        Task<string> GetYearsOfStudy(string regNo, string classStatus);
        Task<string> GetAssignedVehicles(string usercode, string searchText);
        Task<string> BookVehicle(FLBooking booking);
        Task<string> GetSemisterUnits(string regNo, string classStatus);
        Task<string> GetOnlineReporting(string usercode, string classStatus);
        Task<string> ReportOnline(ReportOnlineViewModel reportOnlineViewModel, string classStatus);
        Task<string> GetStudentCurrentTerm(string usercode, string classStatus);
        Task<string> CurrectActiveTerm(string usercode, string classStatus);
        Task<string> CheckReportStatus(string usercode, string classStatus);
        Task<string> GetRegisteredUnits(string usercode, string classStatus);
        Task<string> GetStudentDetails(string usercode, string classStatus, bool isPreviousTermCard = false);
        Task<string> RegisterUnits(UnitRegistrationViewModel regunits, string classStatus);
        Task<string> GetStudentCurriculum(string usercode, string classStatus);
        Task<string> ReturnStudentCurrentSemesterUnits(string userCode, string classStatus, string unitLevel);
        Task<string> SaveStudentCurrentSemesterUnits(CurriculumUnitsModel curriculumUnits, string classStatus);
        Task<string> GetStudentUnitRegisteredHistory(string userCode, string classStatus);
        Task<string> GetStudentExamCard(string userCode, string classStatus, bool isPreviousTermCard);
        Task<string> GetStudentProvisionalTranscript(TranscriptRequestViewModel transcriptRequestViewModel, string classStatus);
        Task<string> GetStudentPreviousAcademicYears(string userCode, string classStatus);
        Task<string> GetStudentData(string userCode, string classStatus);
        Task<string> GetStudentEnrollment(string userCode, string classStatus);
        Task<string> GetStaffData(string userCode);
        Task<string> GetJobTitle(string userCode);
        Task<string> EditStudentProfile(StudentprofileViewModel profileViewModel, string classStatus, ProfileEditor editOperation);
        Task<string> EditStaffProfile(StaffProfileViewModel profileViewModel);
        Task<string> ApplyLeave(HrpLeaveApp leave, bool leaveRelieverMandatory);
        Task<string> GetEmpApplications(string empNo);
        Task<string> GetLeaveApplications(string status);
        Task<string> GetByLeaveRef(string appRef);
        Task<string> GetEmpLeaveDays(string appRef);
        Task<string> GetLeaveDaysCredit(string appRef);
        Task<string> GetValidLeaveDays(GetDaysRequest request);
        Task<string> GetStudentFeeStatement(string userCode, string classStatus);
        Task<string> GetStudentFeeStructure(FeesStructureFilter feesStructureFilter, string classStatus);
        Task<string> GetStudentFeeStructureYears(string progCode, string classStatus);
        Task<string> GetStudentInfoWithDepartment(string userCode, string classStatus);
        Task<string> GetStudentFeeInfo(string userCode, string classStatus);
        /*claims*/
        Task<string> GetClaimRates();
        Task<string> GetEmployeeClaimsSummary(string userCode, string searchString);
        Task<string> GetEmployeeTermsForClaim();
        Task<string> GetUnitsForAddingClaim(string unitNames);
        Task<string> GetClaimDetails(string pcref);
        Task<string> SaveEmployeeClaimDetails(List<ClaimDetailsViewModel> claimDetailsViewModel);
        Task<string> SaveImprest(ImprestReq imprestReq);
        Task<string> GetEmployeeImprest(string userCode, string searchString);
        Task<string> GetEmployeePayslip(string userCode, string month);
        Task<string> GetPayslipYears();
        Task<string> GetPayslipPeriod(string year);
        Task<string> GetStudentAcademicSemstersOfStudy();
        Task<string> GetStudentYearsOfStudy();
        Task<string> GetEmployeeLoans(string userCode);
        Task<string> GetEmployeeLoanStatement(string userCode, int refId);
        Task<string> GetInstitutionInfo();
        Task<string> GetEmpPnine(string userCode, int year);
        Task<string> GetStudentFucultyInfo(string userCode, string classStatus);
        Task<string> GetClassStatus();
        Task<string> GetEmploymentProfile(string userCode);
        Task<string> GetIR(string usercode);
        Task<string> GetGenesisStatus();
        Task<string> GetStudentUnitDetails(string userCode, string unitCode, string classStatus);
        Task<string> ApplyClearance(StudClearance clearance, Role role);
        Task<string> GetClearances(string admnNo, Role role);
        Task<string> GetErpUsers(Role bunchRole);
        Task<string> GetStudAcademicInfo();
		Task<string> DeallocateHostel(string classStatus);
		Task<string> GetWorkOrders(string userCode);
		Task<string> OrderWork(ESWorkRequest workRequest, bool isUpdate = false);
		Task<string> GetUserWorkRequestDetails(string usercode);
		Task<string> GetWorkOrderDetails(string usercode, string orderRef);
		Task<string> GetUnitLecturer(string usercode);
		Task<string> GetStudyTimetable(RegisterViewModel reg, string classStatus);
		Task<string> GetExamTimetable(RegisterViewModel reg, string classStatus);
		Task<string> GetLecturerStudyTimetable(RegisterViewModel reg);
		Task<string> GetLecturerExamTimetable(RegisterViewModel reg);
		Task<string> LecturerAllocationSammary(RegisterViewModel reg);
		Task<string> UpdatePortalEmails();
		Task<string> GetSurveyStatus(string usercode);
		Task<string> GetCertificateDetails(string usercode, bool isStudent);
		Task<string> ApproveLeave(LeaveApproveVm leaveApprove);
		Task<string> GetCurrentHostel(string userCode, string classStatus);
        Task<string> GetEmployeeGrades();
    }

	public class UnisolApiProxy : IUnisolApiProxy
    {
        private readonly string _unisolApiUrl;
        private IConfiguration _configuration { get; }

        public UnisolApiProxy(IConfiguration _configuration)
        {
            _unisolApiUrl = _configuration["Urls:UnisolApiUrl"];
        }

        public UnisolApiProxy(string unisolApiUrl)
        {
            _unisolApiUrl = unisolApiUrl;
        }

        public Task<string> CheckStudentExists(string admNo, string classStatus)
        {
            var data = new RegisterViewModel
            {
                RegNumber = admNo
            };
            var response = Post("users/CheckStudentExists/?classStatus=" + classStatus, data);
            return response;
        }

        public Task<string> CheckEmployeeExists(string empNo)
        {
            var data = new RegisterViewModel
            {
                RegNumber = empNo
            };
            var response = Post("users/CheckEmployeeExists/", data);
            return response;
        }


        public Task<string> GetSors(string usercode)
        {
            var response = Get("sor/getsorsraised/?usercode=" + usercode);
            return response;
        }

        public Task<string> GetSorItems(string reqref)
        {
            var response = Get("sor/getsordetails/?reqref=" + reqref);
            return response;
        }

        public Task<string> CreateAnSor(CreateSorModel createSorModel)
        {
            var response = Post("sor/createansor/", createSorModel);
            return response;
        }

        public Task<string> AddSorItems(AddItems addItems)
        {
            var response = Post("sor/additems/", addItems);
            return response;
        }

        public Task<string> ReturnEvaluationTargetSearch(SectionSearchViewModel searchObject)
        {
            var response = Post("department/ReturnEvaluationTargetSearch/", searchObject);
            return response;
        }


        public Task<string> GetAcademicYears()
        {
            var response = Get("Academic/GetAcademicYears/");
            return response;
        }

        public Task<string> GetHostels()
        {
            var response = Get("Hostel/GetAvailHostels/");
            return response;
        }

        public Task<string> GetHostelRooms(string hostel, string searchRoom)
        {
            var response = Get("Hostel/GetHostelRooms/?hostel=" + hostel + "&searchRoom=" + searchRoom);
            return response;
        }

        public Task<string> GetMyBookings(string usercode, bool fetchLatestHostel, string classStatus)
        {
            var response = Get("HostelBooking/gethostelbookingrequests/?usercode=" + usercode + "&fetchLatestHostel=" +
                               fetchLatestHostel + "&classStatus=" + classStatus);
            return response;
        }

        public Task<string> CheckBookingEligibility(string usercode, string classStatus)
        {
            var response = Get("hostelbooking/CheckIfCanBookHostel/?usercode=" + usercode + "&classStatus=" + classStatus);
            return response;
        }

        public Task<string> SubmitBooking(HostelBookingModel hostelBookingModel, string classStatus, string hostelRatio)
        {
            var response = Post($"HostelBooking/bookhostel/?classStatus={classStatus}&hostelRatio={hostelRatio}", hostelBookingModel);
            return response;
        }

        public Task<string> GetRoomsForBooking(string hostel, string usercode, string searchString, string classStatus, string hostelRatio)
        {
            var response = Get($"hostelbooking/getroomswithspace/?hostel={hostel}&usercode={usercode}&searchString={searchString}&classStatus={classStatus}&hostelRatio={hostelRatio}");
            return response;
        }

        public Task<string> GetBookableHostels(string usercode, string classStatus)
        {
            var response = Get("hostelbooking/getopenhostels/?usercode=" + usercode + "&classStatus=" + classStatus);
            return response;
        }

        public Task<string> GetSemesters(int yearId)
        {
            var response = Get("Academic/GetSemesters/?yearId=" + yearId);

            return response;
        }


        public Task<string> GetOnlineReporting(string usercode, string classStatus)
        {
            var response = Get("onlinereporting/GetOnlineReporting/?usercode=" + usercode + "&classStatus=" + classStatus);

            return response;
        }

        public Task<string> ReportOnline(ReportOnlineViewModel reportOnlineViewModel, string classStatus)
        {
            var response = Post("onlinereporting/AddOnlineReporting/?classStatus=" + classStatus, reportOnlineViewModel);

            return response;
        }

        public Task<string> GetStudentCurrentTerm(string usercode, string classStatus)
        {
            var response = Get("databaseutilities/GetStudentTerm/?usercode=" + usercode + "&classStatus=" + classStatus);

            return response;
        }

        public Task<string> CurrectActiveTerm(string usercode, string classStatus)
        {
            var response = Get("databaseutilities/GetCurrectActiveTerm/?usercode=" + usercode + "&classStatus=" + classStatus);

            return response;
        }

        public Task<string> CheckReportStatus(string usercode, string classStatus)
        {
            var response = Get("databaseutilities/GetReportStatus/?usercode=" + usercode + "&classStatus=" + classStatus);

            return response;
        }

        public Task<string> GetRegisteredUnits(string usercode, string classStatus)
        {
            var response = Get("Units/GetCurrentSemUnits/?usercode=" + usercode + "&classStatus=" + classStatus);

            return response;
        }


        public Task<string> GetStudentDetails(string userCode, string classStatus, bool isPreviousTermCard = false)
        {
            var response = Get("Academic/GetStudentAcademicDetails/?usercode=" + userCode + "&classStatus=" + classStatus + "&isPreviousTermCard=" + isPreviousTermCard);
            return response;
        }


        #region REQUESTS

        public async Task<string> Get(string resourceUrl)
        {
            var restClient = new RestClient(_unisolApiUrl);
            var restRequest = new RestRequest(resourceUrl, Method.GET) { RequestFormat = DataFormat.Json };
            var data = await restClient.ExecuteGetTaskAsync(restRequest);
            return data.Content;
        }

        public async Task<string> Post(string resourceUrl, object entity)
        {
            var restClient = new RestClient(_unisolApiUrl);
            var restRequest = new RestRequest(resourceUrl, Method.POST) { RequestFormat = DataFormat.Json };
            restRequest.AddBody(entity);
            var response = await restClient.ExecutePostTaskAsync(restRequest);
            return response.Content;
        }
        #endregion
        public Task<string> GetStudentProgram(string registrationNumber, string year, string classStatus)
        {
            var response = Get("academic/getprogram/?regNo=" + registrationNumber + "&year=" + year + "&classStatus=" + classStatus);
            return response;
        }

        public Task<string> GetYearsOfStudy(string regNo, string classStatus)
        {
            var response = Get("academic/getyearsofstudy/?regNo=" + regNo + "&classStatus=" + classStatus);
            return response;
        }

        public Task<string> GetSemisterUnits(string regNo, string classStatus)
        {
            var response = Get("academic/getsemisterunits/?regNo=" + regNo + "&classStatus=" + classStatus);
            return response;
        }

        public Task<string> RegisterUnits(UnitRegistrationViewModel regunits, string classStatus)
        {
            var response = Post("academic/unitreg/?classStatus=" + classStatus, regunits);
            return response;
        }


        public Task<string> GetStudentCurriculum(string usercode, string classStatus)
        {
            var response = Get("units/GetStudentCurriculum/?userCode=" + usercode + "&classStatus=" + classStatus);
            return response;
        }


        public Task<string> ReturnStudentCurrentSemesterUnits(string usercode, string classStatus, string unitLevel)
        {
            var response = Get($"units/GetCurrentSemesterUnits/?userCode={ usercode }&classStatus={classStatus}&unitLevel={unitLevel}");
            return response;
        }

        public Task<string> GetStudentUnitRegisteredHistory(string usercode, string classStatus)
        {
            var response = Get("units/GetStudentRegistereddUnits/?userCode=" + usercode + "&classStatus=" + classStatus);
            return response;
        }


        public Task<string> SaveStudentCurrentSemesterUnits(CurriculumUnitsModel curriculumUnits, string classStatus)
        {
            var response = Post("units/saveStudentsUnits/?classStatus=" + classStatus, curriculumUnits);
            return response;
        }

        /**Exam cars*/
        public Task<string> GetStudentExamCard(string usercode, string classStatus, bool isPreviousTermCard)
        {
            var response = Get("examcard/GetExamCardUnits/?usercode=" + usercode + "&classStatus=" + classStatus + "&isPreviousTermCard=" + isPreviousTermCard);
            return response;
        }

        public Task<string> GetStudentProvisionalTranscript(TranscriptRequestViewModel transcriptRequestViewModel, string classStatus)
        {
            var response = Post("transcript/GetSelectedYearResults/?classStatus=" + classStatus, transcriptRequestViewModel);
            return response;
        }

        public Task<string> GetStudentPreviousAcademicYears(string userCode, string classStatus)
        {
            var response = Get("databaseutilities/StudentsYearsBeenInSchool?usercode=" + userCode + "&classStatus=" + classStatus);
            return response;
        }

        public Task<string> GetStudentFeeStatement(string userCode, string classStatus)
        {
            var response = Get("finance/GetFeesStatement?usercode=" + userCode + "&classStatus=" + classStatus);
            return response;
        }

        public Task<string> GetStudentFeeStructure(FeesStructureFilter feesStructureFilter, string classStatus)
        {
            var response = Post("finance/GetFeesStructure/?classStatus=" + classStatus, feesStructureFilter);
            return response;
        }

        public Task<string> GetStudentFeeStructureYears(string progCode, string classStatus)
        {
            var response = Get("databaseutilities/GetFeesYears?progCode=" + progCode + "&classStatus=" + classStatus);
            return response;
        }

        public Task<string> GetStudentInfoWithDepartment(string userCode, string classStatus)
        {
            var response = Get("academic/GetStudentDetailsWithDepartment/?userCode=" + userCode + "&classStatus=" + classStatus);
            return response;
        }

        public Task<string> GetStudentData(string userCode, string classStatus)
        {
            var response = Get("profile/getStudentInfo/?userCode=" + userCode + "&classStatus=" + classStatus);
            return response;
        }

        public Task<string> GetStudentEnrollment(string userCode, string classStatus)
        {
            var response = Get("profile/getStudentEnrollmentProfile/?userCode=" + userCode + "&classStatus=" + classStatus);
            return response;
        }

        public Task<string> GetStaffData(string userCode)
        {
            var response = Get("profile/getStaffInfo/?userCode=" + userCode);
            return response;
        }

        public Task<string> GetJobTitle(string userCode)
        {
            var response = Get("profile/getJobTitle/?userCode=" + userCode);
            return response;
        }

        public Task<string> EditStudentProfile(StudentprofileViewModel profileViewModel, string classStatus, ProfileEditor editOperation)
        {
            var response = Post($"profile/upadateStudentProfile/?classStatus={classStatus}&editOperation={editOperation}", profileViewModel);
            return response;
        }

        public Task<string> EditStaffProfile(StaffProfileViewModel profileViewModel)
        {
            var response = Post("profile/upadateStaffProfile/", profileViewModel);
            return response;
        }

        public Task<string> ApplyLeave(HrpLeaveApp leave, bool leaveRelieverMandatory)
        {
            var response = Post($"leave/applyLeave?leaveRelieverMandatory={leaveRelieverMandatory}", leave);
            return response;
        }

        public Task<string> GetEmpApplications(string empNo)
        {
            var response = Get("leave/getForEmployee?empNo=" + empNo);
            return response;
        }

        public Task<string> GetLeaveApplications(string status)
        {
            var response = Get("leave/getAll?status=" + status);
            return response;
        }

        public Task<string> GetByLeaveRef(string appRef)
        {
            var response = Get("leave/getByRef?appRef=" + appRef);
            return response;
        }

        public Task<string> GetEmpLeaveDays(string empNo)
        {
            var response = Get("leave/getEmpLeaveDays?empNo=" + empNo);
            return response;
        }
        public Task<string> GetLeaveDaysCredit(string empNo)
        {
            var response = Get("leave/getLeaveDaysCredit?empNo=" + empNo);
            return response;
        }
        public Task<string> GetValidLeaveDays(GetDaysRequest request)
        {
            var response = Post("leave/removeNonLeaveDays", request);
            return response;
        }

        public Task<string> GetStudentFeeInfo(string userCode, string classStatus)
        {
            var response = Get("finance/GetFeesInfo?usercode=" + userCode + "&classStatus=" + classStatus);
            return response;
        }


        public Task<string> GetClaimRates()
        {
            var response = Get("Claims/GetPClaimRates");
            return response;
        }

        public Task<string> GetEmployeeClaimsSummary(string userCode, string searchString)
        {
            var response = Get("Claims/GetPClaimSummary?userCode=" + userCode + "&searchString=" + searchString);
            return response;
        }

        public Task<string> GetEmployeeTermsForClaim()
        {
            var response = Get("Claims/GetTermsForClaim");
            return response;
        }

        public Task<string> GetUnitsForAddingClaim(string unitNames)
        {
            var response = Get("Claims/GetUnitsForClaim?searchString=" + unitNames);
            return response;
        }

        public Task<string> GetClaimDetails(string pcref)
        {
            var response = Get("Claims/GetPClaimDetails?claimRef=" + pcref);
            return response;
        }

        public Task<string> SaveEmployeeClaimDetails(List<ClaimDetailsViewModel> claimDetailsViewModel)
        {
            var response = Post("claims/SaveMainClaim/", claimDetailsViewModel);
            return response;
        }

        public Task<string> SaveImprest(ImprestReq imprestReq)
        {
            var response = Post("imprest/SaveEmployeeImprest/", imprestReq);
            return response;
        }

        public Task<string> GetEmployeeImprest(string userCode, string searchString)
        {
            var response = Get("imprest/GetImprest/?userCode=" + userCode + "&searchString=" + searchString);
            return response;
        }
		
        public Task<string> GetEmployeePayslip(string userCode, string month)
        {
            var response = Get("payslip/getpayslip/?userCode=" + userCode + "&month=" + month);
            return response;
        }

        public Task<string> GetPayslipYears()
        {
            var response = Get("payslip/ReturnPayYears/");
            return response;
        }

        public Task<string> GetPayslipPeriod(string year)
        {
            var response = Get("payslip/ReturnPayPeriods/?year=" + year);
            return response;
        }

        public Task<string> GetStudentAcademicSemstersOfStudy()
        {
            var response = Get("academic/GetAcademicSemestersOfStudy/");
            return response;
        }

        public Task<string> GetStudentYearsOfStudy()
        {
            var response = Get("academic/GetStudyYears/");
            return response;
        }

        public Task<string> GetEmployeeLoans(string userCode)
        {
            var response = Get("loans/GetLoansList/?userCode=" + userCode);
            return response;
        }

        public Task<string> GetEmployeeLoanStatement(string userCode, int refId)
        {
            var response = Get("loans/GetLoanStatement/?userCode=" + userCode + "&refId=" + refId);

            return response;
        }

        public Task<string> GetInstitutionInfo()
        {
            var response = Get("databaseutilities/GetInstitutionHeaderDetails/");

            return response;
        }
		
        public Task<string> GetEmpPnine(string userCode, int year)
        {
            var response = Get("pnine/GetP9List/?userCode=" + userCode + "&year=" + year);

            return response;
        }
		
        public Task<string> GetStudentFucultyInfo(string userCode, string classStatus)
        {
            var response = Get("Academic/GetStudentFuculty/?userCode=" + userCode + "&classStatus=" + classStatus);

            return response;
        }

        public Task<string> GetClassStatus()
        {
            var response = Get("academic/ReturnClassStatus");

            return response;
        }

        public Task<string> GetEmploymentProfile(string userCode)
        {
            var response = Get("profile/getEmploymentData?userCode=" + userCode);
            return response;
        }

        public Task<string> GetIR(string usercode)
        {
            var response = Get("ir/getStaffIR/?usercode=" + usercode);
            return response;
        }

        public Task<string> GetGenesisStatus()
        {
            var response = Get("users/checkIfGenesis");
            return response;
        }

        public Task<string> CreateIR(CreateSorModel createIR, string usercode)
        {
            var response = Post("ir/CreateIR?=" + usercode, createIR);
            return response;
        }

        public Task<string> GetStudentUnitDetails(string userCode, string unitCode, string classStatus)
        {
            var response = Get("Academic/getStudUnitDetails/?userCode=" + userCode + "&unitCode=" + unitCode + "&classStatus=" + classStatus);
            return response;
        }

        public Task<string> ApplyClearance(StudClearance clearance, Role role)
        {
            var response = Post("clearances/apply?role=" + role, clearance);
            return response;
        }

        public Task<string> GetClearances(string admnNo, Role role)
        {
            var response = Get($"clearances/history/?admnNo={admnNo}&role={role}");
            return response;
        }

        public Task<string> GetErpUsers(Role bunchRole)
        {
            var response = Get("users/getBunchUsers/?role=" + bunchRole);
            return response;
        }

        public Task<string> GetEmployees()
        {
            var response = Get("users/fetchEmployees");
            return response;
        }

        public Task<string> GetFleetBookings(string usercode, string searchText)
        {
            var response = Get("fleet/getFleetBookings/?usercode=" + usercode + "&searchText=" + searchText);
            return response;
        }

        public Task<string> GetUserFleetDetails(string usercode)
        {
            var response = Get("fleet/GetUserFleetDetails/?usercode=" + usercode);
            return response;
        }

        public Task<string> BookVehicle(FLBooking booking)
        {
            var response = Post("fleet/bookVehicle", booking);
            return response;
        }

        public Task<string> GetAssignedVehicles(string usercode, string searchText)
        {
            var response = Get("fleet/getAssignedVehicles/?usercode=" + usercode + "&searchText" + searchText);
            return response;
        }

        public Task<string> GetEClaims(string userCode, string searchText)
        {
            var response = Get("eClaims/getEClaims/?userCode=" + userCode + "&searchText=" + searchText);
            return response;
        }

        public Task<string> AddEClaim(EclaimUnits eclaimUnits, string userCode, string description)
        {
            var response = Post("eClaims/addEClaim?userCode=" + userCode + "&description=" + description, eclaimUnits);
            return response;
        }

        public Task<string> GetUnitOfMeasure()
        {
            var response = Get("eClaims/getUnitOfMeasure");
            return response;
        }

        public Task<string> GetReciepients(string userName)
        {
            var response = Get("users/GetMessageRecepients/?username=" + userName);
            return response;
        }

        public Task<string> GetStudAcademicInfo()
        {
            var response = Get("Campus/GetStudAcademicInfo");
            return response;
        }

        public Task<string> GetImprestMemo(string usercode, string searchText)
        {
            var response = Get("memo/getImprestMemo/?usercode=" + usercode + "&searchText=" + searchText);
            return response;
        }

        public Task<string> GetMemoResources(string usercode)
        {
            var response = Get("memo/getMemoResources/?usercode=" + usercode);
            return response;
        }

		public Task<string> ReguestMemo(MemoViewModel memoModel, string usercode)
		{
			var response = Post("memo/reguestMemo/?usercode=" + usercode, memoModel);
			return response;
		}

		public Task<string> GetIpProjects(string userCode)
		{
			var response = Get("ipPayslip/getIpProjects/?userCode=" + userCode);
			return response;
		}

		public Task<string> GetIpPaySlip(string userCode, string project)
		{
			var response = Get("ipPayslip/getIpPaySlip/?userCode=" + userCode + "&project="+ project);
			return response;
		}

		public Task<string> GetRetakes(string userCode)
		{
			var response = Get("retake/getRetakes/?userCode=" + userCode);
			return response;
		}

		public Task<string> GetRetakeUnits(string userCode, string classStatus)
		{
			var response = Get("retake/getRetakeUnits/?userCode=" + userCode + "&classStatus=" + classStatus);
			return response;
		}

		public Task<string> SaveRetake(RetakeModel retake, string classStatus)
		{
			var response = Post("retake/saveRetake?classStatus="+ classStatus, retake);
			return response;
		}

		public Task<string> GetRetakeDetails(string userCode, int retakeId)
		{
			var response = Get("retake/getRetakeDetails/?userCode=" + userCode + "&retakeId="+ retakeId);
			return response;
		}

		public Task<string> DeallocateHostel(string classStatus)
		{
			var response = Get($"hostelbooking/deallocateHostel?classStatus={classStatus}");
			return response;
		}

		public Task<string> GetWorkOrders(string userCode)
		{
			var response = Get("workRequest/getWorkOrders?usercode=" + userCode);
			return response;
		}

		public Task<string> OrderWork(ESWorkRequest workRequest, bool isUpdate = false)
		{
			var response = Post($"workRequest/orderWork?isUpdate={isUpdate}", workRequest);
			return response;
		}

		public Task<string> GetUserWorkRequestDetails(string usercode)
		{
			var response = Get("workRequest/getUserWorkRequestDetails/?usercode=" + usercode);
			return response;
		}

		public Task<string> GetWorkOrderDetails(string usercode, string orderRef)
		{
			var response = Get($"workRequest/GetWorkOrderDetails/?usercode={usercode}&orderRef={orderRef}");
			return response;
		}

		public Task<string> GetUnitLecturer(string usercode)
		{
			var response = Get("units/getUnitLecturer/?usercode=" + usercode);
			return response;
		}

		public Task<string> GetStudyTimetable(RegisterViewModel reg, string classStatus)
		{
			var response = Post($"campus360Academics/getStudentsStudyTimetable?classStatus={classStatus}", reg);
			return response;
		}

		public Task<string> GetExamTimetable(RegisterViewModel reg, string classStatus)
		{
			var response = Post($"campus360Academics/getStudentsExamTimetable?classStatus={classStatus}", reg);
			return response;
		}

		public Task<string> GetLecturerStudyTimetable(RegisterViewModel reg)
		{
			var response = Post($"campus360Academics/getLecturerStudyTimetable", reg);
			return response;
		}

		public Task<string> GetLecturerExamTimetable(RegisterViewModel reg)
		{
			var response = Post($"campus360Academics/getLecturerExamTimetable", reg);
			return response;
		}

		public Task<string> LecturerAllocationSammary(RegisterViewModel reg)
		{
			var response = Post($"campus360Academics/lecturerAllocationSammary", reg);
			return response;
		}

		public Task<string> UpdatePortalEmails()
		{
			var response = Get("users/updatePortalEmails");
			return response;
		}

		public Task<string> GetCertificateDetails(string usercode, bool isStudent)
		{
			var response = Get($"clearances/getCertificateDetails/?usercode={usercode}&isStudent={isStudent}");
			return response;
		}

		public Task<string> GetSurveyStatus(string usercode)
		{
			var response = Get($"clearances/getSurveyStatus/?usercode={usercode}");
			return response;
		}

		public Task<string> ApproveLeave(LeaveApproveVm leaveApprove)
		{
			var response = Post("leave/approveLeave", leaveApprove);
			return response;
		}

		public Task<string> GetCurrentHostel(string userCode, string classStatus)
		{
			var response = Get("hostelbooking/getCurrentHostel/?usercode=" + userCode + "&classStatus=" + classStatus);
			return response;
		}

		public Task<string> GetStaffs()
		{
			var response = Get("profile/getStaffs");
			return response;
		}

        public Task<string> GetEmployeeGrades()
        {
            var response = Get("profile/getEmployeeGrades");
            return response;
        }
    }
}