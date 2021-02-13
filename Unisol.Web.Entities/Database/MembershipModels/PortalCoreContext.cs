using Microsoft.EntityFrameworkCore;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public partial class PortalCoreContext : DbContext
    {
        public PortalCoreContext()
        {
        }

        public PortalCoreContext(DbContextOptions<PortalCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }
        public virtual DbSet<ErrorLogs> ErrorLogs { get; set; }
        public virtual DbSet<LeaveGroups> LeaveGroups { get; set; }
        public virtual DbSet<ModuleAction> ModuleAction { get; set; }
        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<PortalAdmins> PortalAdmins { get; set; }
        public virtual DbSet<EvaluationQuestionOption> EvaluationQuestionOptions { get; set; }
        public virtual DbSet<EvaluationQuestion> EvaluationQuestions { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<EvaluationsCurrent> EvaluationsCurrents { get; set; }
        public virtual DbSet<EvaluationsCurrentActive> EvaluationsCurrentActive { get; set; }
        public virtual DbSet<EvaluationTargetGroup> EvaluationTargetGroups { get; set; }
        public virtual DbSet<EvaluationQuestionResponse> EvaluationQuestionResponses { get; set; }
        public virtual DbSet<EvaluationQuestionResponseOption> EvaluationQuestionResponseOptions { get; set; }
        public virtual DbSet<EvaluationTakenUnitWiseByUser> EvaluationTakenUnitWiseByUsers { get; set; }
        public virtual DbSet<EvaluationSection> EvaluationSections { get; set; }
        public virtual DbSet<ExaminationLog> ExaminationLogs { get; set; }
        public virtual DbSet<PortalEvents> PortalEvents { get; set; }
        public virtual DbSet<PortalEventTypes> PortalEventTypes { get; set; }
        public virtual DbSet<PortalMessage> PortalMessage { get; set; }
        public virtual DbSet<PortalNews> PortalNews { get; set; }
        public virtual DbSet<PortalNewsType> PortalNewsTypes { get; set; }
        public virtual DbSet<PortalConfig> PortalConfigs { get; set; }
        public virtual DbSet<UserGroupPrivilege> UserGroupPrivileges { get; set; }
        public virtual DbSet<UserGroups> UserGroups { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<DocumentRepository> DocumentRepository { get; set; }
        public virtual DbSet<DocumentRepositoryFile> DocumentRepositoryFiles { get; set; }
        public virtual DbSet<ProfileUpdates> ProfileUpdate { get; set; }
		public virtual DbSet<UserResetPassword> UserResetPasswords { get; set; }
        public virtual DbSet<ImprestSurrenderReq> ImprestSurrenderReqs { get; set; }
		public virtual DbSet<InaccessibiltyLog> InaccessibiltyLog { get; set; }
		public virtual DbSet<ClientIp> ClientIp { get; set; }
		public virtual DbSet<ClearanceQuestionnaireTemplate> ClearanceQuestionnaireTemplate { get; set; }
		public virtual DbSet<ClearanceSurveyResponse> ClearanceSurveyResponse { get; set; }
		public virtual DbSet<ClearanceSurvey> ClearanceSurvey { get; set; }
		public virtual DbSet<LeaveDocument> LeaveDocument { get; set; }
		public virtual DbSet<ClearanceReason> ClearanceReason { get; set; }
		public virtual DbSet<TimeAttendance> TimeAttendance { get; set; }
		public virtual DbSet<Obstructor> Obstructor { get; set; }
		public virtual DbSet<Complaint> Complaint { get; set; }
		public virtual DbSet<Publication> Publication { get; set; }
		public virtual DbSet<Project> Project { get; set; }
		public virtual DbSet<ProjectCoReseacher> ProjectCoReseacher { get; set; }
		public virtual DbSet<ProjectDisbursement> ProjectDisbursement { get; set; }
		public virtual DbSet<ProjectReport> ProjectReport { get; set; }
		public virtual DbSet<MissedPunch> MissedPunch { get; set; }
		public virtual DbSet<OutOfOffice> OutOfOffice { get; set; }
		public virtual DbSet<ClearanceQuestionSection> ClearanceQuestionSection { get; set; }
		public virtual DbSet<ClearanceQuestion> ClearanceQuestion { get; set; }
        public virtual DbSet<StaffPerformance> StaffPerformance { get; set; } 
        public virtual DbSet<PerformanceSession> PerformanceSession { get; set; }
        public virtual DbSet<PerformanceGrade> PerformanceGrade { get; set; }
        public virtual DbSet<PerformanceSection> PerformanceSection { get; set; } 
        public virtual DbSet<PerformanceQuestionnaire> PerformanceQuestionnaire { get; set; } 
        public virtual DbSet<PerformanceTraining> PerformanceTraining { get; set; }
        public virtual DbSet<StaffPerformanceResponse> StaffPerformanceResponse { get; set; }
        public virtual DbSet<PerformanceActivityResponse> PerformanceActivityResponse { get; set; }
        public virtual DbSet<PerformanceQuestionnaireResponse> PerformanceQuestionnaireResponse { get; set; }
        public virtual DbSet<PerformanceGradeLevelSection> PerformanceGradeLevelSection { get; set; }
        public virtual DbSet<PerformanceTarget> PerformanceTarget { get; set; }
        public virtual DbSet<PerformanceTargetDetail> PerformanceTargetDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.

                optionsBuilder.UseSqlServer("Server=DESKTOP-VK53DAK\\SQLEXPRESS01;Database=aspnet-PortalCore;Trusted_Connection=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.Property(e => e.Paddress).HasColumnName("PAddress");

                entity.Property(e => e.Wemail).HasColumnName("WEmail");

                entity.Property(e => e.Wfax).HasColumnName("WFax");

                entity.Property(e => e.Wtel).HasColumnName("WTel");
            });


            modelBuilder.Entity<UserGroupPrivilege>(entity =>
            {
                entity.HasIndex(e => e.Id);
                entity.Property(e => e.PrivilegeName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ModuleAction>(entity =>
            {
                entity.HasIndex(e => e.ModuleId);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.ModuleAction)
                    .HasForeignKey(d => d.ModuleId);
            });

            modelBuilder.Entity<PortalAdmins>(entity =>
            {
                entity.HasIndex(e => e.ApplicationUserId)
                    .IsUnique();

                entity.HasOne(d => d.ApplicationUser)
                    .WithOne(p => p.PortalAdmins)
                    .HasForeignKey<PortalAdmins>(d => d.ApplicationUserId);
            });


            modelBuilder.Entity<PortalEventTypes>(entity =>
            {
                entity.Property(e => e.EventTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Sections>(entity =>
            {
                entity.HasIndex(e => e.DeptId);

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.DeptId);
            });
        }
    }
}