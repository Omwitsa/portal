using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unisol.Web.Entities.Model;

namespace Unisol.Web.Entities.Database.MembershipModels
{
    public static class aspnetPortalCoreContextExtensions
    {
        public static void EnsureDatabaseSeeded(this PortalCoreContext context)
        {
            if (!context.UserGroups.Any())
            {
                context.Add(
                    new UserGroups
                    {
                        GroupName = "AbnAdmin",
                        Role = Role.Admin,
                        IsDefault = true,
                        Status = true
                    }
                );
                context.SaveChanges();
            }

            var adminGroup = context.UserGroups.FirstOrDefault(k => k.Role == Role.Admin);
            var admin = new User
            {
                EmailConfirmed = true,
                UserName = "admin@abno.com",
                Email = "admin@abno.com",
                UserGroupsId = adminGroup.Id,
				PasswordHash = "$SOL$V1$10000$JV1G9YBlnZ9xrEiX05eMGL8P1DBZsu+Vur2pt1o8IiyT4pfe",
				//PasswordHash = SecurePasswordHasher.Hash("123456"),
				Code = "493ddc84-a8b4-47ff-a3b3-ecd07bf125fa",
                DateCreated = DateTime.Now,
                Role = Role.Admin,
                Status = true,
            };

            var adminExists = context.Users.FirstOrDefault(u => u.UserName == admin.UserName);
            if (adminExists == null)
            {
                context.Add(admin);
            }
            else
            {
                adminExists.Status = true;
                context.Update(adminExists);
            }

            var settings = context.Settings.FirstOrDefault();
            if (settings == null)
            {
                context.Add(
                    new Settings()
                    {
                        Name = "University of ABNO",
                        LogoImageUrl = "/assets/images/logo.jpg",
                        ThemeColor = "#003472",
                        SecondaryColor = "#003472",
                        LoginMessageTitle = "Community of learners",
                        loginMessage = "Login message here",
                        loginImageUrl = "/assets/images/banner.jpg",
                        EmailUserName = "noreply@abnosoftwares.co.ke",
                        SmtpClient = "smtp.office365.com",
                        Password = "Duy74015",
                        Port = "587",
                        ClassStatus = "Active",
                        LeaveRelieverMandatory = true,
                        IsGenesis = true
                    }
                );
            }

            if (!context.UserGroupPrivileges.Any())
            {
                context.AddRange(
                    PrivilegeValues.AddPrivilegesList()
                );
            }

            if (!context.PortalConfigs.Any())
            {
                context.AddRange(
                    StudentPortalConfigs.AddConfigsToList()
                );
            }
			var clintIps = ClientIpValues.GetClientIps();
			clintIps.ForEach(i => {
				if(!context.ClientIp.Any(c => c.Ip.ToLower().Equals(i.Ip.ToLower())))
				{
					context.ClientIp.Add(i);
				}
			});

			context.SaveChanges();
        }
    }
}
