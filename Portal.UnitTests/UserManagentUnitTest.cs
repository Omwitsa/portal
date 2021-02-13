using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Moq;
using Portal.UnitTests.Database;
using Unisol.Web.Common.ViewModels.Login;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IRepository;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Repository;
using Unisol.Web.Portal.Services;
using Xunit;

namespace Portal.UnitTests
{
	public class UserManagentUnitTest
	{
		private IUserManagementService userManagementService;
		private IPortalServices portalServices;
		private IUnisolApiProxy unisolApiProxy;
		private PortalCoreContext portalDbTestContext;
		private IConfiguration configuration;
		private IHostingEnvironment env;
		private IEmailService emailService;
		private IEmailConfiguration emailConfiguration;

		public UserManagentUnitTest()
		{
			portalDbTestContext = new PortalDbTestContext().GetContext();
			unisolApiProxy = new UnisolApiProxy("http://localhost:8088/api/");
			portalServices = new PortalServices(portalDbTestContext, unisolApiProxy);
			configuration = new Mock<IConfiguration>().Object;
			env = new Mock<IHostingEnvironment>().Object;
			emailConfiguration = new EmailConfiguration();
			emailService = new EmailService(emailConfiguration);
			userManagementService = new UserManagementService(portalDbTestContext, portalServices, unisolApiProxy, 
				configuration, emailConfiguration, env, emailService);
		}

		[Fact]
		public void Login_IfSuccessful_ReturnTrue()
		{
			var userData = new LoginViewModel { Username = "Admin@abno.com", Password = "123456" };
			var login = userManagementService.Login(userData);
			Assert.True(login.Success);
		}

		[Fact]
		public void Register_IfSuccessful_ReturnTrue()
		{
			var userData = new RegisterViewModel
			{
				RegNumber = "ABS232-0140/2018",
				Role = Role.Student,
				Password = "123456",
				PasswordConfirm = "123456"
			};
			var registered = userManagementService.Register(userData, false, true);
			Assert.True(registered.Success);
		}
	}
}
