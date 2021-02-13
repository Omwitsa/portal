using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Common.ViewModels.Settings
{
	public class PortalSetting
	{
		public string Address { get; set; }
		public bool? IsGenesis { get; set; }
		public string Initials { get; set; }
		public string Name { get; set; }
		public string logoImageUrl { get; set; }
		public UnitsLevels unitsRegLevels { get; set; }
		public string ThemeColor { get; set; }
		public string SecondaryColor { get; set; }
		public string LogoDataUrl { get; set; }
	}
}
