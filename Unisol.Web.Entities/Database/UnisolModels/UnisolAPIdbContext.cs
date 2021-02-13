using Microsoft.EntityFrameworkCore;

namespace Unisol.Web.Entities.Database.UnisolModels
{
	public partial class UnisolAPIdbContext : DbContext
	{
		public UnisolAPIdbContext()
		{
		}

		public UnisolAPIdbContext(DbContextOptions<UnisolAPIdbContext> options)
			: base(options) { }

		public virtual DbSet<AcademicYear> AcademicYear { get; set; }
		public virtual DbSet<Accounts> Accounts { get; set; }
		public virtual DbSet<AccStatement> AccStatement { get; set; }
		public virtual DbSet<AccStatementDet2> AccStatementDet2 { get; set; }
		public virtual DbSet<Activerecordlog> Activerecordlog { get; set; }
		public virtual DbSet<AdmnLetters> AdmnLetters { get; set; }
		public virtual DbSet<AdvPerStatistic> AdvPerStatistic { get; set; }
		public virtual DbSet<AdvStudStatistic> AdvStudStatistic { get; set; }
		public virtual DbSet<Apaccount> Apaccount { get; set; }
		public virtual DbSet<AppFiles> AppFiles { get; set; }
		public virtual DbSet<Applicant> Applicant { get; set; }
		public virtual DbSet<AppointmentDiary> AppointmentDiary { get; set; }
		public virtual DbSet<AppReferee> AppReferee { get; set; }
		public virtual DbSet<AppSchools> AppSchools { get; set; }
		public virtual DbSet<AppWork> AppWork { get; set; }
		public virtual DbSet<Araccount> Araccount { get; set; }
		public virtual DbSet<AssetCat> AssetCat { get; set; }
		public virtual DbSet<AssetCheckHistory> AssetCheckHistory { get; set; }
		public virtual DbSet<AssetCheckIn> AssetCheckIn { get; set; }
		public virtual DbSet<AssetCheckOut> AssetCheckOut { get; set; }
		public virtual DbSet<AssetCount> AssetCount { get; set; }
		public virtual DbSet<AssetCountPeriod> AssetCountPeriod { get; set; }
		public virtual DbSet<AssetFiles> AssetFiles { get; set; }
		public virtual DbSet<AssetLoc> AssetLoc { get; set; }
		public virtual DbSet<AssetRoom> AssetRoom { get; set; }
		public virtual DbSet<Assets> Assets { get; set; }
		public virtual DbSet<AssetService> AssetService { get; set; }
		public virtual DbSet<AssetStatus> AssetStatus { get; set; }
		public virtual DbSet<AssetSubCat> AssetSubCat { get; set; }
		public virtual DbSet<AssetType> AssetType { get; set; }
		public virtual DbSet<AssetXlsfields> AssetXlsfields { get; set; }
		public virtual DbSet<BankAcc> BankAcc { get; set; }
		public virtual DbSet<Banking> Banking { get; set; }
		public virtual DbSet<BankingDetail> BankingDetail { get; set; }
		public virtual DbSet<BankingPosted> BankingPosted { get; set; }
		public virtual DbSet<BankingPostedDetail> BankingPostedDetail { get; set; }
		public virtual DbSet<BankRec> BankRec { get; set; }
		public virtual DbSet<BankRecDetail> BankRecDetail { get; set; }
		public virtual DbSet<Boarders> Boarders { get; set; }
		public virtual DbSet<BoardersPrev> BoardersPrev { get; set; }
		public virtual DbSet<BoardingSus> BoardingSus { get; set; }
		public virtual DbSet<BudgetAdj> BudgetAdj { get; set; }
		public virtual DbSet<BudgetAdjDetail> BudgetAdjDetail { get; set; }
		public virtual DbSet<BudgetD> BudgetD { get; set; }
		public virtual DbSet<BudgetDdetail> BudgetDdetail { get; set; }
		public virtual DbSet<BudgetM> BudgetM { get; set; }
		public virtual DbSet<BudgetMdetail> BudgetMdetail { get; set; }
		public virtual DbSet<BudgetPeriods> BudgetPeriods { get; set; }
		public virtual DbSet<BudgetProj> BudgetProj { get; set; }
		public virtual DbSet<BudgetProjDetail> BudgetProjDetail { get; set; }
		public virtual DbSet<Campuses> Campuses { get; set; }
		public virtual DbSet<Cheques> Cheques { get; set; }
		public virtual DbSet<ChequesTax> ChequesTax { get; set; }
		public virtual DbSet<ChqCancelled> ChqCancelled { get; set; }
		public virtual DbSet<ChqCollection> ChqCollection { get; set; }
		public virtual DbSet<ChqLog> ChqLog { get; set; }
		public virtual DbSet<ChqRegister> ChqRegister { get; set; }
		public virtual DbSet<ChqSch> ChqSch { get; set; }
		public virtual DbSet<ChqSchDetails> ChqSchDetails { get; set; }
		public virtual DbSet<ChqSettings> ChqSettings { get; set; }
		public virtual DbSet<Class> Class { get; set; }
		public virtual DbSet<ClassCourse> ClassCourse { get; set; }
		public virtual DbSet<Classification> Classification { get; set; }
		public virtual DbSet<ClassStatistics> ClassStatistics { get; set; }
		public virtual DbSet<ClassStatus> ClassStatus { get; set; }
		public virtual DbSet<ClassType> ClassType { get; set; }
		public virtual DbSet<Cmoney> Cmoney { get; set; }
		public virtual DbSet<Colleges> Colleges { get; set; }
		public virtual DbSet<ComMeals> ComMeals { get; set; }
		public virtual DbSet<County> County { get; set; }
		public virtual DbSet<CreditTransfer> CreditTransfer { get; set; }
		public virtual DbSet<CronShared> CronShared { get; set; }
		public virtual DbSet<Csplanner> Csplanner { get; set; }
		public virtual DbSet<CsplannerDetail> CsplannerDetail { get; set; }
		public virtual DbSet<CsummarySettings> CsummarySettings { get; set; }
		public virtual DbSet<Curr> Curr { get; set; }
		public virtual DbSet<CustCreditMemo> CustCreditMemo { get; set; }
		public virtual DbSet<CustCreditMemoDetail> CustCreditMemoDetail { get; set; }
		public virtual DbSet<CustCreditMemoRcptCredit> CustCreditMemoRcptCredit { get; set; }
		public virtual DbSet<CustDebitMemo> CustDebitMemo { get; set; }
		public virtual DbSet<CustDebitMemoDetail> CustDebitMemoDetail { get; set; }
		public virtual DbSet<CustInv> CustInv { get; set; }
		public virtual DbSet<CustInvDetail> CustInvDetail { get; set; }
		public virtual DbSet<CustItemAdjust> CustItemAdjust { get; set; }
		public virtual DbSet<CustItemCat> CustItemCat { get; set; }
		public virtual DbSet<CustItemPrices> CustItemPrices { get; set; }
		public virtual DbSet<CustItems> CustItems { get; set; }
		public virtual DbSet<Customers> Customers { get; set; }
		public virtual DbSet<CustomerType> CustomerType { get; set; }
		public virtual DbSet<CustProInv> CustProInv { get; set; }
		public virtual DbSet<CustProInvDetail> CustProInvDetail { get; set; }
		public virtual DbSet<CustStatement> CustStatement { get; set; }
		public virtual DbSet<CustTaxWh> CustTaxWh { get; set; }
		public virtual DbSet<DebCredit> DebCredit { get; set; }
		public virtual DbSet<DebtorBalances> DebtorBalances { get; set; }
		public virtual DbSet<Department> Department { get; set; }
		public virtual DbSet<Dletters> Dletters { get; set; }
		public virtual DbSet<Eclaim> Eclaim { get; set; }
		public virtual DbSet<EclaimDetail> EclaimDetail { get; set; }
		public virtual DbSet<EclaimDisb> EclaimDisb { get; set; }
		public virtual DbSet<EclaimReq> EclaimReq { get; set; }
		public virtual DbSet<EclaimReqUnits> EclaimReqUnits { get; set; }
		public virtual DbSet<EclaimUnits> EclaimUnits { get; set; }
		public virtual DbSet<Endstand> Endstand { get; set; }
		public virtual DbSet<Events> Events { get; set; }
		public virtual DbSet<EventsHelper> EventsHelper { get; set; }
		public virtual DbSet<Eventslist> Eventslist { get; set; }
		public virtual DbSet<EventsType> EventsType { get; set; }
		public virtual DbSet<EventsUserPreference> EventsUserPreference { get; set; }
		public virtual DbSet<ExamLog> ExamLog { get; set; }
		public virtual DbSet<ExamSlip> ExamSlip { get; set; }
		public virtual DbSet<ExamType> ExamType { get; set; }
		public virtual DbSet<FacilityBooking> FacilityBooking { get; set; }
		public virtual DbSet<FacilityBookingStatusLog> FacilityBookingStatusLog { get; set; }
		public virtual DbSet<FeesPerClass> FeesPerClass { get; set; }
		public virtual DbSet<FeesPerHostelRoom> FeesPerHostelRoom { get; set; }
		public virtual DbSet<FeesPerHostelRoomDetail> FeesPerHostelRoomDetail { get; set; }
		public virtual DbSet<FeesPerProg> FeesPerProg { get; set; }
		public virtual DbSet<FeesPerProgDetail> FeesPerProgDetail { get; set; }
		public virtual DbSet<FeesPerUnit> FeesPerUnit { get; set; }
		public virtual DbSet<FeesPerUnitDetail> FeesPerUnitDetail { get; set; }
		public virtual DbSet<FeesPolicy> FeesPolicy { get; set; }
		public virtual DbSet<FeesPolicyDetail> FeesPolicyDetail { get; set; }
		public virtual DbSet<FileManagerFiles> FileManagerFiles { get; set; }
		public virtual DbSet<FileManagerFolders> FileManagerFolders { get; set; }
		public virtual DbSet<FileStore> FileStore { get; set; }
		public virtual DbSet<FinancialAid> FinancialAid { get; set; }
		public virtual DbSet<FinancialYear> FinancialYear { get; set; }
		public virtual DbSet<Fingerprints> Fingerprints { get; set; }
		public virtual DbSet<Fyear> Fyear { get; set; }
		public virtual DbSet<FyearPeriods> FyearPeriods { get; set; }
		public virtual DbSet<GcsDeviceSetup> GcsDeviceSetup { get; set; }
		public virtual DbSet<GcsEntryTrack> GcsEntryTrack { get; set; }
		public virtual DbSet<GcsLog> GcsLog { get; set; }
		public virtual DbSet<GcsMembers> GcsMembers { get; set; }
		public virtual DbSet<GcsMemCat> GcsMemCat { get; set; }
		public virtual DbSet<GcsSetup> GcsSetup { get; set; }
		public virtual DbSet<GcsTimePlan> GcsTimePlan { get; set; }
		public virtual DbSet<GcsTracking> GcsTracking { get; set; }
		public virtual DbSet<Gpa> Gpa { get; set; }
		public virtual DbSet<GradeApproval> GradeApproval { get; set; }
		public virtual DbSet<GradeApprovalLog> GradeApprovalLog { get; set; }
		public virtual DbSet<Grading> Grading { get; set; }
		public virtual DbSet<Hediagnosis> Hediagnosis { get; set; }
		public virtual DbSet<Helocation> Helocation { get; set; }
		public virtual DbSet<Hepatient> Hepatient { get; set; }
		public virtual DbSet<HepatientFiles> HepatientFiles { get; set; }
		public virtual DbSet<Hetests> Hetests { get; set; }
		public virtual DbSet<Hevisit> Hevisit { get; set; }
		public virtual DbSet<HevisitDiagnosis> HevisitDiagnosis { get; set; }
		public virtual DbSet<HevisitLoc> HevisitLoc { get; set; }
		public virtual DbSet<HevisitReferral> HevisitReferral { get; set; }
		public virtual DbSet<HevisitTests> HevisitTests { get; set; }
		public virtual DbSet<HevisitVitals> HevisitVitals { get; set; }
		public virtual DbSet<Hevitals> Hevitals { get; set; }
		public virtual DbSet<HostelBooking> HostelBooking { get; set; }
		public virtual DbSet<HostelBookingRequest> HostelBookingRequest { get; set; }
		public virtual DbSet<HostelBookings> HostelBookings { get; set; }
		public virtual DbSet<HostelRooms> HostelRooms { get; set; }
		public virtual DbSet<Hostels> Hostels { get; set; }
		public virtual DbSet<HrpAcademicRank> HrpAcademicRank { get; set; }
		public virtual DbSet<HrpBank> HrpBank { get; set; }
		public virtual DbSet<HrpBenefits> HrpBenefits { get; set; }
		public virtual DbSet<HrpContract> HrpContract { get; set; }
		public virtual DbSet<HrpCountry> HrpCountry { get; set; }
		public virtual DbSet<HrpCounty> HrpCounty { get; set; }
		public virtual DbSet<HrpDedSetup> HrpDedSetup { get; set; }
		public virtual DbSet<HrpDedSetupSub> HrpDedSetupSub { get; set; }
		public virtual DbSet<HrpDeductions> HrpDeductions { get; set; }
		public virtual DbSet<HrpDeductionsAdhoc> HrpDeductionsAdhoc { get; set; }
		public virtual DbSet<HrpDependant> HrpDependant { get; set; }
		public virtual DbSet<HrpDivision> HrpDivision { get; set; }
		public virtual DbSet<HrpEarnings> HrpEarnings { get; set; }
		public virtual DbSet<HrpEarningsAdhoc> HrpEarningsAdhoc { get; set; }
		public virtual DbSet<HrpEarnSetup> HrpEarnSetup { get; set; }
		public virtual DbSet<HrpEarnSetupSub> HrpEarnSetupSub { get; set; }
		public virtual DbSet<HrpEmpAccNo> HrpEmpAccNo { get; set; }
		public virtual DbSet<HrpEmpCat> HrpEmpCat { get; set; }
		public virtual DbSet<HrpEmployee> HrpEmployee { get; set; }
		public virtual DbSet<HrpEmpStatus> HrpEmpStatus { get; set; }
		public virtual DbSet<HrpFi> HrpFi { get; set; }
		public virtual DbSet<HrpFiles> HrpFiles { get; set; }
		public virtual DbSet<HrpHospital> HrpHospital { get; set; }
		public virtual DbSet<HrpIncrementalDates> HrpIncrementalDates { get; set; }
		public virtual DbSet<HrpInsProviders> HrpInsProviders { get; set; }
		public virtual DbSet<HrpIpcenter> HrpIpcenter { get; set; }
		public virtual DbSet<HrpIpdeductions> HrpIpdeductions { get; set; }
		public virtual DbSet<HrpIpearnings> HrpIpearnings { get; set; }
		public virtual DbSet<HrpIppayAcc> HrpIppayAcc { get; set; }
		public virtual DbSet<HrpIpprocess> HrpIpprocess { get; set; }
		public virtual DbSet<HrpIpprofile> HrpIpprofile { get; set; }
		public virtual DbSet<HrpIpprojects> HrpIpprojects { get; set; }
		public virtual DbSet<HrpJobCat> HrpJobCat { get; set; }
		public virtual DbSet<HrpJobTitles> HrpJobTitles { get; set; }
		public virtual DbSet<HrpLeaveApp> HrpLeaveApp { get; set; }
		public virtual DbSet<HrpLeaveEntit> HrpLeaveEntit { get; set; }
		public virtual DbSet<HrpLeaveGroups> HrpLeaveGroups { get; set; }
		public virtual DbSet<HrpLeaveHolidays> HrpLeaveHolidays { get; set; }
		public virtual DbSet<HrpLeavePeriod> HrpLeavePeriod { get; set; }
		public virtual DbSet<HrpLeaveReserved> HrpLeaveReserved { get; set; }
		public virtual DbSet<HrpLeaveRules> HrpLeaveRules { get; set; }
		public virtual DbSet<HrpLeaveStatusLog> HrpLeaveStatusLog { get; set; }
		public virtual DbSet<HrpLeaveType> HrpLeaveType { get; set; }
		public virtual DbSet<HrpLeaveWorkWeek> HrpLeaveWorkWeek { get; set; }
		public virtual DbSet<HrpLoanSetup> HrpLoanSetup { get; set; }
		public virtual DbSet<HrpLoanSub> HrpLoanSub { get; set; }
		public virtual DbSet<HrpLoc> HrpLoc { get; set; }
		public virtual DbSet<HrpLog> HrpLog { get; set; }
		public virtual DbSet<HrpMedicalClaims> HrpMedicalClaims { get; set; }
		public virtual DbSet<HrpMedicalClaimsPay> HrpMedicalClaimsPay { get; set; }
		public virtual DbSet<HrpMedicalClaimsPayDetails> HrpMedicalClaimsPayDetails { get; set; }
		public virtual DbSet<HrpNhif> HrpNhif { get; set; }
		public virtual DbSet<HrpNhifmain> HrpNhifmain { get; set; }
		public virtual DbSet<HrpPayAcc> HrpPayAcc { get; set; }
		public virtual DbSet<HrpPaye> HrpPaye { get; set; }
		public virtual DbSet<HrpPayemain> HrpPayemain { get; set; }
		public virtual DbSet<HrpPayGrades> HrpPayGrades { get; set; }
		public virtual DbSet<HrpPayGradesSub> HrpPayGradesSub { get; set; }
		public virtual DbSet<HrpPayrollJournal> HrpPayrollJournal { get; set; }
		public virtual DbSet<HrpPension> HrpPension { get; set; }
		public virtual DbSet<HrpPersonnelImportXlsfields> HrpPersonnelImportXlsfields { get; set; }
		public virtual DbSet<HrpPmperiod> HrpPmperiod { get; set; }
		public virtual DbSet<HrpPmrating> HrpPmrating { get; set; }
		public virtual DbSet<HrpPromoDate> HrpPromoDate { get; set; }
		public virtual DbSet<HrpRace> HrpRace { get; set; }
		public virtual DbSet<HrpRetro> HrpRetro { get; set; }
		public virtual DbSet<HrpRetroDetail> HrpRetroDetail { get; set; }
		public virtual DbSet<HrpReview> HrpReview { get; set; }
		public virtual DbSet<HrpReviewDetails> HrpReviewDetails { get; set; }
		public virtual DbSet<HrpSalPeriod> HrpSalPeriod { get; set; }
		public virtual DbSet<HrpSalProcess> HrpSalProcess { get; set; } 
		public virtual DbSet<HrpStaffClearance> HrpStaffClearance { get; set; }
		public virtual DbSet<HrpSalProcessEmployer> HrpSalProcessEmployer { get; set; }
		public virtual DbSet<HrpSection> HrpSection { get; set; }
		public virtual DbSet<HrpService> HrpService { get; set; }
		public virtual DbSet<HrpSetup> HrpSetup { get; set; }
		public virtual DbSet<HrpSharesOb> HrpSharesOb { get; set; }
		public virtual DbSet<HrpSharesPayOff> HrpSharesPayOff { get; set; }
		public virtual DbSet<HrpTadayProgram> HrpTadayProgram { get; set; }
		public virtual DbSet<HrpTadayProgramDetails> HrpTadayProgramDetails { get; set; }
		public virtual DbSet<HrpTaroster> HrpTaroster { get; set; }
		public virtual DbSet<HrpTatimesheet> HrpTatimesheet { get; set; }
		public virtual DbSet<HrpTatype> HrpTatype { get; set; }
		public virtual DbSet<HrpTraining> HrpTraining { get; set; }
		public virtual DbSet<HrpUnion> HrpUnion { get; set; }
		public virtual DbSet<Imprest> Imprest { get; set; }
		public virtual DbSet<ImprestDetail> ImprestDetail { get; set; }
		public virtual DbSet<ImprestDisb> ImprestDisb { get; set; }
		public virtual DbSet<ImprestDisbDetail> ImprestDisbDetail { get; set; }
		public virtual DbSet<ImprestReq> ImprestReq { get; set; }
		public virtual DbSet<ImprestSur> ImprestSur { get; set; }
		public virtual DbSet<ImprestSurDetail> ImprestSurDetail { get; set; }
		public virtual DbSet<ImprestSurRcpt> ImprestSurRcpt { get; set; }
		public virtual DbSet<InsInv> InsInv { get; set; }
		public virtual DbSet<InsInvDetail> InsInvDetail { get; set; }
		public virtual DbSet<ItemAdd> ItemAdd { get; set; }
		public virtual DbSet<ItemAdjust> ItemAdjust { get; set; }
		public virtual DbSet<ItemAdjustDept> ItemAdjustDept { get; set; }
		public virtual DbSet<ItemAwards> ItemAwards { get; set; }
		public virtual DbSet<ItemBid> ItemBid { get; set; }
		public virtual DbSet<ItemCat> ItemCat { get; set; }
		public virtual DbSet<ItemIssue> ItemIssue { get; set; }
		public virtual DbSet<ItemIssueClear> ItemIssueClear { get; set; }
		public virtual DbSet<ItemLoc> ItemLoc { get; set; }
		public virtual DbSet<ItemReq> ItemReq { get; set; }
		public virtual DbSet<Items> Items { get; set; }
		public virtual DbSet<ItemType> ItemType { get; set; }
		public virtual DbSet<ItemUom> ItemUom { get; set; }
		public virtual DbSet<Journal> Journal { get; set; }
		public virtual DbSet<Ledger> Ledger { get; set; }
		public virtual DbSet<LedgerSub> LedgerSub { get; set; }
		public virtual DbSet<Log> Log { get; set; }
		public virtual DbSet<Lookup> Lookup { get; set; }
		public virtual DbSet<ManagementFeeSetup> ManagementFeeSetup { get; set; }
		public virtual DbSet<MarkSheet> MarkSheet { get; set; }
		public virtual DbSet<MarkSymbols> MarkSymbols { get; set; }
		public virtual DbSet<MatureEntry> MatureEntry { get; set; }
		public virtual DbSet<McsUsers> McsUsers { get; set; }
		public virtual DbSet<Members> Members { get; set; }
		public virtual DbSet<Messages> Messages { get; set; }
		public virtual DbSet<MessageUser> MessageUser { get; set; }
		public virtual DbSet<Notifications> Notifications { get; set; }
		public virtual DbSet<OnlineApplicant> OnlineApplicant { get; set; }
		public virtual DbSet<OnlineReporting> OnlineReporting { get; set; }
		public virtual DbSet<PayCancelled> PayCancelled { get; set; }
		public virtual DbSet<Payecafeteria> Payecafeteria { get; set; }
		public virtual DbSet<PayeCardIssue> PayeCardIssue { get; set; }
		public virtual DbSet<PayeCardReg> PayeCardReg { get; set; }
		public virtual DbSet<PayeDepartment> PayeDepartment { get; set; }
		public virtual DbSet<Payees> Payees { get; set; }
		public virtual DbSet<Payefacility> Payefacility { get; set; }
		public virtual DbSet<PayeIngredients> PayeIngredients { get; set; }
		public virtual DbSet<PayeItemCat> PayeItemCat { get; set; }
		public virtual DbSet<PayeItemGroup> PayeItemGroup { get; set; }
		public virtual DbSet<PayeItemPrices> PayeItemPrices { get; set; }
		public virtual DbSet<PayeItems> PayeItems { get; set; }
		public virtual DbSet<PayeKitchenNotes> PayeKitchenNotes { get; set; }
		public virtual DbSet<PayeLog> PayeLog { get; set; }
		public virtual DbSet<PayeMembers> PayeMembers { get; set; }
		public virtual DbSet<PayeMemCat> PayeMemCat { get; set; }
		public virtual DbSet<PayeModifiers> PayeModifiers { get; set; }
		public virtual DbSet<PayeRecipe> PayeRecipe { get; set; }
		public virtual DbSet<PayeRefund> PayeRefund { get; set; }
		public virtual DbSet<PayeReminder> PayeReminder { get; set; }
		public virtual DbSet<PayeSales> PayeSales { get; set; }
		public virtual DbSet<PayeSalesDetail> PayeSalesDetail { get; set; }
		public virtual DbSet<PayeSysSetup> PayeSysSetup { get; set; }
		public virtual DbSet<PayeTaxType> PayeTaxType { get; set; }
		public virtual DbSet<PayeTopUp> PayeTopUp { get; set; }
		public virtual DbSet<PayeUsers> PayeUsers { get; set; }
		public virtual DbSet<PayInvoice> PayInvoice { get; set; }
		public virtual DbSet<PayInvoiceDetail> PayInvoiceDetail { get; set; }
		public virtual DbSet<PayInvoiceWaiver> PayInvoiceWaiver { get; set; }
		public virtual DbSet<Payments> Payments { get; set; }
		public virtual DbSet<PayRegister> PayRegister { get; set; }
		public virtual DbSet<Pcash> Pcash { get; set; }
		public virtual DbSet<PcashDetail> PcashDetail { get; set; }
		public virtual DbSet<Pcdisb> Pcdisb { get; set; }
		public virtual DbSet<PerformRemarks> PerformRemarks { get; set; }
		public virtual DbSet<Pocancel> Pocancel { get; set; }
		public virtual DbSet<PocancelDetails> PocancelDetails { get; set; }
		public virtual DbSet<Porder> Porder { get; set; }
		public virtual DbSet<PorderDetail> PorderDetail { get; set; }
		public virtual DbSet<Postatus> Postatus { get; set; }
		public virtual DbSet<Preq> Preq { get; set; }
		public virtual DbSet<PreqDetail> PreqDetail { get; set; }
		public virtual DbSet<ProcBudget> ProcBudget { get; set; }
		public virtual DbSet<ProcDeptStores> ProcDeptStores { get; set; }
		public virtual DbSet<ProcItemIssue> ProcItemIssue { get; set; }
		public virtual DbSet<ProcItemIssueDept> ProcItemIssueDept { get; set; }
		public virtual DbSet<ProcItems> ProcItems { get; set; }
		public virtual DbSet<ProcOnlineReq> ProcOnlineReq { get; set; }
		public virtual DbSet<ProcOnlineReqDetail> ProcOnlineReqDetail { get; set; }
		public virtual DbSet<ProcPlan> ProcPlan { get; set; }
		public virtual DbSet<ProcPlanDetails> ProcPlanDetails { get; set; }
		public virtual DbSet<ProgCurriculum> ProgCurriculum { get; set; }
		public virtual DbSet<ProgCurriculumDetail> ProgCurriculumDetail { get; set; }
		public virtual DbSet<Programme> Programme { get; set; }
		public virtual DbSet<ProgSpecialization> ProgSpecialization { get; set; }
		public virtual DbSet<ProgUnitReg> ProgUnitReg { get; set; }
		public virtual DbSet<ProgUnitRegDetail> ProgUnitRegDetail { get; set; }
		public virtual DbSet<ProjBeneficiaries> ProjBeneficiaries { get; set; }
		public virtual DbSet<ProjCoordinators> ProjCoordinators { get; set; }
		public virtual DbSet<Pvdetail> Pvdetail { get; set; }
		public virtual DbSet<Pvecc> Pvecc { get; set; }
		public virtual DbSet<Pveccdetails> Pveccdetails { get; set; }
		public virtual DbSet<Pvic> Pvic { get; set; }
		public virtual DbSet<Pvicdetails> Pvicdetails { get; set; }
		public virtual DbSet<Pvouchers> Pvouchers { get; set; }
		public virtual DbSet<Pvpc> Pvpc { get; set; }
		public virtual DbSet<Pvpcdetails> Pvpcdetails { get; set; }
		public virtual DbSet<Pvprefix> Pvprefix { get; set; }
		public virtual DbSet<Pvtax> Pvtax { get; set; }
		public virtual DbSet<PvtaxDetail> PvtaxDetail { get; set; }
		public virtual DbSet<Quarters> Quarters { get; set; }
		public virtual DbSet<Rcredit> Rcredit { get; set; }
		public virtual DbSet<Rdebit> Rdebit { get; set; }
		public virtual DbSet<ReceiptBook> ReceiptBook { get; set; }
		public virtual DbSet<ReceiptBookCanc> ReceiptBookCanc { get; set; }
		public virtual DbSet<ReceiptBookCustBreak> ReceiptBookCustBreak { get; set; }
		public virtual DbSet<ReceiptBookOtherDetail> ReceiptBookOtherDetail { get; set; }
		public virtual DbSet<ReceiptBreak> ReceiptBreak { get; set; }
		public virtual DbSet<ReceiptXlsfields> ReceiptXlsfields { get; set; }
		public virtual DbSet<Refund> Refund { get; set; }
		public virtual DbSet<Register> Register { get; set; }
		public virtual DbSet<RegList> RegList { get; set; }
		public virtual DbSet<Reminder> Reminder { get; set; }
		public virtual DbSet<RentAutoInv> RentAutoInv { get; set; }
		public virtual DbSet<Reporting> Reporting { get; set; }
		public virtual DbSet<Repository> Repository { get; set; }
		public virtual DbSet<RetakeReg> RetakeReg { get; set; }
		public virtual DbSet<RetakeRegDetail> RetakeRegDetail { get; set; }
		public virtual DbSet<Rfq> Rfq { get; set; }
		public virtual DbSet<Rfqdetail> Rfqdetail { get; set; }
		public virtual DbSet<Savedsearches> Savedsearches { get; set; }
		public virtual DbSet<Schools> Schools { get; set; }
		public virtual DbSet<SCompanyNews> SCompanyNews { get; set; }
		public virtual DbSet<SmsBlackList> SmsBlackList { get; set; }
		public virtual DbSet<SmsClassExam> SmsClassExam { get; set; }
		public virtual DbSet<SmsReceived> SmsReceived { get; set; }
		public virtual DbSet<SmsSent> SmsSent { get; set; }
		public virtual DbSet<SmsSetup> SmsSetup { get; set; }
		public virtual DbSet<SpecialExams> SpecialExams { get; set; }
		public virtual DbSet<StudAccomXlsfields> StudAccomXlsfields { get; set; }
		public virtual DbSet<StudDependant> StudDependant { get; set; }
		public virtual DbSet<StudDepositRefund> StudDepositRefund { get; set; }
		public virtual DbSet<StudDepositRefundBd> StudDepositRefundBd { get; set; }
		public virtual DbSet<StudDepositRefundBdxlsfields> StudDepositRefundBdxlsfields { get; set; }
		public virtual DbSet<StudDocuments> StudDocuments { get; set; }
		public virtual DbSet<StudEmailXlsfields> StudEmailXlsfields { get; set; }
		public virtual DbSet<StudEnrolment> StudEnrolment { get; set; }
		public virtual DbSet<StudentAssn> StudentAssn { get; set; }
		public virtual DbSet<Studentattendance> Studentattendance { get; set; }
		public virtual DbSet<StudentsImportXlsfields> StudentsImportXlsfields { get; set; }
		public virtual DbSet<StudentSource> StudentSource { get; set; }
		public virtual DbSet<StudentTimesheet> StudentTimesheet { get; set; }
		public virtual DbSet<StudentType> StudentType { get; set; }
		public virtual DbSet<StudFeesBalances> StudFeesBalances { get; set; }
		public virtual DbSet<StudFiles> StudFiles { get; set; }
		public virtual DbSet<StudInvoice> StudInvoice { get; set; }
		public virtual DbSet<StudInvoiceAdj> StudInvoiceAdj { get; set; }
		public virtual DbSet<StudInvoiceAdjCredit> StudInvoiceAdjCredit { get; set; }
		public virtual DbSet<StudJabImportXlsfields> StudJabImportXlsfields { get; set; }
		public virtual DbSet<StudMarksXlsfields> StudMarksXlsfields { get; set; }
		public virtual DbSet<StudObxlsfields> StudObxlsfields { get; set; }
		public virtual DbSet<StudReferee> StudReferee { get; set; }
		public virtual DbSet<StudSchools> StudSchools { get; set; }
		public virtual DbSet<StudSponsor> StudSponsor { get; set; }
		public virtual DbSet<StudSponsorBd> StudSponsorBd { get; set; }
		public virtual DbSet<StudSponsorBdcanc> StudSponsorBdcanc { get; set; }
		public virtual DbSet<StudSponsorBdcredit> StudSponsorBdcredit { get; set; }
		public virtual DbSet<StudSponsorBdxlsfields> StudSponsorBdxlsfields { get; set; }
		public virtual DbSet<Studstatement> Studstatement { get; set; }
		public virtual DbSet<StudentStatementModelVirtual> StudentStatementModelVirtual { get; set; }

		public virtual DbSet<Studstatement2> Studstatement2 { get; set; }
		public virtual DbSet<StudTranscriptsPortalResults> StudTranscriptsPortalResults { get; set; }
		public virtual DbSet<StudWork> StudWork { get; set; }
		public virtual DbSet<Subjects> Subjects { get; set; }
		public virtual DbSet<SubjectType> SubjectType { get; set; }
		public virtual DbSet<Sup> Sup { get; set; }
		public virtual DbSet<SupLoad> SupLoad { get; set; }
		public virtual DbSet<Suppliers> Suppliers { get; set; }
		public virtual DbSet<SupplierType> SupplierType { get; set; }
		public virtual DbSet<SupPreq> SupPreq { get; set; }
		public virtual DbSet<SupPreqDetail> SupPreqDetail { get; set; }
		public virtual DbSet<SupStatement> SupStatement { get; set; }
		public virtual DbSet<SysSetup> SysSetup { get; set; }
		public virtual DbSet<SysSetupMore> SysSetupMore { get; set; }
		public virtual DbSet<TaxType> TaxType { get; set; }
		public virtual DbSet<Term> Term { get; set; }
		public virtual DbSet<Thesis> Thesis { get; set; }
		public virtual DbSet<Timetable> Timetable { get; set; }
		public virtual DbSet<Ttatype> Ttatype { get; set; }
		public virtual DbSet<Ttbuilding> Ttbuilding { get; set; }
		public virtual DbSet<TtdayProgram> TtdayProgram { get; set; }
		public virtual DbSet<TtdayProgramDetails> TtdayProgramDetails { get; set; }
		public virtual DbSet<TtexamPeriod> TtexamPeriod { get; set; }
		public virtual DbSet<TtexamProcessed> TtexamProcessed { get; set; }
		public virtual DbSet<TtexamSchedule> TtexamSchedule { get; set; }
		public virtual DbSet<TtexamScheduleDetails> TtexamScheduleDetails { get; set; }
		public virtual DbSet<TtexamScheduleInvigilator> TtexamScheduleInvigilator { get; set; }
		public virtual DbSet<TtexamType> TtexamType { get; set; }
		public virtual DbSet<Ttholidays> Ttholidays { get; set; }
		public virtual DbSet<Ttlecturer> Ttlecturer { get; set; }
		public virtual DbSet<TtlecturerTimePref> TtlecturerTimePref { get; set; }
		public virtual DbSet<TtlecturerUnits> TtlecturerUnits { get; set; }
		public virtual DbSet<Ttreserved> Ttreserved { get; set; }
		public virtual DbSet<TtroomFeature> TtroomFeature { get; set; }
		public virtual DbSet<Ttrooms> Ttrooms { get; set; }
		public virtual DbSet<TtroomType> TtroomType { get; set; }
		public virtual DbSet<TtstudyPeriod> TtstudyPeriod { get; set; }
		public virtual DbSet<TtstudyProcessed> TtstudyProcessed { get; set; }
		public virtual DbSet<TtstudySchedule> TtstudySchedule { get; set; }
		public virtual DbSet<TtstudyScheduleDetails> TtstudyScheduleDetails { get; set; }
		public virtual DbSet<TtstudyScheduleLecturer> TtstudyScheduleLecturer { get; set; }
		public virtual DbSet<TtstudyType> TtstudyType { get; set; }
		public virtual DbSet<Tutors> Tutors { get; set; }
		public virtual DbSet<UsergroupsAccess> UsergroupsAccess { get; set; }
		public virtual DbSet<UsergroupsConfiguration> UsergroupsConfiguration { get; set; }
		public virtual DbSet<UsergroupsCron> UsergroupsCron { get; set; }
		public virtual DbSet<UsergroupsGroup> UsergroupsGroup { get; set; }
		public virtual DbSet<UsergroupsLookup> UsergroupsLookup { get; set; }
		public virtual DbSet<UsergroupsUser> UsergroupsUser { get; set; }
		public virtual DbSet<UserLogEvents> UserLogEvents { get; set; }
		public virtual DbSet<Users> Users { get; set; }
		public virtual DbSet<VacHostel> VacHostel { get; set; }
		public virtual DbSet<Wfapprovers> Wfapprovers { get; set; }
		public virtual DbSet<WfapproversDetails> WfapproversDetails { get; set; }
		public virtual DbSet<WfdocCentre> WfdocCentre { get; set; }
		public virtual DbSet<WfdocCentreDetails> WfdocCentreDetails { get; set; }
		public virtual DbSet<Wfrouting> Wfrouting { get; set; }
		public virtual DbSet<WfroutingDetails> WfroutingDetails { get; set; }
		public virtual DbSet<Xrate> Xrate { get; set; }
		public virtual DbSet<Pclaim> Pclaim { get; set; }

		public virtual DbSet<PclaimDetail> PclaimDetail { get; set; }
		public virtual DbSet<PclaimRates> PclaimRates { get; set; }
		public virtual DbSet<StudClearance> StudClearances { get; set; }
		public virtual DbSet<FLBooking> FLBooking { get; set; }
		public virtual DbSet<FLTrips> FLTrips { get; set; }
		public virtual DbSet<FLCategory> FLCategory { get; set; }
		public virtual DbSet<FLVehicle> FLVehicle { get; set; }
		public virtual DbSet<ImprestMemo> ImprestMemo { get; set; }
		public virtual DbSet<ImprestMemoDetail> ImprestMemoDetail { get; set; }
		public virtual DbSet<ESWorkRequest> ESWorkRequests { get; set; }
		public virtual DbSet<ESProject> ESProjects { get; set; }
		public virtual DbSet<ESLocation> ESLocation { get; set; }
		public virtual DbSet<ESWorkOrder> ESWorkOrders { get; set; }

		//
		// Unable to generate entity type for table 'dbo.AccStatement2'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.AccStatementDet'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.MCS_Log'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.MCS_MealTrack'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.MCS_MealType'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.MCS_Members'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.MCS_MemCat'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.MCS_Setup'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.Studstmt'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.ClassFeesStatistics'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.CloseBal'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.StudReports'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.EditFees'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.IncomeExpStatement'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.EditInvoice'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.IncomeGen'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.StudTrans'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.IncomeGen2'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.MarkType'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.InvoiceSummary'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.FYearClose'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.TrialBal'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.PaySum'. Please see the warning messages.

		//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//        {
		//            if (!optionsBuilder.IsConfigured)
		//            {
		//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
		//                optionsBuilder.UseSqlServer("Server=.;Database=UnisolUOEdb;Trusted_Connection=True;");
		//            }
		//        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AcademicYear>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Enddate)
					.HasColumnName("enddate")
					.HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Startdate)
					.HasColumnName("startdate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<Accounts>(entity =>
			{
				entity.HasKey(e => e.AccNo);

				entity.Property(e => e.AccNo)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Caccount).HasColumnName("CAccount");

				entity.Property(e => e.Class)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.IsRequired()
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Paccount)
					.HasColumnName("PAccount")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Stype)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.SubGroup)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(15)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AccStatement>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasColumnName("account")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Balance)
					.HasColumnName("balance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Credit)
					.HasColumnName("credit")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Debit)
					.HasColumnName("debit")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Description)
					.HasColumnName("description")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Rmonth)
					.HasColumnName("rmonth")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AccStatementDet2>(entity =>
			{
				entity.HasKey(e => e.AdmnNo);

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Class)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ClassType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Paid).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Refund).HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<Activerecordlog>(entity =>
			{
				entity.ToTable("activerecordlog");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Action)
					.HasColumnName("action")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Creationdate)
					.HasColumnName("creationdate")
					.HasColumnType("datetime")
					.HasDefaultValueSql("(getdate())");

				entity.Property(e => e.Description)
					.HasColumnName("description")
					.HasMaxLength(255)
					.IsUnicode(false);

				entity.Property(e => e.Field)
					.HasColumnName("field")
					.HasMaxLength(45)
					.IsUnicode(false);

				entity.Property(e => e.IdModel).HasColumnName("idModel");

				entity.Property(e => e.Model)
					.HasColumnName("model")
					.HasMaxLength(45)
					.IsUnicode(false);

				entity.Property(e => e.Userid)
					.HasColumnName("userid")
					.HasMaxLength(45)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AdmnLetters>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Cclose)
					.HasColumnName("cclose")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Memo)
					.HasColumnName("memo")
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Salutation)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.SignImage).HasColumnType("image");

				entity.Property(e => e.Signature).IsUnicode(false);

				entity.Property(e => e.Source)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AdvPerStatistic>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Layout)
					.HasMaxLength(4000)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<AdvStudStatistic>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Layout)
					.HasMaxLength(4000)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<Apaccount>(entity =>
			{
				entity.ToTable("APAccount");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AppFiles>(entity =>
			{
				entity.HasKey(e => e.Fname);

				entity.Property(e => e.Fname)
					.HasColumnName("FName")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Description)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Extension)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Title)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Applicant>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Activity)
					.HasColumnName("activity")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Afrn)
					.HasColumnName("AFRN")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Constituency)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.County)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Createdate)
					.HasColumnName("createdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Disability)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.District)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Dob)
					.HasColumnName("DOB")
					.HasColumnType("datetime");

				entity.Property(e => e.Emaddress)
					.HasColumnName("EMAddress")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Ememail)
					.HasColumnName("EMEmail")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Emname)
					.HasColumnName("EMName")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Emrel)
					.HasColumnName("EMRel")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Emremarks)
					.HasColumnName("EMRemarks")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Emtel)
					.HasColumnName("EMTel")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Gender)
					.HasColumnName("gender")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Homeaddress)
					.HasColumnName("homeaddress")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.IndexNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Language)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Marital)
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.NationalId)
					.HasColumnName("nationalID")
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.Nationality)
					.HasColumnName("nationality")
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasColumnName("personnel")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Prevadmnno)
					.HasColumnName("prevadmnno")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Programme)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Religion)
					.HasColumnName("religion")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rmonth)
					.HasColumnName("RMonth")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ryear)
					.HasColumnName("RYear")
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Source)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Special)
					.HasColumnName("special")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Sponsor)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Status)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.StudyMode)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.SubCounty)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Telno)
					.HasColumnName("telno")
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AppointmentDiary>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.DateTimeScheduled).HasColumnType("datetime");

				entity.Property(e => e.StatusEnum).HasColumnName("StatusENUM");

				entity.Property(e => e.Title)
					.IsRequired()
					.HasMaxLength(100);
			});

			modelBuilder.Entity<AppReferee>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Address)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Designation)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Tel)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Website)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AppSchools>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.EndYear)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Grades)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.IndexNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qualification)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.StartYear)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AppWork>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Designation)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.EndYear)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.StartYear)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Station)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Araccount>(entity =>
			{
				entity.ToTable("ARAccount");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AssetCat>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.AccumulatedGl)
					.HasColumnName("AccumulatedGL")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Code)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.DepRate).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Ppeclass)
					.HasColumnName("PPEClass")
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AssetCheckHistory>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AssetNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Event)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.MemberId)
					.HasColumnName("MemberID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Rtime)
					.HasColumnName("RTime")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<AssetCheckIn>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AssetNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Location)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.MemberId)
					.HasColumnName("MemberID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Room)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AssetCheckOut>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AssetNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Location)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.MemberId)
					.HasColumnName("MemberID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Room)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AssetCount>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Aroom)
					.HasColumnName("ARoom")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.AssetNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Eroom)
					.HasColumnName("ERoom")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Period)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<AssetCountPeriod>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.DueDate).HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AssetFiles>(entity =>
			{
				entity.HasKey(e => e.Fname);

				entity.Property(e => e.Fname)
					.HasColumnName("FName")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.AssetNo)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Description)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Extension)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Title)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AssetLoc>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});
			modelBuilder.Entity<StudentStatementModelVirtual>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("Id");
				entity.Property(e => e.AdmnNo).HasMaxLength(200)
					.IsUnicode(false);
				entity.Property(e => e.Term).HasMaxLength(200)
					.IsUnicode(false);
				entity.Property(e => e.Rdate).HasColumnName("RDate")
					.HasColumnType("datetime");
				entity.Property(e => e.Ref).HasMaxLength(200)
					.IsUnicode(false);
				entity.Property(e => e.Description).HasMaxLength(200)
					.IsUnicode(false);
				entity.Property(e => e.Debit).HasColumnType("decimal(19, 4)");
				entity.Property(e => e.Credit).HasColumnType("decimal(19, 4)");
				entity.Property(e => e.Balance).HasColumnType("decimal(19, 4)");
				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});


			modelBuilder.Entity<AssetRoom>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Assets>(entity =>
			{
				entity.HasKey(e => e.AssetNo);

				entity.Property(e => e.AssetNo)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.AcqYear)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.AssetCat)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.AssetLoc)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.AssetType)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Barcode)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Brand)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.BusinessArea)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.CapitalDate).HasColumnType("datetime");

				entity.Property(e => e.CompanyCode)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.ControlAssign)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.CountryOrigin)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Description)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.FunctionalArea)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Fund)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.GrantNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.InsComp)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.InsText)
					.HasMaxLength(4000)
					.IsUnicode(false);

				entity.Property(e => e.InsType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.LicenseNo)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Manufacturer)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Model)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(4000)
					.IsUnicode(false);

				entity.Property(e => e.OldInvNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.OrderNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Pdate)
					.HasColumnName("PDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.PersonnelNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Plant)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.PolicyNo)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Pprice)
					.HasColumnName("PPrice")
					.HasColumnType("money");

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Room)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.SerialNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Specification)
					.HasMaxLength(2000)
					.IsUnicode(false);

				entity.Property(e => e.Status)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.SubClass)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Wdate)
					.HasColumnName("WDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<AssetService>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AssetNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Cdate)
					.HasColumnName("CDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Description)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Lcost)
					.HasColumnName("LCost")
					.HasColumnType("money");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Nsdate)
					.HasColumnName("NSDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Pcost)
					.HasColumnName("PCost")
					.HasColumnType("money");

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.ServiceBy)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Stype)
					.HasColumnName("SType")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AssetStatus>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AssetSubCat>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AssetType>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<AssetXlsfields>(entity =>
			{
				entity.HasKey(e => e.Fname);

				entity.ToTable("AssetXLSFields");

				entity.Property(e => e.Fname)
					.HasColumnName("FName")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Xlsvalue)
					.HasColumnName("XLSValue")
					.HasMaxLength(500)
					.IsUnicode(false);
			});

			modelBuilder.Entity<BankAcc>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AccClosed).HasColumnName("accClosed");

				entity.Property(e => e.AccNumber)
					.HasColumnName("accNumber")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Address)
					.HasColumnName("address")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.AssetAcc)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Btname)
					.HasColumnName("BTName")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasColumnName("ledger")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.MaxPayAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Password)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Payments).HasColumnName("payments");

				entity.Property(e => e.ReceiveCash).HasColumnName("receiveCash");

				entity.Property(e => e.StartBal)
					.HasColumnName("startBal")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UserName)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Banking>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasColumnName("account")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount)
					.HasColumnName("amount")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BankRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Cashier)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.LedgerFrom)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.LedgerTo)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.IsUnicode(false);

				entity.Property(e => e.Payee)
					.HasColumnName("payee")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasColumnName("personnel")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Reference)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<BankingDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BankRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ReceiptNumber)
					.HasColumnName("Receipt Number")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<BankingPosted>(entity =>
			{
				entity.HasKey(e => e.BankRef);

				entity.Property(e => e.BankRef)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Bdate).HasColumnType("datetime");

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Reference)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<BankingPostedDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.BankRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ReceiptNumber)
					.HasColumnName("Receipt Number")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Reference)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<BankRec>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Bank)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Cdate).HasColumnType("datetime");

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.LastDate).HasColumnType("datetime");

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.RecDate).HasColumnType("datetime");

				entity.Property(e => e.StateBal).HasColumnType("money");
			});

			modelBuilder.Entity<BankRecDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("money");

				entity.Property(e => e.Ddate)
					.HasColumnName("DDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Payee)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Ref1)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ref2)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Tdate)
					.HasColumnName("TDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Boarders>(entity =>
			{
				entity.HasKey(e => e.AdmnNo);

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Hostel)
					.HasColumnName("hostel")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Keynumber)
					.HasColumnName("keynumber")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasColumnName("personnel")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<BoardersPrev>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Hostel)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<BoardingSus>(entity =>
			{
				entity.HasKey(e => e.AdmnNo);

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Personnel)
					.HasColumnName("personnel")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Reason)
					.HasColumnName("reason")
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<BudgetAdj>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Fyear)
					.HasColumnName("FYear")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<BudgetAdjDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<BudgetD>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.BudgetPeriod)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<BudgetDdetail>(entity =>
			{
				entity.ToTable("BudgetDDetail");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ebp).HasColumnName("EBP");

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<BudgetM>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.Fyear)
					.HasColumnName("FYear")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<BudgetMdetail>(entity =>
			{
				entity.ToTable("BudgetMDetail");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<BudgetPeriods>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.EndDate).HasColumnType("datetime");

				entity.Property(e => e.Fyear)
					.HasColumnName("FYear")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.StartDate).HasColumnType("datetime");
			});

			modelBuilder.Entity<BudgetProj>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.Fyear)
					.HasColumnName("FYear")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<BudgetProjDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Campuses>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Address)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Contact)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Tel)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Website)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Cheques>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Bank)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ChequeNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.DocType)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.VoucherNo)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ChequesTax>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Bank)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ChequeNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.VoucherNo)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ChqCancelled>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Bank)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ChequeNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Reason)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ChqCollection>(entity =>
			{
				entity.ToTable("chqCollection");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Bank)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ChequeNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.CollectedBy)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Idnumber)
					.HasColumnName("IDNumber")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Tel)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ChqLog>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ChequeNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Computer)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Payee)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Rtime)
					.HasColumnName("rtime")
					.HasColumnType("datetime");

				entity.Property(e => e.VoucherNo)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ChqRegister>(entity =>
			{
				entity.ToTable("chqRegister");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Bank)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ChequeNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<ChqSch>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Bank)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<ChqSchDetails>(entity =>
			{
				entity.HasKey(e => e.VoucherNo);

				entity.Property(e => e.VoucherNo)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Ref)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ChqSettings>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.FigP)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.FigS)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Fsize).HasColumnName("FSize");

				entity.Property(e => e.PayeeP)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.PayeeS)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.PreviewB4print).HasColumnName("PreviewB4Print");

				entity.Property(e => e.WordsP)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Class>(entity =>
			{
				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Ayduration)
					.HasColumnName("AYDuration")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Cdate).HasColumnType("datetime");

				entity.Property(e => e.ClassType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Ends)
					.HasColumnName("ends")
					.HasColumnType("datetime");

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Programme)
					.HasColumnName("programme")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Starts)
					.HasColumnName("starts")
					.HasColumnType("datetime");

				entity.Property(e => e.Term)
					.HasColumnName("term")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ClassCourse>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Cat).HasColumnName("CAT");

				//entity.Property(e => e.Cat2).HasColumnName("CAT 2");

				entity.Property(e => e.Class)
					.HasMaxLength(50)
					.IsUnicode(false);

				//entity.Property(e => e.CourseWork).HasColumnName("COURSE WORK");

				entity.Property(e => e.Exam).HasColumnName("EXAM");

				entity.Property(e => e.ExamComp).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Hours).HasColumnType("decimal(18, 0)");

				entity.Property(e => e.MarkType)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.OtherTests).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PassMark).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Subject)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.TermType)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Tutors)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Classification>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Range)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.RepeatCase)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Scheme)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ClassStatistics>(entity =>
			{
				entity.HasKey(e => e.Class);

				entity.Property(e => e.Class)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.ClassType)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ClassStatus>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.IsUnicode(false);
			});

			modelBuilder.Entity<ClassType>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Cmoney>(entity =>
			{
				entity.ToTable("CMoney");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<Colleges>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Address)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Contact)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Tel)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Website)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ComMeals>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Boarding).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ewc)
					.HasColumnName("EWC")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<County>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CreditTransfer>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ApprovalStatus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Score).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Subject)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CronShared>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Stime).HasColumnType("datetime");

				entity.Property(e => e.Type)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Csplanner>(entity =>
			{
				entity.ToTable("CSPlanner");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasColumnName("personnel")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CsplannerDetail>(entity =>
			{
				entity.ToTable("CSPlannerDetail");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Class)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Milestone)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Odate)
					.HasColumnName("ODate")
					.HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Stage)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CsummarySettings>(entity =>
			{
				entity.ToTable("CSummarySettings");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Csmsg)
					.HasColumnName("CSMsg")
					.IsUnicode(false);
			});

			modelBuilder.Entity<Curr>(entity =>
			{
				entity.HasKey(e => e.Code);

				entity.Property(e => e.Code)
					.HasMaxLength(20)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CustCreditMemo>(entity =>
			{
				entity.HasKey(e => e.MemoRef);

				entity.Property(e => e.MemoRef)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.InvRef)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Reason)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CustCreditMemoDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Discount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MemoRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<CustCreditMemoRcptCredit>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.CustRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.MemoRef)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CustDebitMemo>(entity =>
			{
				entity.HasKey(e => e.MemoRef);

				entity.Property(e => e.MemoRef)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.InvRef)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Reason)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CustDebitMemoDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Charge).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.MemoRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<CustInv>(entity =>
			{
				entity.HasKey(e => e.InvRef);

				entity.Property(e => e.InvRef)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Araccount)
					.HasColumnName("ARAccount")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Curr)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.CustRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.DueDate).HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Pono)
					.HasColumnName("PONo")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.RecurEdate)
					.HasColumnName("RecurEDate")
					.HasColumnType("datetime");

				entity.Property(e => e.RecurInterval)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.RecurSdate)
					.HasColumnName("RecurSDate")
					.HasColumnType("datetime");

				entity.Property(e => e.SalesRep)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Terms)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CustInvDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Cost).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Discount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.InvRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Spec).IsUnicode(false);

				entity.Property(e => e.Tax).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TaxName)
					.HasMaxLength(1000)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CustItemAdjust>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<CustItemCat>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CustItemPrices>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate)
					.HasColumnName("SDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Taxes)
					.HasMaxLength(500)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CustItems>(entity =>
			{
				entity.HasKey(e => e.Code);

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Category)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Names)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Uom)
					.HasColumnName("UOM")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Customers>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Address)
					.HasColumnName("address")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Araccount)
					.HasColumnName("ARAccount")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Contact)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.CreditLimit).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CustomerType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Discount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Fax)
					.HasColumnName("fax")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Paddress)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Provider)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.RelationD)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Teld)
					.HasColumnName("teld")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Tele)
					.HasColumnName("tele")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Telm)
					.HasColumnName("telm")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Terms)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Web)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CustomerType>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CustProInv>(entity =>
			{
				entity.HasKey(e => e.InvRef);

				entity.Property(e => e.InvRef)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Curr)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.CustRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Terms)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CustProInvDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Cost).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Discount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.InvRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Spec).IsUnicode(false);

				entity.Property(e => e.Tax).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TaxName)
					.HasMaxLength(1000)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CustStatement>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Balance).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Credit).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Debit).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Description)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(20)
					.IsUnicode(false);
			});

			modelBuilder.Entity<CustTaxWh>(entity =>
			{
				entity.ToTable("CustTaxWH");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Adate)
					.HasColumnName("ADate")
					.HasColumnType("datetime");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CertNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.InvRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.TaxType)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<DebCredit>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes).IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<DebtorBalances>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Department>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.School)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Dletters>(entity =>
			{
				entity.ToTable("DLetters");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Cclose)
					.HasColumnName("cclose")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Memo)
					.HasColumnName("memo")
					.IsUnicode(false);

				entity.Property(e => e.Salutation)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Signature).IsUnicode(false);

				entity.Property(e => e.Type)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Eclaim>(entity =>
			{
				entity.HasKey(e => e.Ecref);

				entity.ToTable("EClaim");

				entity.Property(e => e.Ecref)
					.HasColumnName("ECRef")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Cc)
					.HasColumnName("CC")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ChequeNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ClaimDays)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Description)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.DestFrom)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.DestTo)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Distance)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.ImpRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.OnlineId)
					.HasColumnName("OnlineID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.OrderNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.PayeeRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");

				entity.Property(e => e.Status)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.VehicleRegNo)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<EclaimDetail>(entity =>
			{
				entity.ToTable("EClaimDetail");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Ecref)
					.HasColumnName("ECRef")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<EclaimDisb>(entity =>
			{
				entity.HasKey(e => e.Ecref);

				entity.ToTable("EClaimDisb");

				entity.Property(e => e.Ecref)
					.HasColumnName("ECRef")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Bank)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<EclaimReq>(entity =>
			{
				entity.ToTable("EClaimReq");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Cc)
					.HasColumnName("CC")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ClaimDays)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Description)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.DestFrom)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.DestTo)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Distance)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.ReactDate).HasColumnType("datetime");

				entity.Property(e => e.ReactTime).HasColumnType("datetime");

				entity.Property(e => e.Reactby)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Reaction).IsUnicode(false);

				entity.Property(e => e.Rtime).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");

				entity.Property(e => e.VehicleRegNo)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<EclaimReqUnits>(entity =>
			{
				entity.ToTable("EClaimReqUnits");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rate).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Units)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<EclaimUnits>(entity =>
			{
				entity.ToTable("EClaimUnits");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ecref)
					.HasColumnName("ECRef")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rate).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Units)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Endstand>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Art)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Begriff)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Benutzer)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Datum).HasColumnType("datetime");

				entity.Property(e => e.Ebene)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Klasse)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Matrikelnummer)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Partitur)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Thema)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Zeit).HasColumnType("datetime");
			});

			modelBuilder.Entity<Events>(entity =>
			{
				entity.ToTable("events");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.AllDay)
					.HasColumnName("allDay")
					.HasDefaultValueSql("('0')");

				entity.Property(e => e.Desc)
					.HasColumnName("desc")
					.HasColumnType("text");

				entity.Property(e => e.Editable)
					.HasColumnName("editable")
					.HasDefaultValueSql("('1')");

				entity.Property(e => e.End).HasColumnName("end");

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasMaxLength(1);

				entity.Property(e => e.Start).HasColumnName("start");

				entity.Property(e => e.TimeCreated)
					.HasColumnName("time_created")
					.HasColumnType("datetime");

				entity.Property(e => e.Title)
					.HasColumnName("title")
					.HasMaxLength(1000)
					.IsUnicode(false);

				entity.Property(e => e.Type).HasColumnName("type");

				entity.Property(e => e.UserId).HasColumnName("user_id");
			});

			modelBuilder.Entity<EventsHelper>(entity =>
			{
				entity.ToTable("events_helper");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Title)
					.HasColumnName("title")
					.HasMaxLength(1000)
					.IsUnicode(false);

				entity.Property(e => e.UserId).HasColumnName("user_id");
			});

			modelBuilder.Entity<Eventslist>(entity =>
			{
				entity.ToTable("eventslist");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.AllDay)
					.HasColumnName("allDay")
					.HasDefaultValueSql("('0')");

				entity.Property(e => e.Desc)
					.HasColumnName("desc")
					.HasColumnType("text");

				entity.Property(e => e.Editable)
					.HasColumnName("editable")
					.HasDefaultValueSql("('1')");

				entity.Property(e => e.End).HasColumnName("end");

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasMaxLength(1);

				entity.Property(e => e.Start).HasColumnName("start");

				entity.Property(e => e.TimeCreated)
					.HasColumnName("time_created")
					.HasColumnType("datetime");

				entity.Property(e => e.Title)
					.HasColumnName("title")
					.HasMaxLength(1000)
					.IsUnicode(false);

				entity.Property(e => e.Type).HasColumnName("type");

				entity.Property(e => e.UserId).HasColumnName("user_id");
			});

			modelBuilder.Entity<EventsType>(entity =>
			{
				entity.ToTable("events_type");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Color)
					.HasColumnName("color")
					.HasMaxLength(120)
					.IsUnicode(false);

				entity.Property(e => e.Name)
					.IsRequired()
					.HasColumnName("name")
					.HasMaxLength(120)
					.IsUnicode(false);
			});

			modelBuilder.Entity<EventsUserPreference>(entity =>
			{
				entity.HasKey(e => e.UserId);

				entity.ToTable("events_user_preference");

				entity.Property(e => e.UserId)
					.HasColumnName("user_id")
					.ValueGeneratedNever();

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(40)
					.IsUnicode(false);

				entity.Property(e => e.EmailAlert).HasColumnName("email_alert");

				entity.Property(e => e.Mobile)
					.HasColumnName("mobile")
					.HasMaxLength(1)
					.IsUnicode(false);

				entity.Property(e => e.MobileAlert).HasColumnName("mobile_alert");
			});

			modelBuilder.Entity<ExamLog>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Computer)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Macaddress)
					.HasColumnName("MACAddress")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.MarkType)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Rtime).HasColumnType("datetime");

				entity.Property(e => e.Subject)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ExamSlip>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ExamType>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.IsUnicode(false);
			});

			modelBuilder.Entity<FacilityBooking>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.BookingBy)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Etime).HasColumnType("datetime");

				entity.Property(e => e.EventType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Facility)
					.IsRequired()
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");

				entity.Property(e => e.Status)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Stime)
					.HasColumnName("STime")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<FacilityBookingStatusLog>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Computer)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Reason)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rtime).HasColumnType("datetime");

				entity.Property(e => e.Status)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<FeesPerClass>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AccommodationIncome)
					.HasColumnName("Accommodation Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccommodationStudents)
					.HasColumnName("Accommodation (Students)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccomodationFees)
					.HasColumnName("Accomodation Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccruedExpenses)
					.HasColumnName("Accrued Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccruedStatutoryOtherDeductions)
					.HasColumnName("Accrued Statutory & Other Deductions")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccummulatedArmotizationDepreciation)
					.HasColumnName("Accummulated Armotization & Depreciation")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedArmotizationOfLand)
					.HasColumnName("Accumulated Armotization of Land")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationBuilding)
					.HasColumnName("Accumulated Depreciation Building")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationComputersAndAccessories)
					.HasColumnName("Accumulated Depreciation Computers and Accessories")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationFurnitureAndFittings)
					.HasColumnName("Accumulated Depreciation Furniture and Fittings")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationLibraryBooks)
					.HasColumnName("Accumulated Depreciation Library Books")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationMotorVehicles)
					.HasColumnName("Accumulated Depreciation Motor Vehicles")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationPlantAndEquipment)
					.HasColumnName("Accumulated Depreciation Plant and Equipment")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ActivityFees)
					.HasColumnName("Activity Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AdministrativeAndRelatedIncomes)
					.HasColumnName("Administrative and Related Incomes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AgribusinessTradeFair)
					.HasColumnName("Agribusiness Trade Fair")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Amenity).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AmenityFees)
					.HasColumnName("Amenity Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ApplicationFees)
					.HasColumnName("Application Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BankLoans)
					.HasColumnName("Bank Loans")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BankTransfers)
					.HasColumnName("Bank transfers")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BookshopSales)
					.HasColumnName("Bookshop Sales")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BridgingFees)
					.HasColumnName("Bridging Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CapitalCreditors)
					.HasColumnName("Capital Creditors")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CateringIncome)
					.HasColumnName("Catering Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CautionMoney)
					.HasColumnName("Caution Money")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Cdf)
					.HasColumnName("CDF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CdfConstituencyDevelopmentFund)
					.HasColumnName("CDF- Constituency Development Fund")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Class)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.CollaboratingFees)
					.HasColumnName("Collaborating fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CommissionerOfDomesticTaxesWithholdingTax)
					.HasColumnName("Commissioner of Domestic Taxes (Withholding Tax)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ComputerFees)
					.HasColumnName("Computer Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ConferenceWorkshops)
					.HasColumnName("Conference & Workshops")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ContractualFees)
					.HasColumnName("Contractual Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CustomerPrepayments)
					.HasColumnName("Customer Prepayments")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DirectCharges)
					.HasColumnName("Direct Charges")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DonorFundedResearchReceipts)
					.HasColumnName("Donor Funded Research Receipts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Eia)
					.HasColumnName("EIA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ExaminationFees)
					.HasColumnName("Examination Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ExaminationsFees)
					.HasColumnName("Examinations Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ExchequerGrants)
					.HasColumnName("Exchequer Grants")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ExchequerGrantsRecurrent)
					.HasColumnName("Exchequer Grants (Recurrent)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FarmIncome)
					.HasColumnName("Farm Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldAttachment)
					.HasColumnName("Field Attachment")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldCourse)
					.HasColumnName("Field Course")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldTrips)
					.HasColumnName("Field Trips")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldWorkSupervision)
					.HasColumnName("Field Work Supervision")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FinesPenalties)
					.HasColumnName("Fines & Penalties")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Fisheries).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ForestryWoodScience)
					.HasColumnName("Forestry & Wood Science")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GraduationFees)
					.HasColumnName("Graduation Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GraduationIncome)
					.HasColumnName("Graduation Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Grants).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GuestHouse)
					.HasColumnName("Guest House")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GuestHouseIncome)
					.HasColumnName("Guest House Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbBursariesStudents)
					.HasColumnName("HELB-Bursaries Students")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbLoanRepaymentStaff)
					.HasColumnName("HELB-Loan Repayment Staff")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbLoanStudents)
					.HasColumnName("HELB-Loan Students")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbLoans)
					.HasColumnName("HELB Loans")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HireOfFacility)
					.HasColumnName("Hire of facility")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HireOfMotorVehicles)
					.HasColumnName("Hire of Motor Vehicles")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.IgaIncomes)
					.HasColumnName("IGA Incomes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.IncomeTaxPartTimeClaims)
					.HasColumnName("Income Tax (Part time claims)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.InterestIncome)
					.HasColumnName("Interest Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LegalAttachments)
					.HasColumnName("Legal Attachments")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LibraryFees)
					.HasColumnName("Library Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LibraryIncome)
					.HasColumnName("Library Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LoanRecoveries)
					.HasColumnName("Loan Recoveries")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LongTermLiabilities)
					.HasColumnName("Long Term Liabilities")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LongTermLoan)
					.HasColumnName("Long Term Loan")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MbaThesis)
					.HasColumnName("MBA Thesis")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MedicalFees)
					.HasColumnName("Medical Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MiscelaneuosIncome)
					.HasColumnName("Miscelaneuos Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.NetPay)
					.HasColumnName("Net Pay")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.NetSalary)
					.HasColumnName("Net Salary")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Nhif)
					.HasColumnName("NHIF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Nssf)
					.HasColumnName("NSSF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherIgaIncome)
					.HasColumnName("Other IGA Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherIncomes)
					.HasColumnName("Other Incomes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherLiabilitiesProvisions)
					.HasColumnName("Other Liabilities & Provisions")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherPayrollRecoveries)
					.HasColumnName("Other payroll recoveries")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherStudentRelatedIncome)
					.HasColumnName("Other Student Related Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PartTimeLecturers)
					.HasColumnName("Part-time Lecturers")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Paye)
					.HasColumnName("PAYE")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PayrollRecoveries)
					.HasColumnName("Payroll Recoveries")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Pension).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.PhotocopyingBinderyServices)
					.HasColumnName("Photocopying & Bindery Services")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PrepaidFeesStudents)
					.HasColumnName("Prepaid Fees (Students)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Prepayments).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProjectsRetentionMoney)
					.HasColumnName("Projects Retention Money")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProvisionForAuditFees)
					.HasColumnName("Provision for Audit Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProvisionForBadDebts)
					.HasColumnName("Provision for Bad Debts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.ReMarkingCharges)
					.HasColumnName("Re-marking Charges")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ReferralSupplementary)
					.HasColumnName("Referral/Supplementary")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Registration).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RentIncome)
					.HasColumnName("Rent Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RentPayable)
					.HasColumnName("Rent Payable")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ResearchAdministrationIncome)
					.HasColumnName("Research Administration Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ResearchAdministrativeIncome)
					.HasColumnName("Research Administrative Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ResearchFundAccounts)
					.HasColumnName("Research Fund Accounts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RetentionContractor)
					.HasColumnName("Retention (Contractor)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RetentionFees)
					.HasColumnName("Retention Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RoomDeposit)
					.HasColumnName("Room Deposit")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Saccos)
					.HasColumnName("SACCOs")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.SalaryRecovery)
					.HasColumnName("Salary Recovery")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.SpecialProject)
					.HasColumnName("Special Project")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Sponsor)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Sponsorships).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StaffInsurance)
					.HasColumnName("Staff Insurance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StaffMedicalClaims)
					.HasColumnName("Staff Medical Claims")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentIdFees)
					.HasColumnName("Student ID Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentMedicalFees)
					.HasColumnName("Student Medical Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentsOpeningBalance)
					.HasColumnName("Students Opening Balance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentsUnion)
					.HasColumnName("Students Union")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Supervision).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TeachingPractice)
					.HasColumnName("Teaching Practice")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TeachingPracticeFees)
					.HasColumnName("Teaching Practice Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Term)
					.HasColumnName("term")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ThesisFees)
					.HasColumnName("Thesis Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TradeAndOtherPayables)
					.HasColumnName("Trade and Other Payables")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TradeCreditors)
					.HasColumnName("Trade Creditors")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TuitionFees)
					.HasColumnName("Tuition Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TuitionIncome)
					.HasColumnName("Tuition Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UnallocatedFee)
					.HasColumnName("Unallocated Fee")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UnionDues)
					.HasColumnName("UNION DUES")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoExpenses)
					.HasColumnName("UoESO Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoFunds)
					.HasColumnName("UoESO Funds")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoFundsReceipts)
					.HasColumnName("UoESO Funds Receipts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Uoeso)
					.HasColumnName("UOESO")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoesoRent)
					.HasColumnName("UOESO Rent")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Vat)
					.HasColumnName("VAT")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.VatTaxes)
					.HasColumnName("VAT Taxes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.VlirCarHire)
					.HasColumnName("VLIR Car Hire")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Welfares)
					.HasColumnName("WELFARES")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.WithHoldingVatTaxWhvat)
					.HasColumnName("With-Holding VAT Tax (WHVAT)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.WithholdingTax)
					.HasColumnName("Withholding Tax")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.WorkshopPractice)
					.HasColumnName("Workshop Practice")
					.HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<FeesPerHostelRoom>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Hostel)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");

				entity.Property(e => e.Sponsor)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<FeesPerHostelRoomDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<FeesPerProg>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Campus)
					.HasMaxLength(1000)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Personnel).HasMaxLength(10);

				entity.Property(e => e.ProgCode)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");

				entity.Property(e => e.Specialization)
					.HasMaxLength(5000)
					.IsUnicode(false);

				entity.Property(e => e.Sponsor)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.StudyMode)
					.HasMaxLength(1000)
					.IsUnicode(false);
			});

			modelBuilder.Entity<FeesPerProgDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Stage)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<FeesPerUnit>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Campus)
					.HasMaxLength(1000)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");

				entity.Property(e => e.Sponsor)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.StudyMode)
					.HasMaxLength(1000)
					.IsUnicode(false);

				entity.Property(e => e.UnitCode)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<FeesPerUnitDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<FeesPolicy>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Paid).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");

				entity.Property(e => e.Sponsor)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<FeesPolicyDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Paid).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<FileManagerFiles>(entity =>
			{
				entity.HasKey(e => e.FileId);

				entity.Property(e => e.DateAdded).HasColumnType("datetime");

				entity.Property(e => e.FileDescription)
					.HasMaxLength(255)
					.IsUnicode(false);

				entity.Property(e => e.FileExt)
					.HasMaxLength(128)
					.IsUnicode(false);

				entity.Property(e => e.FileName)
					.HasMaxLength(255)
					.IsUnicode(false);

				entity.Property(e => e.FileOwner)
					.HasMaxLength(128)
					.IsUnicode(false);

				entity.Property(e => e.FilePath).IsUnicode(false);

				entity.Property(e => e.FileStatus)
					.HasMaxLength(128)
					.IsUnicode(false);

				entity.Property(e => e.FileType)
					.HasMaxLength(255)
					.IsUnicode(false);

				entity.HasOne(d => d.Folder)
					.WithMany(p => p.FileManagerFiles)
					.HasForeignKey(d => d.FolderId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__FileManag__Folde__454AAE85");
			});

			modelBuilder.Entity<FileManagerFolders>(entity =>
			{
				entity.HasKey(e => e.FolderId);

				entity.Property(e => e.DateAdded).HasColumnType("datetime");

				entity.Property(e => e.FolderName)
					.HasMaxLength(255)
					.IsUnicode(false);

				entity.Property(e => e.FolderOwner)
					.HasMaxLength(128)
					.IsUnicode(false);

				entity.Property(e => e.FolderPath).IsUnicode(false);

				entity.Property(e => e.FolderStatus)
					.HasMaxLength(128)
					.IsUnicode(false);

				entity.Property(e => e.ParentId)
					.HasMaxLength(10)
					.IsUnicode(false);
			});

			modelBuilder.Entity<FileStore>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.FileContent)
					.IsRequired()
					.HasColumnType("image");

				entity.Property(e => e.FileName)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.MimeType)
					.IsRequired()
					.HasMaxLength(50);
			});

			modelBuilder.Entity<FinancialAid>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(200)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Address)
					.HasColumnName("address")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.Fax)
					.HasColumnName("fax")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Teld)
					.HasColumnName("teld")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Tele)
					.HasColumnName("tele")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Telm)
					.HasColumnName("telm")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<FinancialYear>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.CloseBal).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Enddate)
					.HasColumnName("enddate")
					.HasColumnType("datetime");

				entity.Property(e => e.Ledger)
					.HasColumnName("ledger")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.IsUnicode(false);

				entity.Property(e => e.Startdate)
					.HasColumnName("startdate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<Fingerprints>(entity =>
			{
				entity.HasKey(e => e.Serial);

				entity.Property(e => e.Memo)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Template1).HasColumnType("image");

				entity.Property(e => e.Template2).HasColumnType("image");

				entity.Property(e => e.UserId)
					.HasColumnName("UserID")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Fyear>(entity =>
			{
				entity.ToTable("FYear");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.CloseBal).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CloseDate).HasColumnType("datetime");

				entity.Property(e => e.Enddate)
					.HasColumnName("enddate")
					.HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Startdate)
					.HasColumnName("startdate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<FyearPeriods>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.ToTable("FYearPeriods");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Caption)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.EndDate).HasColumnType("datetime");

				entity.Property(e => e.Fyear)
					.HasColumnName("FYear")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.StartDate).HasColumnType("datetime");
			});

			modelBuilder.Entity<GcsDeviceSetup>(entity =>
			{
				entity.ToTable("GCS_DeviceSetup");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AccessType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.DeviceId)
					.HasColumnName("DeviceID")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Ipaddress)
					.HasColumnName("IPAddress")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Port)
					.HasMaxLength(10)
					.IsUnicode(false);
			});

			modelBuilder.Entity<GcsEntryTrack>(entity =>
			{
				entity.ToTable("GCS_EntryTrack");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.BarcodeId)
					.HasColumnName("BarcodeID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.InDate).HasColumnType("datetime");

				entity.Property(e => e.InPlan)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.InTime).HasColumnType("datetime");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.OutDate).HasColumnType("datetime");

				entity.Property(e => e.OutPlan)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.OutTime).HasColumnType("datetime");

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<GcsLog>(entity =>
			{
				entity.ToTable("GCS_Log");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Computer)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Description).HasColumnType("ntext");

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Rtime)
					.HasColumnName("RTime")
					.HasColumnType("datetime");

				entity.Property(e => e.UserName)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<GcsMembers>(entity =>
			{
				entity.HasKey(e => e.BarcodeId);

				entity.ToTable("GCS_Members");

				entity.Property(e => e.BarcodeId)
					.HasColumnName("BarcodeID")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Category)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.DateLost).HasColumnType("datetime");

				entity.Property(e => e.DateSus).HasColumnType("datetime");

				entity.Property(e => e.Edate)
					.HasColumnName("EDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Epermission).HasColumnName("EPermission");

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.MemberId)
					.IsRequired()
					.HasColumnName("MemberID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<GcsMemCat>(entity =>
			{
				entity.ToTable("GCS_MemCat");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.DaysAllowed)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ExDate).HasColumnType("datetime");

				entity.Property(e => e.Names)
					.IsRequired()
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<GcsSetup>(entity =>
			{
				entity.ToTable("GCS_Setup");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Aname).HasColumnName("AName");

				entity.Property(e => e.Bcode)
					.HasColumnName("BCode")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.BiostarDbname)
					.HasColumnName("BiostarDBName")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.BiostarHost)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.BiostarPwd)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.BiostarUname)
					.HasColumnName("BiostarUName")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Category)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ClassStatus)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.ClassType)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.ImportOnlyMembersWithFp).HasColumnName("ImportOnlyMembersWithFP");

				entity.Property(e => e.MinArrears).HasColumnType("money");

				entity.Property(e => e.OverwriteFp).HasColumnName("OverwriteFP");

				entity.Property(e => e.StaffCat)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.VoiceType)
					.HasMaxLength(10)
					.IsUnicode(false);
			});

			modelBuilder.Entity<GcsTimePlan>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.ToTable("GCS_TimePlan");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.EndTime).HasColumnType("datetime");

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.StartTime).HasColumnType("datetime");

				entity.Property(e => e.Station)
					.IsRequired()
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<GcsTracking>(entity =>
			{
				entity.ToTable("GCS_Tracking");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.DeviceId)
					.HasColumnName("DeviceID")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.EventId)
					.HasColumnName("EventID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.InOut)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.MemberNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Rtime)
					.HasColumnName("RTime")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<Gpa>(entity =>
			{
				entity.HasKey(e => e.Grade);

				entity.ToTable("GPA");

				entity.Property(e => e.Grade)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Names)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Points).HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<GradeApproval>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Bcolor)
					.HasColumnName("BColor")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Fcolor)
					.HasColumnName("FColor")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Scope)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<GradeApprovalLog>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ApprovalStatus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Computer)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Rtime).HasColumnType("datetime");

				entity.Property(e => e.Subject)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Grading>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Gpa)
					.HasColumnName("GPA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GradeType)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Points)
					.HasColumnName("points")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Range)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Hediagnosis>(entity =>
			{
				entity.ToTable("HEDiagnosis");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Helocation>(entity =>
			{
				entity.ToTable("HELocation");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Hepatient>(entity =>
			{
				entity.HasKey(e => e.Pid);

				entity.ToTable("HEPatient");

				entity.Property(e => e.Pid)
					.HasColumnName("PID")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Allergies)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Dob)
					.HasColumnName("DOB")
					.HasColumnType("datetime");

				entity.Property(e => e.Exercise)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Gender)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.MedCondition)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Pref)
					.HasColumnName("PRef")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Smoker)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.SocialHistory)
					.HasMaxLength(500)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HepatientFiles>(entity =>
			{
				entity.HasKey(e => e.Fname);

				entity.ToTable("HEPatientFiles");

				entity.Property(e => e.Fname)
					.HasColumnName("FName")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Description)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Extension)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Title)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Hetests>(entity =>
			{
				entity.ToTable("HETests");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Hevisit>(entity =>
			{
				entity.HasKey(e => e.Vid);

				entity.ToTable("HEVisit");

				entity.Property(e => e.Vid)
					.HasColumnName("VID")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Condition)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Location)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Medication)
					.HasMaxLength(2000)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Pid)
					.HasColumnName("PID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<HevisitDiagnosis>(entity =>
			{
				entity.ToTable("HEVisitDiagnosis");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Diagnosis)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Result)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Vid)
					.HasColumnName("VID")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HevisitLoc>(entity =>
			{
				entity.ToTable("HEVisitLoc");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Location)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Rtime)
					.HasColumnName("RTime")
					.HasColumnType("datetime");

				entity.Property(e => e.Vid)
					.HasColumnName("VID")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HevisitReferral>(entity =>
			{
				entity.ToTable("HEVisitReferral");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Reason)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Recipient)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Subject)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Vid)
					.HasColumnName("VID")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HevisitTests>(entity =>
			{
				entity.ToTable("HEVisitTests");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Result)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Test)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Vid)
					.HasColumnName("VID")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HevisitVitals>(entity =>
			{
				entity.ToTable("HEVisitVitals");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Result)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Vid)
					.HasColumnName("VID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Vital)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Hevitals>(entity =>
			{
				entity.ToTable("HEVitals");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HostelBooking>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Hostel)
					.HasColumnName("hostel")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasColumnName("personnel")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HostelBookingRequest>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.IsRequired()
					.HasMaxLength(125)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime")
					.HasDefaultValueSql("(getdate())");

				entity.Property(e => e.Term)
					.IsRequired()
					.HasColumnName("term")
					.HasMaxLength(155)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HostelBookings>(entity =>
			{
				entity.ToTable("hostel_bookings");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.Names)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.Term)
					.IsRequired()
					.HasMaxLength(50);
			});

			modelBuilder.Entity<HostelRooms>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Gender)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Hostel)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Maxacc).HasColumnName("maxacc");

				entity.Property(e => e.Names)
					.IsRequired()
					.HasColumnName("names")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.RoomType)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Hostels>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amenities)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Contact)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Gender)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.HostelType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Location)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpAcademicRank>(entity =>
			{
				entity.ToTable("hrpAcademicRank");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpBank>(entity =>
			{
				entity.HasKey(e => e.Code);

				entity.ToTable("hrpBank");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Address)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Bank)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Branch)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Fax)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Scode)
					.HasColumnName("SCode")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Tel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Web)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpBenefits>(entity =>
			{
				entity.ToTable("hrpBenefits");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Benefit)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Coverage)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.EmployeePrem).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.EmployerPrem).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GrpPno)
					.HasColumnName("GrpPNo")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.IndPno)
					.HasColumnName("IndPNo")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Provider)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");

				entity.Property(e => e.Type)
					.HasMaxLength(30)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpContract>(entity =>
			{
				entity.ToTable("hrpContract");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Sdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpCountry>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.ToTable("hrpCountry");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpCounty>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.ToTable("hrpCounty");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpDedSetup>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.ToTable("hrpDedSetup");

				entity.Property(e => e.Deduction)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Fi)
					.HasColumnName("FI")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Sdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpDedSetupSub>(entity =>
			{
				entity.ToTable("hrpDedSetupSub");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Pgrade)
					.HasColumnName("PGrade")
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpDeductions>(entity =>
			{
				entity.ToTable("hrpDeductions");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Deduction)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Description)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Fi)
					.HasColumnName("FI")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.MaxAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MemNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.NumType)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate)
					.HasColumnName("SDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Type)
					.HasMaxLength(30)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpDeductionsAdhoc>(entity =>
			{
				entity.ToTable("hrpDeductionsAdhoc");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Deduction)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Description)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Fi)
					.HasColumnName("FI")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.MemNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.NumType)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate)
					.HasColumnName("SDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpDependant>(entity =>
			{
				entity.ToTable("hrpDependant");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Dob)
					.HasColumnName("DOB")
					.HasColumnType("datetime");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Gender)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Relationship)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpDivision>(entity =>
			{
				entity.ToTable("hrpDivision");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpEarnings>(entity =>
			{
				entity.ToTable("hrpEarnings");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Description)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Earning)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Edate)
					.HasColumnName("EDate")
					.HasColumnType("datetime");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Sdate)
					.HasColumnName("SDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Type)
					.HasMaxLength(30)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpEarningsAdhoc>(entity =>
			{
				entity.ToTable("hrpEarningsAdhoc");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Description)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Earning)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Sdate)
					.HasColumnName("SDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpEarnSetup>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.ToTable("hrpEarnSetup");

				entity.Property(e => e.Earning)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Sdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpEarnSetupSub>(entity =>
			{
				entity.ToTable("hrpEarnSetupSub");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Pgrade)
					.HasColumnName("PGrade")
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpEmpAccNo>(entity =>
			{
				entity.ToTable("hrpEmpAccNo");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AccNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.AccPercent).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bank)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpEmpCat>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.ToTable("hrpEmpCat");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpEmployee>(entity =>
			{
				entity.HasKey(e => e.EmpNo);

				entity.ToTable("hrpEmployee");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.AcademicRank)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Adate)
					.HasColumnName("ADate")
					.HasColumnType("datetime");

				entity.Property(e => e.Address)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Address2)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Cell)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.City)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.City2)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ContactNote)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Country)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.County)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.County2)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Disability).IsUnicode(false);

				entity.Property(e => e.Division)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Dob)
					.HasColumnName("DOB")
					.HasColumnType("datetime");

				entity.Property(e => e.Educ).IsUnicode(false);

				entity.Property(e => e.EmgName)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.EmgNotes).IsUnicode(false);

				entity.Property(e => e.EmgRel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.EmgTel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.EmpCat)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Exp).IsUnicode(false);

				entity.Property(e => e.Gender)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Hdate)
					.HasColumnName("HDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Hfax)
					.HasColumnName("HFax")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.House)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.House2)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Htel)
					.HasColumnName("HTel")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Idno)
					.HasColumnName("IDNo")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.InsExp).HasColumnType("datetime");

				entity.Property(e => e.JobCat)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Lang).IsUnicode(false);

				entity.Property(e => e.LeaveGroup)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.LicClass)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.LicExp).HasColumnType("datetime");

				entity.Property(e => e.LicNo)
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.Location)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Marital)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Medical).IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Nhif)
					.HasColumnName("NHIF")
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.Notes).IsUnicode(false);

				entity.Property(e => e.Nssf)
					.HasColumnName("NSSF")
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.Paddress)
					.HasColumnName("PAddress")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Pager)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Pcode)
					.HasColumnName("PCode")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Pcode2)
					.HasColumnName("PCode2")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Pemail)
					.HasColumnName("PEmail")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Pin)
					.HasColumnName("PIN")
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.Ppn)
					.HasColumnName("PPN")
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.Ppnexp)
					.HasColumnName("PPNExp")
					.HasColumnType("datetime");

				entity.Property(e => e.Race)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Religion)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Section)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Skills).IsUnicode(false);

				entity.Property(e => e.Spouse)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Supervisor)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.TerminationDate).HasColumnType("datetime");

				entity.Property(e => e.TerminationNotes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.TerminationType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Title)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Visa)
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.VisaExp).HasColumnType("datetime");

				entity.Property(e => e.Web)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Wemail)
					.HasColumnName("WEmail")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Wfax)
					.HasColumnName("WFax")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Wtel)
					.HasColumnName("WTel")
					.HasMaxLength(20)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpEmpStatus>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.ToTable("hrpEmpStatus");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.ExAccount)
					.HasMaxLength(2000)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.PayType)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Rate).HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<HrpFi>(entity =>
			{
				entity.ToTable("hrpFI");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Address)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Contact)
					.HasColumnName("contact")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Fax)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Tel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Web)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpFiles>(entity =>
			{
				entity.HasKey(e => e.Fname);

				entity.ToTable("hrpFiles");

				entity.Property(e => e.Fname)
					.HasColumnName("FName")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Description)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Extension)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Title)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpHospital>(entity =>
			{
				entity.ToTable("hrpHospital");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Address)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Contact)
					.HasColumnName("contact")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Fax)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Tel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Web)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpIncrementalDates>(entity =>
			{
				entity.HasKey(e => e.IncDate);

				entity.ToTable("hrpIncrementalDates");

				entity.Property(e => e.IncDate).HasColumnType("datetime");

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpInsProviders>(entity =>
			{
				entity.ToTable("hrpInsProviders");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Address)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Contact)
					.HasColumnName("contact")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Fax)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Tel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Web)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpIpcenter>(entity =>
			{
				entity.ToTable("hrpIPCenter");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpIpdeductions>(entity =>
			{
				entity.ToTable("hrpIPDeductions");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Deduction)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Description)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Fi)
					.HasColumnName("FI")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.MemNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.NumType)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpIpearnings>(entity =>
			{
				entity.ToTable("hrpIPEarnings");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.PayAccount)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rate).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Units)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpIppayAcc>(entity =>
			{
				entity.HasKey(e => e.Code);

				entity.ToTable("hrpIPPayAcc");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ItaxName)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Paye).HasColumnName("PAYE");

				entity.Property(e => e.PayeMin).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpIpprocess>(entity =>
			{
				entity.ToTable("hrpIPProcess");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.All)
					.HasColumnName("ALL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Alla)
					.HasColumnName("ALLA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Asai)
					.HasColumnName("ASAI")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bpfc)
					.HasColumnName("BPFC")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bppr)
					.HasColumnName("BPPR")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bpvl)
					.HasColumnName("BPVL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bsal)
					.HasColumnName("BSAL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Car)
					.HasColumnName("CAR")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Carr)
					.HasColumnName("CARR")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Che)
					.HasColumnName("CHE")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ChepkoilelEstatesShg)
					.HasColumnName("CHEPKOILEL ESTATES SHG")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Com)
					.HasColumnName("COM")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Cs)
					.HasColumnName("CS")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Emp)
					.HasColumnName("EMP")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Eq1)
					.HasColumnName("EQ1")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Exa)
					.HasColumnName("EXA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ext)
					.HasColumnName("EXT")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Flu)
					.HasColumnName("FLU")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Hall)
					.HasColumnName("HALL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Helb)
					.HasColumnName("HELB")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Hsc)
					.HasColumnName("HSC")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Lall)
					.HasColumnName("LALL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Lob)
					.HasColumnName("LOB")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Minto)
					.HasColumnName("MINTO")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MuInternalAuditShg)
					.HasColumnName("MU INTERNAL AUDIT SHG")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Musc)
					.HasColumnName("MUSC")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.NetPay).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Nhif)
					.HasColumnName("NHIF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Nssf)
					.HasColumnName("NSSF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Pay)
					.HasColumnName("PAYE")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Personnel)
					.HasColumnName("personnel")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Pro)
					.HasColumnName("PRO")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Pssp)
					.HasColumnName("PSSP")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RDate)
					.HasColumnName("rDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Rsc)
					.HasColumnName("RSC")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Salr)
					.HasColumnName("SALR")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Sdal)
					.HasColumnName("SDAL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Spc)
					.HasColumnName("SPC")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Stima)
					.HasColumnName("STIMA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Taxable).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Tel)
					.HasColumnName("TEL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Tela)
					.HasColumnName("TELA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Uhsshg)
					.HasColumnName("UHSSHG")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Uo)
					.HasColumnName("UO")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Uoesacco)
					.HasColumnName("UOESACCO")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Wacera)
					.HasColumnName("WACERA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Whd)
					.HasColumnName("WHD")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Wth)
					.HasColumnName("WTH")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._001)
					.HasColumnName("001")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._002)
					.HasColumnName("002")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._005)
					.HasColumnName("005")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._006)
					.HasColumnName("006")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._015)
					.HasColumnName("015")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._036)
					.HasColumnName("036")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._101)
					.HasColumnName("101")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._102)
					.HasColumnName("102")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._103)
					.HasColumnName("103")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._106)
					.HasColumnName("106")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._107)
					.HasColumnName("107")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._110)
					.HasColumnName("110")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._111)
					.HasColumnName("111")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._112)
					.HasColumnName("112")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._113)
					.HasColumnName("113")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._18)
					.HasColumnName("18")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._200)
					.HasColumnName("200")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._314)
					.HasColumnName("314")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._555)
					.HasColumnName("555")
					.HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<HrpIpprofile>(entity =>
			{
				entity.ToTable("hrpIPProfile");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AccNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Bank)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Center)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.EmpNo)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.JobTitle)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Pmode)
					.HasColumnName("PMode")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Salary).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Sdate)
					.HasColumnName("SDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpIpprojects>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.ToTable("hrpIPProjects");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Cdate)
					.HasColumnName("CDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Description)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.DueDate).HasColumnType("datetime");

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpJobCat>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.ToTable("hrpJobCat");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpJobTitles>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.ToTable("hrpJobTitles");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Description).IsUnicode(false);

				entity.Property(e => e.Duties).IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Pgrade)
					.HasColumnName("PGrade")
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpLeaveApp>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.ToTable("hrpLeaveApp");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Etime)
					.HasMaxLength(5)
					.IsUnicode(false);

				entity.Property(e => e.LeaveDays).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LeavePeriod)
					.IsRequired()
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.LeaveType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");

				entity.Property(e => e.Status)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Stime)
					.HasMaxLength(5)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpLeaveEntit>(entity =>
			{
				entity.ToTable("hrpLeaveEntit");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.LeaveDays).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LeavePeriod)
					.IsRequired()
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.LeaveType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpLeaveGroups>(entity =>
			{
				entity.ToTable("hrpLeaveGroups");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpLeaveHolidays>(entity =>
			{
				entity.ToTable("hrpLeaveHolidays");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Hdate)
					.HasColumnName("HDate")
					.HasColumnType("datetime");

				entity.Property(e => e.LeavePeriod)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Location)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpLeavePeriod>(entity =>
			{
				entity.ToTable("hrpLeavePeriod");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.EndDate).HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.StartDate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpLeaveReserved>(entity =>
			{
				entity.ToTable("hrpLeaveReserved");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.EndDate).HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.StartDate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpLeaveRules>(entity =>
			{
				entity.ToTable("hrpLeaveRules");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.CfdayValidity)
					.HasColumnName("CFDayValidity")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CfdaysLimit)
					.HasColumnName("CFDaysLimit")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Edate)
					.HasColumnName("EDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Gender)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.LeaveDays).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LeaveGroup)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.LeaveType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate)
					.HasColumnName("SDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpLeaveStatusLog>(entity =>
			{
				entity.ToTable("hrpLeaveStatusLog");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Computer)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Reason)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rtime).HasColumnType("datetime");

				entity.Property(e => e.Status)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpLeaveType>(entity =>
			{
				entity.HasKey(e => e.Code);

				entity.ToTable("hrpLeaveType");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpLeaveWorkWeek>(entity =>
			{
				entity.ToTable("hrpLeaveWorkWeek");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Location)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpLoanSetup>(entity =>
			{
				entity.ToTable("hrpLoanSetup");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DateClosed).HasColumnType("datetime");

				entity.Property(e => e.Description)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Fi)
					.HasColumnName("FI")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.IntPeriod)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.IntRate).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.IntType)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Loan)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.LoanTerm).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MemNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.NumType)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate)
					.HasColumnName("SDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpLoanSub>(entity =>
			{
				entity.ToTable("hrpLoanSub");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Interest).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Premium).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Principal).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpLoc>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.ToTable("hrpLoc");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpLog>(entity =>
			{
				entity.ToTable("hrpLog");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Computer)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Description).IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Rtime)
					.HasColumnName("RTime")
					.HasColumnType("datetime");

				entity.Property(e => e.UserName)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpMedicalClaims>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.ToTable("hrpMedicalClaims");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DocDate).HasColumnType("datetime");

				entity.Property(e => e.Doctor)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Hospital)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Patient)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpMedicalClaimsPay>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.ToTable("hrpMedicalClaimsPay");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpMedicalClaimsPayDetails>(entity =>
			{
				entity.HasKey(e => e.ClaimRef);

				entity.ToTable("hrpMedicalClaimsPayDetails");

				entity.Property(e => e.ClaimRef)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Ref)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpNhif>(entity =>
			{
				entity.ToTable("hrpNHIF");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Deduction).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MaxAmt)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.MinAmt)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpNhifmain>(entity =>
			{
				entity.ToTable("hrpNHIFMain");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpPayAcc>(entity =>
			{
				entity.HasKey(e => e.Code);

				entity.ToTable("hrpPayAcc");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Eraccount)
					.HasColumnName("ERAccount")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ItaxName)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Nhif).HasColumnName("NHIF");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Paye).HasColumnName("PAYE");

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpPaye>(entity =>
			{
				entity.ToTable("hrpPAYE");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.MaxAmt)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.MinAmt)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Tax).HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<HrpPayemain>(entity =>
			{
				entity.ToTable("hrpPAYEMain");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Prelief)
					.HasColumnName("PRelief")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpPayGrades>(entity =>
			{
				entity.ToTable("hrpPayGrades");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Drate)
					.HasColumnName("DRate")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Hrate)
					.HasColumnName("HRate")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MedicalExp).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Names)
					.IsRequired()
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Otrate)
					.HasColumnName("OTRate")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpPayGradesSub>(entity =>
			{
				entity.ToTable("hrpPayGradesSub");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.MaxSal).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MinSal).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PayGrade)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rank)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.StepInc).HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<HrpPayrollJournal>(entity =>
			{
				entity.ToTable("hrpPayrollJournal");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AcademicFieldTrips)
					.HasColumnName("Academic Field Trips")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AcademicTeachingResearchConsultancyExtension)
					.HasColumnName("Academic ( Teaching, Research, Consultancy & Extension)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccreditationAdmissionRegistrationExpenses)
					.HasColumnName("Accreditation, Admission & Registration Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccruedExpenses)
					.HasColumnName("Accrued Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccruedStatutoryOtherDeductions)
					.HasColumnName("Accrued Statutory & Other Deductions")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccummulatedArmotizationDepreciation)
					.HasColumnName("Accummulated Armotization & Depreciation")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedArmotizationOfLand)
					.HasColumnName("Accumulated Armotization of Land")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationBuilding)
					.HasColumnName("Accumulated Depreciation Building")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationComputersAndAccessories)
					.HasColumnName("Accumulated Depreciation Computers and Accessories")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationFurnitureAndFittings)
					.HasColumnName("Accumulated Depreciation Furniture and Fittings")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationLibraryBooks)
					.HasColumnName("Accumulated Depreciation Library Books")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationMotorVehicles)
					.HasColumnName("Accumulated Depreciation Motor Vehicles")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationPlantAndEquipment)
					.HasColumnName("Accumulated Depreciation Plant and Equipment")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AdministrationAcademicAndCentralServicesExpenses)
					.HasColumnName("Administration, Academic and Central Services Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AdministrationCosts)
					.HasColumnName("Administration Costs")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AdvertisingPublicity)
					.HasColumnName("Advertising & Publicity")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AppiaryExpenses)
					.HasColumnName("Appiary Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ArmotizationDepreciationExpenses)
					.HasColumnName("Armotization & Depreciation Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ArmotizationOfLand)
					.HasColumnName("Armotization of Land")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AuditFeesExpenses)
					.HasColumnName("Audit Fees Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BankChargesCommissions)
					.HasColumnName("Bank Charges & Commissions")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BankLoans)
					.HasColumnName("Bank Loans")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BankTransfers)
					.HasColumnName("Bank transfers")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BarleyExpenses)
					.HasColumnName("Barley Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BookShopExpenses)
					.HasColumnName("Book Shop Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CapitalCreditors)
					.HasColumnName("Capital Creditors")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CateringExpenses)
					.HasColumnName("Catering Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CautionMoney)
					.HasColumnName("Caution Money")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CdfConstituencyDevelopmentFund)
					.HasColumnName("CDF- Constituency Development Fund")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ChancellorsExpenses)
					.HasColumnName("Chancellors Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CleaningMaterialsDetergents)
					.HasColumnName("Cleaning Materials & Detergents")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CollaboratingExpense)
					.HasColumnName("Collaborating Expense")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CommercialEnterprisesIguWorkingCapital)
					.HasColumnName("Commercial Enterprises & IGU Working Capital")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CommissionerOfDomesticTaxesWithholdingTax)
					.HasColumnName("Commissioner of Domestic Taxes (Withholding Tax)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CommuterAllowances)
					.HasColumnName("Commuter Allowances")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ConferenceWorkshopsExpenses)
					.HasColumnName("Conference & Workshops Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ContigentExpenses)
					.HasColumnName("Contigent Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ContractServicesSubscriptions)
					.HasColumnName("Contract Services & Subscriptions")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ContractedEmployees)
					.HasColumnName("Contracted Employees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CouncilCouncilCommitteesExpenses)
					.HasColumnName("Council & Council Committees Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CouncilMealsRefreshments)
					.HasColumnName("Council Meals & Refreshments")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CouncilOtherExpenses)
					.HasColumnName("Council Other Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CouncilSittingAllowance)
					.HasColumnName("Council Sitting Allowance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CouncilTravellingAndAccomodation)
					.HasColumnName("Council Travelling and Accomodation")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Crops).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CustomerPrepayments)
					.HasColumnName("Customer Prepayments")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DairyExpenses)
					.HasColumnName("Dairy Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DeansSenateComitteesConfrenceExpenses)
					.HasColumnName("Deans, Senate Comittees & Confrence Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DepreciationBuildings)
					.HasColumnName("Depreciation Buildings")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DepreciationComputersAndAssesories)
					.HasColumnName("Depreciation Computers and Assesories")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DepreciationFurnitureAndFittings)
					.HasColumnName("Depreciation Furniture and Fittings")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DepreciationLibraryBooks)
					.HasColumnName("Depreciation Library Books")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DepreciationMotorVehicles)
					.HasColumnName("Depreciation Motor Vehicles")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DepreciationPlantAndEquipment)
					.HasColumnName("Depreciation plant and Equipment")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DonorFundedResearchDisbursements)
					.HasColumnName("Donor Funded Research Disbursements")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DonorFundedResearchReceipts)
					.HasColumnName("Donor Funded Research Receipts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.EiaExpenses)
					.HasColumnName("EIA Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.EmploymentExpenses)
					.HasColumnName("Employment Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ErpSytemMentainance)
					.HasColumnName("ERP Sytem Mentainance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ExaminationExpenses)
					.HasColumnName("Examination Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ExternalExaminers)
					.HasColumnName("External Examiners")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ExternalTravellingAccomodation)
					.HasColumnName("External Travelling & Accomodation")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FarmExpenses)
					.HasColumnName("Farm Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FarmExpensesOld)
					.HasColumnName("Farm Expenses Old")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FinanceCharges)
					.HasColumnName("Finance Charges")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FisheriesExpense)
					.HasColumnName("Fisheries Expense")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ForestryAndWoodScienceExpenses)
					.HasColumnName("Forestry and Wood Science Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GainLossOnBiologicalAssets)
					.HasColumnName("Gain/(Loss) on Biological Assets")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GainLossOnDisposalOfAssets)
					.HasColumnName("Gain/(Loss) on Disposal of Assets")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GainLossOnForeignExchangeTransactions)
					.HasColumnName("Gain/(Loss) on Foreign Exchange Transactions")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GraduationExpenses)
					.HasColumnName("Graduation Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GratuityPensionContributions)
					.HasColumnName("Gratuity & Pension Contributions")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GuestHouseExpense)
					.HasColumnName("Guest House Expense")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbBursariesStudents)
					.HasColumnName("HELB-Bursaries Students")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbLoanRepaymentStaff)
					.HasColumnName("HELB-Loan Repayment Staff")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbLoanStudents)
					.HasColumnName("HELB-Loan Students")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HireOfMotorVehiclesExpense)
					.HasColumnName("Hire of Motor Vehicles Expense")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HouseAllowances)
					.HasColumnName("House Allowances")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.IgaExpenses)
					.HasColumnName("IGA Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.IncomeTaxPartTimeClaims)
					.HasColumnName("Income Tax (Part time claims)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.IncreaseDecreaseInProvisionForBadDebts)
					.HasColumnName("Increase/(Decrease) in Provision for Bad Debts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.InsuranceExpenses)
					.HasColumnName("Insurance Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.InterUniversityGamesSports)
					.HasColumnName("Inter University Games & Sports")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.InterestCharges)
					.HasColumnName("Interest Charges")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.InternetServices)
					.HasColumnName("Internet Services")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.IsoQualityAssuranceExpenses)
					.HasColumnName("ISO & Quality Assurance Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LandTrasferExpenses)
					.HasColumnName("Land Trasfer Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LegalAttachments)
					.HasColumnName("Legal Attachments")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LegalExpenses)
					.HasColumnName("Legal Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LibraryExpenses)
					.HasColumnName("Library Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LibraryPeriodicalsJournals)
					.HasColumnName("Library Periodicals & Journals")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Livestock).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LongTermLiabilities)
					.HasColumnName("Long Term Liabilities")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MaintainaceOfPlantFurnitureEquipment)
					.HasColumnName("Maintainace of Plant, Furniture & Equipment")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MaintenanceOfBuildingsStations)
					.HasColumnName("Maintenance of Buildings & Stations")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MaintenanceOfCateringHostelFacilities)
					.HasColumnName("Maintenance of Catering & Hostel Facilities")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MaintenanceOfComputersPrintersCopiers)
					.HasColumnName("Maintenance of Computers, Printers & Copiers")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MaintenanceOfMotorVehicles)
					.HasColumnName("Maintenance of Motor Vehicles")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MaintenanceOfPlaygroundsParks)
					.HasColumnName("Maintenance of Playgrounds & Parks")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MaintenanceOfWaterSuppliersSewerage)
					.HasColumnName("Maintenance of Water Suppliers & Sewerage")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MaizeExpenses)
					.HasColumnName("Maize Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MedicalExpenses)
					.HasColumnName("Medical Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MilletExpenses)
					.HasColumnName("Millet Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.NetPay)
					.HasColumnName("Net Pay")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Newspapers).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Nhif)
					.HasColumnName("NHIF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Nssf)
					.HasColumnName("NSSF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OfficeRunningExpenses)
					.HasColumnName("Office Running Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OfficialEntertainment)
					.HasColumnName("Official Entertainment")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OpenCulturalDayExpenses)
					.HasColumnName("Open & Cultural Day Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherGainsLoss)
					.HasColumnName("Other Gains/(Loss)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherIgaExpenses)
					.HasColumnName("Other IGA Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherLiabilitiesProvisions)
					.HasColumnName("Other Liabilities & Provisions")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherPersonalAllowances)
					.HasColumnName("Other Personal Allowances")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PartTimeClaims)
					.HasColumnName("Part Time Claims")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PartTimeLecturers)
					.HasColumnName("Part-time Lecturers")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PassageLeaveAllowance)
					.HasColumnName("Passage & Leave Allowance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Paye)
					.HasColumnName("PAYE")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PaymentOfRentRates)
					.HasColumnName("Payment of Rent & Rates")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PayrollRecoveries)
					.HasColumnName("Payroll Recoveries")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Pension)
					.HasColumnName("PENSION")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PerformanceContracting)
					.HasColumnName("Performance Contracting")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PersonalEmoluments)
					.HasColumnName("Personal Emoluments")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PiggeryExpenses)
					.HasColumnName("Piggery Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PostalTelegrams)
					.HasColumnName("Postal & Telegrams")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PostgraduateSupervision)
					.HasColumnName("Postgraduate Supervision")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PoultryExpenses)
					.HasColumnName("Poultry Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PrepaidFeesStudents)
					.HasColumnName("Prepaid Fees (Students)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PrintingPublications)
					.HasColumnName("Printing & Publications")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProjectsRetentionMoney)
					.HasColumnName("Projects Retention Money")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProvisionForAuditFees)
					.HasColumnName("Provision for Audit Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProvisionForBadDebts)
					.HasColumnName("Provision for Bad Debts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PsspServiceProvidersDisbursements)
					.HasColumnName("PSSP Service Providers Disbursements")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PublicCelebrationsStaffWelfare)
					.HasColumnName("Public Celebrations & Staff Welfare")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PurchaseOfGowns)
					.HasColumnName("Purchase of Gowns")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PurchaseOfStationary)
					.HasColumnName("Purchase of Stationary")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PurchaseOfUniformsClothing)
					.HasColumnName("Purchase of Uniforms & Clothing")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RDate)
					.HasColumnName("rDate")
					.HasColumnType("datetime");

				entity.Property(e => e.RabbitsExpenses)
					.HasColumnName("Rabbits Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RecruitmentTrainingExpenses)
					.HasColumnName("Recruitment & Training Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RentPayable)
					.HasColumnName("Rent Payable")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ResearchFundAccounts)
					.HasColumnName("Research Fund Accounts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RetentionContractor)
					.HasColumnName("Retention (Contractor)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Saccos)
					.HasColumnName("SACCOs")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.SalaryRecovery)
					.HasColumnName("Salary Recovery")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.SecurityServices)
					.HasColumnName("Security Services")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ShowAndAgribusinessExpenses)
					.HasColumnName("Show and Agribusiness Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Speriod)
					.HasColumnName("SPeriod")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Sponsorships).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StaffAndStudentsWelfare)
					.HasColumnName("Staff and Students Welfare")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StaffInsurance)
					.HasColumnName("Staff Insurance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StaffMedicalClaims)
					.HasColumnName("Staff Medical Claims")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StaffTuitionWaivers)
					.HasColumnName("Staff Tuition Waivers")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StrategicPlanMasterPlanDesign)
					.HasColumnName("Strategic Plan & Master Plan Design")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentsWelfareOtherActivities)
					.HasColumnName("Students Welfare & Other Activities")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.SupportServices)
					.HasColumnName("Support Services")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TeachingMaterialExpenses)
					.HasColumnName("Teaching material expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TeachingPracticeFieldAttachment)
					.HasColumnName("Teaching Practice & Field Attachment")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TelephoneExpenses)
					.HasColumnName("Telephone Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TradeAndOtherPayables)
					.HasColumnName("Trade and Other Payables")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TradeCreditors)
					.HasColumnName("Trade Creditors")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TransportFuelExpenses)
					.HasColumnName("Transport Fuel Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TravellingAccomodation)
					.HasColumnName("Travelling & Accomodation")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UesoExpenses)
					.HasColumnName("UESO Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UnallocatedFee)
					.HasColumnName("Unallocated Fee")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UnionDues)
					.HasColumnName("UNION DUES")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UniversityFundedResearchExpenses)
					.HasColumnName("University Funded Research Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UniversityOutreachProgrammeExhibition)
					.HasColumnName("University Outreach Programme & Exhibition")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoExpenses)
					.HasColumnName("UoESO Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoFunds)
					.HasColumnName("UoESO Funds")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoFundsReceipts)
					.HasColumnName("UoESO Funds Receipts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoesoRentExpenses)
					.HasColumnName("UOESO Rent Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UtilitiesElectricityWaterConservancy)
					.HasColumnName("Utilities (Electricity, Water & Conservancy)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.VatTaxes)
					.HasColumnName("VAT Taxes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Welfares)
					.HasColumnName("WELFARES")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.WheatExpenses)
					.HasColumnName("Wheat Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.WithHoldingVatTaxWhvat)
					.HasColumnName("With-Holding VAT Tax (WHVAT)")
					.HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<HrpPension>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.ToTable("hrpPension");

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Eevalue)
					.HasColumnName("EEValue")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ervalue)
					.HasColumnName("ERValue")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Fi)
					.HasColumnName("FI")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Pension)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Pgrade)
					.HasColumnName("PGrade")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpPersonnelImportXlsfields>(entity =>
			{
				entity.ToTable("hrpPersonnelImportXLSFields");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Fname)
					.HasColumnName("FName")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Xlsvalue)
					.HasColumnName("XLSValue")
					.HasMaxLength(500)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpPmperiod>(entity =>
			{
				entity.ToTable("hrpPMPeriod");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.CloseDate).HasColumnType("datetime");

				entity.Property(e => e.EndDate).HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.StartDate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpPmrating>(entity =>
			{
				entity.ToTable("hrpPMRating");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rate).HasColumnType("decimal(19, 10)");

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpPromoDate>(entity =>
			{
				entity.ToTable("hrpPromoDate");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Pdate)
					.HasColumnName("PDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpRace>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.ToTable("hrpRace");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpRetro>(entity =>
			{
				entity.ToTable("hrpRetro");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpRetroDetail>(entity =>
			{
				entity.ToTable("hrpRetroDetail");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Fi)
					.HasColumnName("FI")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.MemNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.NumType)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Sdate).HasColumnType("datetime");

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpReview>(entity =>
			{
				entity.ToTable("hrpReview");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.DeptObjectives)
					.HasMaxLength(5000)
					.IsUnicode(false);

				entity.Property(e => e.EmpComments)
					.HasMaxLength(5000)
					.IsUnicode(false);

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.EmpSwca)
					.HasColumnName("EmpSWCA")
					.HasMaxLength(5000)
					.IsUnicode(false);

				entity.Property(e => e.NextObjectives)
					.HasMaxLength(5000)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.RevDate).HasColumnType("datetime");

				entity.Property(e => e.ReviewAction)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ReviewActionDate).HasColumnType("datetime");

				entity.Property(e => e.ReviewPeriod)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpReviewDetails>(entity =>
			{
				entity.ToTable("hrpReviewDetails");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.DateWhen).HasColumnType("datetime");

				entity.Property(e => e.PerformanceProof)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.PerformanceRating).HasColumnType("decimal(19, 10)");

				entity.Property(e => e.PerformanceTarget)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ResultsAchieved).HasColumnType("decimal(19, 10)");

				entity.Property(e => e.WeightTarget).HasColumnType("decimal(19, 10)");
			});

			modelBuilder.Entity<HrpSalPeriod>(entity =>
			{
				entity.ToTable("hrpSalPeriod");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Cdate)
					.HasColumnName("CDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Edate)
					.HasColumnName("EDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Pfreq)
					.HasColumnName("PFreq")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ryear)
					.HasColumnName("RYear")
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Sdate)
					.HasColumnName("SDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpSalProcess>(entity =>
			{
				entity.ToTable("hrpSalProcess");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Arr)
					.HasColumnName("ARR")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bam)
					.HasColumnName("BAM")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bja)
					.HasColumnName("BJA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bor)
					.HasColumnName("BOR")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bun)
					.HasColumnName("BUN")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bunl)
					.HasColumnName("BUNL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Cewl)
					.HasColumnName("CEWL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Cewshg)
					.HasColumnName("CEWSHG")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Co)
					.HasColumnName("CO")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Court)
					.HasColumnName("COURT")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Disall)
					.HasColumnName("DISALL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Eca)
					.HasColumnName("ECA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ecaar)
					.HasColumnName("ECAAR")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Emp)
					.HasColumnName("EMP")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Flu)
					.HasColumnName("FLU")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Gra)
					.HasColumnName("GRA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Gus)
					.HasColumnName("GUS")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Guss)
					.HasColumnName("GUSS")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Hall)
					.HasColumnName("hall")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Hfck)
					.HasColumnName("HFCK")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Hlt)
					.HasColumnName("HLT")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Hpg)
					.HasColumnName("HPG")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Im)
					.HasColumnName("IM")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Imp)
					.HasColumnName("IMP")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Imp2)
					.HasColumnName("IMP2")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Imp3)
					.HasColumnName("IMP3")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Impref)
					.HasColumnName("IMPREF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Imw)
					.HasColumnName("IMW")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Kcb2)
					.HasColumnName("KCB2")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Kei)
					.HasColumnName("KEI")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Koy)
					.HasColumnName("KOY")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Lobl)
					.HasColumnName("LOBL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Lobs)
					.HasColumnName("LOBS")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Lta)
					.HasColumnName("LTA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Luall)
					.HasColumnName("LUALL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Mmed)
					.HasColumnName("MMED")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Muacd)
					.HasColumnName("MUACD")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Mvl)
					.HasColumnName("MVL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Mwae)
					.HasColumnName("MWAE")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Mwd)
					.HasColumnName("MWD")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Mwl)
					.HasColumnName("MWL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Mwsl)
					.HasColumnName("MWSL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Mwss)
					.HasColumnName("MWSS")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.NetPay).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.New)
					.HasColumnName("NEW")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Npa)
					.HasColumnName("NPA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Npaar)
					.HasColumnName("NPAAR")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Oldmut)
					.HasColumnName("OLDMUT")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Op)
					.HasColumnName("OP")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Penv)
					.HasColumnName("PENV")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Personnel)
					.HasColumnName("personnel")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Plcr)
					.HasColumnName("PLCR")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Pres)
					.HasColumnName("PRES")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Pssp)
					.HasColumnName("PSSP")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ptc)
					.HasColumnName("PTC")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Pts)
					.HasColumnName("PTS")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ptsl)
					.HasColumnName("PTSL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RDate)
					.HasColumnName("rDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Sal)
					.HasColumnName("SAL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Sm)
					.HasColumnName("SM")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Sod)
					.HasColumnName("SOD")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Sop)
					.HasColumnName("SOP")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Speriod)
					.HasColumnName("SPeriod")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Stimln)
					.HasColumnName("stimln")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Stl)
					.HasColumnName("STL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Stmsacco)
					.HasColumnName("stmsacco")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Sum)
					.HasColumnName("SUM")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Suma)
					.HasColumnName("SUMA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Taxable).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Tx)
					.HasColumnName("TX")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Uap)
					.HasColumnName("UAP")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ukfosa)
					.HasColumnName("UKFOSA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ukl)
					.HasColumnName("UKL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ukl2)
					.HasColumnName("UKL2")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ukreg)
					.HasColumnName("UKREG")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Un)
					.HasColumnName("UN")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Uoeau)
					.HasColumnName("UOEAU")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Wevc)
					.HasColumnName("wevc")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Wevcfee)
					.HasColumnName("wevcfee")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Wevf)
					.HasColumnName("WEVF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Wevp)
					.HasColumnName("WEVP")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._0011)
					.HasColumnName("0011")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._005)
					.HasColumnName("005")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._006)
					.HasColumnName("006")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._013)
					.HasColumnName("013")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._014)
					.HasColumnName("014")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._015)
					.HasColumnName("015")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._018)
					.HasColumnName("018")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._020)
					.HasColumnName("020")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._023)
					.HasColumnName("023")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._024)
					.HasColumnName("024")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._025)
					.HasColumnName("025")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._026)
					.HasColumnName("026")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._027)
					.HasColumnName("027")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._0340)
					.HasColumnName("0340")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._036)
					.HasColumnName("036")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._049)
					.HasColumnName("049")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._053)
					.HasColumnName("053")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._054)
					.HasColumnName("054")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._055)
					.HasColumnName("055")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._056)
					.HasColumnName("056")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._0560)
					.HasColumnName("0560")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._057)
					.HasColumnName("057")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._058)
					.HasColumnName("058")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._060)
					.HasColumnName("060")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._063)
					.HasColumnName("063")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._065)
					.HasColumnName("065")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._0662)
					.HasColumnName("0662")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._074)
					.HasColumnName("074")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._0806)
					.HasColumnName("0806")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._0890)
					.HasColumnName("0890")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._100)
					.HasColumnName("100")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._102)
					.HasColumnName("102")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._110)
					.HasColumnName("110")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._111)
					.HasColumnName("111")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._115)
					.HasColumnName("115")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._117)
					.HasColumnName("117")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._118)
					.HasColumnName("118")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._140)
					.HasColumnName("140")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._144)
					.HasColumnName("144")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._145)
					.HasColumnName("145")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._147)
					.HasColumnName("147")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._151)
					.HasColumnName("151")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._18inv)
					.HasColumnName("18INV")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._245)
					.HasColumnName("245")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._259)
					.HasColumnName("259")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._260)
					.HasColumnName("260")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._271)
					.HasColumnName("271")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._296)
					.HasColumnName("296")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._304)
					.HasColumnName("304")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._311)
					.HasColumnName("311")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._314)
					.HasColumnName("314")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._316)
					.HasColumnName("316")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._321)
					.HasColumnName("321")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._328)
					.HasColumnName("328")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._330)
					.HasColumnName("330")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._335)
					.HasColumnName("335")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._345)
					.HasColumnName("345")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._348)
					.HasColumnName("348")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._356)
					.HasColumnName("356")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._380)
					.HasColumnName("380")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._384)
					.HasColumnName("384")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._385)
					.HasColumnName("385")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._388)
					.HasColumnName("388")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._415)
					.HasColumnName("415")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._455)
					.HasColumnName("455")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._586)
					.HasColumnName("586")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._588)
					.HasColumnName("588")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._590)
					.HasColumnName("590")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._591)
					.HasColumnName("591")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._592)
					.HasColumnName("592")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._593)
					.HasColumnName("593")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._595)
					.HasColumnName("595")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._600)
					.HasColumnName("600")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._603)
					.HasColumnName("603")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._605)
					.HasColumnName("605")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._607)
					.HasColumnName("607")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._610)
					.HasColumnName("610")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._615)
					.HasColumnName("615")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._617)
					.HasColumnName("617")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._622)
					.HasColumnName("622")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._625)
					.HasColumnName("625")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._626)
					.HasColumnName("626")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._632)
					.HasColumnName("632")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._634)
					.HasColumnName("634")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._636)
					.HasColumnName("636")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._637)
					.HasColumnName("637")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._639)
					.HasColumnName("639")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._640)
					.HasColumnName("640")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._641)
					.HasColumnName("641")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._6411)
					.HasColumnName("6411")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._644)
					.HasColumnName("644")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._647)
					.HasColumnName("647")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._649)
					.HasColumnName("649")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._652)
					.HasColumnName("652")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._653)
					.HasColumnName("653")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._660)
					.HasColumnName("660")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._690)
					.HasColumnName("690")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._691)
					.HasColumnName("691")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._692)
					.HasColumnName("692")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._694)
					.HasColumnName("694")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._696)
					.HasColumnName("696")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._700)
					.HasColumnName("700")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._701)
					.HasColumnName("701")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._702)
					.HasColumnName("702")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._703)
					.HasColumnName("703")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._707)
					.HasColumnName("707")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._708)
					.HasColumnName("708")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._710)
					.HasColumnName("710")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._712)
					.HasColumnName("712")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._713)
					.HasColumnName("713")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._718)
					.HasColumnName("718")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._722)
					.HasColumnName("722")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._723)
					.HasColumnName("723")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._725)
					.HasColumnName("725")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._726)
					.HasColumnName("726")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._730)
					.HasColumnName("730")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._731)
					.HasColumnName("731")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._732)
					.HasColumnName("732")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._733)
					.HasColumnName("733")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._736)
					.HasColumnName("736")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._737)
					.HasColumnName("737")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._740)
					.HasColumnName("740")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._742)
					.HasColumnName("742")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._744)
					.HasColumnName("744")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._745)
					.HasColumnName("745")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._746)
					.HasColumnName("746")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._750)
					.HasColumnName("750")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._752)
					.HasColumnName("752")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._767)
					.HasColumnName("767")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._768)
					.HasColumnName("768")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._772)
					.HasColumnName("772")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._776)
					.HasColumnName("776")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._788)
					.HasColumnName("788")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._789)
					.HasColumnName("789")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._800)
					.HasColumnName("800")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._801)
					.HasColumnName("801")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._805)
					.HasColumnName("805")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._806)
					.HasColumnName("806")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._822)
					.HasColumnName("822")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._823)
					.HasColumnName("823")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._835)
					.HasColumnName("835")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._836)
					.HasColumnName("836")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._837)
					.HasColumnName("837")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._869)
					.HasColumnName("869")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._870)
					.HasColumnName("870")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._889)
					.HasColumnName("889")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._895)
					.HasColumnName("895")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._896)
					.HasColumnName("896")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._898)
					.HasColumnName("898")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._899)
					.HasColumnName("899")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._904)
					.HasColumnName("904")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._905)
					.HasColumnName("905")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._921)
					.HasColumnName("921")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._922)
					.HasColumnName("922")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._923)
					.HasColumnName("923")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._924)
					.HasColumnName("924")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._940)
					.HasColumnName("940")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._947)
					.HasColumnName("947")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._949)
					.HasColumnName("949")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._952)
					.HasColumnName("952")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._956)
					.HasColumnName("956")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._958)
					.HasColumnName("958")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._960)
					.HasColumnName("960")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._962)
					.HasColumnName("962")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._965)
					.HasColumnName("965")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._966)
					.HasColumnName("966")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._968)
					.HasColumnName("968")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._970)
					.HasColumnName("970")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._971)
					.HasColumnName("971")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._972)
					.HasColumnName("972")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._973)
					.HasColumnName("973")
					.HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<HrpSalProcessEmployer>(entity =>
			{
				entity.ToTable("hrpSalProcessEmployer");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Arr)
					.HasColumnName("ARR")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bam)
					.HasColumnName("BAM")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bja)
					.HasColumnName("BJA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bor)
					.HasColumnName("BOR")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bun)
					.HasColumnName("BUN")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bunl)
					.HasColumnName("BUNL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Cewl)
					.HasColumnName("CEWL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Cewshg)
					.HasColumnName("CEWSHG")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Co)
					.HasColumnName("CO")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Court)
					.HasColumnName("COURT")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Disall)
					.HasColumnName("DISALL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Eca)
					.HasColumnName("ECA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ecaar)
					.HasColumnName("ECAAR")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Emp)
					.HasColumnName("EMP")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Flu)
					.HasColumnName("FLU")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Gra)
					.HasColumnName("GRA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Gus)
					.HasColumnName("GUS")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Guss)
					.HasColumnName("GUSS")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Hall)
					.HasColumnName("hall")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Hfck)
					.HasColumnName("HFCK")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Hlt)
					.HasColumnName("HLT")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Hpg)
					.HasColumnName("HPG")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Im)
					.HasColumnName("IM")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Imp)
					.HasColumnName("IMP")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Imp2)
					.HasColumnName("IMP2")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Imp3)
					.HasColumnName("IMP3")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Impref)
					.HasColumnName("IMPREF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Imw)
					.HasColumnName("IMW")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Kcb2)
					.HasColumnName("KCB2")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Kei)
					.HasColumnName("KEI")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Koy)
					.HasColumnName("KOY")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Lobl)
					.HasColumnName("LOBL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Lobs)
					.HasColumnName("LOBS")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Lta)
					.HasColumnName("LTA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Luall)
					.HasColumnName("LUALL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Mmed)
					.HasColumnName("MMED")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Muacd)
					.HasColumnName("MUACD")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Mvl)
					.HasColumnName("MVL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Mwae)
					.HasColumnName("MWAE")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Mwd)
					.HasColumnName("MWD")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Mwl)
					.HasColumnName("MWL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Mwsl)
					.HasColumnName("MWSL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Mwss)
					.HasColumnName("MWSS")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.New)
					.HasColumnName("NEW")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Npa)
					.HasColumnName("NPA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Npaar)
					.HasColumnName("NPAAR")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Oldmut)
					.HasColumnName("OLDMUT")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Op)
					.HasColumnName("OP")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Penv)
					.HasColumnName("PENV")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Personnel)
					.HasColumnName("personnel")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Plcr)
					.HasColumnName("PLCR")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Pres)
					.HasColumnName("PRES")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Pssp)
					.HasColumnName("PSSP")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ptc)
					.HasColumnName("PTC")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Pts)
					.HasColumnName("PTS")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ptsl)
					.HasColumnName("PTSL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Sal)
					.HasColumnName("SAL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Sm)
					.HasColumnName("SM")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Sod)
					.HasColumnName("SOD")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Sop)
					.HasColumnName("SOP")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Speriod)
					.HasColumnName("SPeriod")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Stimln)
					.HasColumnName("stimln")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Stl)
					.HasColumnName("STL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Stmsacco)
					.HasColumnName("stmsacco")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Sum)
					.HasColumnName("SUM")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Suma)
					.HasColumnName("SUMA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Tx)
					.HasColumnName("TX")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Uap)
					.HasColumnName("UAP")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ukfosa)
					.HasColumnName("UKFOSA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ukl)
					.HasColumnName("UKL")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ukl2)
					.HasColumnName("UKL2")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ukreg)
					.HasColumnName("UKREG")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Un)
					.HasColumnName("UN")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Uoeau)
					.HasColumnName("UOEAU")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Wevc)
					.HasColumnName("wevc")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Wevcfee)
					.HasColumnName("wevcfee")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Wevf)
					.HasColumnName("WEVF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Wevp)
					.HasColumnName("WEVP")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._0011)
					.HasColumnName("0011")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._005)
					.HasColumnName("005")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._006)
					.HasColumnName("006")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._013)
					.HasColumnName("013")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._014)
					.HasColumnName("014")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._015)
					.HasColumnName("015")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._018)
					.HasColumnName("018")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._020)
					.HasColumnName("020")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._023)
					.HasColumnName("023")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._024)
					.HasColumnName("024")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._025)
					.HasColumnName("025")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._026)
					.HasColumnName("026")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._027)
					.HasColumnName("027")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._0340)
					.HasColumnName("0340")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._036)
					.HasColumnName("036")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._049)
					.HasColumnName("049")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._053)
					.HasColumnName("053")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._054)
					.HasColumnName("054")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._055)
					.HasColumnName("055")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._056)
					.HasColumnName("056")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._0560)
					.HasColumnName("0560")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._057)
					.HasColumnName("057")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._058)
					.HasColumnName("058")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._060)
					.HasColumnName("060")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._063)
					.HasColumnName("063")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._065)
					.HasColumnName("065")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._0662)
					.HasColumnName("0662")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._074)
					.HasColumnName("074")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._0806)
					.HasColumnName("0806")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._0890)
					.HasColumnName("0890")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._100)
					.HasColumnName("100")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._102)
					.HasColumnName("102")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._110)
					.HasColumnName("110")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._111)
					.HasColumnName("111")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._115)
					.HasColumnName("115")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._117)
					.HasColumnName("117")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._118)
					.HasColumnName("118")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._140)
					.HasColumnName("140")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._144)
					.HasColumnName("144")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._145)
					.HasColumnName("145")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._147)
					.HasColumnName("147")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._151)
					.HasColumnName("151")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._18inv)
					.HasColumnName("18INV")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._245)
					.HasColumnName("245")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._259)
					.HasColumnName("259")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._260)
					.HasColumnName("260")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._271)
					.HasColumnName("271")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._296)
					.HasColumnName("296")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._304)
					.HasColumnName("304")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._311)
					.HasColumnName("311")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._314)
					.HasColumnName("314")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._316)
					.HasColumnName("316")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._321)
					.HasColumnName("321")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._328)
					.HasColumnName("328")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._330)
					.HasColumnName("330")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._335)
					.HasColumnName("335")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._345)
					.HasColumnName("345")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._348)
					.HasColumnName("348")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._356)
					.HasColumnName("356")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._380)
					.HasColumnName("380")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._384)
					.HasColumnName("384")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._385)
					.HasColumnName("385")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._388)
					.HasColumnName("388")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._415)
					.HasColumnName("415")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._455)
					.HasColumnName("455")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._586)
					.HasColumnName("586")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._588)
					.HasColumnName("588")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._590)
					.HasColumnName("590")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._591)
					.HasColumnName("591")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._592)
					.HasColumnName("592")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._593)
					.HasColumnName("593")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._595)
					.HasColumnName("595")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._600)
					.HasColumnName("600")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._603)
					.HasColumnName("603")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._605)
					.HasColumnName("605")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._607)
					.HasColumnName("607")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._610)
					.HasColumnName("610")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._615)
					.HasColumnName("615")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._617)
					.HasColumnName("617")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._622)
					.HasColumnName("622")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._625)
					.HasColumnName("625")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._626)
					.HasColumnName("626")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._632)
					.HasColumnName("632")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._634)
					.HasColumnName("634")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._636)
					.HasColumnName("636")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._637)
					.HasColumnName("637")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._639)
					.HasColumnName("639")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._640)
					.HasColumnName("640")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._641)
					.HasColumnName("641")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._6411)
					.HasColumnName("6411")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._644)
					.HasColumnName("644")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._647)
					.HasColumnName("647")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._649)
					.HasColumnName("649")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._652)
					.HasColumnName("652")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._653)
					.HasColumnName("653")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._660)
					.HasColumnName("660")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._690)
					.HasColumnName("690")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._691)
					.HasColumnName("691")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._692)
					.HasColumnName("692")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._694)
					.HasColumnName("694")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._696)
					.HasColumnName("696")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._700)
					.HasColumnName("700")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._701)
					.HasColumnName("701")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._702)
					.HasColumnName("702")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._703)
					.HasColumnName("703")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._707)
					.HasColumnName("707")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._708)
					.HasColumnName("708")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._710)
					.HasColumnName("710")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._712)
					.HasColumnName("712")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._713)
					.HasColumnName("713")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._718)
					.HasColumnName("718")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._722)
					.HasColumnName("722")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._723)
					.HasColumnName("723")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._725)
					.HasColumnName("725")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._726)
					.HasColumnName("726")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._730)
					.HasColumnName("730")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._731)
					.HasColumnName("731")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._732)
					.HasColumnName("732")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._733)
					.HasColumnName("733")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._736)
					.HasColumnName("736")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._737)
					.HasColumnName("737")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._740)
					.HasColumnName("740")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._742)
					.HasColumnName("742")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._744)
					.HasColumnName("744")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._745)
					.HasColumnName("745")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._746)
					.HasColumnName("746")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._750)
					.HasColumnName("750")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._752)
					.HasColumnName("752")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._767)
					.HasColumnName("767")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._768)
					.HasColumnName("768")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._772)
					.HasColumnName("772")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._776)
					.HasColumnName("776")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._788)
					.HasColumnName("788")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._789)
					.HasColumnName("789")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._800)
					.HasColumnName("800")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._801)
					.HasColumnName("801")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._805)
					.HasColumnName("805")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._806)
					.HasColumnName("806")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._822)
					.HasColumnName("822")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._823)
					.HasColumnName("823")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._835)
					.HasColumnName("835")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._836)
					.HasColumnName("836")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._837)
					.HasColumnName("837")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._869)
					.HasColumnName("869")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._870)
					.HasColumnName("870")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._889)
					.HasColumnName("889")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._895)
					.HasColumnName("895")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._896)
					.HasColumnName("896")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._898)
					.HasColumnName("898")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._899)
					.HasColumnName("899")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._904)
					.HasColumnName("904")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._905)
					.HasColumnName("905")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._921)
					.HasColumnName("921")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._922)
					.HasColumnName("922")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._923)
					.HasColumnName("923")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._924)
					.HasColumnName("924")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._940)
					.HasColumnName("940")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._947)
					.HasColumnName("947")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._949)
					.HasColumnName("949")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._952)
					.HasColumnName("952")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._956)
					.HasColumnName("956")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._958)
					.HasColumnName("958")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._960)
					.HasColumnName("960")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._962)
					.HasColumnName("962")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._965)
					.HasColumnName("965")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._966)
					.HasColumnName("966")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._968)
					.HasColumnName("968")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._970)
					.HasColumnName("970")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._971)
					.HasColumnName("971")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._972)
					.HasColumnName("972")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e._973)
					.HasColumnName("973")
					.HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<HrpSection>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.ToTable("hrpSection");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpService>(entity =>
			{
				entity.ToTable("hrpService");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AccNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Bank)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Edate)
					.HasColumnName("EDate")
					.HasColumnType("datetime");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.EmpStatus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Event)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.HseRent).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HseRentType)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.HseTerms)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.HseType)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.HseValue).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.IncDate).HasColumnType("datetime");

				entity.Property(e => e.JobTitle)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Nhif).HasColumnName("NHIF");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Nssf).HasColumnName("NSSF");

				entity.Property(e => e.Oointerest)
					.HasColumnName("OOInterest")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Paye).HasColumnName("PAYE");

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Pfreq)
					.HasColumnName("PFreq")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Pgrade)
					.HasColumnName("PGrade")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Pmode)
					.HasColumnName("PMode")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Rank)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpSetup>(entity =>
			{
				entity.ToTable("hrpSetup");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Basic)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ConsMin).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ConsRate).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.EmpNssf)
					.HasColumnName("EmpNSSF")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Farm).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Fringe)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ImpAcc)
					.HasMaxLength(1000)
					.IsUnicode(false);

				entity.Property(e => e.ImpFi)
					.HasColumnName("ImpFI")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.InsRelief).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.InsReliefMax).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ippayeentry)
					.HasColumnName("IPPAYEEntry")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MaxPensionAllowable).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Mnssf)
					.HasColumnName("MNSSF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Nearest)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.NetAccount)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Nhif)
					.HasColumnName("NHIF")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Nhifno)
					.HasColumnName("NHIFNo")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Nssf)
					.HasColumnName("NSSF")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Nssfno)
					.HasColumnName("NSSFNo")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Oointerest)
					.HasColumnName("OOInterest")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ordinary).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Paye)
					.HasColumnName("PAYE")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Payemax)
					.HasColumnName("PAYEMax")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PayslipEmailMsg)
					.HasMaxLength(1000)
					.IsUnicode(false);

				entity.Property(e => e.PayslipMsg)
					.HasMaxLength(800)
					.IsUnicode(false);

				entity.Property(e => e.Pin)
					.HasColumnName("PIN")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Prelief)
					.HasColumnName("PRelief")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Relief)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rent)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.RetAge).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RetMonths)
					.HasMaxLength(150)
					.IsUnicode(false);

				entity.Property(e => e.RetRemAge).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TerminationStatus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Whtax)
					.HasColumnName("WHTax")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Wnssf)
					.HasColumnName("WNSSF")
					.HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<HrpSharesOb>(entity =>
			{
				entity.ToTable("hrpSharesOB");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Shares).HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<HrpSharesPayOff>(entity =>
			{
				entity.ToTable("hrpSharesPayOff");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Shares).HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<HrpTadayProgram>(entity =>
			{
				entity.ToTable("hrpTADayProgram");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Bcolor)
					.HasColumnName("BColor")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Category)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpTadayProgramDetails>(entity =>
			{
				entity.ToTable("hrpTADayProgramDetails");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Eday).HasColumnName("EDay");

				entity.Property(e => e.Etime)
					.HasColumnName("ETime")
					.HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Sday).HasColumnName("SDay");

				entity.Property(e => e.Stime)
					.HasColumnName("STime")
					.HasColumnType("datetime");

				entity.Property(e => e.Type)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpTaroster>(entity =>
			{
				entity.ToTable("hrpTARoster");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Category)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.CreateDate).HasColumnType("datetime");

				entity.Property(e => e.DayProgram)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpTatimesheet>(entity =>
			{
				entity.ToTable("hrpTATimesheet");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.DeviceId)
					.HasColumnName("DeviceID")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.InOut)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Rtime)
					.HasColumnName("RTime")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<HrpTatype>(entity =>
			{
				entity.ToTable("hrpTAType");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Bcolor)
					.HasColumnName("BColor")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Category)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpTraining>(entity =>
			{
				entity.ToTable("hrpTraining");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Began).HasColumnType("datetime");

				entity.Property(e => e.Completed).HasColumnType("datetime");

				entity.Property(e => e.Cost).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Course)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Institution)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Period)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Results)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<HrpUnion>(entity =>
			{
				entity.ToTable("hrpUnion");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Exited).HasColumnType("datetime");

				entity.Property(e => e.Joined).HasColumnType("datetime");

				entity.Property(e => e.MemNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<Imprest>(entity =>
			{
				entity.HasKey(e => e.ImpRef);

				entity.Property(e => e.ImpRef)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ChequeNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Description)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.ImpDays)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Itinerary)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.OnlineId)
					.HasColumnName("OnlineID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.OrderNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.PayeeRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");

				entity.Property(e => e.Status)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ImprestDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ImpRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.PayeeRef)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ImprestDisb>(entity =>
			{
				entity.HasKey(e => e.ImpRef);

				entity.Property(e => e.ImpRef)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Bank)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<ImprestDisbDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bank)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ChequeNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ImpId)
					.HasColumnName("ImpID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ImpRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.PayeeRef)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ImprestReq>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Description)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Edate)
					.HasColumnName("EDate")
					.HasColumnType("datetime");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ImpDays)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Itinerary)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.ReactDate).HasColumnType("datetime");

				entity.Property(e => e.ReactTime).HasColumnType("datetime");

				entity.Property(e => e.Reactby)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Reaction).IsUnicode(false);

				entity.Property(e => e.Rtime).HasColumnType("datetime");

				entity.Property(e => e.Sdate)
					.HasColumnName("SDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Usercode)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ImprestSur>(entity =>
			{
				entity.HasKey(e => e.ImpRef);

				entity.Property(e => e.ImpRef)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.ActualAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<ImprestSurDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ActualAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ImpRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.PayeeRef)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ImprestSurRcpt>(entity =>
			{
				entity.HasKey(e => e.ReceiptNumber);

				entity.ToTable("ImprestSurRCPT");

				entity.Property(e => e.ReceiptNumber)
					.HasColumnName("Receipt Number")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bank)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ChequeNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ImpRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<InsInv>(entity =>
			{
				entity.HasKey(e => e.InvRef);

				entity.Property(e => e.InvRef)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CustRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Pinv).HasColumnName("PInv");

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<InsInvDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Cost).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Description).IsUnicode(false);

				entity.Property(e => e.InvRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<ItemAdd>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Cost)
					.HasColumnName("cost")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Discount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Grnno)
					.HasColumnName("grnno")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.GrossAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Invoice)
					.HasColumnName("invoice")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.NetAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Orderno)
					.HasColumnName("orderno")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasColumnName("personnel")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qty)
					.HasColumnName("qty")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Spec).IsUnicode(false);

				entity.Property(e => e.Supref)
					.HasColumnName("supref")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ItemAdjust>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<ItemAdjustDept>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<ItemAwards>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Cost).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Fyear)
					.HasColumnName("FYear")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.SupRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ValidUntil).HasColumnType("datetime");
			});

			modelBuilder.Entity<ItemBid>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Cost).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Fyear)
					.HasColumnName("FYear")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.SupRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ValidUntil).HasColumnType("datetime");
			});

			modelBuilder.Entity<ItemCat>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Prefix)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ItemIssue>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasColumnName("personnel")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ItemIssueClear>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasColumnName("personnel")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ItemLoc>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ItemReq>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Description).IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.ReactDate).HasColumnType("datetime");

				entity.Property(e => e.ReactTime).HasColumnType("datetime");

				entity.Property(e => e.Reactby)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Reaction).IsUnicode(false);

				entity.Property(e => e.Rtime).HasColumnType("datetime");

				entity.Property(e => e.Usercode)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Items>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasColumnName("type")
					.HasMaxLength(20)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ItemType>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ItemUom>(entity =>
			{
				entity.ToTable("ItemUOM");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Journal>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AccountFrom)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.AccountTo)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CampusFrom)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.CampusTo)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.DeptFrom)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.DeptTo)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Jvno)
					.HasColumnName("JVNo")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.LedgerFrom)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.LedgerTo)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ProjectFrom)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ProjectTo)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.RecurEdate)
					.HasColumnName("RecurEDate")
					.HasColumnType("datetime");

				entity.Property(e => e.RecurInterval)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.RecurSdate)
					.HasColumnName("RecurSDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Reference)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Ledger>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Curr)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.IsUnicode(false);
			});

			modelBuilder.Entity<LedgerSub>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Description)
					.HasMaxLength(5000)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Ob)
					.HasColumnName("OB")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OverallAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ProjLoc)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ProjNo)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<Log>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Computer)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Description).IsUnicode(false);

				entity.Property(e => e.Macaddress)
					.HasColumnName("MACAddress")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Rtime).HasColumnType("datetime");

				entity.Property(e => e.UserName)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Lookup>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Item)
					.HasColumnName("item")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ManagementFeeSetup>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Rate).HasColumnType("decimal(19, 10)");

				entity.Property(e => e.RoundTo)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.RoundType)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<MarkSheet>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ApprovalStatus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Att).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Cat)
					.HasColumnName("CAT")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Cat1)
					.HasColumnName("CAT 1")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Cat2)
					.HasColumnName("CAT 2")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Class)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.CourseWork)
					.HasColumnName("COURSE WORK")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Exam)
					.HasColumnName("EXAM")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Mip).HasColumnName("MIP");

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Subject)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<MarkSymbols>(entity =>
			{
				entity.HasKey(e => e.Symbol);

				entity.Property(e => e.Symbol)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Names)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<MatureEntry>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Basis)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<McsUsers>(entity =>
			{
				entity.HasKey(e => e.UserCode);

				entity.ToTable("MCS_Users");

				entity.Property(e => e.UserCode)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Mcsadmin).HasColumnName("MCSAdmin");

				entity.Property(e => e.Mcsbarcode).HasColumnName("MCSBarcode");

				entity.Property(e => e.McsmealTrack).HasColumnName("MCSMealTrack");

				entity.Property(e => e.McsmemCat).HasColumnName("MCSMemCat");

				entity.Property(e => e.Mcsmembers).HasColumnName("MCSMembers");

				entity.Property(e => e.Mcsreports).HasColumnName("MCSReports");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Password)
					.HasColumnName("password")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Members>(entity =>
			{
				entity.HasKey(e => e.MemberId);

				entity.Property(e => e.MemberId)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Address)
					.HasColumnName("address")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Createdate)
					.HasColumnName("createdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Department)
					.HasColumnName("department")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Designation)
					.HasColumnName("designation")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.DtSuspended)
					.HasColumnName("dtSuspended")
					.HasColumnType("datetime");

				entity.Property(e => e.Edate)
					.HasColumnName("edate")
					.HasColumnType("datetime");

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Phone)
					.HasColumnName("phone")
					.HasMaxLength(20)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Messages>(entity =>
			{
				entity.ToTable("messages");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Body)
					.HasColumnName("body")
					.HasColumnType("text");

				entity.Property(e => e.CreatedAt)
					.HasColumnName("created_at")
					.HasColumnType("datetime");

				entity.Property(e => e.DeletedBy)
					.HasColumnName("deleted_by")
					.HasMaxLength(1)
					.IsUnicode(false);

				entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

				entity.Property(e => e.IsDraft).HasColumnName("is_draft");

				entity.Property(e => e.IsImportant).HasColumnName("is_important");

				entity.Property(e => e.IsRead)
					.IsRequired()
					.HasColumnName("is_read")
					.HasDefaultValueSql("('0')");

				entity.Property(e => e.IsSpam).HasColumnName("is_spam");

				entity.Property(e => e.ReceiverId)
					.HasColumnName("receiver_id")
					.HasMaxLength(150)
					.IsUnicode(false);

				entity.Property(e => e.SenderId)
					.IsRequired()
					.HasColumnName("sender_id")
					.HasMaxLength(150)
					.IsUnicode(false);

				entity.Property(e => e.Subject)
					.IsRequired()
					.HasColumnName("subject")
					.HasMaxLength(256)
					.IsUnicode(false)
					.HasDefaultValueSql("('')");
			});

			modelBuilder.Entity<MessageUser>(entity =>
			{
				entity.ToTable("message_user");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.MessageId).HasColumnName("message_id");

				entity.Property(e => e.UserId)
					.IsRequired()
					.HasColumnName("user_id")
					.HasMaxLength(120)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Notifications>(entity =>
			{
				entity.ToTable("notifications");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Datec)
					.HasColumnName("datec")
					.HasColumnType("datetime");

				entity.Property(e => e.From)
					.HasColumnName("from")
					.HasMaxLength(125)
					.IsUnicode(false);

				entity.Property(e => e.IsRead).HasColumnName("is_read");

				entity.Property(e => e.Title)
					.HasColumnName("title")
					.HasMaxLength(125)
					.IsUnicode(false);

				entity.Property(e => e.To)
					.HasColumnName("to")
					.HasMaxLength(125)
					.IsUnicode(false);
			});

			modelBuilder.Entity<OnlineApplicant>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Activity)
					.HasColumnName("activity")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Afrn)
					.HasColumnName("AFRN")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.County)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Createdate)
					.HasColumnName("createdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Disability)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.District)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Dob)
					.HasColumnName("DOB")
					.HasColumnType("datetime");

				entity.Property(e => e.Emaddress)
					.HasColumnName("EMAddress")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Ememail)
					.HasColumnName("EMEmail")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Emname)
					.HasColumnName("EMName")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Emrel)
					.HasColumnName("EMRel")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Emremarks)
					.HasColumnName("EMRemarks")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Emtel)
					.HasColumnName("EMTel")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Gender)
					.HasColumnName("gender")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Homeaddress)
					.HasColumnName("homeaddress")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Language)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Marital)
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.NationalId)
					.HasColumnName("nationalID")
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.Nationality)
					.HasColumnName("nationality")
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasColumnName("personnel")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Prevadmnno)
					.HasColumnName("prevadmnno")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Programme)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Religion)
					.HasColumnName("religion")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rmonth)
					.HasColumnName("RMonth")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ryear)
					.HasColumnName("RYear")
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Source)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Special)
					.HasColumnName("special")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Sponsor)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Status)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.StudyMode)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Telno)
					.HasColumnName("telno")
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<OnlineReporting>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Status)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayCancelled>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Reason)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Payecafeteria>(entity =>
			{
				entity.ToTable("PAYECafeteria");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayeCardIssue>(entity =>
			{
				entity.HasKey(e => e.BarcodeId);

				entity.ToTable("PAYE_CardIssue");

				entity.Property(e => e.BarcodeId)
					.HasColumnName("BarcodeID")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<PayeCardReg>(entity =>
			{
				entity.HasKey(e => e.BarcodeId);

				entity.ToTable("PAYE_CardReg");

				entity.Property(e => e.BarcodeId)
					.HasColumnName("BarcodeID")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<PayeDepartment>(entity =>
			{
				entity.ToTable("PAYE_Department");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.IsUnicode(false);
			});

			modelBuilder.Entity<Payees>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Address)
					.HasColumnName("address")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.EmpNo)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Fax)
					.HasColumnName("fax")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.IsUnicode(false);

				entity.Property(e => e.Teld)
					.HasColumnName("teld")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Tele)
					.HasColumnName("tele")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Telm)
					.HasColumnName("telm")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Payefacility>(entity =>
			{
				entity.ToTable("PAYEFacility");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayeIngredients>(entity =>
			{
				entity.ToTable("PAYE_Ingredients");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Cost).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Uom)
					.HasColumnName("UOM")
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayeItemCat>(entity =>
			{
				entity.ToTable("PAYE_ItemCat");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayeItemGroup>(entity =>
			{
				entity.ToTable("PAYE_ItemGroup");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayeItemPrices>(entity =>
			{
				entity.ToTable("PAYE_ItemPrices");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate)
					.HasColumnName("SDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Taxes)
					.HasMaxLength(500)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayeItems>(entity =>
			{
				entity.HasKey(e => e.Code);

				entity.ToTable("PAYE_Items");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Category)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Fmodifier).HasColumnName("FModifier");

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.ItemGroup)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<PayeKitchenNotes>(entity =>
			{
				entity.ToTable("PAYE_kitchenNotes");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayeLog>(entity =>
			{
				entity.ToTable("PAYE_Log");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Computer)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Description).IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Rtime).HasColumnType("datetime");

				entity.Property(e => e.UserName)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayeMembers>(entity =>
			{
				entity.HasKey(e => e.BarcodeId);

				entity.ToTable("PAYE_Members");

				entity.Property(e => e.BarcodeId)
					.HasColumnName("BarcodeID")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Address)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Category)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.DateLost).HasColumnType("datetime");

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.MemberId)
					.IsRequired()
					.HasColumnName("MemberID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.NationalId)
					.HasColumnName("NationalID")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Phone)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<PayeMemCat>(entity =>
			{
				entity.ToTable("PAYE_MemCat");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayeModifiers>(entity =>
			{
				entity.ToTable("PAYE_Modifiers");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Cost).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayeRecipe>(entity =>
			{
				entity.ToTable("PAYE_Recipe");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.ItemCode)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.MenuCode)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 10)");
			});

			modelBuilder.Entity<PayeRefund>(entity =>
			{
				entity.ToTable("PAYE_Refund");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MemberId)
					.HasColumnName("MemberID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayeReminder>(entity =>
			{
				entity.ToTable("PAYE_Reminder");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.CreateDate).HasColumnType("datetime");

				entity.Property(e => e.Duedate).HasColumnType("datetime");

				entity.Property(e => e.Duetime)
					.HasColumnType("datetime")
					.HasDefaultValueSql("('12:00:00 AM')");

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Subject)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayeSales>(entity =>
			{
				entity.HasKey(e => e.InvNo);

				entity.ToTable("PAYE_Sales");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AmountPaid).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Barcode)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Cafeteria)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Rtime).HasColumnType("datetime");
			});

			modelBuilder.Entity<PayeSalesDetail>(entity =>
			{
				entity.ToTable("PAYE_SalesDetail");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Cost).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Total).HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<PayeSysSetup>(entity =>
			{
				entity.ToTable("PAYE_SysSetup");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AlbumPath).IsUnicode(false);

				entity.Property(e => e.Aname).HasColumnName("AName");

				entity.Property(e => e.Bcode)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Contacts)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Location)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.LockDate).HasColumnType("datetime");

				entity.Property(e => e.Misdb)
					.HasColumnName("MISDB")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.OrgName)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Payecategory)
					.HasColumnName("PAYECategory")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Pinno)
					.HasColumnName("PINNo")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Smtpserver)
					.HasColumnName("SMTPServer")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.SubTitle)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Thankyou).IsUnicode(false);

				entity.Property(e => e.Vatno)
					.HasColumnName("VATNo")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayeTaxType>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.ToTable("PAYE_TaxType");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Rate).HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<PayeTopUp>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.ToTable("PAYE_TopUp");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.MemberId)
					.HasColumnName("MemberID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.TopUpSource)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayeUsers>(entity =>
			{
				entity.HasKey(e => e.UserCode);

				entity.ToTable("PAYE_Users");

				entity.Property(e => e.UserCode)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Administrator).HasColumnName("administrator");

				entity.Property(e => e.Cafeteria)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Password)
					.HasColumnName("password")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayInvoice>(entity =>
			{
				entity.HasKey(e => e.InvRef);

				entity.Property(e => e.InvRef)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Apaccount)
					.HasColumnName("APAccount")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Discount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DueDate).HasColumnType("datetime");

				entity.Property(e => e.GrossAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Invdate)
					.HasColumnName("invdate")
					.HasColumnType("datetime");

				entity.Property(e => e.InvoiceNumber)
					.HasColumnName("invoice number")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Lpo)
					.HasColumnName("LPO")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasColumnName("personnel")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Tax).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Terms)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayInvoiceDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Discount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GrossAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.InvRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.NetAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.TaxAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TaxName)
					.HasMaxLength(1000)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayInvoiceWaiver>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Adate)
					.HasColumnName("ADate")
					.HasColumnType("datetime");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.InvRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Payments>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ActualDate).HasColumnType("datetime");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.InvoiceNumber)
					.HasColumnName("Invoice Number")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Lpo)
					.HasColumnName("LPO")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ModeNumber)
					.HasColumnName("Mode Number")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(2000)
					.IsUnicode(false);

				entity.Property(e => e.PaymentMode)
					.HasColumnName("Payment Mode")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.UniqId)
					.HasColumnName("UniqID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.VoucherNumber)
					.IsRequired()
					.HasColumnName("Voucher Number")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PayRegister>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Bank)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ChequeNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.DocNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Payee)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.PayeeRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Status)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Pcash>(entity =>
			{
				entity.HasKey(e => e.Pcref);

				entity.ToTable("PCash");

				entity.Property(e => e.Pcref)
					.HasColumnName("PCRef")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Description)
					.HasMaxLength(8000)
					.IsUnicode(false);

				entity.Property(e => e.ImpRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.PayeeRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Status)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PcashDetail>(entity =>
			{
				entity.ToTable("PCashDetail");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Pcref)
					.HasColumnName("PCRef")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Pcdisb>(entity =>
			{
				entity.HasKey(e => e.Pcref);

				entity.ToTable("PCDisb");

				entity.Property(e => e.Pcref)
					.HasColumnName("PCRef")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<PerformRemarks>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.RemarkType)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Pocancel>(entity =>
			{
				entity.ToTable("POCancel");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.OrderNo)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Reason)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PocancelDetails>(entity =>
			{
				entity.ToTable("POCancelDetails");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Cost).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GrossAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ref)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Porder>(entity =>
			{
				entity.HasKey(e => e.OrderNo);

				entity.ToTable("POrder");

				entity.Property(e => e.OrderNo)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Curr)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.DeliverTo)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.MinRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.OrderType)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.ReqNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ReqOn)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ShowNotes)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Status)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.SupRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Vote)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PorderDetail>(entity =>
			{
				entity.ToTable("POrderDetail");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Cost).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.OrderNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Spec).IsUnicode(false);

				entity.Property(e => e.Vat).HasColumnName("VAT");
			});

			modelBuilder.Entity<Postatus>(entity =>
			{
				entity.ToTable("POStatus");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Preq>(entity =>
			{
				entity.HasKey(e => e.ReqNo);

				entity.ToTable("PReq");

				entity.Property(e => e.ReqNo)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BudgetBy)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.BudgetDate).HasColumnType("datetime");

				entity.Property(e => e.BudgetStatus)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Curr)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.DeliverTo)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.QuoteNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.ReqOn)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ShowNotes)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Status)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.SupRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Vote)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PreqDetail>(entity =>
			{
				entity.ToTable("PReqDetail");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BudgetBal).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Commitment).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Cost).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ReqNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.SetBudget).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Spec).IsUnicode(false);

				entity.Property(e => e.Vat).HasColumnName("VAT");

				entity.Property(e => e.Ytdate)
					.HasColumnName("YTDate")
					.HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<ProcBudget>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Fyear)
					.HasColumnName("FYear")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<ProcDeptStores>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Store)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ProcItemIssue>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Fpcode)
					.HasColumnName("FPCode")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.RecBy)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ReqQty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ReqStaff)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ProcItemIssueDept>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.PayesaleRef)
					.HasColumnName("PAYESaleRef")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.UserRef)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ProcItems>(entity =>
			{
				entity.HasKey(e => e.Code);

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Description)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.DimUnit)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ItemCat)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ItemLength)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ItemLoc)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ItemType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ItemWeight)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ItemWidth)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.MaxStock).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MinStock).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes).IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Reorder).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Uom)
					.HasColumnName("uom")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Wunit)
					.HasColumnName("WUnit")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ProcOnlineReq>(entity =>
			{
				entity.HasKey(e => e.ReqRef);

				entity.Property(e => e.ReqRef)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.ReactDate).HasColumnType("datetime");

				entity.Property(e => e.ReactTime).HasColumnType("datetime");

				entity.Property(e => e.Reactby)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Reaction).IsUnicode(false);

				entity.Property(e => e.Rtime).HasColumnType("datetime");

				entity.Property(e => e.Status)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Usercode)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ProcOnlineReqDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Cost).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Description).IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ReqRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.UoM)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ProcPlan>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Fyear)
					.HasColumnName("FYear")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<ProcPlanDetails>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Cost).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ProgCurriculum>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Aggregation)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.AwardScheme)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.CreditUnits).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DistAggregate)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.NoUnits).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ProgCode)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate).HasColumnType("datetime");

				entity.Property(e => e.Specialization)
					.HasMaxLength(150)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ProgCurriculumDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Grading)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.GroupType)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.GrpMaxChoice)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.GrpMinChoice)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Prerequisite)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Stage)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.UnitCode)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Programme>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdminReq)
					.HasMaxLength(5000)
					.IsUnicode(false);

				entity.Property(e => e.CertType)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Code)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasColumnName("department")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.GradeType)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.IsRequired()
					.HasColumnName("names")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Period)
					.HasColumnName("period")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Startyear)
					.HasColumnName("startyear")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ProgSpecialization>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(150)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ProgCode)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<ProgUnitReg>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Class)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Specialization)
					.HasMaxLength(150)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ProgUnitRegDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Status)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.UnitCode)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ProjBeneficiaries>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.BenRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ProjCoordinators>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Pvdetail>(entity =>
			{
				entity.ToTable("PVDetail");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Discount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FeeAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FeeName)
					.HasMaxLength(1000)
					.IsUnicode(false);

				entity.Property(e => e.GrossAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.InvoiceNumber)
					.HasColumnName("Invoice Number")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.NetAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.TaxAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TaxName)
					.HasMaxLength(1000)
					.IsUnicode(false);

				entity.Property(e => e.VoucherNo)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Pvecc>(entity =>
			{
				entity.HasKey(e => e.VoucherNo);

				entity.ToTable("PVECC");

				entity.Property(e => e.VoucherNo)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Description)
					.HasMaxLength(8000)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ModeNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.PayMode)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<Pveccdetails>(entity =>
			{
				entity.ToTable("PVECCDetails");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Ecref)
					.HasColumnName("ECRef")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.VoucherNo)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Pvic>(entity =>
			{
				entity.HasKey(e => e.VoucherNo);

				entity.ToTable("PVIC");

				entity.Property(e => e.VoucherNo)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Description)
					.HasMaxLength(8000)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ModeNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.PayMode)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<Pvicdetails>(entity =>
			{
				entity.ToTable("PVICDetails");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.ImpRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.VoucherNo)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Pvouchers>(entity =>
			{
				entity.HasKey(e => e.VoucherNo);

				entity.ToTable("PVouchers");

				entity.Property(e => e.VoucherNo)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ChequeNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Description)
					.HasMaxLength(8000)
					.IsUnicode(false);

				entity.Property(e => e.Discount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GrossAmount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.PayToNames)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.SponsorName)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.SupRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Tax).HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<Pvpc>(entity =>
			{
				entity.HasKey(e => e.VoucherNo);

				entity.ToTable("PVPC");

				entity.Property(e => e.VoucherNo)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Description)
					.HasMaxLength(8000)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ModeNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.PayMode)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.SupRef)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Pvpcdetails>(entity =>
			{
				entity.ToTable("PVPCDetails");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Pcref)
					.IsRequired()
					.HasColumnName("PCRef")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.VoucherNo)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Pvprefix>(entity =>
			{
				entity.ToTable("PVPrefix");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Pvtax>(entity =>
			{
				entity.HasKey(e => e.VoucherNo);

				entity.ToTable("PVTax");

				entity.Property(e => e.VoucherNo)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("money");

				entity.Property(e => e.ChequeNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Description).IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.InvSpec).IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.SupRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.TaxType)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PvtaxDetail>(entity =>
			{
				entity.ToTable("PVTaxDetail");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.InvRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.InvoiceNumber)
					.HasColumnName("Invoice Number")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.SupRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.VoucherNo)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Quarters>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Edate)
					.HasColumnName("EDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Sdate)
					.HasColumnName("SDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<Rcredit>(entity =>
			{
				entity.HasKey(e => e.ReceiptNumber);

				entity.ToTable("RCredit");

				entity.Property(e => e.ReceiptNumber)
					.HasColumnName("Receipt Number")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Curr)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.CustRef)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Rdebit>(entity =>
			{
				entity.HasKey(e => e.ReceiptNumber);

				entity.ToTable("RDebit");

				entity.Property(e => e.ReceiptNumber)
					.HasColumnName("Receipt Number")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Curr)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.CustRef)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ReceiptBook>(entity =>
			{
				entity.HasKey(e => e.ReceiptNumber);

				entity.Property(e => e.ReceiptNumber)
					.HasColumnName("Receipt Number")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.AccommodationIncome)
					.HasColumnName("Accommodation Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccomodationFees)
					.HasColumnName("Accomodation Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.AccruedExpenses)
					.HasColumnName("Accrued Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccruedStatutoryOtherDeductions)
					.HasColumnName("Accrued Statutory & Other Deductions")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccummulatedArmotizationDepreciation)
					.HasColumnName("Accummulated Armotization & Depreciation")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedArmotizationOfLand)
					.HasColumnName("Accumulated Armotization of Land")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationBuilding)
					.HasColumnName("Accumulated Depreciation Building")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationComputersAndAccessories)
					.HasColumnName("Accumulated Depreciation Computers and Accessories")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationFurnitureAndFittings)
					.HasColumnName("Accumulated Depreciation Furniture and Fittings")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationLibraryBooks)
					.HasColumnName("Accumulated Depreciation Library Books")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationMotorVehicles)
					.HasColumnName("Accumulated Depreciation Motor Vehicles")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationPlantAndEquipment)
					.HasColumnName("Accumulated Depreciation Plant and Equipment")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ActivityFees)
					.HasColumnName("Activity Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AdministrativeAndRelatedIncomes)
					.HasColumnName("Administrative and Related Incomes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.AgribusinessTradeFair)
					.HasColumnName("Agribusiness Trade Fair")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Amenity).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ApplicationFees)
					.HasColumnName("Application Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BankLoans)
					.HasColumnName("Bank Loans")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BankTransfers)
					.HasColumnName("Bank transfers")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BookshopSales)
					.HasColumnName("Bookshop Sales")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BridgingFees)
					.HasColumnName("Bridging Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.CapitalCreditors)
					.HasColumnName("Capital Creditors")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CateringIncome)
					.HasColumnName("Catering Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CautionMoney)
					.HasColumnName("Caution Money")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CdfConstituencyDevelopmentFund)
					.HasColumnName("CDF- Constituency Development Fund")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CollaboratingFees)
					.HasColumnName("Collaborating fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CommissionerOfDomesticTaxesWithholdingTax)
					.HasColumnName("Commissioner of Domestic Taxes (Withholding Tax)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ComputerFees)
					.HasColumnName("Computer Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ConferenceWorkshops)
					.HasColumnName("Conference & Workshops")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Credit).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Curr)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.CustRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.CustomerPrepayments)
					.HasColumnName("Customer Prepayments")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.DirectCharges)
					.HasColumnName("Direct Charges")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DocDate).HasColumnType("datetime");

				entity.Property(e => e.DonorFundedResearchReceipts)
					.HasColumnName("Donor Funded Research Receipts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Eia)
					.HasColumnName("EIA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ExaminationsFees)
					.HasColumnName("Examinations Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ExchequerGrantsRecurrent)
					.HasColumnName("Exchequer Grants (Recurrent)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FarmIncome)
					.HasColumnName("Farm Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldAttachment)
					.HasColumnName("Field Attachment")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldCourse)
					.HasColumnName("Field Course")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldTrips)
					.HasColumnName("Field Trips")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldWorkSupervision)
					.HasColumnName("Field Work Supervision")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FinesPenalties)
					.HasColumnName("Fines & Penalties")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Fisheries).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ForestryWoodScience)
					.HasColumnName("Forestry & Wood Science")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GraduationFees)
					.HasColumnName("Graduation Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GraduationIncome)
					.HasColumnName("Graduation Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Grants).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GuestHouse)
					.HasColumnName("Guest House")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbBursariesStudents)
					.HasColumnName("HELB-Bursaries Students")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbLoanRepaymentStaff)
					.HasColumnName("HELB-Loan Repayment Staff")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbLoanStudents)
					.HasColumnName("HELB-Loan Students")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HireOfMotorVehicles)
					.HasColumnName("Hire of Motor Vehicles")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.IgaIncomes)
					.HasColumnName("IGA Incomes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.IncomeTaxPartTimeClaims)
					.HasColumnName("Income Tax (Part time claims)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ledger)
					.HasColumnName("ledger")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.LegalAttachments)
					.HasColumnName("Legal Attachments")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LibraryFees)
					.HasColumnName("Library Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LibraryIncome)
					.HasColumnName("Library Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LongTermLiabilities)
					.HasColumnName("Long Term Liabilities")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MiscelaneuosIncome)
					.HasColumnName("Miscelaneuos Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ModeNumber)
					.HasColumnName("Mode Number")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.NetPay)
					.HasColumnName("Net Pay")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Nhif)
					.HasColumnName("NHIF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Nssf)
					.HasColumnName("NSSF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherIgaIncome)
					.HasColumnName("Other IGA Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherIncomes)
					.HasColumnName("Other Incomes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherLiabilitiesProvisions)
					.HasColumnName("Other Liabilities & Provisions")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherStudentRelatedIncome)
					.HasColumnName("Other Student Related Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PartTimeLecturers)
					.HasColumnName("Part-time Lecturers")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Paye)
					.HasColumnName("PAYE")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PaymentMode)
					.HasColumnName("Payment Mode")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.PayrollRecoveries)
					.HasColumnName("Payroll Recoveries")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Pension)
					.HasColumnName("PENSION")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.PhotocopyingBinderyServices)
					.HasColumnName("Photocopying & Bindery Services")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PrepaidFeesStudents)
					.HasColumnName("Prepaid Fees (Students)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ProjectsRetentionMoney)
					.HasColumnName("Projects Retention Money")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProvisionForAuditFees)
					.HasColumnName("Provision for Audit Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProvisionForBadDebts)
					.HasColumnName("Provision for Bad Debts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.ReMarkingCharges)
					.HasColumnName("Re-marking Charges")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ReferralSupplementary)
					.HasColumnName("Referral/Supplementary")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Registration).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RentIncome)
					.HasColumnName("Rent Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RentPayable)
					.HasColumnName("Rent Payable")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ResearchAdministrationIncome)
					.HasColumnName("Research Administration Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ResearchAdministrativeIncome)
					.HasColumnName("Research Administrative Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ResearchFundAccounts)
					.HasColumnName("Research Fund Accounts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RetentionContractor)
					.HasColumnName("Retention (Contractor)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rtime)
					.HasColumnName("RTime")
					.HasColumnType("datetime");

				entity.Property(e => e.Saccos)
					.HasColumnName("SACCOs")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.SalaryRecovery)
					.HasColumnName("Salary Recovery")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.SpecialProject)
					.HasColumnName("Special Project")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Sponsorships).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StaffInsurance)
					.HasColumnName("Staff Insurance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StaffMedicalClaims)
					.HasColumnName("Staff Medical Claims")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentIdFees)
					.HasColumnName("Student ID Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentMedicalFees)
					.HasColumnName("Student Medical Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentsOpeningBalance)
					.HasColumnName("Students Opening Balance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Supervision).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TeachingPracticeFees)
					.HasColumnName("Teaching Practice Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ThesisFees)
					.HasColumnName("Thesis Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TradeAndOtherPayables)
					.HasColumnName("Trade and Other Payables")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TradeCreditors)
					.HasColumnName("Trade Creditors")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TuitionFees)
					.HasColumnName("Tuition Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TuitionIncome)
					.HasColumnName("Tuition Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UnallocatedFee)
					.HasColumnName("Unallocated Fee")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UnionDues)
					.HasColumnName("UNION DUES")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoExpenses)
					.HasColumnName("UoESO Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoFunds)
					.HasColumnName("UoESO Funds")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoFundsReceipts)
					.HasColumnName("UoESO Funds Receipts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Uoeso)
					.HasColumnName("UOESO")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoesoRent)
					.HasColumnName("UOESO Rent")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.VatTaxes)
					.HasColumnName("VAT Taxes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.VlirCarHire)
					.HasColumnName("VLIR Car Hire")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Welfares)
					.HasColumnName("WELFARES")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.WithHoldingVatTaxWhvat)
					.HasColumnName("With-Holding VAT Tax (WHVAT)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.WorkshopPractice)
					.HasColumnName("Workshop Practice")
					.HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<ReceiptBookCanc>(entity =>
			{
				entity.HasKey(e => e.ReceiptNumber);

				entity.Property(e => e.ReceiptNumber)
					.HasColumnName("Receipt Number")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Reason)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ReceiptBookCustBreak>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.CustRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.InvRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ReceiptNumber)
					.HasColumnName("Receipt Number")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ReceiptBookOtherDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.ReceiptNumber)
					.HasColumnName("Receipt Number")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ReceiptBreak>(entity =>
			{
				entity.HasKey(e => e.ReceiptNumber);

				entity.Property(e => e.ReceiptNumber)
					.HasColumnName("Receipt Number")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Credit).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Curr)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.CustRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.DocDate).HasColumnType("datetime");

				entity.Property(e => e.InvDetails)
					.HasMaxLength(2000)
					.IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasColumnName("ledger")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ModeNumber)
					.HasColumnName("Mode Number")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.PaymentMode)
					.HasColumnName("Payment Mode")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Project)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Rtime)
					.HasColumnName("RTime")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<ReceiptXlsfields>(entity =>
			{
				entity.ToTable("ReceiptXLSFields");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Fname)
					.HasColumnName("FName")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Xlsvalue)
					.HasColumnName("XLSValue")
					.HasMaxLength(500)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Refund>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CustRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(1000)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.ReceiptNumber)
					.HasColumnName("Receipt Number")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Register>(entity =>
			{
				entity.HasKey(e => e.AdmnNo);

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Activity)
					.HasColumnName("activity")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.CloseReason)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Closed).HasColumnName("closed");

				entity.Property(e => e.Constituency)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.County)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Createdate)
					.HasColumnName("createdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Dateclosed)
					.HasColumnName("dateclosed")
					.HasColumnType("datetime");

				entity.Property(e => e.Disability)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.District)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Dob)
					.HasColumnName("DOB")
					.HasColumnType("datetime");

				entity.Property(e => e.Domicile)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Emaddress)
					.HasColumnName("EMAddress")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Ememail)
					.HasColumnName("EMEmail")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Emname)
					.HasColumnName("EMName")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Emrel)
					.HasColumnName("EMRel")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Emremarks)
					.HasColumnName("EMRemarks")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Emtel)
					.HasColumnName("EMTel")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Faid)
					.HasColumnName("FAid")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Gender)
					.HasColumnName("gender")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Homeaddress)
					.HasColumnName("homeaddress")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Language)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Marital)
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.NationalId)
					.HasColumnName("nationalID")
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.Nationality)
					.HasColumnName("nationality")
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasColumnName("personnel")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.PortalPwd)
					.HasColumnName("PortalPWD")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.PortalUn)
					.HasColumnName("PortalUN")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Prevadmnno)
					.HasColumnName("prevadmnno")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Programme)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Religion)
					.HasColumnName("religion")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Source)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Special)
					.HasColumnName("special")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Sponsor)
					.HasColumnName("sponsor")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.SubCounty)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Telno)
					.HasColumnName("telno")
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<RegList>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Arrears).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Expected).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Paid).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Refund).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Stay)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Total).HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<Reminder>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.CreateDate).HasColumnType("datetime");

				entity.Property(e => e.Duedate).HasColumnType("datetime");

				entity.Property(e => e.Duetime)
					.HasColumnType("datetime")
					.HasDefaultValueSql("('12:00:00 AM')");

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Subject)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<RentAutoInv>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CustRef)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ledger)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Ndate)
					.HasColumnName("NDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<Reporting>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Rtime).HasColumnType("datetime");

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Repository>(entity =>
			{
				entity.ToTable("repository");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.CreatedAt)
					.HasColumnName("created_at")
					.HasColumnType("datetime");

				entity.Property(e => e.CreatedBy)
					.IsRequired()
					.HasColumnName("created_by")
					.HasMaxLength(255)
					.IsUnicode(false);

				entity.Property(e => e.Descr)
					.IsRequired()
					.HasColumnName("descr")
					.HasMaxLength(1000)
					.IsUnicode(false);

				entity.Property(e => e.Filename)
					.IsRequired()
					.HasColumnName("filename")
					.HasMaxLength(255)
					.IsUnicode(false);

				entity.Property(e => e.Filetype)
					.IsRequired()
					.HasColumnName("filetype")
					.HasMaxLength(255)
					.IsUnicode(false);
			});

			modelBuilder.Entity<RetakeReg>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Class)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<RetakeRegDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.UnitCode)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Rfq>(entity =>
			{
				entity.HasKey(e => e.Rfqref);

				entity.ToTable("RFQ");

				entity.Property(e => e.Rfqref)
					.HasColumnName("RFQRef")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Sdate).HasColumnType("datetime");

				entity.Property(e => e.Stime)
					.HasColumnName("STime")
					.HasColumnType("datetime");

				entity.Property(e => e.Subject)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.SupRef)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Rfqdetail>(entity =>
			{
				entity.ToTable("RFQDetail");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rfqref)
					.HasColumnName("RFQRef")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Spec).IsUnicode(false);
			});

			modelBuilder.Entity<Savedsearches>(entity =>
			{
				entity.ToTable("savedsearches");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasMaxLength(120)
					.IsUnicode(false);

				entity.Property(e => e.Type).HasColumnName("type");

				entity.Property(e => e.Url)
					.HasColumnName("url")
					.HasMaxLength(8000)
					.IsUnicode(false);

				entity.Property(e => e.UserId).HasColumnName("user_id");
			});

			modelBuilder.Entity<Schools>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Address)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.College)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Contact)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.DeanUserName)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Tel)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Website)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<SCompanyNews>(entity =>
			{
				entity.ToTable("s_company_news");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Content)
					.IsRequired()
					.HasColumnName("content")
					.HasColumnType("text");

				entity.Property(e => e.CreatedBy)
					.HasColumnName("created_by")
					.HasMaxLength(150)
					.IsUnicode(false);

				entity.Property(e => e.CreatedDate)
					.HasColumnName("created_date")
					.HasColumnType("datetime");

				entity.Property(e => e.Document)
					.HasColumnName("document")
					.HasMaxLength(150)
					.IsUnicode(false);

				entity.Property(e => e.Group)
					.HasColumnName("group")
					.HasMaxLength(150)
					.IsUnicode(false);

				entity.Property(e => e.StatusId).HasColumnName("status_id");

				entity.Property(e => e.Tags)
					.HasColumnName("tags")
					.HasColumnType("text");

				entity.Property(e => e.Title)
					.IsRequired()
					.HasColumnName("title")
					.HasMaxLength(128)
					.IsUnicode(false);

				entity.Property(e => e.UpdatedBy)
					.HasColumnName("updated_by")
					.HasMaxLength(150)
					.IsUnicode(false);

				entity.Property(e => e.UpdatedDate)
					.HasColumnName("updated_date")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<SmsBlackList>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Bnum)
					.HasColumnName("BNum")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Rtime)
					.HasColumnName("RTime")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<SmsClassExam>(entity =>
			{
				entity.ToTable("smsClassExam");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Class)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<SmsReceived>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Msg)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Msgtype)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.ReplyMsg)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Rtime).HasColumnType("datetime");

				entity.Property(e => e.Sender)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<SmsSent>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Msg)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Recipient)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rtime).HasColumnType("datetime");

				entity.Property(e => e.Status)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<SmsSetup>(entity =>
			{
				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedNever();

				entity.Property(e => e.SmsBlnum).HasColumnName("smsBLNum");

				entity.Property(e => e.SmsReplyMsg)
					.HasColumnName("smsReplyMsg")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.SmsSecs).HasColumnName("smsSecs");

				entity.Property(e => e.Smsdelete).HasColumnName("smsdelete");

				entity.Property(e => e.Smsdisablepin).HasColumnName("smsdisablepin");

				entity.Property(e => e.Smsflash).HasColumnName("smsflash");

				entity.Property(e => e.Smsmultipart).HasColumnName("smsmultipart");

				entity.Property(e => e.Smspin)
					.HasColumnName("smspin")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Smsport)
					.HasColumnName("smsport")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Smsreport).HasColumnName("smsreport");

				entity.Property(e => e.Smsspeed)
					.HasColumnName("smsspeed")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Smsstore)
					.HasColumnName("smsstore")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<SpecialExams>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ground)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Subject)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudAccomXlsfields>(entity =>
			{
				entity.ToTable("StudAccomXLSFields");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Fname)
					.HasColumnName("FName")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Xlsvalue)
					.HasColumnName("XLSValue")
					.HasMaxLength(500)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudDependant>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Dob)
					.HasColumnName("DOB")
					.HasColumnType("datetime");

				entity.Property(e => e.Gender)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Occupation)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Relationship)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Status)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Tel)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudDepositRefund>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Description)
					.HasMaxLength(5000)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Term)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudDepositRefundBd>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.ToTable("StudDepositRefundBD");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DepositRefundName)
					.IsRequired()
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<StudDepositRefundBdxlsfields>(entity =>
			{
				entity.ToTable("StudDepositRefundBDXLSFields");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Fname)
					.HasColumnName("FName")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Xlsvalue)
					.HasColumnName("XLSValue")
					.HasMaxLength(500)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudDocuments>(entity =>
			{
				entity.HasKey(e => e.DocumentId);

				entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

				entity.Property(e => e.AssignId).HasColumnName("AssignID");

				entity.Property(e => e.DocumentName)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.StudentId)
					.HasColumnName("StudentID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.SubjectId)
					.HasColumnName("SubjectID")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.TutorId)
					.HasColumnName("TutorID")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudEmailXlsfields>(entity =>
			{
				entity.ToTable("StudEmailXLSFields");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Fname)
					.HasColumnName("FName")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Xlsvalue)
					.HasColumnName("XLSValue")
					.HasMaxLength(500)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudEnrolment>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Class)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Event)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Hostel)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Sdate)
					.HasColumnName("SDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Specialization)
					.HasMaxLength(150)
					.IsUnicode(false);

				entity.Property(e => e.Status)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Stay)
					.HasMaxLength(30)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudentAssn>(entity =>
			{
				entity.HasKey(e => e.AssignId);

				entity.Property(e => e.AssignId).HasColumnName("AssignID");

				entity.Property(e => e.AssignContent)
					.IsRequired()
					.HasMaxLength(250)
					.IsUnicode(false);

				entity.Property(e => e.DurationEnd).HasColumnType("datetime");

				entity.Property(e => e.DurationStart).HasColumnType("datetime");

				entity.Property(e => e.SubjectCode)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Studentattendance>(entity =>
			{
				entity.ToTable("studentattendance");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.AttendanceDate)
					.HasColumnName("attendance_date")
					.HasColumnType("datetime");

				entity.Property(e => e.IsHalfDay).HasColumnName("is_half_day");

				entity.Property(e => e.Reason)
					.IsRequired()
					.HasColumnName("reason")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.StudentId)
					.IsRequired()
					.HasColumnName("student_id")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudentsImportXlsfields>(entity =>
			{
				entity.ToTable("StudentsImportXLSFields");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Fname)
					.HasColumnName("FName")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Xlsvalue)
					.HasColumnName("XLSValue")
					.HasMaxLength(500)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudentSource>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudentTimesheet>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.DeviceId)
					.HasColumnName("DeviceID")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.InOut)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Lecturer)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Room)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rtime)
					.HasColumnName("RTime")
					.HasColumnType("datetime");

				entity.Property(e => e.Subject)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudentType>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudFeesBalances>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<StudFiles>(entity =>
			{
				entity.HasKey(e => e.Fname);

				entity.Property(e => e.Fname)
					.HasColumnName("FName")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Description)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Extension)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Title)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudInvoice>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.AccommodationIncome)
					.HasColumnName("Accommodation Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccomodationFees)
					.HasColumnName("Accomodation Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccruedExpenses)
					.HasColumnName("Accrued Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccruedStatutoryOtherDeductions)
					.HasColumnName("Accrued Statutory & Other Deductions")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccummulatedArmotizationDepreciation)
					.HasColumnName("Accummulated Armotization & Depreciation")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedArmotizationOfLand)
					.HasColumnName("Accumulated Armotization of Land")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationBuilding)
					.HasColumnName("Accumulated Depreciation Building")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationComputersAndAccessories)
					.HasColumnName("Accumulated Depreciation Computers and Accessories")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationFurnitureAndFittings)
					.HasColumnName("Accumulated Depreciation Furniture and Fittings")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationLibraryBooks)
					.HasColumnName("Accumulated Depreciation Library Books")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationMotorVehicles)
					.HasColumnName("Accumulated Depreciation Motor Vehicles")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationPlantAndEquipment)
					.HasColumnName("Accumulated Depreciation Plant and Equipment")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ActivityFees)
					.HasColumnName("Activity Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AdministrativeAndRelatedIncomes)
					.HasColumnName("Administrative and Related Incomes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.AgribusinessTradeFair)
					.HasColumnName("Agribusiness Trade Fair")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Amenity).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ApplicationFees)
					.HasColumnName("Application Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BankLoans)
					.HasColumnName("Bank Loans")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BankTransfers)
					.HasColumnName("Bank transfers")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BookshopSales)
					.HasColumnName("Bookshop Sales")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BridgingFees)
					.HasColumnName("Bridging Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CapitalCreditors)
					.HasColumnName("Capital Creditors")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CateringIncome)
					.HasColumnName("Catering Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CautionMoney)
					.HasColumnName("Caution Money")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CdfConstituencyDevelopmentFund)
					.HasColumnName("CDF- Constituency Development Fund")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Class)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.CollaboratingFees)
					.HasColumnName("Collaborating fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CommissionerOfDomesticTaxesWithholdingTax)
					.HasColumnName("Commissioner of Domestic Taxes (Withholding Tax)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ComputerFees)
					.HasColumnName("Computer Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ConferenceWorkshops)
					.HasColumnName("Conference & Workshops")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CustomerPrepayments)
					.HasColumnName("Customer Prepayments")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DirectCharges)
					.HasColumnName("Direct Charges")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DonorFundedResearchReceipts)
					.HasColumnName("Donor Funded Research Receipts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Eia)
					.HasColumnName("EIA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ExaminationsFees)
					.HasColumnName("Examinations Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ExchequerGrantsRecurrent)
					.HasColumnName("Exchequer Grants (Recurrent)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FarmIncome)
					.HasColumnName("Farm Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldAttachment)
					.HasColumnName("Field Attachment")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldCourse)
					.HasColumnName("Field Course")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldTrips)
					.HasColumnName("Field Trips")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldWorkSupervision)
					.HasColumnName("Field Work Supervision")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FinesPenalties)
					.HasColumnName("Fines & Penalties")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Fisheries).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ForestryWoodScience)
					.HasColumnName("Forestry & Wood Science")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GraduationFees)
					.HasColumnName("Graduation Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GraduationIncome)
					.HasColumnName("Graduation Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Grants).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GuestHouse)
					.HasColumnName("Guest House")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbBursariesStudents)
					.HasColumnName("HELB-Bursaries Students")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbLoanRepaymentStaff)
					.HasColumnName("HELB-Loan Repayment Staff")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbLoanStudents)
					.HasColumnName("HELB-Loan Students")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HireOfMotorVehicles)
					.HasColumnName("Hire of Motor Vehicles")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.IgaIncomes)
					.HasColumnName("IGA Incomes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.IncomeTaxPartTimeClaims)
					.HasColumnName("Income Tax (Part time claims)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LegalAttachments)
					.HasColumnName("Legal Attachments")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LibraryFees)
					.HasColumnName("Library Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LibraryIncome)
					.HasColumnName("Library Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LongTermLiabilities)
					.HasColumnName("Long Term Liabilities")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MiscelaneuosIncome)
					.HasColumnName("Miscelaneuos Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.NetPay)
					.HasColumnName("Net Pay")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Nhif)
					.HasColumnName("NHIF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Nssf)
					.HasColumnName("NSSF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherIgaIncome)
					.HasColumnName("Other IGA Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherIncomes)
					.HasColumnName("Other Incomes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherLiabilitiesProvisions)
					.HasColumnName("Other Liabilities & Provisions")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherStudentRelatedIncome)
					.HasColumnName("Other Student Related Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PartTimeLecturers)
					.HasColumnName("Part-time Lecturers")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Paye)
					.HasColumnName("PAYE")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PayrollRecoveries)
					.HasColumnName("Payroll Recoveries")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Pension)
					.HasColumnName("PENSION")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PhotocopyingBinderyServices)
					.HasColumnName("Photocopying & Bindery Services")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PrepaidFeesStudents)
					.HasColumnName("Prepaid Fees (Students)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProjectsRetentionMoney)
					.HasColumnName("Projects Retention Money")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProvisionForAuditFees)
					.HasColumnName("Provision for Audit Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProvisionForBadDebts)
					.HasColumnName("Provision for Bad Debts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.ReMarkingCharges)
					.HasColumnName("Re-marking Charges")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ReferralSupplementary)
					.HasColumnName("Referral/Supplementary")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Registration).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RentIncome)
					.HasColumnName("Rent Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RentPayable)
					.HasColumnName("Rent Payable")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ResearchAdministrationIncome)
					.HasColumnName("Research Administration Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ResearchAdministrativeIncome)
					.HasColumnName("Research Administrative Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ResearchFundAccounts)
					.HasColumnName("Research Fund Accounts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RetentionContractor)
					.HasColumnName("Retention (Contractor)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Saccos)
					.HasColumnName("SACCOs")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.SalaryRecovery)
					.HasColumnName("Salary Recovery")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.SpecialProject)
					.HasColumnName("Special Project")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Sponsorships).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StaffInsurance)
					.HasColumnName("Staff Insurance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StaffMedicalClaims)
					.HasColumnName("Staff Medical Claims")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentIdFees)
					.HasColumnName("Student ID Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentMedicalFees)
					.HasColumnName("Student Medical Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentsOpeningBalance)
					.HasColumnName("Students Opening Balance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Supervision).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TeachingPracticeFees)
					.HasColumnName("Teaching Practice Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Term)
					.HasColumnName("term")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ThesisFees)
					.HasColumnName("Thesis Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TradeAndOtherPayables)
					.HasColumnName("Trade and Other Payables")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TradeCreditors)
					.HasColumnName("Trade Creditors")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TuitionFees)
					.HasColumnName("Tuition Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TuitionIncome)
					.HasColumnName("Tuition Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UnallocatedFee)
					.HasColumnName("Unallocated Fee")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UnionDues)
					.HasColumnName("UNION DUES")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoExpenses)
					.HasColumnName("UoESO Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoFunds)
					.HasColumnName("UoESO Funds")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoFundsReceipts)
					.HasColumnName("UoESO Funds Receipts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Uoeso)
					.HasColumnName("UOESO")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoesoRent)
					.HasColumnName("UOESO Rent")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.VatTaxes)
					.HasColumnName("VAT Taxes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.VlirCarHire)
					.HasColumnName("VLIR Car Hire")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Welfares)
					.HasColumnName("WELFARES")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.WithHoldingVatTaxWhvat)
					.HasColumnName("With-Holding VAT Tax (WHVAT)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.WorkshopPractice)
					.HasColumnName("Workshop Practice")
					.HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<StudInvoiceAdj>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.AccommodationIncome)
					.HasColumnName("Accommodation Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccomodationFees)
					.HasColumnName("Accomodation Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccruedExpenses)
					.HasColumnName("Accrued Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccruedStatutoryOtherDeductions)
					.HasColumnName("Accrued Statutory & Other Deductions")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccummulatedArmotizationDepreciation)
					.HasColumnName("Accummulated Armotization & Depreciation")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedArmotizationOfLand)
					.HasColumnName("Accumulated Armotization of Land")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationBuilding)
					.HasColumnName("Accumulated Depreciation Building")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationComputersAndAccessories)
					.HasColumnName("Accumulated Depreciation Computers and Accessories")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationFurnitureAndFittings)
					.HasColumnName("Accumulated Depreciation Furniture and Fittings")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationLibraryBooks)
					.HasColumnName("Accumulated Depreciation Library Books")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationMotorVehicles)
					.HasColumnName("Accumulated Depreciation Motor Vehicles")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationPlantAndEquipment)
					.HasColumnName("Accumulated Depreciation Plant and Equipment")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ActivityFees)
					.HasColumnName("Activity Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AdministrativeAndRelatedIncomes)
					.HasColumnName("Administrative and Related Incomes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.AgribusinessTradeFair)
					.HasColumnName("Agribusiness Trade Fair")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Amenity).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ApplicationFees)
					.HasColumnName("Application Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BankLoans)
					.HasColumnName("Bank Loans")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BankTransfers)
					.HasColumnName("Bank transfers")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BookshopSales)
					.HasColumnName("Bookshop Sales")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BridgingFees)
					.HasColumnName("Bridging Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CapitalCreditors)
					.HasColumnName("Capital Creditors")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CateringIncome)
					.HasColumnName("Catering Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CautionMoney)
					.HasColumnName("Caution Money")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CdfConstituencyDevelopmentFund)
					.HasColumnName("CDF- Constituency Development Fund")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Class)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.CollaboratingFees)
					.HasColumnName("Collaborating fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CommissionerOfDomesticTaxesWithholdingTax)
					.HasColumnName("Commissioner of Domestic Taxes (Withholding Tax)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ComputerFees)
					.HasColumnName("Computer Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ConferenceWorkshops)
					.HasColumnName("Conference & Workshops")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CustomerPrepayments)
					.HasColumnName("Customer Prepayments")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DirectCharges)
					.HasColumnName("Direct Charges")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DonorFundedResearchReceipts)
					.HasColumnName("Donor Funded Research Receipts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Eia)
					.HasColumnName("EIA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ExaminationsFees)
					.HasColumnName("Examinations Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ExchequerGrantsRecurrent)
					.HasColumnName("Exchequer Grants (Recurrent)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FarmIncome)
					.HasColumnName("Farm Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldAttachment)
					.HasColumnName("Field Attachment")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldCourse)
					.HasColumnName("Field Course")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldTrips)
					.HasColumnName("Field Trips")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldWorkSupervision)
					.HasColumnName("Field Work Supervision")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FinesPenalties)
					.HasColumnName("Fines & Penalties")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Fisheries).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ForestryWoodScience)
					.HasColumnName("Forestry & Wood Science")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GraduationFees)
					.HasColumnName("Graduation Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GraduationIncome)
					.HasColumnName("Graduation Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Grants).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GuestHouse)
					.HasColumnName("Guest House")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbBursariesStudents)
					.HasColumnName("HELB-Bursaries Students")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbLoanRepaymentStaff)
					.HasColumnName("HELB-Loan Repayment Staff")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbLoanStudents)
					.HasColumnName("HELB-Loan Students")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HireOfMotorVehicles)
					.HasColumnName("Hire of Motor Vehicles")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.IgaIncomes)
					.HasColumnName("IGA Incomes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.IncomeTaxPartTimeClaims)
					.HasColumnName("Income Tax (Part time claims)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LegalAttachments)
					.HasColumnName("Legal Attachments")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LibraryFees)
					.HasColumnName("Library Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LibraryIncome)
					.HasColumnName("Library Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LongTermLiabilities)
					.HasColumnName("Long Term Liabilities")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MiscelaneuosIncome)
					.HasColumnName("Miscelaneuos Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.NetPay)
					.HasColumnName("Net Pay")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Nhif)
					.HasColumnName("NHIF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Nssf)
					.HasColumnName("NSSF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ob).HasColumnName("OB");

				entity.Property(e => e.OtherIgaIncome)
					.HasColumnName("Other IGA Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherIncomes)
					.HasColumnName("Other Incomes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherLiabilitiesProvisions)
					.HasColumnName("Other Liabilities & Provisions")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherStudentRelatedIncome)
					.HasColumnName("Other Student Related Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PartTimeLecturers)
					.HasColumnName("Part-time Lecturers")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Paye)
					.HasColumnName("PAYE")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PayrollRecoveries)
					.HasColumnName("Payroll Recoveries")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Pension)
					.HasColumnName("PENSION")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.PhotocopyingBinderyServices)
					.HasColumnName("Photocopying & Bindery Services")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PrepaidFeesStudents)
					.HasColumnName("Prepaid Fees (Students)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProjectsRetentionMoney)
					.HasColumnName("Projects Retention Money")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProvisionForAuditFees)
					.HasColumnName("Provision for Audit Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProvisionForBadDebts)
					.HasColumnName("Provision for Bad Debts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.ReMarkingCharges)
					.HasColumnName("Re-marking Charges")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ReferralSupplementary)
					.HasColumnName("Referral/Supplementary")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Registration).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RentIncome)
					.HasColumnName("Rent Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RentPayable)
					.HasColumnName("Rent Payable")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ResearchAdministrationIncome)
					.HasColumnName("Research Administration Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ResearchAdministrativeIncome)
					.HasColumnName("Research Administrative Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ResearchFundAccounts)
					.HasColumnName("Research Fund Accounts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RetentionContractor)
					.HasColumnName("Retention (Contractor)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Saccos)
					.HasColumnName("SACCOs")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.SalaryRecovery)
					.HasColumnName("Salary Recovery")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.SpecialProject)
					.HasColumnName("Special Project")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Sponsorships).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StaffInsurance)
					.HasColumnName("Staff Insurance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StaffMedicalClaims)
					.HasColumnName("Staff Medical Claims")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentIdFees)
					.HasColumnName("Student ID Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentMedicalFees)
					.HasColumnName("Student Medical Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentsOpeningBalance)
					.HasColumnName("Students Opening Balance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Supervision).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TeachingPracticeFees)
					.HasColumnName("Teaching Practice Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Term)
					.HasColumnName("term")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ThesisFees)
					.HasColumnName("Thesis Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TradeAndOtherPayables)
					.HasColumnName("Trade and Other Payables")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TradeCreditors)
					.HasColumnName("Trade Creditors")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TuitionFees)
					.HasColumnName("Tuition Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TuitionIncome)
					.HasColumnName("Tuition Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UnallocatedFee)
					.HasColumnName("Unallocated Fee")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UnionDues)
					.HasColumnName("UNION DUES")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoExpenses)
					.HasColumnName("UoESO Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoFunds)
					.HasColumnName("UoESO Funds")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoFundsReceipts)
					.HasColumnName("UoESO Funds Receipts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Uoeso)
					.HasColumnName("UOESO")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoesoRent)
					.HasColumnName("UOESO Rent")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.VatTaxes)
					.HasColumnName("VAT Taxes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.VlirCarHire)
					.HasColumnName("VLIR Car Hire")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Welfares)
					.HasColumnName("WELFARES")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.WithHoldingVatTaxWhvat)
					.HasColumnName("With-Holding VAT Tax (WHVAT)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.WorkshopPractice)
					.HasColumnName("Workshop Practice")
					.HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<StudInvoiceAdjCredit>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudJabImportXlsfields>(entity =>
			{
				entity.ToTable("StudJabImportXLSFields");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Fname)
					.HasColumnName("FName")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Xlsvalue)
					.HasColumnName("XLSValue")
					.HasMaxLength(500)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudMarksXlsfields>(entity =>
			{
				entity.ToTable("StudMarksXLSFields");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Fname)
					.HasColumnName("FName")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Xlsvalue)
					.HasColumnName("XLSValue")
					.HasMaxLength(500)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudObxlsfields>(entity =>
			{
				entity.ToTable("StudOBXLSFields");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Fname)
					.HasColumnName("FName")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Xlsvalue)
					.HasColumnName("XLSValue")
					.HasMaxLength(500)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudReferee>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Address)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Designation)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Tel)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Website)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudSchools>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.EndYear)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Grades)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.IndexNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qualification)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.StartYear)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudSponsor>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Description)
					.HasMaxLength(5000)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Faid)
					.HasColumnName("FAid")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Prefix)
					.HasMaxLength(5)
					.IsUnicode(false);

				entity.Property(e => e.Rcptno)
					.HasColumnName("RCPTNo")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Type)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudSponsorBd>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.ToTable("StudSponsorBD");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.AccommodationIncome)
					.HasColumnName("Accommodation Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccomodationFees)
					.HasColumnName("Accomodation Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccruedExpenses)
					.HasColumnName("Accrued Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccruedStatutoryOtherDeductions)
					.HasColumnName("Accrued Statutory & Other Deductions")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccummulatedArmotizationDepreciation)
					.HasColumnName("Accummulated Armotization & Depreciation")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedArmotizationOfLand)
					.HasColumnName("Accumulated Armotization of Land")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationBuilding)
					.HasColumnName("Accumulated Depreciation Building")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationComputersAndAccessories)
					.HasColumnName("Accumulated Depreciation Computers and Accessories")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationFurnitureAndFittings)
					.HasColumnName("Accumulated Depreciation Furniture and Fittings")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationLibraryBooks)
					.HasColumnName("Accumulated Depreciation Library Books")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationMotorVehicles)
					.HasColumnName("Accumulated Depreciation Motor Vehicles")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AccumulatedDepreciationPlantAndEquipment)
					.HasColumnName("Accumulated Depreciation Plant and Equipment")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ActivityFees)
					.HasColumnName("Activity Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AdministrativeAndRelatedIncomes)
					.HasColumnName("Administrative and Related Incomes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.AgribusinessTradeFair)
					.HasColumnName("Agribusiness Trade Fair")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Amenity).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ApplicationFees)
					.HasColumnName("Application Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BankLoans)
					.HasColumnName("Bank Loans")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BankTransfers)
					.HasColumnName("Bank transfers")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BookshopSales)
					.HasColumnName("Bookshop Sales")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.BridgingFees)
					.HasColumnName("Bridging Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CapitalCreditors)
					.HasColumnName("Capital Creditors")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CateringIncome)
					.HasColumnName("Catering Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CautionMoney)
					.HasColumnName("Caution Money")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CdfConstituencyDevelopmentFund)
					.HasColumnName("CDF- Constituency Development Fund")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Class)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.CollaboratingFees)
					.HasColumnName("Collaborating fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CommissionerOfDomesticTaxesWithholdingTax)
					.HasColumnName("Commissioner of Domestic Taxes (Withholding Tax)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ComputerFees)
					.HasColumnName("Computer Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ConferenceWorkshops)
					.HasColumnName("Conference & Workshops")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.CustomerPrepayments)
					.HasColumnName("Customer Prepayments")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DirectCharges)
					.HasColumnName("Direct Charges")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.DonorFundedResearchReceipts)
					.HasColumnName("Donor Funded Research Receipts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Eia)
					.HasColumnName("EIA")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ExaminationsFees)
					.HasColumnName("Examinations Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ExchequerGrantsRecurrent)
					.HasColumnName("Exchequer Grants (Recurrent)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FarmIncome)
					.HasColumnName("Farm Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldAttachment)
					.HasColumnName("Field Attachment")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldCourse)
					.HasColumnName("Field Course")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldTrips)
					.HasColumnName("Field Trips")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FieldWorkSupervision)
					.HasColumnName("Field Work Supervision")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.FinesPenalties)
					.HasColumnName("Fines & Penalties")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Fisheries).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ForestryWoodScience)
					.HasColumnName("Forestry & Wood Science")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GraduationFees)
					.HasColumnName("Graduation Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GraduationIncome)
					.HasColumnName("Graduation Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Grants).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.GuestHouse)
					.HasColumnName("Guest House")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbBursariesStudents)
					.HasColumnName("HELB-Bursaries Students")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbLoanRepaymentStaff)
					.HasColumnName("HELB-Loan Repayment Staff")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HelbLoanStudents)
					.HasColumnName("HELB-Loan Students")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.HireOfMotorVehicles)
					.HasColumnName("Hire of Motor Vehicles")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.IgaIncomes)
					.HasColumnName("IGA Incomes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ImportRef)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.IncomeTaxPartTimeClaims)
					.HasColumnName("Income Tax (Part time claims)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LegalAttachments)
					.HasColumnName("Legal Attachments")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LibraryFees)
					.HasColumnName("Library Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LibraryIncome)
					.HasColumnName("Library Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.LongTermLiabilities)
					.HasColumnName("Long Term Liabilities")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MiscelaneuosIncome)
					.HasColumnName("Miscelaneuos Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.NetPay)
					.HasColumnName("Net Pay")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Nhif)
					.HasColumnName("NHIF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Nssf)
					.HasColumnName("NSSF")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherIgaIncome)
					.HasColumnName("Other IGA Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherIncomes)
					.HasColumnName("Other Incomes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherLiabilitiesProvisions)
					.HasColumnName("Other Liabilities & Provisions")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherStudentRelatedIncome)
					.HasColumnName("Other Student Related Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PartTimeLecturers)
					.HasColumnName("Part-time Lecturers")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Paye)
					.HasColumnName("PAYE")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PayrollRecoveries)
					.HasColumnName("Payroll Recoveries")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Pension)
					.HasColumnName("PENSION")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.PhotocopyingBinderyServices)
					.HasColumnName("Photocopying & Bindery Services")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.PrepaidFeesStudents)
					.HasColumnName("Prepaid Fees (Students)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProjectsRetentionMoney)
					.HasColumnName("Projects Retention Money")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProvisionForAuditFees)
					.HasColumnName("Provision for Audit Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ProvisionForBadDebts)
					.HasColumnName("Provision for Bad Debts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.ReMarkingCharges)
					.HasColumnName("Re-marking Charges")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ReferralSupplementary)
					.HasColumnName("Referral/Supplementary")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Registration).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RentIncome)
					.HasColumnName("Rent Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RentPayable)
					.HasColumnName("Rent Payable")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ResearchAdministrationIncome)
					.HasColumnName("Research Administration Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ResearchAdministrativeIncome)
					.HasColumnName("Research Administrative Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ResearchFundAccounts)
					.HasColumnName("Research Fund Accounts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RetentionContractor)
					.HasColumnName("Retention (Contractor)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Saccos)
					.HasColumnName("SACCOs")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.SalaryRecovery)
					.HasColumnName("Salary Recovery")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.SpecialProject)
					.HasColumnName("Special Project")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.SponsorName)
					.IsRequired()
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Sponsorships).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StaffInsurance)
					.HasColumnName("Staff Insurance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StaffMedicalClaims)
					.HasColumnName("Staff Medical Claims")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentIdFees)
					.HasColumnName("Student ID Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentMedicalFees)
					.HasColumnName("Student Medical Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.StudentsOpeningBalance)
					.HasColumnName("Students Opening Balance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Supervision).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TeachingPracticeFees)
					.HasColumnName("Teaching Practice Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Term)
					.HasColumnName("term")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ThesisFees)
					.HasColumnName("Thesis Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TradeAndOtherPayables)
					.HasColumnName("Trade and Other Payables")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TradeCreditors)
					.HasColumnName("Trade Creditors")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TuitionFees)
					.HasColumnName("Tuition Fees")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TuitionIncome)
					.HasColumnName("Tuition Income")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UnallocatedFee)
					.HasColumnName("Unallocated Fee")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UnionDues)
					.HasColumnName("UNION DUES")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoExpenses)
					.HasColumnName("UoESO Expenses")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoFunds)
					.HasColumnName("UoESO Funds")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoEsoFundsReceipts)
					.HasColumnName("UoESO Funds Receipts")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Uoeso)
					.HasColumnName("UOESO")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.UoesoRent)
					.HasColumnName("UOESO Rent")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.VatTaxes)
					.HasColumnName("VAT Taxes")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.VlirCarHire)
					.HasColumnName("VLIR Car Hire")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Welfares)
					.HasColumnName("WELFARES")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.WithHoldingVatTaxWhvat)
					.HasColumnName("With-Holding VAT Tax (WHVAT)")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.WorkshopPractice)
					.HasColumnName("Workshop Practice")
					.HasColumnType("decimal(19, 4)");
			});

			modelBuilder.Entity<StudSponsorBdcanc>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.ToTable("StudSponsorBDCanc");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Notes)
					.HasMaxLength(400)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Reason)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudSponsorBdcredit>(entity =>
			{
				entity.ToTable("StudSponsorBDCredit");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudSponsorBdxlsfields>(entity =>
			{
				entity.ToTable("StudSponsorBDXLSFields");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Fname)
					.HasColumnName("FName")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Xlsvalue)
					.HasColumnName("XLSValue")
					.HasMaxLength(500)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Studstatement>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Balance)
					.HasColumnName("balance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Credit)
					.HasColumnName("credit")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Debit)
					.HasColumnName("debit")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Description)
					.HasColumnName("description")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasColumnName("ref")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.SortDate).HasColumnType("datetime");

				entity.Property(e => e.Term)
					.HasColumnName("term")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasColumnName("type")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Studstatement2>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Paid).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Refund).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Required).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Term)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudTranscriptsPortalResults>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ayear)
					.HasColumnName("AYear")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Recommendation)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.YearOfStudy)
					.HasMaxLength(10)
					.IsUnicode(false);
			});

			modelBuilder.Entity<StudWork>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Designation)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.EndYear)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.StartYear)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Station)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Subjects>(entity =>
			{
				entity.HasKey(e => e.Code);

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Campuses)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Closed).HasColumnName("closed");

				entity.Property(e => e.CreditLevel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.CreditUnits).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Description)
					.HasMaxLength(5000)
					.IsUnicode(false);

				entity.Property(e => e.Exam).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.MarkTypes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(150)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.OtherTests).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.SubjectType)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<SubjectType>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Sup>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ApprovalStatus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.MarkType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Marks).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Subject)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<SupLoad>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Subject)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Suppliers>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.AccNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Address)
					.HasColumnName("address")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Bank)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Discount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Fax)
					.HasColumnName("fax")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.PinNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.SupplierType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Teld)
					.HasColumnName("teld")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Tele)
					.HasColumnName("tele")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Telm)
					.HasColumnName("telm")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Terms)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.VatNo)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<SupplierType>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<SupPreq>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.Fyear)
					.HasColumnName("FYear")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.SupRef)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<SupPreqDetail>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.ItemCat)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<SupStatement>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Balance).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Credit).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Debit).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Description)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(20)
					.IsUnicode(false);
			});

			modelBuilder.Entity<SysSetup>(entity =>
			{
				entity.HasKey(e => e.ReceiptNumber);

				entity.Property(e => e.ReceiptNumber)
					.HasColumnName("Receipt Number")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.AccumAcc)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.AlbumPath)
					.HasMaxLength(5000)
					.IsUnicode(false);

				entity.Property(e => e.AllowJvedit).HasColumnName("AllowJVEdit");

				entity.Property(e => e.AllowPvedit).HasColumnName("AllowPVEdit");

				entity.Property(e => e.AppendPayeeOnBt).HasColumnName("AppendPayeeOnBT");

				entity.Property(e => e.BadDebtAccount)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Bccemail)
					.HasColumnName("BCCEmail")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.BoardAcc)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.CancellationDate).HasColumnType("datetime");

				entity.Property(e => e.CapitalGrantsAcc)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.CcEmail)
					.HasColumnName("ccEmail")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.ClassStatus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ClassType)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.ComputeIncomeTaxLessFullVat).HasColumnName("ComputeIncomeTaxLessFullVAT");

				entity.Property(e => e.Contacts)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Contra)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Country)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.CurVersion)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.CustPrepaymentAcc)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.DefaultBudgetDept)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.DepreciationAcc)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.DisSymbol)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.DisType)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.DisplayCtgrades).HasColumnName("DisplayCTGrades");

				entity.Property(e => e.EmailAuth)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.EmailMsg)
					.HasMaxLength(1000)
					.IsUnicode(false);

				entity.Property(e => e.EmailPort)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.EmailPwd)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.EmailUname)
					.HasColumnName("EmailUName")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Exam).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.ExamSlipMsg).IsUnicode(false);

				entity.Property(e => e.ExcDept)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.FeesStatementMsg).IsUnicode(false);

				entity.Property(e => e.GradExcStatus)
					.HasMaxLength(5000)
					.IsUnicode(false);

				entity.Property(e => e.GradRoundTo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.GradRoundType)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Hbterm)
					.HasColumnName("HBTerm")
					.HasMaxLength(1000)
					.IsUnicode(false);

				entity.Property(e => e.JeminDate)
					.HasColumnName("JEMinDate")
					.HasColumnType("datetime");

				entity.Property(e => e.LastFeesBalStoredDate).HasColumnType("datetime");

				entity.Property(e => e.LatestVersion)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.LibBranchCode)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.LibDbname)
					.HasColumnName("LibDBName")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.LibHost)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.LibPort)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.LibPwd)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.LibStaffCat)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.LibStudentCat)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.LibUname)
					.HasColumnName("LibUName")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Location)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.LockDate).HasColumnType("datetime");

				entity.Property(e => e.MailFrom)
					.HasColumnName("mailFrom")
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.MarkInputDate)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.MaxUnitsPerAy).HasColumnName("MaxUnitsPerAY");

				entity.Property(e => e.MinUnitsPerAy).HasColumnName("MinUnitsPerAY");

				entity.Property(e => e.NewBankingStartDate).HasColumnType("datetime");

				entity.Property(e => e.Obaccount)
					.HasColumnName("OBAccount")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.OpeningDate)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.OrgCurrency)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.OrgName)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.OtherTests).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.OtherTestsTreat)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.RcreditAcc)
					.HasColumnName("RCreditAcc")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.RcreditName)
					.HasColumnName("RCreditName")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Referral).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.RepSymbol)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.RepType)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.RepeatCaseEvent)
					.HasMaxLength(5000)
					.IsUnicode(false);

				entity.Property(e => e.ReportMsg).IsUnicode(false);

				entity.Property(e => e.ReportingDeadline).HasColumnType("datetime");

				entity.Property(e => e.RoomArrears).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Smsenabled).HasColumnName("SMSEnabled");

				entity.Property(e => e.Smshost)
					.HasColumnName("SMSHost")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.SmsnoFormat)
					.HasColumnName("SMSNoFormat")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Smsport)
					.HasColumnName("SMSPort")
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Smspwd)
					.HasColumnName("SMSPwd")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Smsuname)
					.HasColumnName("SMSUName")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Smsurltemp)
					.HasColumnName("SMSURLTemp")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Smtpserver)
					.HasColumnName("SMTPServer")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Ssl).HasColumnName("SSL");

				entity.Property(e => e.StartDate).HasColumnType("datetime");

				entity.Property(e => e.StudTerminationStatus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.SubTitle)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.SupSymbol)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.SupType)
					.HasMaxLength(10)
					.IsUnicode(false);

				entity.Property(e => e.Tax).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Thankyou)
					.HasMaxLength(2000)
					.IsUnicode(false);

				entity.Property(e => e.TheLatestVersion)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Tpallowance)
					.HasColumnName("TPAllowance")
					.HasColumnType("decimal(19, 4)");

				entity.Property(e => e.TransMsg).IsUnicode(false);

				entity.Property(e => e.UnitRegDeadLine).HasColumnType("datetime");
			});

			modelBuilder.Entity<SysSetupMore>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Cdmfooter)
					.HasColumnName("CDMFooter")
					.IsUnicode(false);

				entity.Property(e => e.CdmprintHeader).HasColumnName("CDMPrintHeader");

				entity.Property(e => e.CdmtopMargin)
					.HasColumnName("CDMTopMargin")
					.HasColumnType("decimal(19, 0)");

				entity.Property(e => e.CheckIn).IsUnicode(false);

				entity.Property(e => e.CheckOut).IsUnicode(false);

				entity.Property(e => e.ChqSchFooter).IsUnicode(false);

				entity.Property(e => e.Cpvfooter)
					.HasColumnName("CPVFooter")
					.IsUnicode(false);

				entity.Property(e => e.CpvprintHeader).HasColumnName("CPVPrintHeader");

				entity.Property(e => e.CpvtopMargin)
					.HasColumnName("CPVTopMargin")
					.HasColumnType("decimal(19, 0)");

				entity.Property(e => e.Dbmfooter)
					.HasColumnName("DBMFooter")
					.IsUnicode(false);

				entity.Property(e => e.DbmprintHeader).HasColumnName("DBMPrintHeader");

				entity.Property(e => e.DbmtopMargin)
					.HasColumnName("DBMTopMargin")
					.HasColumnType("decimal(19, 0)");

				entity.Property(e => e.DeliverTo)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.DepMethod)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Hecategory)
					.HasColumnName("HECategory")
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.ImpSurFooter).IsUnicode(false);

				entity.Property(e => e.ImpSurTopMargin).HasColumnType("decimal(19, 0)");

				entity.Property(e => e.InvFooter).IsUnicode(false);

				entity.Property(e => e.InvTopMargin).HasColumnType("decimal(19, 0)");

				entity.Property(e => e.LeaveFooter).IsUnicode(false);

				entity.Property(e => e.OnlineReqFooter).IsUnicode(false);

				entity.Property(e => e.PinvFooter)
					.HasColumnName("PInvFooter")
					.IsUnicode(false);

				entity.Property(e => e.PinvPrintHeader).HasColumnName("PInvPrintHeader");

				entity.Property(e => e.PinvTopMargin)
					.HasColumnName("PInvTopMargin")
					.HasColumnType("decimal(19, 0)");

				entity.Property(e => e.Pofooter)
					.HasColumnName("POFooter")
					.IsUnicode(false);

				entity.Property(e => e.Posign)
					.HasColumnName("POSign")
					.IsUnicode(false);

				entity.Property(e => e.PostatusFinal)
					.HasColumnName("POStatusFinal")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.PostatusStart)
					.HasColumnName("POStatusStart")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Pvfooter)
					.HasColumnName("PVFooter")
					.IsUnicode(false);

				entity.Property(e => e.PvprintHeader).HasColumnName("PVPrintHeader");

				entity.Property(e => e.PvtopMargin)
					.HasColumnName("PVTopMargin")
					.HasColumnType("decimal(19, 0)");

				entity.Property(e => e.ReqFooter).IsUnicode(false);

				entity.Property(e => e.ReqOn)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ReqReqOn)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ReqTopMargin).HasColumnType("decimal(19, 0)");

				entity.Property(e => e.Salutation).IsUnicode(false);

				entity.Property(e => e.TamanualClockIn).HasColumnName("TAManualClockIn");

				entity.Property(e => e.TopMargin).HasColumnType("decimal(19, 0)");

				entity.Property(e => e.TtignoreExamTime).HasColumnName("TTIgnoreExamTime");

				entity.Property(e => e.TtignoreStudyTime).HasColumnName("TTIgnoreStudyTime");

				entity.Property(e => e.TtminBlockTime).HasColumnName("TTMinBlockTime");

				entity.Property(e => e.TtscheduleWithoutRoom).HasColumnName("TTScheduleWithoutRoom");

				entity.Property(e => e.TtstudNumberToBeUsed)
					.HasColumnName("TTStudNumberToBeUsed")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TaxType>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Account)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Rate).HasColumnType("decimal(19, 10)");

				entity.Property(e => e.RoundTo)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.RoundType)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Vat).HasColumnName("VAT");

				entity.Property(e => e.Vatwithhold).HasColumnName("VATWithhold");
			});

			modelBuilder.Entity<Term>(entity =>
			{
				entity.HasKey(e => e.Names);

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.AcademicYear)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Ends)
					.HasColumnName("ends")
					.HasColumnType("datetime");

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Starts)
					.HasColumnName("starts")
					.HasColumnType("datetime");

				entity.Property(e => e.TermAlias)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Type)
					.IsRequired()
					.HasColumnName("type")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Thesis>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.AdmnNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Supervisor)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Title)
					.HasMaxLength(3000)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Timetable>(entity =>
			{
				entity.HasKey(e => e.EventId);

				entity.ToTable("timetable");

				entity.Property(e => e.EventId).HasColumnName("event_id");

				entity.Property(e => e.EndDate)
					.HasColumnName("end_date")
					.HasColumnType("datetime");

				entity.Property(e => e.EventName)
					.IsRequired()
					.HasColumnName("event_name")
					.HasMaxLength(255)
					.IsUnicode(false);

				entity.Property(e => e.StartDate)
					.HasColumnName("start_date")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<Ttatype>(entity =>
			{
				entity.ToTable("TTAType");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Bcolor)
					.HasColumnName("BColor")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");
			});

			modelBuilder.Entity<Ttbuilding>(entity =>
			{
				entity.ToTable("TTBuilding");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Xcoord)
					.HasColumnName("XCoord")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ycoord)
					.HasColumnName("YCoord")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtdayProgram>(entity =>
			{
				entity.ToTable("TTDayProgram");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Rday)
					.HasColumnName("RDay")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.StudyMode)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtdayProgramDetails>(entity =>
			{
				entity.ToTable("TTDayProgramDetails");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Etime)
					.HasColumnName("ETime")
					.HasColumnType("datetime");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Stime)
					.HasColumnName("STime")
					.HasColumnType("datetime");

				entity.Property(e => e.Type)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtexamPeriod>(entity =>
			{
				entity.ToTable("TTExamPeriod");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Cdate)
					.HasColumnName("CDate")
					.HasColumnType("datetime");

				entity.Property(e => e.EndDate).HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.StartDate).HasColumnType("datetime");

				entity.Property(e => e.Term)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtexamProcessed>(entity =>
			{
				entity.ToTable("TTExamProcessed");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Etime)
					.HasColumnName("ETime")
					.HasColumnType("time");

				entity.Property(e => e.Stime)
				  .HasColumnName("STime")
				  .HasColumnType("time");


				entity.Property(e => e.ExamPeriod)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ExamType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Room)
					.HasMaxLength(50)
					.IsUnicode(false);



				entity.Property(e => e.StudyMode)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.UnitCode)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("Rdate")
					.HasColumnType("datetime");

				entity.Property(e => e.Rhours)
					.HasColumnName("Rhours")
					.HasColumnType("float(53)");

				entity.Property(e => e.DayPlan)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Invigilator)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtexamSchedule>(entity =>
			{
				entity.ToTable("TTExamSchedule");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.ExamPeriod)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.StudyMode)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.UnitCode)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtexamScheduleDetails>(entity =>
			{
				entity.ToTable("TTExamScheduleDetails");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.ExamType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.RoomPref)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.TimePref)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtexamScheduleInvigilator>(entity =>
			{
				entity.ToTable("TTExamScheduleInvigilator");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtexamType>(entity =>
			{
				entity.ToTable("TTExamType");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Ttholidays>(entity =>
			{
				entity.ToTable("TTHolidays");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Hdate)
					.HasColumnName("HDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.StudyMode)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Ttlecturer>(entity =>
			{
				entity.ToTable("TTLecturer");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Dname)
					.IsRequired()
					.HasColumnName("DName")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.EmpNo)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Sdate)
					.HasColumnName("SDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Type)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtlecturerTimePref>(entity =>
			{
				entity.ToTable("TTLecturerTimePref");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Rday)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.TimePref)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtlecturerUnits>(entity =>
			{
				entity.ToTable("TTLecturerUnits");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Ttreserved>(entity =>
			{
				entity.ToTable("TTReserved");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.EndDate).HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.StartDate).HasColumnType("datetime");
			});

			modelBuilder.Entity<TtroomFeature>(entity =>
			{
				entity.ToTable("TTRoomFeature");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Ttrooms>(entity =>
			{
				entity.ToTable("TTRooms");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Building)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.RoomFeatures)
					.HasMaxLength(2000)
					.IsUnicode(false);

				entity.Property(e => e.RoomType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.SharedDepartment)
					.HasMaxLength(5000)
					.IsUnicode(false);

				entity.Property(e => e.Size)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Xcoord)
					.HasColumnName("XCoord")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ycoord)
					.HasColumnName("YCoord")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtroomType>(entity =>
			{
				entity.ToTable("TTRoomType");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtstudyPeriod>(entity =>
			{
				entity.ToTable("TTStudyPeriod");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Cdate)
					.HasColumnName("CDate")
					.HasColumnType("datetime");

				entity.Property(e => e.EndDate).HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.StartDate).HasColumnType("datetime");

				entity.Property(e => e.Term)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtstudyProcessed>(entity =>
			{
				entity.ToTable("TTStudyProcessed");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Etime)
					.HasColumnName("ETime")
					.HasColumnType("datetime");

				entity.Property(e => e.LecturerUsed)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rday)
					.HasColumnName("RDay")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Room)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Stime)
					.HasColumnName("STime")
					.HasColumnType("datetime");

				entity.Property(e => e.StudyMode)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.StudyPeriod)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.StudyType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.UnitCode)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtstudySchedule>(entity =>
			{
				entity.ToTable("TTStudySchedule");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.DoubleBlock)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.StudyMode)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.StudyPeriod)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.UnitCode)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtstudyScheduleDetails>(entity =>
			{
				entity.ToTable("TTStudyScheduleDetails");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.RoomPref)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.StudyType)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.TimePref)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtstudyScheduleLecturer>(entity =>
			{
				entity.ToTable("TTStudyScheduleLecturer");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<TtstudyType>(entity =>
			{
				entity.ToTable("TTStudyType");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Tutors>(entity =>
			{
				entity.HasKey(e => e.Ref);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Address)
					.HasColumnName("address")
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.Fax)
					.HasColumnName("fax")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.IsUnicode(false);

				entity.Property(e => e.Subjects).IsUnicode(false);

				entity.Property(e => e.Teld)
					.HasColumnName("teld")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Tele)
					.HasColumnName("tele")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Telm)
					.HasColumnName("telm")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Tscno)
					.HasColumnName("TSCNo")
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<UsergroupsAccess>(entity =>
			{
				entity.ToTable("usergroups_access");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Controller)
					.IsRequired()
					.HasColumnName("controller")
					.HasMaxLength(140)
					.IsUnicode(false);

				entity.Property(e => e.Element).HasColumnName("element");

				entity.Property(e => e.ElementId).HasColumnName("element_id");

				entity.Property(e => e.Module)
					.IsRequired()
					.HasColumnName("module")
					.HasMaxLength(140)
					.IsUnicode(false);

				entity.Property(e => e.Permission)
					.IsRequired()
					.HasColumnName("permission")
					.HasMaxLength(7)
					.IsUnicode(false);
			});

			modelBuilder.Entity<UsergroupsConfiguration>(entity =>
			{
				entity.ToTable("usergroups_configuration");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Description)
					.HasColumnName("description")
					.HasColumnType("text");

				entity.Property(e => e.Options)
					.HasColumnName("options")
					.HasColumnType("text");

				entity.Property(e => e.Rules)
					.HasColumnName("rules")
					.HasMaxLength(40)
					.IsUnicode(false);

				entity.Property(e => e.Value)
					.HasColumnName("value")
					.HasMaxLength(20)
					.IsUnicode(false);
			});

			modelBuilder.Entity<UsergroupsCron>(entity =>
			{
				entity.ToTable("usergroups_cron");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Lapse).HasColumnName("lapse");

				entity.Property(e => e.LastOccurrence)
					.HasColumnName("last_occurrence")
					.HasColumnType("datetime");

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasMaxLength(40)
					.IsUnicode(false);
			});

			modelBuilder.Entity<UsergroupsGroup>(entity =>
			{
				entity.ToTable("usergroups_group");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Groupname)
					.IsRequired()
					.HasColumnName("groupname")
					.HasMaxLength(120)
					.IsUnicode(false);

				entity.Property(e => e.Home)
					.HasColumnName("home")
					.HasMaxLength(120)
					.IsUnicode(false);

				entity.Property(e => e.Level).HasColumnName("level");
			});

			modelBuilder.Entity<UsergroupsLookup>(entity =>
			{
				entity.ToTable("usergroups_lookup");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Element)
					.HasColumnName("element")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Text)
					.HasColumnName("text")
					.HasMaxLength(40)
					.IsUnicode(false);

				entity.Property(e => e.Value).HasColumnName("value");
			});

			modelBuilder.Entity<UsergroupsUser>(entity =>
			{
				entity.ToTable("usergroups_user");

				entity.HasIndex(e => new { e.Username, e.Email })
					.HasName("UQ__usergroups_user__62EF9734")
					.IsUnique();

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.ActivationCode)
					.HasColumnName("activation_code")
					.HasMaxLength(30)
					.IsUnicode(false);

				entity.Property(e => e.ActivationTime)
					.HasColumnName("activation_time")
					.HasColumnType("datetime");

				entity.Property(e => e.Answer)
					.HasColumnName("answer")
					.HasColumnType("text");

				entity.Property(e => e.Ban)
					.HasColumnName("ban")
					.HasColumnType("datetime");

				entity.Property(e => e.BanReason)
					.HasColumnName("ban_reason")
					.HasColumnType("text");

				entity.Property(e => e.CreationDate)
					.HasColumnName("creation_date")
					.HasColumnType("datetime");

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(120)
					.IsUnicode(false);

				entity.Property(e => e.GroupId).HasColumnName("group_id");

				entity.Property(e => e.Home)
					.HasColumnName("home")
					.HasMaxLength(120)
					.IsUnicode(false);

				entity.Property(e => e.LastLogin)
					.HasColumnName("last_login")
					.HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasColumnName("names")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Password)
					.HasColumnName("password")
					.HasMaxLength(120)
					.IsUnicode(false);

				entity.Property(e => e.Question)
					.HasColumnName("question")
					.HasColumnType("text");

				entity.Property(e => e.Status)
					.HasColumnName("status")
					.HasDefaultValueSql("('1')");

				entity.Property(e => e.Username)
					.IsRequired()
					.HasColumnName("username")
					.HasMaxLength(120)
					.IsUnicode(false);

				entity.HasOne(d => d.Group)
					.WithMany(p => p.UsergroupsUser)
					.HasForeignKey(d => d.GroupId)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK__usergroup__group__63E3BB6D");
			});

			modelBuilder.Entity<UserLogEvents>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Computer)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.EventType)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Macaddress)
					.HasColumnName("MACAddress")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Rtime).HasColumnType("datetime");

				entity.Property(e => e.UserName)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Users>(entity =>
			{
				entity.HasKey(e => e.UserCode);

				entity.Property(e => e.UserCode)
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Administrator).HasColumnName("administrator");

				entity.Property(e => e.Applicant).HasColumnName("applicant");

				entity.Property(e => e.Board).HasColumnName("board");

				entity.Property(e => e.Campus)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Class).HasColumnName("class");

				entity.Property(e => e.Clear).HasColumnName("clear");

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Dept).HasColumnName("dept");

				entity.Property(e => e.Edate).HasColumnType("datetime");

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.EmpNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Fsuppliers).HasColumnName("FSuppliers");

				entity.Property(e => e.Gcsadmin).HasColumnName("GCSAdmin");

				entity.Property(e => e.Gcsbarcode).HasColumnName("GCSBarcode");

				entity.Property(e => e.GcsentryTrack).HasColumnName("GCSEntryTrack");

				entity.Property(e => e.GcsmemCat).HasColumnName("GCSMemCat");

				entity.Property(e => e.Gcsmembers).HasColumnName("GCSMembers");

				entity.Property(e => e.Gcsreports).HasColumnName("GCSReports");

				entity.Property(e => e.GradeApproval)
					.HasMaxLength(1000)
					.IsUnicode(false);

				entity.Property(e => e.Headmin).HasColumnName("HEAdmin");

				entity.Property(e => e.Hediagnosis).HasColumnName("HEDiagnosis");

				entity.Property(e => e.Hedrugs).HasColumnName("HEDrugs");

				entity.Property(e => e.HeorderTests).HasColumnName("HEOrderTests");

				entity.Property(e => e.Hepatient).HasColumnName("HEPatient");

				entity.Property(e => e.Heprescription).HasColumnName("HEPrescription");

				entity.Property(e => e.Hereports).HasColumnName("HEReports");

				entity.Property(e => e.HetestResults).HasColumnName("HETestResults");

				entity.Property(e => e.Hevisit).HasColumnName("HEVisit");

				entity.Property(e => e.Hod).HasColumnName("HOD");

				entity.Property(e => e.Hostel).HasColumnName("hostel");

				entity.Property(e => e.HrpBank).HasColumnName("hrpBank");

				entity.Property(e => e.HrpDeductions).HasColumnName("hrpDeductions");

				entity.Property(e => e.HrpDept).HasColumnName("hrpDept");

				entity.Property(e => e.HrpEarnings).HasColumnName("hrpEarnings");

				entity.Property(e => e.HrpEmpCat).HasColumnName("hrpEmpCat");

				entity.Property(e => e.HrpEmployee).HasColumnName("hrpEmployee");

				entity.Property(e => e.HrpFi).HasColumnName("hrpFI");

				entity.Property(e => e.HrpHire).HasColumnName("hrpHire");

				entity.Property(e => e.HrpJobCat).HasColumnName("hrpJobCat");

				entity.Property(e => e.HrpLeave).HasColumnName("hrpLeave");

				entity.Property(e => e.HrpLoan).HasColumnName("hrpLoan");

				entity.Property(e => e.HrpLoc).HasColumnName("hrpLoc");

				entity.Property(e => e.HrpMedicalExp).HasColumnName("hrpMedicalExp");

				entity.Property(e => e.HrpPayAcc).HasColumnName("hrpPayAcc");

				entity.Property(e => e.HrpPayAdmin).HasColumnName("hrpPayAdmin");

				entity.Property(e => e.HrpPayGrade).HasColumnName("hrpPayGrade");

				entity.Property(e => e.HrpPayReports).HasColumnName("hrpPayReports");

				entity.Property(e => e.HrpPersAdmin).HasColumnName("hrpPersAdmin");

				entity.Property(e => e.HrpPersReports).HasColumnName("hrpPersReports");

				entity.Property(e => e.HrpRecruit).HasColumnName("hrpRecruit");

				entity.Property(e => e.HrpSalProcess).HasColumnName("hrpSalProcess");

				entity.Property(e => e.HrpSection).HasColumnName("hrpSection");

				entity.Property(e => e.HrpService).HasColumnName("hrpService");

				entity.Property(e => e.HrpSperiod).HasColumnName("hrpSPeriod");

				entity.Property(e => e.HrpTimeAtt).HasColumnName("hrpTimeAtt");

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Itemissue).HasColumnName("itemissue");

				entity.Property(e => e.Items).HasColumnName("items");

				entity.Property(e => e.LastPwdChangeDate).HasColumnType("datetime");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Ostatus).HasColumnName("OStatus");

				entity.Property(e => e.Password)
					.HasColumnName("password")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Pcash).HasColumnName("PCash");

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Prog).HasColumnName("prog");

				entity.Property(e => e.Psuppliers).HasColumnName("PSuppliers");

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Rfq).HasColumnName("RFQ");

				entity.Property(e => e.SendSms).HasColumnName("SendSMS");

				entity.Property(e => e.StudentSponsorBd).HasColumnName("StudentSponsorBD");

				entity.Property(e => e.Ttadmin).HasColumnName("TTAdmin");

				entity.Property(e => e.TtexamProcess).HasColumnName("TTExamProcess");

				entity.Property(e => e.TtexamReports).HasColumnName("TTExamReports");

				entity.Property(e => e.TtexamSchedule).HasColumnName("TTExamSchedule");

				entity.Property(e => e.Ttlecturer).HasColumnName("TTLecturer");

				entity.Property(e => e.Ttroom).HasColumnName("TTRoom");

				entity.Property(e => e.TtstudyProcess).HasColumnName("TTStudyProcess");

				entity.Property(e => e.TtstudyReports).HasColumnName("TTStudyReports");

				entity.Property(e => e.TtstudySchedule).HasColumnName("TTStudySchedule");

				entity.Property(e => e.Uiskin)
					.HasColumnName("UISkin")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Uistyle)
					.HasColumnName("UIStyle")
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Vpost).HasColumnName("VPost");
			});

			modelBuilder.Entity<VacHostel>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Maxacc).HasColumnName("maxacc");

				entity.Property(e => e.Names)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Wfapprovers>(entity =>
			{
				entity.ToTable("WFApprovers");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Title)
					.HasMaxLength(100)
					.IsUnicode(false);
			});

			modelBuilder.Entity<WfapproversDetails>(entity =>
			{
				entity.ToTable("WFApproversDetails");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.UserCode)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<WfdocCentre>(entity =>
			{
				entity.ToTable("WFDocCentre");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Department)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Description)
					.HasMaxLength(2000)
					.IsUnicode(false);

				entity.Property(e => e.DocNo)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.FinalStatus)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.LatestApprovalBy)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.LatestApprovalReason)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.LatestApprovalStatus)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Names)
					.HasMaxLength(300)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");

				entity.Property(e => e.Rtime)
					.HasColumnName("RTime")
					.HasColumnType("datetime");

				entity.Property(e => e.Type)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.UserRef)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<WfdocCentreDetails>(entity =>
			{
				entity.ToTable("WFDocCentreDetails");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Action)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ActionSelected)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Approver)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Reason)
					.HasMaxLength(500)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rtime).HasColumnType("datetime");

				entity.Property(e => e.Station)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.UserCode)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Wfrouting>(entity =>
			{
				entity.ToTable("WFRouting");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.ApprovalMsg)
					.HasMaxLength(3000)
					.IsUnicode(false);

				entity.Property(e => e.ApprovalSubject)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.DenialMsg)
					.HasMaxLength(3000)
					.IsUnicode(false);

				entity.Property(e => e.DenialSubject)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Document)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate)
					.HasColumnName("RDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<WfroutingDetails>(entity =>
			{
				entity.ToTable("WFRoutingDetails");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Action)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Approver)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Ref)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Xrate>(entity =>
			{
				entity.ToTable("XRate");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Cmethod)
					.HasColumnName("CMethod")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.CurFrom)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.CurTo)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rate).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Xdate)
					.HasColumnName("XDate")
					.HasColumnType("datetime");
			});

			modelBuilder.Entity<Pclaim>(entity =>
			{
				entity.HasKey(e => e.Pcref);

				entity.ToTable("PClaim");

				entity.Property(e => e.Pcref)
					.HasColumnName("PCRef")
					.HasMaxLength(50)
					.IsUnicode(false)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Names)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.PayeeRef)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Status)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Term)
					.HasMaxLength(100)
					.IsUnicode(false);
			});
			modelBuilder.Entity<PclaimDetail>(entity =>
			{
				entity.ToTable("PClaimDetail");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Code)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.IpearningRef)
					.HasColumnName("IPEarningRef")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.PayAccount)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Pcref)
					.HasColumnName("PCRef")
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rate).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Units)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<PclaimRates>(entity =>
			{
				entity.ToTable("PClaimRates");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.CertType)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Notes)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.PayAccount)
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Personnel)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Rate).HasColumnType("decimal(19, 4)");

				entity.Property(e => e.Rdate).HasColumnType("datetime");

				entity.Property(e => e.Units)
					.HasMaxLength(50)
					.IsUnicode(false);
			});


		}
	}
}
