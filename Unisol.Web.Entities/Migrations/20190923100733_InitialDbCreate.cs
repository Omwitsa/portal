using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unisol.Web.Entities.Migrations
{
    public partial class InitialDbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Constituency = table.Column<string>(nullable: true),
                    ContactNote = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    HomeFax = table.Column<string>(nullable: true),
                    HomeTel = table.Column<string>(nullable: true),
                    House = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    PAddress = table.Column<string>(nullable: true),
                    Pager = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    StaffId = table.Column<int>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Street1 = table.Column<string>(nullable: true),
                    StudentId = table.Column<int>(nullable: false),
                    SubCounty = table.Column<string>(nullable: true),
                    WEmail = table.Column<string>(nullable: true),
                    WFax = table.Column<string>(nullable: true),
                    WTel = table.Column<string>(nullable: true),
                    Web = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentRepository",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FolderName = table.Column<string>(nullable: true),
                    FolderPath = table.Column<string>(nullable: true),
                    IsParent = table.Column<bool>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    UserGroups = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentRepository", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ControllerUrl = table.Column<string>(nullable: true),
                    Error = table.Column<string>(nullable: true),
                    UserCode = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    PossibleReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    EvaluationName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    EvaluationDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExaminationLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdminNo = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    Semester = table.Column<string>(nullable: true),
                    ActionDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<string>(nullable: true),
                    DateEnabled = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortalConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    AspNetUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortalEventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    EventTypeName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalEventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortalMessage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateReceived = table.Column<DateTime>(nullable: false),
                    DateSent = table.Column<DateTime>(nullable: false),
                    GroupMessage = table.Column<bool>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    MessageStatus = table.Column<int>(nullable: false),
                    ReceiverId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<bool>(nullable: false),
                    SenderId = table.Column<Guid>(nullable: false),
                    GroupName = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortalNewsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NewsTypeName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalNewsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileUpdate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TelNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    HomeAddress = table.Column<string>(nullable: true),
                    UserCode = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    AllowedAdminApproval = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileUpdate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    LogoImageUrl = table.Column<string>(nullable: true),
                    Initials = table.Column<string>(nullable: true),
                    ThemeColor = table.Column<string>(nullable: true),
                    SecondaryColor = table.Column<string>(nullable: true),
                    Modules = table.Column<string>(nullable: true),
                    LoginMessageTitle = table.Column<string>(nullable: true),
                    loginMessage = table.Column<string>(nullable: true),
                    loginImageUrl = table.Column<string>(nullable: true),
                    EmailUserName = table.Column<string>(nullable: true),
                    SmtpClient = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Port = table.Column<string>(nullable: true),
                    ClassStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerminationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroupPrivileges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrivilegeName = table.Column<string>(maxLength: 50, nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: true),
                    Level = table.Column<int>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupPrivileges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    AllowedPrivileges = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserResetPasswords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    ResetCode = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResetPasswords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeptId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentRepositoryFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FolderId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    FileDescription = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    UserGroups = table.Column<string>(nullable: true),
                    FileStatus = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    FileSize = table.Column<int>(nullable: true),
                    FileType = table.Column<string>(nullable: true),
                    FileExt = table.Column<string>(nullable: true),
                    RepositoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentRepositoryFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentRepositoryFiles_DocumentRepository_RepositoryId",
                        column: x => x.RepositoryId,
                        principalTable: "DocumentRepository",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationsCurrents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EvaluationId = table.Column<int>(nullable: false),
                    YearId = table.Column<int>(nullable: true),
                    SemesterId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CurrentEvaluationName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    EvaluationTarget = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationsCurrents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationsCurrents_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EvaluationId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SectionName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    SectionDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationSections_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationTakenUnitWiseByUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UnitCode = table.Column<string>(nullable: true),
                    TargetNames = table.Column<string>(nullable: true),
                    AspNetUserId = table.Column<Guid>(nullable: false),
                    EvaluationCurrentActiveId = table.Column<int>(nullable: false),
                    EvaluationCurrentId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    EvaluationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationTakenUnitWiseByUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationTakenUnitWiseByUsers_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModuleAction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    DateActivated = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<string>(nullable: true),
                    ModuleId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleAction_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortalEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    EventDesc = table.Column<string>(nullable: true),
                    EventEndDate = table.Column<DateTime>(nullable: false),
                    EventStartDate = table.Column<DateTime>(nullable: false),
                    EventTitle = table.Column<string>(nullable: true),
                    PortalEventTypeId = table.Column<int>(nullable: true),
                    SendEmailFlag = table.Column<bool>(nullable: false),
                    TargetAudience = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortalEvents_PortalEventTypes_PortalEventTypeId",
                        column: x => x.PortalEventTypeId,
                        principalTable: "PortalEventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PortalNews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    NewsBody = table.Column<string>(nullable: true),
                    NewsStatus = table.Column<bool>(nullable: false),
                    NewsTitle = table.Column<string>(nullable: true),
                    PortalNewsTypeId = table.Column<int>(nullable: false),
                    SendEmailFlag = table.Column<bool>(nullable: false),
                    TargetAudience = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortalNews_PortalNewsTypes_PortalNewsTypeId",
                        column: x => x.PortalNewsTypeId,
                        principalTable: "PortalNewsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    AccountType = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FingerTemplate1 = table.Column<byte[]>(nullable: true),
                    FingerTemplate2 = table.Column<byte[]>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    UserGroupsId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserGroups_UserGroupsId",
                        column: x => x.UserGroupsId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Divisions_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationsCurrentActive",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EvaluationTarget = table.Column<int>(nullable: true),
                    EvaluationsCurrentId = table.Column<int>(nullable: false),
                    EvaluationsId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationsCurrentActive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationsCurrentActive_EvaluationsCurrents_EvaluationsCurrentId",
                        column: x => x.EvaluationsCurrentId,
                        principalTable: "EvaluationsCurrents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowMultiple = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    EvaluationSectionId = table.Column<int>(nullable: false),
                    QuestionDesc = table.Column<string>(nullable: true),
                    QuestionResponse = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationQuestions_EvaluationSections_EvaluationSectionId",
                        column: x => x.EvaluationSectionId,
                        principalTable: "EvaluationSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortalNewsViews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    AspNetUsersId = table.Column<int>(nullable: true),
                    PortalNewsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalNewsViews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortalNewsViews_PortalNews_PortalNewsId",
                        column: x => x.PortalNewsId,
                        principalTable: "PortalNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortalAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<Guid>(nullable: false),
                    Closed = table.Column<bool>(nullable: false),
                    ClosureReason = table.Column<string>(nullable: true),
                    DateClosed = table.Column<DateTime>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalAdmins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortalAdmins_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HrEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcademicRank = table.Column<string>(nullable: true),
                    Adate = table.Column<DateTime>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Disability = table.Column<string>(nullable: true),
                    DivisionId = table.Column<int>(nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    Educ = table.Column<string>(nullable: true),
                    EmgName = table.Column<string>(nullable: true),
                    EmgNotes = table.Column<string>(nullable: true),
                    EmgRel = table.Column<string>(nullable: true),
                    EmgTel = table.Column<string>(nullable: true),
                    EmpCatId = table.Column<int>(nullable: false),
                    EmplNo = table.Column<string>(nullable: true),
                    Exp = table.Column<string>(nullable: true),
                    Hiredate = table.Column<DateTime>(nullable: false),
                    InsExp = table.Column<DateTime>(nullable: false),
                    IsSmoker = table.Column<bool>(nullable: false),
                    JobCatId = table.Column<int>(nullable: false),
                    KraPin = table.Column<string>(nullable: true),
                    Lang = table.Column<string>(nullable: true),
                    LeaveGroupId = table.Column<int>(nullable: false),
                    LicClass = table.Column<string>(nullable: true),
                    LicExp = table.Column<DateTime>(nullable: false),
                    LicNo = table.Column<string>(nullable: true),
                    Marital = table.Column<int>(nullable: false),
                    Medical = table.Column<string>(nullable: true),
                    Nhif = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Nssf = table.Column<string>(nullable: true),
                    PassportId = table.Column<string>(nullable: true),
                    PersonnelId = table.Column<int>(nullable: true),
                    Ppn = table.Column<string>(nullable: true),
                    Ppnexp = table.Column<DateTime>(nullable: false),
                    Race = table.Column<string>(nullable: true),
                    Rdate = table.Column<DateTime>(nullable: false),
                    Religion = table.Column<string>(nullable: true),
                    Skills = table.Column<string>(nullable: true),
                    SpouseName = table.Column<string>(nullable: true),
                    SupervisorId = table.Column<int>(nullable: true),
                    Terminated = table.Column<bool>(nullable: false),
                    TerminationId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Visa = table.Column<string>(nullable: true),
                    VisaExp = table.Column<DateTime>(nullable: false),
                    ApplicationUserId1 = table.Column<Guid>(nullable: true),
                    PersonnelId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HrEmployees_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrEmployees_Users_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrEmployees_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrEmployees_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrEmployees_EmployeeCategories_EmpCatId",
                        column: x => x.EmpCatId,
                        principalTable: "EmployeeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrEmployees_JobCategories_JobCatId",
                        column: x => x.JobCatId,
                        principalTable: "JobCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrEmployees_LeaveGroups_LeaveGroupId",
                        column: x => x.LeaveGroupId,
                        principalTable: "LeaveGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrEmployees_Users_PersonnelId1",
                        column: x => x.PersonnelId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrEmployees_HrEmployees_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "HrEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationTargetGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EvaluationsCurrentId = table.Column<int>(nullable: false),
                    EvaluationsCurrentActiveId = table.Column<int>(nullable: false),
                    TargetGroupId = table.Column<int>(nullable: true),
                    ReferenceId = table.Column<string>(nullable: true),
                    TargetType = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Names = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationTargetGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationTargetGroups_EvaluationsCurrentActive_EvaluationsCurrentActiveId",
                        column: x => x.EvaluationsCurrentActiveId,
                        principalTable: "EvaluationsCurrentActive",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationQuestionOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    EvaluationQuestionId = table.Column<int>(nullable: false),
                    QuestionOption = table.Column<string>(nullable: true),
                    OptionResponse = table.Column<bool>(nullable: true),
                    QuestionOptionStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationQuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationQuestionOptions_EvaluationQuestions_EvaluationQuestionId",
                        column: x => x.EvaluationQuestionId,
                        principalTable: "EvaluationQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationQuestionResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EvaluationQuestionId = table.Column<int>(nullable: false),
                    EvaluationId = table.Column<int>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    EvaluationsCurrentActiveId = table.Column<int>(nullable: false),
                    UnitCode = table.Column<string>(nullable: true),
                    QuestionResponse = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    EvaluationTakenUnitWiseByUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationQuestionResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationQuestionResponses_EvaluationQuestions_EvaluationQuestionId",
                        column: x => x.EvaluationQuestionId,
                        principalTable: "EvaluationQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffTerminations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    StaffId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffTerminations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffTerminations_HrEmployees_StaffId",
                        column: x => x.StaffId,
                        principalTable: "HrEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffTerminations_TerminationTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TerminationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationQuestionResponseOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EvaluationQuestionResponseId = table.Column<int>(nullable: false),
                    EvaluationQuestionOptionId = table.Column<int>(nullable: false),
                    OptionName = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationQuestionResponseOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationQuestionResponseOptions_EvaluationQuestionResponses_EvaluationQuestionResponseId",
                        column: x => x.EvaluationQuestionResponseId,
                        principalTable: "EvaluationQuestionResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_SectionId",
                table: "Divisions",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentRepositoryFiles_RepositoryId",
                table: "DocumentRepositoryFiles",
                column: "RepositoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationQuestionOptions_EvaluationQuestionId",
                table: "EvaluationQuestionOptions",
                column: "EvaluationQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationQuestionResponseOptions_EvaluationQuestionResponseId",
                table: "EvaluationQuestionResponseOptions",
                column: "EvaluationQuestionResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationQuestionResponses_EvaluationQuestionId",
                table: "EvaluationQuestionResponses",
                column: "EvaluationQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationQuestions_EvaluationSectionId",
                table: "EvaluationQuestions",
                column: "EvaluationSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationsCurrentActive_EvaluationsCurrentId",
                table: "EvaluationsCurrentActive",
                column: "EvaluationsCurrentId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationsCurrents_EvaluationId",
                table: "EvaluationsCurrents",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationSections_EvaluationId",
                table: "EvaluationSections",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationTakenUnitWiseByUsers_EvaluationId",
                table: "EvaluationTakenUnitWiseByUsers",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationTargetGroups_EvaluationsCurrentActiveId",
                table: "EvaluationTargetGroups",
                column: "EvaluationsCurrentActiveId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployees_AddressId",
                table: "HrEmployees",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployees_ApplicationUserId1",
                table: "HrEmployees",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployees_CountryId",
                table: "HrEmployees",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployees_DivisionId",
                table: "HrEmployees",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployees_EmpCatId",
                table: "HrEmployees",
                column: "EmpCatId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployees_JobCatId",
                table: "HrEmployees",
                column: "JobCatId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployees_LeaveGroupId",
                table: "HrEmployees",
                column: "LeaveGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployees_PersonnelId1",
                table: "HrEmployees",
                column: "PersonnelId1");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmployees_SupervisorId",
                table: "HrEmployees",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleAction_ModuleId",
                table: "ModuleAction",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalAdmins_ApplicationUserId",
                table: "PortalAdmins",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortalEvents_PortalEventTypeId",
                table: "PortalEvents",
                column: "PortalEventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalNews_PortalNewsTypeId",
                table: "PortalNews",
                column: "PortalNewsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalNewsViews_PortalNewsId",
                table: "PortalNewsViews",
                column: "PortalNewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_DeptId",
                table: "Sections",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffTerminations_StaffId",
                table: "StaffTerminations",
                column: "StaffId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffTerminations_TypeId",
                table: "StaffTerminations",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupPrivileges_Id",
                table: "UserGroupPrivileges",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserGroupsId",
                table: "Users",
                column: "UserGroupsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentRepositoryFiles");

            migrationBuilder.DropTable(
                name: "ErrorLogs");

            migrationBuilder.DropTable(
                name: "EvaluationQuestionOptions");

            migrationBuilder.DropTable(
                name: "EvaluationQuestionResponseOptions");

            migrationBuilder.DropTable(
                name: "EvaluationTakenUnitWiseByUsers");

            migrationBuilder.DropTable(
                name: "EvaluationTargetGroups");

            migrationBuilder.DropTable(
                name: "ExaminationLogs");

            migrationBuilder.DropTable(
                name: "ModuleAction");

            migrationBuilder.DropTable(
                name: "PortalAdmins");

            migrationBuilder.DropTable(
                name: "PortalConfigs");

            migrationBuilder.DropTable(
                name: "PortalEvents");

            migrationBuilder.DropTable(
                name: "PortalMessage");

            migrationBuilder.DropTable(
                name: "PortalNewsViews");

            migrationBuilder.DropTable(
                name: "ProfileUpdate");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "StaffTerminations");

            migrationBuilder.DropTable(
                name: "UserGroupPrivileges");

            migrationBuilder.DropTable(
                name: "UserResetPasswords");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "DocumentRepository");

            migrationBuilder.DropTable(
                name: "EvaluationQuestionResponses");

            migrationBuilder.DropTable(
                name: "EvaluationsCurrentActive");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "PortalEventTypes");

            migrationBuilder.DropTable(
                name: "PortalNews");

            migrationBuilder.DropTable(
                name: "HrEmployees");

            migrationBuilder.DropTable(
                name: "TerminationTypes");

            migrationBuilder.DropTable(
                name: "EvaluationQuestions");

            migrationBuilder.DropTable(
                name: "EvaluationsCurrents");

            migrationBuilder.DropTable(
                name: "PortalNewsTypes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "EmployeeCategories");

            migrationBuilder.DropTable(
                name: "JobCategories");

            migrationBuilder.DropTable(
                name: "LeaveGroups");

            migrationBuilder.DropTable(
                name: "EvaluationSections");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
