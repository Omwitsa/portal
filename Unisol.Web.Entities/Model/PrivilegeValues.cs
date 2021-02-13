using System.Collections.Generic;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Entities.Model
{
    public static class PrivilegeValues
	{
		public static List<UserGroupPrivilege> AddPrivilegesList()
		{
			var privileges = new List<UserGroupPrivilege>();
			
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "User Management",
					Action = "users",
					Role = Role.Admin,
					Level = ActionLevel.MenuAction,
					Code = "01"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "User Login",
					Action = "login/user",
					Role = Role.All,
					Level = ActionLevel.OtherAction,
					Code = "0101"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Get Privileges",
					Action = "privileges/getGroupPrivileges",
					Role = Role.All,
					Level = ActionLevel.OtherAction,
					Code = "0102"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Change Password",
					Action = "users/ChangePassword",
					Role = Role.All,
					Level = ActionLevel.OtherAction,
					Code = "0103"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "View Users",
					Action = "users/pages",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0104"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "User Registration",
					Action = "users/register",
					Role = Role.All,
					Level = ActionLevel.OtherAction,
					Code = "0105"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "View User Groups",
					Action = "usergroups/pages",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0106"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "View Privileges",
					Action = "privileges/pages",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0107"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Add User Group",
					Action = "usergroups/add",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0108"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Get Roles",
					Action = "users/getRoles",
					Role = Role.All,
					Level = ActionLevel.OtherAction,
					Code = "0109"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Add Privileges",
					Action = "privileges/add",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0110"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Group Privileges",
					Action = "usergroups/get",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0111"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Get Settings",
					Action = "settings/get",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0112"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Upload Logo",
					Action = "settings/logo",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0113"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Add Branding",
					Action = "settings/add",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0114"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Update Settings",
					Action = "settings/updateSettings",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0115"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Save Portal Configs",
					Action = "portalconfig/savePortalSettingsConfigs",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0116"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Staff Data",
					Action = "profile/getStaffData",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "0117"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Student Profile",
					Action = "profile/getStudentData",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0118"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Student Enrollment",
					Action = "profile/getStudentEnrollment",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0119"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Employment profile",
					Action = "profile/getEmploymentProfile",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "0120"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Confirm Accounts",
					Action = "users/adminconfirmpassword",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0121"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Update Status",
					Action = "users/updateUsersStatus",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0122"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Delete Users",
					Action = "users/DeleteUser",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0123"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "News & Events",
					Action = "news",
					Role = Role.All,
					Level = ActionLevel.MenuAction,
					Code = "02"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "View News",
					Action = "news/GetNews",
					Role = Role.All,
					Level = ActionLevel.OtherAction,
					Code = "0201"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "View News Categories",
					Action = "news/getnewstypes",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0202"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Check News Categories",
					Action = "news/checknewstype",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0203"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Add News Categories",
					Action = "news/addnewstypes",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0204"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Add News",
					Action = "news/addNews",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0205"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "News Details",
					Action = "news/getNewTypeDetails",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0206"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "View Events",
					Action = "events/getevents",
					Role = Role.All,
					Level = ActionLevel.OtherAction,
					Code = "0207"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Add Event",
					Action = "events/addEvents",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0208"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "News Details",
					Action = "news/getnewsdetails",
					Role = Role.All,
					Level = ActionLevel.OtherAction,
					Code = "0209"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Events Details",
					Action = "events/geteventdetails",
					Role = Role.All,
					Level = ActionLevel.OtherAction,
					Code = "0210"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Reporting",
					Action = "reporting",
					Role = Role.Student,
					Level = ActionLevel.MenuAction,
					Code = "03"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Report Online",
					Action = "onlinereporting/report",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0301"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "View Reportings",
					Action = "onlinereporting/OnlineReporting",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0302"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Report Status",
					Action = "commonutilities/CheckReportStatus",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0303"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Settings Status",
					Action = "commonutilities/settingstatus",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0304"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Current Term",
					Action = "commonutilities/getStudentcurrentTerm",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0305"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Fees",
					Action = "fees",
					Role = Role.Student,
					Level = ActionLevel.MenuAction,
					Code = "04"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Fee Structure Years",
					Action = "commonutilities/GetStudentFeeStructureYears",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0401"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Fees Details",
					Action = "finance/getStudentFeeInfo",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0402"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Fees Statement",
					Action = "finance/GetStudentFeeStatement",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0403"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Fee Structure",
					Action = "finance/getStudentfeestructure",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0404"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Units",
					Action = "academics",
					Role = Role.Student,
					Level = ActionLevel.MenuAction,
					Code = "05"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Exam Card",
					Action = "examcard/GetStudentExamCard",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0501"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Save examination logs",
					Action = "PortalLogs/saveexaminationlogging",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0502"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Provisional Transcript",
					Action = "transcript/GetStudentProvivisonalTranscript",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0503"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Privious Academic Years",
					Action = "transcript/GetStudentPreviousAcademicYears",
					Role = Role.All,
					Level = ActionLevel.OtherAction,
					Code = "0504"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "View Registered Units",
					Action = "units/GetRegisteredUnits",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0505"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Student Curriculum",
					Action = "units/ReturnStudentCurriulum",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0506"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Academic Details",
					Action = "commonutilities/GetStudentAcademicInfo",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0507"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Current Session Units",
					Action = "units/ReturnStudentCurrentSemesterUnits",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0508"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Save Session Units",
					Action = "units/SaveStudentCurrentSemesterUnits",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0509"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Unit History",
					Action = "units/GetStudentUnitRegisteredHistory",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0510"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Student Fuculty Information",
					Action = "academic/getStudentFucultyInfo",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0511"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Student Institution Information",
					Action = "commonutilities/GetInstitutionInfo",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0512"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Exam Gradings",
					Action = "transcript/GetStudentGradingSettings",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0513"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Examinations",
					Action = "examinations",
					Role = Role.Student,
					Level = ActionLevel.MenuAction,
					Code = "06"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Exam Card Status",
					Action = "portalconfig/getexamcardstatus",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0601"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Hostel Booking",
					Action = "hostel",
					Role = Role.Student,
					Level = ActionLevel.MenuAction,
					Code = "07"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Hostel Booking Details",
					Action = "hostelbooking/myhostelbookings",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0701"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Available Hostel",
					Action = "hostelbooking/RetrieveOpenHostels",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0702"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Booking Eligibility",
					Action = "hostelbooking/checkeligibility",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0703"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Booking Status",
					Action = "hostelbooking/checkhostelbookingstatus",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0704"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Bookable Rooms",
					Action = "hostelbooking/retrievebookablerooms",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0705"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Book Room",
					Action = "hostelbooking/savebooking",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "0706"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Payments",
					Action = "payslip",
					Role = Role.Staff,
					Level = ActionLevel.MenuAction,
					Code = "08"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Get Pay Slip",
					Action = "payslip/GetEmployeePayslip",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "0801"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Pay Slip Period",
					Action = "payslip/GetPayslipPeriod",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "0802"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Pay Slip Years",
					Action = "payslip/GetPayslipYears",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "0803"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Loan Statement",
					Action = "loans/GetEmployeeLoanStatement",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "0804"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Loans",
					Action = "loans/GetEmployeeLoans",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "0805"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "PNine",
					Action = "pnine/GetEmpPnine",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "0806"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Messages",
					Action = "messaging",
					Role = Role.All,
					Level = ActionLevel.MenuAction,
					Code = "09"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Get Messages",
					Action = "messages/getMessages",
					Role = Role.All,
					Level = ActionLevel.OtherAction,
					Code = "0901"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Message Receipients",
					Action = "messages/getRecipients",
					Role = Role.All,
					Level = ActionLevel.OtherAction,
					Code = "0902"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Compose Message",
					Action = "messages/compose",
					Role = Role.All,
					Level = ActionLevel.OtherAction,
					Code = "0903"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Delete Message",
					Action = "messages/permanentDelete",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "0904"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Leave Management",
					Action = "leave",
					Role = Role.Staff,
					Level = ActionLevel.MenuAction,
					Code = "10"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Apply leave",
					Action = "leave/applyleave",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "1001"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "View Leave",
					Action = "leave/getByEmployee",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "1002"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Leave Days",
					Action = "leave/getEmpLeaveDays",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "1003"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Valid Leave Days",
					Action = "leave/getValidLeaveDates",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "1004"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "SOR, IR, Claims & Imprest",
					Action = "sor-claims-imprest",
					Role = Role.Staff,
					Level = ActionLevel.MenuAction,
					Code = "11"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Internal Requisition",
					Action = "ir/getIR",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "1101"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Create Internal Requisition",
					Action = "ir/createIR",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "1102"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Add Sor",
					Action = "sor/get",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "1103"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "SOR items",
					Action = "Sor/getsoritems",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "1104"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "View Sor",
					Action = "Sor/getraised",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "1105"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "View Claims",
					Action = "Claims/GetEmployeeClaimSummary",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "1106"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Claims Rate",
					Action = "Claims/GetClaimRates",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "1107"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Claims Terms",
					Action = "Claims/GetEmployeeTermsForClaim",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "1108"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "View Imprest",
					Action = "imprest/getImprest",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "1109"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Save Imprest",
					Action = "imprest/saveImprest",
					Role = Role.Staff,
					Level = ActionLevel.OtherAction,
					Code = "1110"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Repository",
					Action = "repository",
					Role = Role.All,
					Level = ActionLevel.MenuAction,
					Code = "12"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Create folder",
					Action = "repository/createFolder",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "1201"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Get Parent Folder",
					Action = "repository/getParentFolders",
					Role = Role.All,
					Level = ActionLevel.OtherAction,
					Code = "1202"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Get Sub-Folders",
					Action = "repository/getParentSubFolders",
					Role = Role.All,
					Level = ActionLevel.OtherAction,
					Code = "1203"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "View Files",
					Action = "repository/filesInFolder",
					Role = Role.All,
					Level = ActionLevel.OtherAction,
					Code = "1204"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Upload Files",
					Action = "repository/saveUploadedFiles",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "1205"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Edit Folder",
					Action = "repository/EditFolder",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "1206"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Delete Folder",
					Action = "repository/DeleteFolder",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "1207"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Evaluations",
					Action = "evaluations",
					Role = Role.Admin,
					Level = ActionLevel.MenuAction,
					Code = "13"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Evaluations",
					Action = "evaluations",
					Role = Role.Staff,
					Level = ActionLevel.MenuAction,
					Code = "13"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "View Evaluations",
					Action = "evaluations/getevaluations",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "1301"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Add Evaluations",
					Action = "evaluations/addevaluation",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "1302"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Evaluations Information",
					Action = "evaluations/getevaluationinfo",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "1303"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "View Current Evaluations",
					Action = "currentevaluations/GetCurrentEvaluations",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "1304"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Academic Years",
					Action = "currentevaluations/GetAcademicYears",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "1305"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Target Evaluation Session",
					Action = "currentevaluations/GetStudentAcademicSemstersOfStudy",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "1306"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Target Evaluation Year",
					Action = "currentevaluations/GetStudentYearsOfStudy",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "1307"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Add Current Evaluation",
					Action = "currentevaluations/SaveCurrentEvaluation",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "1308"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Save Active Evaluations",
					Action = "currentevaluations/SaveActiveEvaluation",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "1309"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Delete Evaluation",
					Action = "currentevaluations/DeleteCurrentEvaluation",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "1310"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Evaluation Responses",
					Action = "AdminEvaluationsResponse/GetCurrentActiveEvaluations",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "1311"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Current Evaluation",
					Action = "evaluations/current-evaluations",
					Role = Role.Admin,
					Level = ActionLevel.OtherAction,
					Code = "1312"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Evaluation",
					Action = "portal-evaluations",
					Role = Role.Student,
					Level = ActionLevel.MenuAction,
					Code = "14"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Active Evaluations",
					Action = "portalevaluations/getPortalActiveEvaluations",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "1401"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Evaluation History",
					Action = "portalevaluations/GetEvaluationHistory",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "1402"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Registered Units",
					Action = "portalevaluations/GetRegisteredUnits",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "1403"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Evaluation Questions",
					Action = "portalevaluations/getEvaluationQuestions",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "1404"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Subject Evaluation Response",
					Action = "portalevaluations/SaveStudentSubjectResponse",
					Role = Role.Student,
					Level = ActionLevel.OtherAction,
					Code = "1405"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Clearance",
					Action = "clearances",
					Role = Role.Student,
					Level = ActionLevel.MenuAction,
					Code = "15"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Clearance",
					Action = "clearances",
					Role = Role.Staff,
					Level = ActionLevel.MenuAction,
					Code = "15"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Fleet Management",
					Action = "fleet",
					Role = Role.Staff,
					Level = ActionLevel.MenuAction,
					Code = "16"
				}
			);
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Online Memo",
					Action = "onlineMemo",
					Role = Role.Staff,
					Level = ActionLevel.MenuAction,
					Code = "17"
				}
			);
            privileges.Add(
                new UserGroupPrivilege()
                {
                    PrivilegeName = "Imprest Surrender",
                    Action = "user-imprest-surrender",
                    Role = Role.Staff,
                    Level = ActionLevel.MenuAction,
                    Code = "18"
                });
            privileges.Add(
                new UserGroupPrivilege()
                {
                    PrivilegeName = "Finance Surrenders",
                    Action = "surrenders",
                    Role = Role.Staff,
                    Level = ActionLevel.MenuAction,
                    Code = "19"
                });
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Work Request",
					Action = "work-request",
					Role = Role.Staff,
					Level = ActionLevel.MenuAction,
					Code = "20"
				});
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Timetable",
					Action = "timetable",
					Role = Role.Student,
					Level = ActionLevel.MenuAction,
					Code = "21"
				});
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Timetable",
					Action = "timetable",
					Role = Role.Staff,
					Level = ActionLevel.MenuAction,
					Code = "21"
				});

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "System Logs",
					Action = "systemlogs",
					Role = Role.Admin,
					Level = ActionLevel.MenuAction,
					Code = "22"
				});

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Clearance Quetionnaire",
					Action = "clearanceQuetionnaire",
					Role = Role.Admin,
					Level = ActionLevel.MenuAction,
					Code = "23"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Leave Documents",
					Action = "leaveDocuments",
					Role = Role.Admin,
					Level = ActionLevel.MenuAction,
					Code = "24"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Attendance",
					Action = "attendance",
					Role = Role.Staff,
					Level = ActionLevel.MenuAction,
					Code = "25"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Complains/Complements",
					Action = "complaint",
					Role = Role.All,
					Level = ActionLevel.MenuAction,
					Code = "26"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Attendance",
					Action = "attendance",
					Role = Role.Admin,
					Level = ActionLevel.MenuAction,
					Code = "25"
				}
			);
			
			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Research/projects/publications",
					Action = "research",
					Role = Role.Staff,
					Level = ActionLevel.MenuAction,
					Code = "27"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Research/projects/publications",
					Action = "research",
					Role = Role.Admin,
					Level = ActionLevel.MenuAction,
					Code = "27"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Performance Management",
					Action = "performance",
					Role = Role.Admin,
					Level = ActionLevel.MenuAction,
					Code = "28"
				}
			);

			privileges.Add(
				new UserGroupPrivilege()
				{
					PrivilegeName = "Performance Management",
					Action = "performance",
					Role = Role.Staff,
					Level = ActionLevel.MenuAction,
					Code = "28"
				}
			);

			return privileges;
		}
	}
}
