using Portal.UnitTests.Database;
using Unisol.Web.Entities.Database.MembershipModels;
using Unisol.Web.Portal.IServices;
using Unisol.Web.Portal.Services;
using Xunit;

namespace Portal.UnitTests
{
	public class AcademicsUnitTest
	{
		private IUnisolApiProxy unisolApiProxy;
		private IAcademicsServices academicsServices;
		private PortalCoreContext portalDbTestContext;
		public AcademicsUnitTest()
		{
			portalDbTestContext = new PortalDbTestContext().GetContext();
			unisolApiProxy = new UnisolApiProxy("http://localhost:8088/api/");
			academicsServices = new AcademicsServices(unisolApiProxy, portalDbTestContext);
		}

		[Fact]
		public void GetStudentExamCard_IfSuccessful_ReturnTrue()
		{
			//string usercode = "ABS232-0140/2018";
			//var examCard = academicsServices.GetStudentExamCard(usercode);
			//Assert.True(examCard.Success);
		}
	}
}
