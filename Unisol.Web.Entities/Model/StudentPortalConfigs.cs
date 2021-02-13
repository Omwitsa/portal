using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Unisol.Web.Entities.Model
{
	public static class StudentPortalConfigs
	{
		public static List<PortalConfig> AddConfigsToList()
		{
			var portalConfigs = new List<PortalConfig>();
			portalConfigs.Add(
				new PortalConfig()
				{
					Name = "ALLOW ONLINE BOOKING",
					Code = "001",
					Status = false,
				}
			);
			portalConfigs.Add(
				new PortalConfig()
				{
					Name = "ALLOW EXAM CARD DOWNLOAD",
					Code = "002",
					Status = false,
				}
			);
			portalConfigs.Add(
				new PortalConfig()
				{
					Name = "ALLOW ONLINE LOGIN",
					Code = "003",
					Status = false,
				}
			);
			portalConfigs.Add(
				new PortalConfig()
				{
					Name = "ALLOW TRANSCRIPT DOWNLOAD",
					Code = "004",
					Status = false,
				}
			);
			portalConfigs.Add(
				new PortalConfig()
				{
					Name = "ALLOW ONLINE UNIT REGISTRATION",
					Code = "005",
					Status = false,
				}
			);
			portalConfigs.Add(
				new PortalConfig()
				{
					Name = "ALLOW ONLINE REPORTING",
					Code = "006",
					Status = false,
				}
			);
			portalConfigs.Add(
				new PortalConfig()
				{
					Name = "ALLOW FEES STATEMENT VIEWING",
					Code = "007",
					Status = false,
				}
			);
			portalConfigs.Add(
				new PortalConfig()
				{
					Name = "ALLOW PROFILE EDITING",
					Code = "008",
					Status = false,
				}
			);
			portalConfigs.Add(
				new PortalConfig()
				{
					Name = "ALLOW FEES STRUCTURE VIEWING",
					Code = "009",
					Status = false,
				}
			);
			return portalConfigs;
		}
	}
}
