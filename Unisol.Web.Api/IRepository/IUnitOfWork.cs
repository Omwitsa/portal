using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.IRepository
{
	public interface IUnitOfWork
	{
		// Custome repositories
		ITermRepository Term { get; }
		IStudentStatementRepository StudentStatementModelVirtual { get; }
		IHrpSalProcessRepository HrpSalProcess { get; }
		IStudInvoiceAdjRepository StudInvoiceAdj { get; }
		IMarkSheetRepository MarkSheet { get; }
		IUsersRepository Users { get; }
		IDepartmentRepository Department { get; }
		// Generic repositories
		IGenericRepository<Register> Register { get; }
		IGenericRepository<StudEnrolment> StudEnrolment { get; }
		IGenericRepository<Class> Class { get; }
		IGenericRepository<Csplanner> Csplanner { get; }
		IGenericRepository<CsplannerDetail> CsplannerDetail { get; }
		IGenericRepository<OnlineReporting> OnlineReporting { get; }
		IGenericRepository<Reporting> Reporting { get; }
		IGenericRepository<Programme> Programme { get; }
		IGenericRepository<ProgUnitReg> ProgUnitReg { get; }
		IGenericRepository<ProgUnitRegDetail> ProgUnitRegDetail { get; }
		IGenericRepository<Subjects> Subjects { get; }
		IGenericRepository<Ttlecturer> Ttlecturer { get; }
		IGenericRepository<TtlecturerUnits> TtlecturerUnits { get; }
		IGenericRepository<Grading> Grading { get; }
		IGenericRepository<Endstand> Endstand { get; }
		IGenericRepository<Accounts> Accounts { get; }
		IGenericRepository<StudInvoice> StudInvoice { get; }
		IGenericRepository<ReceiptBookCanc> ReceiptBookCanc { get; }
		IGenericRepository<ReceiptBook> ReceiptBook { get; }
		IGenericRepository<StudSponsorBdcanc> StudSponsorBdcanc { get; }
		IGenericRepository<MarkSymbols> MarkSymbols { get; }
		IGenericRepository<StudTranscriptsPortalResults> StudTranscriptsPortalResults { get; }
		IGenericRepository<FeesPolicy> FeesPolicy { get; }
		IGenericRepository<ProgCurriculum> ProgCurriculum { get; }
		IGenericRepository<ProgCurriculumDetail> ProgCurriculumDetail { get; }
		IGenericRepository<ProcOnlineReq> ProcOnlineReq { get; }
		IGenericRepository<HrpEmployee> HrpEmployee { get; }
		IGenericRepository<HrpLeaveApp> HrpLeaveApp { get; }
		IGenericRepository<HrpIpprofile> HrpIpprofile { get; }
		IGenericRepository<HrpPayAcc> HrpPayAcc { get; }
		IGenericRepository<HrpSalPeriod> HrpSalPeriod { get; }
		IGenericRepository<HrpLeaveEntit> HrpLeaveEntit { get; }
		IGenericRepository<HrpLeaveType> HrpLeaveType { get; }
		IGenericRepository<HrpLeaveGroups> HrpLeaveGroups { get; }
		IGenericRepository<HrpLeavePeriod> HrpLeavePeriod { get; }
		IGenericRepository<HrpLeaveRules> HrpLeaveRules { get; }
		IGenericRepository<Pclaim> Pclaim { get; }
		IGenericRepository<Wfrouting> Wfrouting { get; }
		IGenericRepository<ItemUom> ItemUom { get; }
		IGenericRepository<ProcItems> ProcItems { get; }
		IGenericRepository<SysSetup> SysSetup { get; }
		IGenericRepository<FLBooking> FLBooking { get; }
		IGenericRepository<FLCategory> FLCategory { get; }
		IGenericRepository<FLTrips> FLTrips { get; }
		IGenericRepository<Eclaim> Eclaim { get; }
		IGenericRepository<EclaimUnits> EclaimUnits { get; }
		IGenericRepository<HrpService> HrpService { get; }
		IGenericRepository<FLVehicle> FLVehicle { get; }
		IGenericRepository<HrpEmpAccNo> hrpEmpAccNo { get; }
		IGenericRepository<HrpBank> hrpBank { get; }
		IGenericRepository<ImprestMemo> ImprestMemo { get; }
		IGenericRepository<ImprestMemoDetail> ImprestMemoDetail { get; }
		IGenericRepository<GradeApproval> GradeApproval { get; }
		IGenericRepository<StudSchools> StudSchools { get; }
		IGenericRepository<StudDependant> StudDependant { get; }
		IGenericRepository<ESWorkRequest> ESWorkRequests { get; }
		IGenericRepository<ESProject> ESProjects { get; }
		IGenericRepository<ESLocation> ESLocation { get; }
		IGenericRepository<ESWorkOrder> ESWorkOrders { get; }
		IGenericRepository<ClassCourse> ClassCourse { get; }
		IGenericRepository<WfdocCentre> WFDocCentre { get; }
		IGenericRepository<WfdocCentreDetails> WFDocCentreDetails { get; }
		IGenericRepository<Sup> Sup { get; }
		int Save();
	}
}
