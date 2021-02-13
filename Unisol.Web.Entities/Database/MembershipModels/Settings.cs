using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public class Settings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string LogoImageUrl { get; set; }
        public string Initials { get; set; }
        public string ThemeColor { get; set; }
        public string SecondaryColor { get; set; }
        public string Modules { get; set; }
		public string LoginMessageTitle { get; set; }
		public string loginMessage { get; set; }
		public string loginImageUrl { get; set; }
		public string EmailUserName { get; set; }
        public string SmtpClient { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
		public string ClassStatus { get; set; }
        public bool LeaveRelieverMandatory { get; set; }
        public bool IsGenesis { get; set; }
		public UnitsLevels UnitsRegLevels { get; set; }
		public string HostelRatio { get; set; }
		public int HostelDuration { get; set; }
		public DateTime? HostelBookingStartDate { get; set; }
		public string ExamCardNotes { get; set; }
        public string SocketOption { get; set; }
    }

	public enum UnitsLevels
	{
		SessionUnits = 0,
		YearlyUnits = 1,
		EntireUnits = 2
	}
}
