import CounterExample from 'components/counter-example'
import WeatherForecast from 'views/WeatherForecast'
import Home from 'views/dashboards/Home'

import LoginLayout from 'views/login/LoginLayout'
import Login from 'views/login/Login'
import Register from 'views/login/Register'
import Confirm from 'views/login/Confirm'
import Reset from 'views/login/Reset'
import emailConfirmationMessage from 'views/login/emailConfirmationMessage'
import emailResetConfirmation from 'views/login/emailResetConfirmation'
import changePassword from 'views/login/ChangePassword'
import ResetPassword from 'views/login/ResetPassword'

import Users from 'views/users/Users'
import UsersList from 'views/users/List'
import UsersEdit from 'views/users/Edit'
import UserGroups from 'views/users/usergroups/List'
import UserGroupsEdit from 'views/users/usergroups/Edit'

import Settings from 'views/settings/Settings'
import Branding from 'views/settings/Branding'
import OtherSettings from 'views/settings/OtherSettings'
import Email from 'views/settings/Email'
import Privileges from 'views/settings/privileges/List'
import PrivilegesEdit from 'views/settings/privileges/Edit'
import SysSetting from 'views/settings/SysSetting'

import News from 'views/news/News'
import NewsList from 'views/news/List'
import NewsEdit from 'views/news/Edit'
import NewsDetails from 'views/news/Details'
import NewsTypes from 'views/news/newstypes/List'
import NewsTypesEdit from 'views/news/newstypes/Edit'

import StudentNews from 'views/studentnews/News'
import StudentNewsList from 'views/studentnews/List'
import StudentEventsList from 'views/studentnews/Events'
import PortalEventDetails from 'views/studentnews/EventDetails'

import Hostel from 'views/hostels/Hostel'
import BookingHistory from 'views/hostels/BookingHistory'
import AddBooking from 'views/hostels/Booking'

import PortalEvaluation from 'views/portalevaluations/PortalEvaluations.vue'
import PortalHistory from 'views/portalevaluations/EvaluationsHistory'
import TakeEvaluation from 'views/portalevaluations/TakeEvaluation'

import EventsList from 'views/news/events/List'
import AddEvent from 'views/news/events/Add'
import EventDetails from 'views/news/events/Details'
import EventCategoryList from 'views/news/events/eventstypes/List'
import EventsTypesEdit from 'views/news/events/eventstypes/Edit'

import Sor from 'views/sor/List'
import SorEdit from 'views/sor/Edit'

import IRList from 'views/IR/List'
import CreateIR from 'views/IR/Add'

import OnlineReporting from 'views/reporting/Report'
import AddReporting from 'views/reporting/AddReporting'

import Evaluations from 'views/evaluations/Evaluations'
import EvaluationsList from 'views/evaluations/List'

import EvaluationsResponsesUnits from 'views/evaluations/responses/EvaluationsResponsesUnits'

import CurrentEvaluationsList from 'views/evaluations/current/List'

import EvaluationsAdd from 'views/evaluations/Add'
import EvaluationsEdit from 'views/evaluations/Edit'

import EvaluationsAddCurrent from 'views/evaluations/current/Add'
import RespondedUnits from 'views/evaluations/responses/RespondedUnits'
import EvaluationsResponses from 'views/evaluations/responses/List'
import Booking from 'views/hostels/Booking'

import RegisterUnits from 'views/academics/unitregistration/RegisterUnits'
import ViewCurriculum from 'views/academics/unitregistration/ViewCurriculum'
import RegistrationHistory from 'views/academics/unitregistration/RegistrationHistory'

import Academics from 'views/academics/Academics'

import ViewFinalTranscripts from 'views/examinations/exams/ViewFinalTranscripts'
import ExamCard from 'views/examinations/exams/SemExamCard'
import PreviousExamCard from 'views/examinations/exams/PreviousExamCard'
import Retake from 'views/examinations/retakes/Retake'
import RetakeDetails from 'views/examinations/retakes/RetakeDetails'
import ApplyRetake from 'views/examinations/retakes/ApplyRetake'
import ViewProvisionalTranscripts from 'views/examinations/exams/ViewProvisionalTranscripts'
import Examinations from 'views/examinations/Examinations'

import FeeStructure from 'views/fees/fees/FeeStructure'
import FeeStatement from 'views/fees/fees/FeeStatement'
import SpecialFee from 'views/fees/fees/SpecialFees'

import Fees from 'views/fees/Fees'

import StudentProfile from 'views/profile/student/Profile'
import StudentData from 'views/profile/student/personalProfile'
import StudentAcademic from 'views/profile/student/academicProfile'

import StaffProfile from 'views/profile/staff/Profile'
import StaffData from 'views/profile/staff/personalProfile'
import StaffEmployement from 'views/profile/staff/employmentProfile'

import Repository from 'views/repository/repository'

import LeaveNavigation from 'views/leave/LeaveNav'
import LeaveApplications from 'views/leave/Applications'
import LeaveEdit from 'views/leave/Apply'
import AdminLeavedocuments from 'views/leave/admin/Document'
import LeaveObstructors from 'views/leave/Obstructors'

import LeaveDays from 'views/leave/LeaveDays'

import Claims from 'views/claims/Claims'
import AddClaim from 'views/claims/AddClaim'
import EClaims from 'views/eclaims/Eclaims'
import AddEclaims from 'views/eclaims/Edit'

import Imprest from 'views/imprest/Imprest'
import AddImprest from 'views/imprest/AddImprest'

import Messages from 'views/messaging/messages'
import ViewMessages from 'views/messaging/ViewMessages'
import Inbox from 'views/messaging/messages/inbox'
import sent from 'views/messaging/messages/sent'
import trash from 'views/messaging/messages/trash'
import Compose from 'views/messaging/messages/Compose'

import Payslip from 'views/payslip/Payslip'

import Slip from 'views/payslip/payslip/Slip'
import IpSlip from 'views/payslip/payslip/IpSlip'
import Loans from 'views/payslip/payslip/Loans'
import P9 from 'views/payslip/payslip/P9'

import SorClaimsImprest from 'views/sorclaimsimprest/SorClaimsImprest'
import Forbidden from 'views/auth/Forbidden.vue'

import ClearanceNavigation from 'views/clearances/ClearancesNav'
import ClearanceHistory from 'views/clearances/History'
import ClearanceApply from 'views/clearances/Apply'
import ClearanceCertificate from 'views/clearances/Certificates'
import ClearanceReasons from 'views/clearances/Reasons'
import ClearanceAddReason from 'views/clearances/AddReason'  
import ClearanceQuetionnaire from 'views/clearances/questionnaire/Questionnaire'
import CreateClearanceQuetionnaire from 'views/clearances/questionnaire/CreateQuestionnaire'
import ClearanceQuetionnaireResponse from 'views/clearances/questionnaire/Responses'
import FillSurvey from 'views/clearances/questionnaire/FillSurvey'
import ClearanceSurvey from 'views/clearances/questionnaire/ClearenceSurvey'

import Fleets from 'views/fleets/Fleets'
import FleetList from 'views/fleets/List'
import BookVehicle from 'views/fleets/Edit'
import AssignedVehicles from 'views/fleets/Assigned'
import AllocationSlip from 'views/fleets/AllocationSlip'

import Memo from 'views/memo/memo'
import MemoList from 'views/memo/List'
import AddMemo from 'views/memo/Add'

import SurrenderRequest from 'views/imprest-surrender/Surrenders'
import UserSurrenderList from 'views/imprest-surrender/UserRequest'
import AddSurrender from 'views/imprest-surrender/Edit'
import ClearedSurrenders from 'views/imprest-surrender/Cleared'
import PendingSurrenders from 'views/imprest-surrender/Pending'

import WorkDetails from 'views/work-request/WorkDetails' 
import WorkRequests from 'views/work-request/List'
import EditWorkRequest from 'views/work-request/Edit'  
import OrderDetails from 'views/work-request/OrderDetails'
import WorkRequestFeedBack from 'views/work-request/FeedBack' 

import Timetable from 'views/timetable/Timetable'
import StudyTimetable from 'views/timetable/StudyTimetable'
import ExamTimetable from 'views/timetable/ExamTimetable'
import AllocationSummary from 'views/timetable/AllocationSummary'

import Logs from 'views/logs/logs'
import ExamCardLogs from 'views/logs/ExamCardLogs'
import InaccessibilityLogs from 'views/logs/InaccessibilityLogs'

import Attendance from 'views/time_attendance/Attendance'
import MyAttendance from 'views/time_attendance/MyAttendance'
import AttendanceApprovalRequest from 'views/time_attendance/ApprovalRequest'
import MissedPunchList from 'views/time_attendance/MissedPunchList'
import OutOfOffice from 'views/time_attendance/OutOfOffice'
import AddOutOfOffice from 'views/time_attendance/AddOutOfOffice'
import ApproveMissedPunch from 'views/time_attendance/ApproveMissedPunch'
import ApproveOutOfOffice from 'views/time_attendance/ApproveOutOfOffice'
import AttendanceSammery from 'views/time_attendance/AttendanceSammery'

import Complaint from 'views/complaint/Complaint'
import MyComplaint from 'views/complaint/myComplaint'
import AddComplaint from 'views/complaint/Add'

import Research from 'views/Research/ResearchNav'
import Publication from 'views/Research/Publication'
import AddPublication from 'views/Research/AddPublication'
import Projects from 'views/Research/Projects'
import AddProject from 'views/Research/AddProject'

import PerformanceTemplate from 'views/performance/PerformanceTemplate'
import PerformanceNav from 'views/performance/PerformanceNav'
import AddPerformance from 'views/performance/Add'
import PerformanceGrades from 'views/performance/GradeList'
import PerformanceList from 'views/performance/List'
import AddPerformanceGrade from 'views/performance/AddGrade'
import PerformanceSession from 'views/performance/PerformanceSession'
import PerformanceResponseItems from 'views/performance/responses/ResponseItems'
import PerformanceGradeLevels from 'views/performance/GradeLevel'
import PerformanceTargets from 'views/performance/Targets'
import PerformanceReporters from 'views/performance/Reporters'
import PerformanceResponses from 'views/performance/responses/ResponseList'

export const routes = [
  {
    name: 'home',
    path: '/',
    component: Home,
    meta: {
      breadcrumb: [
        { name: 'Home' }
      ]
    }
  },
  {
    name: 'fetch-data',
    path: '/fetch-data',
    component: WeatherForecast,
    meta: {
      breadcrumb: [
        { name: 'Home', link: 'home' },
        { name: 'Weather Forecast' }
      ]
    }
  },
  {
    name: 'users',
    path: '/users',
    component: Users,
    redirect: '/users/users-list',
    children: [
      {
        path: 'users-list',
        name: 'users-list',
        component: UsersList,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Users' }
          ]
        }
      },
      {
        path: 'reset-password',
        name: 'admin-set-password',
        component: ResetPassword
      },
      {
        path: 'reset-password/:id',
        name: 'reset-password',
        component: ResetPassword,
        redirect: '/login/reset-password/:id'
      },
      {
        name: 'add-users',
        path: 'users/add',
        component: UsersEdit,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Users', link: 'users' },
            { name: 'Add Users' }
          ]
        }
      },
      {
        name: 'edit-users',
        path: 'users/edit/:id',
        component: UsersEdit,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Users', link: 'users' },
            { name: 'Edit Users' }
          ]
        }
      },
      {
        name: 'user-groups',
        path: 'user-groups',
        component: UserGroups,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Users', link: 'users' },
            { name: 'User Groups' }
          ]
        }
      },
      {
        name: 'previous-examCard',
        path: 'previous-examCard',
        component: PreviousExamCard,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Users', link: 'users' },
            { name: 'Exam Card' }
          ]
        }
      },
      {
        name: 'add-user-groups',
        path: 'user-groups/add',
        component: UserGroupsEdit,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Users', link: 'users' },
            { name: 'User Groups', link: 'user-groups' },
            { name: 'Add User Groups' }
          ]
        }
      },
      {
        name: 'edit-user-groups',
        path: 'user-groups/edit/:id',
        component: UserGroupsEdit,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Users', link: 'users' },
            { name: 'User Groups', link: 'user-groups' },
            { name: 'Edit User Groups' }
          ]
        }
      }
    ]
  },
  {
    name: 'student-profile',
    path: '/student-profile',
    component: StudentProfile,
    redirect: '/student-profile/student-data',
    children: [
      {
        name: 'student-data',
        path: 'student-data',
        component: StudentData,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Student Profile', link: 'student-profile' },
            { name: 'Student Data' }
          ]
        }
      },
      {
        name: 'academic-profile',
        path: 'academic-profile',
        component: StudentAcademic,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Student Profile', link: 'student-profile' },
            { name: 'Academic Profile' }
          ]
        }
      }
    ]
  },
  {
    name: 'staff-profile',
    path: '/staff-profile',
    component: StaffProfile,
    redirect: '/staff-profile/staff-data',
    children: [
      {
        name: 'staff-data',
        path: 'staff-data',
        component: StaffData,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Staff Profile', link: 'staff-profile' },
            { name: 'Staff Data' }
          ]
        }
      },
      {
        name: 'employment-profile',
        path: 'employment-profile',
        component: StaffEmployement,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Staff Profile', link: 'Staff-profile' },
            { name: 'Employment Profile' }
          ]
        }
      }
    ]
  },
  {
    name: 'counter',
    path: '/counter',
    component: CounterExample,
    meta: {
      breadcrumb: [
        { name: 'counter' }
      ]
    }
  },
  {
    name: 'login',
    path: '/login',
    component: LoginLayout,
    redirect: '/login/sign-in',
    children: [
      {
        path: 'sign-in',
        name: 'sign-in',
        component: Login
      },
      {
        path: 'register',
        name: 'register',
        component: Register
      },
      {
        path: 'confirm/:code',
        name: 'confirm',
        component: Confirm
      },
      {
        path: 'reset-password/:code',
        name: 'reset-password',
        component: ResetPassword
      },
      {
        path: 'reset',
        name: 'reset',
        component: Reset
      },
      {
        path: 'email-confirmation',
        name: 'email-confirmation',
        component: emailConfirmationMessage
      },
      {
        path: 'reset-confirmation',
        name: 'reset-confirmation',
        component: emailResetConfirmation
      },
      {
        path: 'changePassword',
        name: 'changePassword',
        component: changePassword
      }
    ]
  },
  {
    name: 'evaluations',
    path: '/evaluations',
    component: Evaluations,
    redirect: '/evaluations/evaluations',
    children: [
      {
        path: 'evaluations',
        name: 'evaluations',
        component: EvaluationsList,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Evaluations' }
          ]
        }
      },
      {
        path: 'current-evaluations',
        name: 'current-evaluations',
        component: CurrentEvaluationsList,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Evaluations', link: 'evaluations' },
            { name: 'Current Evaluations' }
          ]
        }
      },
      {
        path: 'current-responses/:id',
        name: 'current-responses',
        component: EvaluationsList,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Evaluations', link: 'evaluations' },
            { name: 'Evaluations Responses' }
          ]
        }
      },
      {
        path: 'responses-units/:id',
        name: 'responses-units',
        component: EvaluationsResponsesUnits,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Evaluations', link: 'evaluations' },
            { name: 'Evaluations Responses' }
          ]
        }
      },
      {
        path: 'add-evaluation',
        name: 'add-evaluation',
        component: EvaluationsAdd,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Evaluations', link: 'evaluations' },
            { name: 'Add-Evaluations' }
          ]
        }
      },
      {
        path: 'add-current',
        name: 'add-current',
        component: EvaluationsAddCurrent,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Evaluations', link: 'evaluations' },
            { name: 'Current Evaluations', link: 'current-evaluations' },
            { name: 'Add-Current' }
          ]
        }
      },
      {
        path: 'responses/',
        name: 'responses',
        component: EvaluationsResponses,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Evaluations', link: 'evaluations' },
            { name: 'Responses' }
          ]
        }
      },
      {
        path: 'respondedUnits/:id',
        name: 'respondedUnits',
        component: RespondedUnits,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Evaluations', link: 'evaluations' },
            { name: 'Responded Units' }
          ]
        }
      },
      {
        path: 'edit-evaluation/:id',
        name: 'edit-evaluation',
        component: EvaluationsEdit,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Evaluations', link: 'evaluations' },
            { name: 'Edit Evaluation' }
          ]
        }
      }
    ]
  },
  {
    path: '/settings',
    name: 'settings',
    component: Settings,
    redirect: '/settings/branding',
    children: [
      {
        path: 'branding',
        name: 'branding',
        component: Branding,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Settings', link: 'settings' },
            { name: 'Branding' }
          ]
        }
      },
      {
        path: 'privileges',
        name: 'privileges',
        component: Privileges,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Settings', link: 'settings' },
            { name: 'Privileges' }
          ]
        }
      },
      {
        name: 'add-privileges',
        path: 'privileges/add',
        component: PrivilegesEdit,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Settings', link: 'settings' },
            { name: 'Privileges', link: 'privileges' },
            { name: 'Add Privileges' }
          ]
        }
      },
      {
        name: 'edit-privileges',
        path: 'privileges/edit/:id',
        component: PrivilegesEdit,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Settings', link: 'settings' },
            { name: 'Privileges', link: 'privileges' },
            { name: 'Edit Privileges' }
          ]
        }
      },
      {
        path: 'email',
        name: 'email',
        component: Email,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Settings', link: 'settings' },
            { name: 'Email' }
          ]
        }
      }, 
      {
        path: 'other-settings',
        name: 'other-settings',
        component: OtherSettings,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Settings', link: 'other-settings' },
            { name: 'Other Settings' }
          ]
        }
      },
      {
        path: 'sys-setting',
        name: 'sys-setting',
        component: SysSetting,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Settings', link: 'other-settings' },
            { name: 'Portal Settings' }
          ]
        }
      }
    ]
  },
  {
    name: 'news',
    path: '/news',
    component: News,
    redirect: '/news/news-list',
    children: [
      {
        name: 'add-news',
        path: 'news/add',
        component: NewsEdit,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'News', link: 'news' },
            { name: 'Add News' }
          ]
        }
      },
      {
        name: 'edit-news',
        path: 'news/edit/:id',
        component: NewsEdit,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'News', link: 'news' },
            { name: 'Edit News' }
          ]
        }
      },
      {
        name: 'events',
        path: 'events',
        component: EventsList,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'News', link: 'news' },
            { name: 'Events' }
          ]
        }
      },
      {
        name: 'portal-Event-Details',
        path: 'details/:id',
        component: EventDetails,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'News', link: 'news' },
            { name: 'Events', link: 'events' },
            { name: 'Events Details' }
          ]
        }
      },
      {
        name: 'event-categories',
        path: 'event-categories',
        component: EventCategoryList,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'News', link: 'news' },
            { name: 'Events', link: 'events' },
            { name: 'Events Categories' }
          ]
        }
      },
      {
        name: 'add-event-categories',
        path: 'event-categories/add',
        component: EventsTypesEdit,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'News', link: 'news' },
            { name: 'Events', link: 'events' },
            { name: 'Categories', link: 'event-categories' },
            { name: 'Add Categories' }
          ]
        }
      },
      {
        name: 'edit-event-categories',
        path: 'event-categories/edit/:id',
        component: EventsTypesEdit,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'News', link: 'news' },
            { name: 'Events', link: 'events' },
            { name: 'Categories', link: 'event-categories' },
            { name: 'Edit Categories' }
          ]
        }
      },
      {
        name: 'add-events',
        path: 'events/add-events',
        component: AddEvent,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'News', link: 'news' },
            { name: 'Events', link: 'events' },
            { name: 'Add Events' }
          ]
        }
      },
      {
        name: 'edit-events',
        path: 'events/edit/:id',
        component: AddEvent,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'News', link: 'news' },
            { name: 'Events', link: 'events' },
            { name: 'Edit News' }
          ]
        }
      },
      {
        name: 'news-details',
        path: 'news/details/:id',
        component: NewsDetails,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'News', link: 'news' },
            { name: 'News Details' }
          ]
        }
      },
      {
        name: 'news-list',
        path: 'news-list',
        component: NewsList,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'News' }
          ]
        }
      },
      {
        name: 'categories',
        path: 'categories',
        component: NewsTypes,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'News', link: 'news' },
            { name: 'Categories' }
          ]
        }
      },
      {
        name: 'add-categories',
        path: 'categories/add',
        component: NewsTypesEdit,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'News', link: 'news' },
            { name: 'Categories', link: 'categories' },
            { name: 'Add Categories' }
          ]
        }
      },
      {
        name: 'edit-categories',
        path: 'categories/edit/:id',
        component: NewsTypesEdit,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'News', link: 'news' },
            { name: 'Categories', link: 'categories' },
            { name: 'Edit Categories' }
          ]
        }
      }
    ]
  },
  {
    name: 'reporting',
    path: '/reporting',
    component: OnlineReporting,
    meta: {
      breadcrumb: [
        { name: 'Home', link: 'home' },
        { name: 'Online Reporting' }
      ]
    }
  },
  {
    name: '401-forbidden',
    path: '/forbidden',
    component: Forbidden,
    meta: {
    }
  },
  {
    name: 'reporting',
    path: '/reporting/report',
    component: AddReporting,
    meta: {
      breadcrumb: [
        { name: 'Home', link: 'home' },
        { name: 'Online Reporting', link: 'reporting' },
        { name: 'Report' }
      ]
    }
  },
  {
    name: 'hostel-booking',
    path: '/hostel-booking',
    component: Booking,
    meta: {
      breadcrumb: [
        { name: 'Home', link: 'home' },
        { name: 'Booking' }
      ]
    }
  },
  {
    name: 'hostel',
    path: '/hostel',
    component: Hostel,
    redirect: '/hostel/book-hostel',
    children: [
      {
        name: 'booking history',
        path: 'hostel-list',
        component: BookingHistory,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Hostel', link: 'hostel' },
            { name: 'Booking History' }
          ]
        }
      },
      {
        name: 'Book Hostel',
        path: 'book-hostel',
        component: AddBooking,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Hostel', link: 'hostel' },
            { name: 'Book Hostel' }
          ]
        }
      }
    ]
  },
  {
    name: 'portal-evaluations',
    path: '/portal-evaluations',
    component: PortalEvaluation,
    redirect: '/portal-evaluations/take-evaluation',
    children: [
      {
        name: 'evaluation history',
        path: 'evaluation-history',
        component: PortalHistory,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Evaluations', link: 'portal-evaluations' },
            { name: 'Evaluation History' }
          ]
        }
      },
      {
        name: 'Take Evaluation',
        path: 'take-evaluation',
        component: TakeEvaluation,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Evaluations', link: 'portal-evaluations' },
            { name: 'Take Evaluation' }
          ]
        }
      }
    ]
  },
  { 
    name: 'clearanceQuetionnaire', 
    path: '/clearancequetionnaire',
    component: ClearanceQuetionnaire,
    redirect: '/clearanceQuetionnaire/quections',
    children: [
      {
        name: 'quections',
        path: '/clearanceQuetionnaire/quections',
        component: CreateClearanceQuetionnaire,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Clearances', link: 'clearances' },
            { name: 'apply-clearance' }
          ]
        }
      }, 
      {
        name: 'clearance-survey',
        path: '/clearanceQuetionnaire/clearance-survey',
        component: ClearanceSurvey,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Clearances', link: 'clearances' },
            { name: 'clearance-survey' }
          ]
        }
      }, 
      {
        name: 'response',
        path: '/clearanceQuetionnaire/response',
        component: ClearanceQuetionnaireResponse,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Clearances', link: 'clearances' },
            { name: 'apply-clearance' }
          ]
        }
      },
      {
        name: 'clearanceReasons',
        path: '/clearanceQuetionnaire/clearanceReasons',
        component: ClearanceReasons,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Clearances', link: 'clearances' },
            { name: 'clearance-reasons' }
          ]
        }
      },
      {
        name: 'clearanceAddReason',
        path: '/clearanceQuetionnaire/clearanceAddReason',
        component: ClearanceAddReason,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Clearances', link: 'clearances' },
            { name: 'clearance-add-reason' }
          ]
        }
      }
    ]
  },
  {
    name: 'clearances',
    path: '/clearances',
    component: ClearanceNavigation,
    redirect: '/clearances/survey',
    children: [
      {
        name: 'survey',
        path: '/clearances/survey',
        component: FillSurvey,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Clearances', link: 'clearances' },
            { name: 'fill-survey' }
          ]
        }
      },
      {
        name: 'apply-clearance',
        path: '/clearances/apply',
        component: ClearanceApply,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Clearances', link: 'clearances' },
            { name: 'apply-clearance' }
          ]
        }
      },
      {
        name: 'clearance-certificate',
        path: '/clearances/clearance-certificate',
        component: ClearanceCertificate,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Clearances', link: 'clearances' },
            { name: 'clearance-certificate' }
          ]
        }
      }, 
      {
        name: 'clearances-history',
        path: '/clearances/history',
        component: ClearanceHistory,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Clearances', link: 'clearances' },
            { name: 'clearances-history' }
          ]
        }
      }
    ]
  },
  {
    name: 'portal-news',
    path: '/portal-news',
    component: StudentNews,
    redirect: '/portal-news/portal-list',
    children: [
      {
        name: 'Portal News',
        path: 'portal-list',
        component: StudentNewsList,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Portal News', link: 'portal-news' },
            { name: 'News' }
          ]
        }
      },
      {
        name: 'portal-events',
        path: 'portal-events',
        component: StudentEventsList,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Portal News', link: 'portal-news' },
            { name: 'Portal Events' }
          ]
        }
      },
      {
        name: 'portal-News-Details',
        path: 'dtls/:id',
        component: NewsDetails,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Portal News', link: 'news' },
            { name: 'News Details' }
          ]
        }
      },
      {
        name: 'events-details',
        path: 'details/:id',
        component: PortalEventDetails,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Portal News', link: 'news' },
            { name: 'News Details' }
          ]
        }
      }
    ]
  },
  {
    name: 'academics',
    path: '/academics',
    component: Academics,
    redirect: '/academics/units-register',
    children: [
      {
        name: 'view-curriculum',
        path: 'view-curriculum',
        component: ViewCurriculum,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Academics', link: 'view-curriculum' },
            { name: 'View Curriculum' }
          ]
        }
      },
      {
        name: 'Register-Units',
        path: 'units-register',
        component: RegisterUnits,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Evaluations', link: 'portal-evaluations' },
            { name: 'Register Units' }
          ]
        }
      },
      {
        name: 'Registration-History',
        path: 'registration-history',
        component: RegistrationHistory,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Evaluations', link: 'portal-evaluations' },
            { name: 'Register Units' }
          ]
        }
      }
    ]
  },
  {
    name: 'examinations',
    path: '/examinations',
    component: Examinations,
    redirect: '/examinations/view-examcard',
    children: [
      {
        name: 'view-examcard',
        path: 'view-examcard',
        component: ExamCard,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Examinations', link: 'examinations' },
            { name: 'Exam Card' }
          ]
        }
      },  
      {
        name: 'previous-examCard',
        path: 'previous-examCard',
        component: PreviousExamCard,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Examinations', link: 'examinations' },
            { name: 'Previous ExamCard' }
          ]
        }
      },
      {
        name: 'retake',
        path: 'retake',
        component: Retake,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Examinations', link: 'examinations' },
            { name: 'Retake' }
          ]
        }
      },
      {
        name: 'apply-retake',
        path: 'apply-retake',
        component: ApplyRetake,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Examinations', link: 'examinations' },
            { name: 'Apply Retake' }
          ]
        }
      },
      {
        name: 'retake-details',
        path: 'retake-details/:id',
        component: RetakeDetails,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Examinations', link: 'examinations' },
            { name: 'Retake Details' }
          ]
        }
      },
      {
        name: 'Provisional-Transcripts',
        path: 'provisional-transcripts',
        component: ViewProvisionalTranscripts,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Examinations', link: 'examinations' },
            { name: 'Provisional Transcripts' }
          ]
        }
      },
      {
        name: 'Exam-History',
        path: 'exam-history',
        component: ViewFinalTranscripts,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Examinations', link: 'examinations' },
            { name: 'Exam History' }
          ]
        }
      }
    ]
  },
  {
    name: 'repository',
    path: '/repository',
    component: Repository,
    meta: {
      breadcrumb: [
        { name: 'Home', link: 'home' },
        { name: 'Repository' }
      ]
    }
  },
  {
    name: 'fees',
    path: '/fees',
    component: Fees,
    redirect: '/fees/fee-statement',
    children: [
      {
        name: 'fee-statement',
        path: 'fee-statement',
        component: FeeStatement,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Fees', link: 'fees' },
            { name: 'Fees Statement' }
          ]
        }
      },
      {
        name: 'fees-structure',
        path: 'fees-structure',
        component: FeeStructure,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Fees', link: 'fees' },
            { name: 'Fees Structure' }
          ]
        }
      },
      {
        name: 'special-fees',
        path: 'special-fees',
        component: SpecialFee,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Fees', link: 'fees' },
            { name: 'Special Fees' }
          ]
        }
      }
    ]
  },
  {
    name: 'leave',
    path: '/leave',
    component: LeaveNavigation,
    redirect: '/leave/applications',
    children: [
      {
        name: 'leave requests',
        path: 'applications',
        component: LeaveApplications,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Applications' }
          ]
        } 
      },
      {
        name: 'obstructors',
        path: 'obstructors',
        component: LeaveObstructors,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Leave Obstructors' }
          ]
        } 
      },
      {
        name: 'leave days',
        path: 'days',
        component: LeaveDays,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Applications', link: 'leave' },
            { name: 'Leave Balance' }
          ]
        }
      },
      {
        name: 'Apply Leave',
        path: 'applications/add',
        component: LeaveEdit,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Applications', link: 'leave' },
            { name: 'Apply Leave' }
          ]
        }
      }
    ]
  },
  {
    name: 'messaging',
    path: '/messaging',
    component: Messages,
    redirect: '/messaging/inbox',
    children: [
      {
        name: 'inbox',
        path: 'inbox',
        component: Inbox,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Messages', link: 'messaging' },
            { name: 'Inbox' }
          ]
        }
      },
      {
        name: 'sent',
        path: 'sent',
        component: sent,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Messages', link: 'messaging' },
            { name: 'Sent' }
          ]
        }
      },
      {
        name: 'trash',
        path: 'trash',
        component: trash,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Messages', link: 'messaging' },
            { name: 'Trash' }
          ]
        }
      },
      {
        name: 'compose',
        path: 'compose',
        component: Compose,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Messages', link: 'messaging' },
            { name: 'Compose' }
          ]
        }
      }
    ]
  },
  {
    name: 'view-message',
    path: 'view-message',
    component: ViewMessages,
    meta: {
      breadcrumb: [
        { name: 'Home', link: 'home' },
        { name: 'View Message' }
      ]
    }
  },
  {
    name: 'payslip',
    path: '/payslip',
    component: Payslip,
    redirect: '/payslip/payslip',
    children: [
      {
        name: 'payslip',
        path: 'payslip',
        component: Slip,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Payslip', link: 'payslip' },
            { name: 'Payslip' }
          ]
        }
      },
      {
        name: 'ippayslip',
        path: 'ippayslip',
        component: IpSlip,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Payslip', link: 'payslip' },
            { name: 'IP Payslip' }
          ]
        }
      },
      {
        name: 'loans',
        path: 'Loans',
        component: Loans,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Payslip', link: 'payslip' },
            { name: 'Load Statement' }
          ]
        }
      },
      {
        name: 'P9',
        path: 'p9',
        component: P9,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Payslip', link: 'p9' },
            { name: 'P9' }
          ]
        }
      }
    ]
  },
  {
    name: 'sor-claims-imprest',
    path: '/sor-claims-imprest',
    component: SorClaimsImprest,
    redirect: '/sor-claims-imprest/sor',
    children: [
      {
        name: 'sor',
        path: 'sor',
        component: Sor,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'SOR Claims & Imprest', link: 'sor-claims-imprest' },
            { name: 'SOR' }
          ]
        }
      },
      {
        name: 'specification-of-requirement-items',
        path: 'sor/Add',
        component: SorEdit,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'SOR Claims & Imprest', link: 'sor-claims-imprest' },
            { name: 'SOR', link: 'sor' },
            { name: 'SOR Items' }
          ]
        }
      },
      {
        name: 'internal-requisition',
        path: 'IR',
        component: IRList,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'SOR Claims & Imprest', link: 'sor-claims-imprest' },
            { name: 'IR' }
          ]
        }
      },
      {
        name: 'IR-create',
        path: 'IR/add',
        component: CreateIR,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'SOR Claims & Imprest', link: 'sor-claims-imprest' },
            { name: 'Add' }
          ]
        }
      },
      {
        name: 'claims',
        path: 'claims',
        component: Claims,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'SOR Claims & Imprest', link: 'sor-claims-imprest' },
            { name: 'Claims' }
          ]
        }
      },
      {
        name: 'add-claims',
        path: '/claims/add',
        component: AddClaim,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'SOR Claims & Imprest', link: 'sor-claims-imprest' },
            { name: 'Claims', link: 'claims' },
            { name: 'Add Claims' }
          ]
        }
      },
      {
        name: 'eclaims',
        path: 'eclaims',
        component: EClaims,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'SOR Claims & Imprest', link: 'sor-claims-imprest' },
            { name: 'Expense Claim' }
          ]
        }
      },
      {
        name: 'add-eclaims',
        path: 'add-eclaims',
        component: AddEclaims,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'SOR Claims & Imprest', link: 'sor-claims-imprest' },
            { name: 'Expense Claims', link: 'eclaims' },
            { name: 'Add Expense Claim' }
          ]
        }
      },
      {
        name: 'imprest',
        path: 'imprest',
        component: Imprest,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'SOR Claims & Imprest', link: 'sor-claims-imprest' },
            { name: 'Imprest' }
          ]
        }
      },
      {
        name: 'add-imprest',
        path: '/imprest/add',
        component: AddImprest,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'SOR Claims & Imprest', link: 'sor-claims-imprest' },
            { name: 'Imprest', link: 'imprest' },
            { name: 'Add Imprest' }
          ]
        }
      }
    ]
  },
  {
    name: 'fleet',
    path: '/fleet',
    component: Fleets,
    redirect: '/fleet/fleet-bookings',
    children: [
      {
        name: 'fleet-bookings',
        path: 'fleet-bookings',
        component: FleetList,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Fleet Management', link: 'fleet' },
            { name: 'Bookings' }
          ]
        }
      },
      {
        name: 'book-vehicle',
        path: 'book-vehicle',
        component: BookVehicle,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Fleet Management', link: 'fleet' },
            { name: 'Book' }
          ]
        }
      },
      {
        name: 'assigned-vehicles',
        path: 'assigned-vehicles',
        component: AssignedVehicles,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Fleet Management', link: 'fleet' },
            { name: 'Assigned' }
          ]
        }
      }, 
      {
        name: 'allocation-slip',
        path: 'allocation-slip',
        component: AllocationSlip,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Fleet Management', link: 'fleet' },
            { name: 'Slip' }
          ]
        }
      },
    ]
  },
  {
    name: 'onlineMemo',
    path: '/onlineMemo',
    component: Memo,
    redirect: '/onlineMemo/raised-memos',
    children: [
      {
        name: 'raised-memos',
        path: 'raised-memos',
        component: MemoList,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Memo', link: 'onlineMemo' },
            { name: 'Raised Memos' }
          ]
        }
      },
      {
        name: 'add-memo',
        path: 'add-memo',
        component: AddMemo,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Memo', link: 'onlineMemo' },
            { name: 'Add Memo' }
          ]
        }
      }
    ]
  },
  {
    name: 'user-imprest-surrender',
    path: '/imprest-surrender/surrender-requests',
    component: UserSurrenderList
  },
  {
    name: 'add-surrender',
    path: '/imprest-surrender/add-surrender',
    component: AddSurrender
  },
  {
    name: 'surrenders',
    path: '/imprest-surrender',
    component: SurrenderRequest,
    redirect: '/imprest-surrender/pending-surrenders',
    children: [
      {
        name: 'pending-surrenders',
        path: 'pending-surrenders',
        component: PendingSurrenders,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Memo', link: 'onlineMemo' },
            { name: 'Raised Memos' }
          ]
        }
      },
      {
        name: 'cleared-surrenders',
        path: 'cleared-surrenders',
        component: ClearedSurrenders,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Memo', link: 'onlineMemo' },
            { name: 'Raised Memos' }
          ]
        }
      }
    ]
  },
  {
    name: 'work-request',
    path: 'work-request',
    component: WorkRequests,
  },
  {
    name: 'work-details',
    path: '/work-details/',
    component: WorkDetails,
    redirect: '/work-details/edit',
    children: [
      {
        name: 'Work request',
        path: 'edit',
        component: EditWorkRequest,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Work Details', link: 'work-details' },
            { name: 'Edit' }
          ] 
        }
      }, 
      {
        name: 'order-details',
        path: 'order-details',
        component: OrderDetails,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Work Details', link: 'work-details' },
            { name: 'Details' }
          ]
        }
      },
      {
        name: 'feedback',
        path: 'feedback',
        component: WorkRequestFeedBack,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Work Details', link: 'work-details' },
            { name: 'FeedBack' }
          ]
        }
      },
    ]
  }, 
  {
    name: 'timetable',
    path: '/timetable',
    component: Timetable,
    redirect: '/timetable/study-timetable',
    children: [
      {
        name: 'study-timetable',
        path: 'study-timetable',
        component: StudyTimetable,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Study Timetable'}
          ]
        }
      },
      {
        name: 'exam-timetable',
        path: 'exam-timetable',
        component: ExamTimetable,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Exam Timetable'}
          ]
        }
      },
      {
        name: 'allocation-summary',
        path: 'allocation-summary',
        component: AllocationSummary,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Allocation Summary'}
          ]
        }
      }
    ]
  },
  {
    name: 'systemlogs',
    path: '/systemlogs',
    component: Logs,
    redirect: '/systemlogs/inaccessibility-logs',
    children: [
      {
        name: 'inaccessibility-logs',
        path: 'inaccessibility-logs',
        component: InaccessibilityLogs,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Inaccessibility Logs' }
          ]
        }
      },
      {
        name: 'exam-card-logs',
        path: 'exam-card-logs',
        component: ExamCardLogs,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Exam Card Logs' }
          ]
        }
      },
    ]
  },
  {
    name: 'attendance',
    path: '/attendance',
    component: Attendance,
    redirect: '/attendance/myAttendance',
    children: [
      {
        name: 'myAttendance',
        path: 'myAttendance',
        component: MyAttendance,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'My Attendance' }
          ]
        }
      },
      {
        name: 'attendanceSammery',
        path: 'attendanceSammery',
        component: AttendanceSammery,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Attendance Sammery' }
          ]
        }
      },
      {
        name: 'missedPunchList',
        path: 'missedPunchList',
        component: MissedPunchList,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Missed Punch' }
          ]
        }
      },
      {
        name: 'outOfOffice',
        path: 'outOfOffice',
        component: OutOfOffice,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Out of Office' }
          ]
        }
      },  
      {
        name: 'addOutOfOffice',
        path: 'addOutOfOffice',
        component: AddOutOfOffice,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Out of Office' }
          ]
        }
      },
      {
        name: 'approveMissedPunch',
        path: 'approveMissedPunch',
        component: ApproveMissedPunch,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Missed Office' }
          ]
        }
      },
      {
        name: 'approveOutOfOffice',
        path: 'approveOutOfOffice',
        component: ApproveOutOfOffice,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Out of Office' }
          ]
        }
      },
      {
        name: 'attendanceApprovalRequest',
        path: 'attendanceApprovalRequest',
        component: AttendanceApprovalRequest,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Approval Request' }
          ]
        }
      },
    ]
  },
  {
    name: 'complaint',
    path: '/complaint',
    component: Complaint,
    redirect: '/complaint/myComplaint',
    children: [
      {
        name: 'myComplaint',
        path: 'myComplaint',
        component: MyComplaint,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Complaint' }
          ]
        }
      },
      {
        name: 'add-complaint',
        path: 'add-complaint',
        component: AddComplaint,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Create Complaint' }
          ]
        }
      },
    ]
  },
  {
    name: 'research',
    path: '/research',
    component: Research,
    redirect: '/research/projects',
    children: [
      {
        name: 'projects',
        path: 'projects',
        component: Projects,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Projects' }
          ]
        }
      },
      {
        name: 'add-project',
        path: 'add-project',
        component: AddProject,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'add-project' }
          ]
        }
      },
      {
        name: 'publication',
        path: 'publication',
        component: Publication,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Publication' }
          ]
        }
      },
      {
        name: 'add-publication',
        path: 'add-publication',
        component: AddPublication,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Add Publication' }
          ]
        }
      },
    ]
  },
  {
    name: 'leaveDocuments',
    path: '/leaveDocuments',
    component: AdminLeavedocuments
  }, 
  {
    name: 'performance',
    path: '/performance',
    component: PerformanceNav,
    redirect: '/performance/performance-template',
    children: [
      {
        name: 'performance-template',
        path: 'performance-template',
        component: PerformanceTemplate,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Performance' }
          ]
        }
      },  
      {
        name: 'add-performance',
        path: 'add-performance',
        component: AddPerformance,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Performance' }
          ]
        }
      },  
      {
        name: 'performance-grades',
        path: 'performance-grades',
        component: PerformanceGrades,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Grades' }
          ]
        }
      },
      {
        name: 'performance-list',
        path: 'performance-list',
        component: PerformanceList,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Performance' }
          ]
        }
      }, 
      {
        name: 'add-performance-grade',
        path: 'add-performance-grade',
        component: AddPerformanceGrade,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Grades' }
          ]
        }
      },
      {
        name: 'performance-session',
        path: 'performance-session',
        component: PerformanceSession,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Performance' }
          ]
        }
      }, 
      {
        name: 'performance-response-items',
        path: 'performance-response-items',
        component: PerformanceResponseItems,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Performance Response' }
          ]
        }
      },
      {
        name: 'performance-grade-levels',
        path: 'performance-grade-levels',
        component: PerformanceGradeLevels,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Grades' }
          ]
        }
      },
      {
        name: 'performance-targets',
        path: 'performance-targets',
        component: PerformanceTargets,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Targets' }
          ]
        }
      }, 
      {
        name: 'performance-reporters',
        path: 'performance-reporters',
        component: PerformanceReporters,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Reporters' }
          ]
        }
      },
      {
        name: 'performance-responses',
        path: 'performance-responses',
        component: PerformanceResponses,
        meta: {
          breadcrumb: [
            { name: 'Home', link: 'home' },
            { name: 'Responses' }
          ]
        }
      },
    ]
  }, 
]
