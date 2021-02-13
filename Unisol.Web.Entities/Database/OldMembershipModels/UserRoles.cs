using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Unisol.Web.Entities.Database.OldMembershipModels
{
	public class UserRoles
	{
		[Key]
		public string UserId { get; set; }
		public string RoleId { get; set; }
	}
}
