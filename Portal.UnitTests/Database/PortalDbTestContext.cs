using Microsoft.EntityFrameworkCore;
using System;
using Unisol.Web.Common.Process;
using Unisol.Web.Entities.Database.MembershipModels;

namespace Portal.UnitTests.Database
{
	public class PortalDbTestContext
	{
		public PortalCoreContext GetContext()
		{
			var options = new DbContextOptionsBuilder<PortalCoreContext>()
							  .UseInMemoryDatabase(Guid.NewGuid().ToString())
							  .Options;
			var context = new PortalCoreContext(options);
			// ABS232-0140/2018
			context.Users.Add(new User
			{
				EmailConfirmed = true,
				UserName = "Admin@abno.com",
				Email = "womwitsa@abnosftwares.co.ke",
				UserGroupsId = 1,
				PasswordHash = SecurePasswordHasher.Hash("123456"),
				Code = "493ddc84-a8b4-47ff-a3b3-ecd07bf125fa",
				DateCreated = DateTime.Now,
				Role = Role.Admin,
				Status = true,
			});

			context.UserGroups.Add(new UserGroups
			{
				GroupName = "AbnAdmin",
				Role = Role.Admin,
				IsDefault = true,
				Status = true
			});

			context.UserGroups.Add(new UserGroups
			{
				GroupName = "Student",
				Role = Role.Student,
				IsDefault = true,
				Status = true
			});

			context.Settings.Add(new Settings
			{
				Name = "University of ABNO",
				EmailUserName = "noreply@abnosoftwares.co.ke",
				LogoImageUrl = "../../../assets/images/logo.jpg",
			});

			context.SaveChanges();
			return context;
		}
	}
}
