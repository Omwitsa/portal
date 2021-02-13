using Unisol.Web.Api.IRepository;
using Unisol.Web.Entities.Database.UnisolModels;

namespace Unisol.Web.Api.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private UnisolAPIdbContext _context;
		public UnitOfWork(UnisolAPIdbContext context)
		{
			_context = context;
			Term = new TermRepository(context);
			StudInvoiceAdj = new StudInvoiceAdjRepository(context);
			HrpSalProcess = new HrpSalProcessRepository(context);
			StudentStatementModelVirtual = new StudentStatementRepository(context);
			MarkSheet = new MarkSheetRepository(context);
			Users = new UsersRepository(context);
			Department = new DepartmentRepository(context);
			Register = new GenericRepository<Register>(context);
			StudEnrolment = new GenericRepository<StudEnrolment>(context);
			Class = new GenericRepository<Class>(context);
			ClassCourse = new GenericRepository<ClassCourse>(context);
			Csplanner = new GenericRepository<Csplanner>(context);
			CsplannerDetail = new GenericRepository<CsplannerDetail>(context);
			OnlineReporting = new GenericRepository<OnlineReporting>(context);
			Reporting = new GenericRepository<Reporting>(context);
			Programme = new GenericRepository<Programme>(context);
			ProgUnitReg = new GenericRepository<ProgUnitReg>(context);
			ProgUnitRegDetail = new GenericRepository<ProgUnitRegDetail>(context);
			Subjects = new GenericRepository<Subjects>(context);
			Ttlecturer = new GenericRepository<Ttlecturer>(context);
			TtlecturerUnits = new GenericRepository<TtlecturerUnits>(context);
			Grading = new GenericRepository<Grading>(context);
			Endstand = new GenericRepository<Endstand>(context);
			Accounts = new GenericRepository<Accounts>(context);
			StudInvoice = new GenericRepository<StudInvoice>(context);
			ReceiptBookCanc = new GenericRepository<ReceiptBookCanc>(context);
			ReceiptBook = new GenericRepository<ReceiptBook>(context);
			StudSponsorBdcanc = new GenericRepository<StudSponsorBdcanc>(context);
			MarkSymbols = new GenericRepository<MarkSymbols>(context);
			StudTranscriptsPortalResults = new GenericRepository<StudTranscriptsPortalResults>(context);
			FeesPolicy = new GenericRepository<FeesPolicy>(context);
			ProgCurriculum = new GenericRepository<ProgCurriculum>(context);
			ProgCurriculumDetail = new GenericRepository<ProgCurriculumDetail>(context);
			ProcOnlineReq = new GenericRepository<ProcOnlineReq>(context);
			HrpEmployee = new GenericRepository<HrpEmployee>(context);
			HrpLeaveApp = new GenericRepository<HrpLeaveApp>(context);
			HrpIpprofile = new GenericRepository<HrpIpprofile>(context);
			HrpPayAcc = new GenericRepository<HrpPayAcc>(context);
			HrpSalPeriod = new GenericRepository<HrpSalPeriod>(context);
			HrpLeaveEntit = new GenericRepository<HrpLeaveEntit>(context);
			HrpLeaveType = new GenericRepository<HrpLeaveType>(context);
			HrpLeaveGroups = new GenericRepository<HrpLeaveGroups>(context);
			HrpLeavePeriod = new GenericRepository<HrpLeavePeriod>(context);
			HrpLeaveRules = new GenericRepository<HrpLeaveRules>(context);
			Pclaim = new GenericRepository<Pclaim>(context);
			Wfrouting = new GenericRepository<Wfrouting>(context);
			ItemUom = new GenericRepository<ItemUom>(context);
			ProcItems = new GenericRepository<ProcItems>(context);
			SysSetup = new GenericRepository<SysSetup>(context);
			FLBooking = new GenericRepository<FLBooking>(context);
			FLCategory = new GenericRepository<FLCategory>(context);
			FLTrips = new GenericRepository<FLTrips>(context);
			Eclaim = new GenericRepository<Eclaim>(context);
			EclaimUnits = new GenericRepository<EclaimUnits>(context);
			HrpService = new GenericRepository<HrpService>(context);
			FLVehicle = new GenericRepository<FLVehicle>(context);
			hrpEmpAccNo = new GenericRepository<HrpEmpAccNo>(context);
			hrpBank = new GenericRepository<HrpBank>(context);
			ImprestMemo = new GenericRepository<ImprestMemo>(context);
			ImprestMemoDetail = new GenericRepository<ImprestMemoDetail>(context);
			GradeApproval = new GenericRepository<GradeApproval>(context);
			StudSchools = new GenericRepository<StudSchools>(context);
			StudDependant = new GenericRepository<StudDependant>(context);
			ESWorkRequests = new GenericRepository<ESWorkRequest>(context);
			ESProjects = new GenericRepository<ESProject>(context);
			ESLocation = new GenericRepository<ESLocation>(context);
			ESWorkOrders = new GenericRepository<ESWorkOrder>(context); 
			WFDocCentre = new GenericRepository<WfdocCentre>(context); 
			WFDocCentreDetails = new GenericRepository<WfdocCentreDetails>(context);
			Sup = new GenericRepository<Sup>(context);
		}

		public ITermRepository Term { get; }

		public IStudentStatementRepository StudentStatementModelVirtual { get; }

		public IStudInvoiceAdjRepository StudInvoiceAdj { get; }

		public IUsersRepository Users { get; }

		public IDepartmentRepository Department { get; }

		public IMarkSheetRepository MarkSheet { get; }

		public IGenericRepository<Register> Register { get; }

		public IGenericRepository<StudEnrolment> StudEnrolment { get; }

		public IGenericRepository<Class> Class { get; }

		public IGenericRepository<Csplanner> Csplanner { get; }

		public IGenericRepository<CsplannerDetail> CsplannerDetail { get; }

		public IGenericRepository<OnlineReporting> OnlineReporting { get; }

		public IGenericRepository<Reporting> Reporting { get; }

		public IGenericRepository<Programme> Programme { get; }

		public IGenericRepository<ProgUnitReg> ProgUnitReg { get; }

		public IGenericRepository<ProgUnitRegDetail> ProgUnitRegDetail { get; }

		public IGenericRepository<Subjects> Subjects { get; }

		public IGenericRepository<Ttlecturer> Ttlecturer { get; }

		public IGenericRepository<TtlecturerUnits> TtlecturerUnits { get; }

		public IGenericRepository<Grading> Grading { get; }

		public IGenericRepository<Endstand> Endstand { get; }

		public IGenericRepository<Accounts> Accounts { get; }

		public IGenericRepository<StudInvoice> StudInvoice { get; }

		public IGenericRepository<ReceiptBookCanc> ReceiptBookCanc { get; }

		public IGenericRepository<ReceiptBook> ReceiptBook { get; }

		public IGenericRepository<StudSponsorBdcanc> StudSponsorBdcanc { get; }

		public IGenericRepository<MarkSymbols> MarkSymbols { get; }

		public IGenericRepository<StudTranscriptsPortalResults> StudTranscriptsPortalResults { get; }

		public IGenericRepository<FeesPolicy> FeesPolicy { get; }

		public IGenericRepository<ProgCurriculum> ProgCurriculum { get; }

		public IGenericRepository<ProgCurriculumDetail> ProgCurriculumDetail { get; }

		public IGenericRepository<ProcOnlineReq> ProcOnlineReq { get; }

		public IGenericRepository<HrpEmployee> HrpEmployee { get; }

		public IGenericRepository<HrpLeaveApp> HrpLeaveApp { get; }

		public IGenericRepository<HrpIpprofile> HrpIpprofile { get; }

		public IGenericRepository<HrpPayAcc> HrpPayAcc { get; }

		public IHrpSalProcessRepository HrpSalProcess { get; }

		public IGenericRepository<HrpSalPeriod> HrpSalPeriod { get; }

		public IGenericRepository<HrpLeaveEntit> HrpLeaveEntit { get; }

		public IGenericRepository<HrpLeaveType> HrpLeaveType { get; }

		public IGenericRepository<HrpLeaveGroups> HrpLeaveGroups { get; }

		public IGenericRepository<HrpLeavePeriod> HrpLeavePeriod { get; }

		public IGenericRepository<Pclaim> Pclaim { get; }

		public IGenericRepository<Wfrouting> Wfrouting { get; }

		public IGenericRepository<ItemUom> ItemUom { get; }

		public IGenericRepository<ProcItems> ProcItems { get; }

		public IGenericRepository<SysSetup> SysSetup { get; }

		public IGenericRepository<FLBooking> FLBooking { get; }

		public IGenericRepository<FLCategory> FLCategory { get; }

		public IGenericRepository<FLTrips> FLTrips { get; }

		public IGenericRepository<Eclaim> Eclaim { get; }

		public IGenericRepository<EclaimUnits> EclaimUnits { get; }

		public IGenericRepository<HrpService> HrpService { get; }

		public IGenericRepository<FLVehicle> FLVehicle { get; }

		public IGenericRepository<HrpEmpAccNo> hrpEmpAccNo { get; }

		public IGenericRepository<HrpBank> hrpBank { get; }

		public IGenericRepository<ImprestMemo> ImprestMemo { get; }

		public IGenericRepository<ImprestMemoDetail> ImprestMemoDetail { get; }

		public IGenericRepository<GradeApproval> GradeApproval { get; }

		public IGenericRepository<StudSchools> StudSchools { get; }

		public IGenericRepository<StudDependant> StudDependant { get; }

		public IGenericRepository<ESWorkRequest> ESWorkRequests { get; }

		public IGenericRepository<ESProject> ESProjects { get; }

		public IGenericRepository<ESLocation> ESLocation { get; }

		public IGenericRepository<ESWorkOrder> ESWorkOrders { get; }
		public IGenericRepository<HrpLeaveRules> HrpLeaveRules { get; set; }

		public IGenericRepository<ClassCourse> ClassCourse { get; }

		public IGenericRepository<WfdocCentre> WFDocCentre { get; }

		public IGenericRepository<WfdocCentreDetails> WFDocCentreDetails { get; }

		public IGenericRepository<Sup> Sup { get; }

		public int Save()
		{
			return _context.SaveChanges();
		}
	}
}
