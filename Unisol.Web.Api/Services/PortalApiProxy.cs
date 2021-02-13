using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Threading.Tasks;
using Unisol.Web.Api.IServices;

namespace Unisol.Web.Api.Services
{
	public class PortalApiProxy : IPortalApiProxy
	{
		private readonly string _portalApiUrl;
		private IConfiguration _configuration { get; }

		public PortalApiProxy(IConfiguration _configuration)
		{
			_portalApiUrl = _configuration["Urls:UnisolPortalUrl"];
		}

		#region REQUESTS
		public async Task<string> Get(string resourceUrl)
		{
			var restClient = new RestClient(_portalApiUrl);
			var restRequest = new RestRequest(resourceUrl, Method.GET) { RequestFormat = DataFormat.Json };
			var data = await restClient.ExecuteGetTaskAsync(restRequest);
			return data.Content;
		}

		public async Task<string> Post(string resourceUrl, object entity)
		{
			var restClient = new RestClient(_portalApiUrl);
			var restRequest = new RestRequest(resourceUrl, Method.POST) { RequestFormat = DataFormat.Json };
			restRequest.AddBody(entity);
			var response = await restClient.ExecutePostTaskAsync(restRequest);
			return response.Content;
		}

		public Task<string> ReturnCourseMaterials()
		{
			var response = Get("repository/GetStudentRepository");
			return response;
		}
		#endregion
	}
}
