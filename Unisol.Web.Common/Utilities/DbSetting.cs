using Microsoft.Extensions.Configuration;

namespace Unisol.Web.Common.Utilities
{
	public class DbSetting
	{
		public static string ConnectionString(IConfiguration configuration, string key)
		{
			var serverIp = configuration["Database:" + key + ":ServerIp"];
			var dbName = configuration["Database:" + key + ":DbName"];
			var dbUser = configuration["Database:" + key + ":DbUser"];
			var dbPassword = configuration["Database:" + key + ":DbPassword"];

			dbUser = Encrypter.Decrypt(dbUser);
			dbPassword = Encrypter.Decrypt(dbPassword);

			var conString = $"Server={serverIp};Database={dbName};User Id={dbUser};password={dbPassword};";
			return conString;
		}
	}
}
