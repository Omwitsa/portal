using System.Threading.Tasks;

namespace Unisol.Web.Api.IServices
{
	public interface IPortalApiProxy
	{
		Task<string> ReturnCourseMaterials();
	}
}
