using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Unisol.Web.Common.Utilities
{
	public class Encrypter
	{
		private const string InitVector = "6BFBE0E1CA96C459";
		private const string PassPhrase = "f2we528192aa23ea283cfcb45627xd30zc784c43";
		private const int KeySize = 256;

		public static string Encrypt(string plainText)
		{
			var initVectorBytes = Encoding.UTF8.GetBytes(InitVector);
			var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			var password = new PasswordDeriveBytes(PassPhrase, null);
			var keyBytes = password.GetBytes(KeySize / 8);
			var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC };
			var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
			var memoryStream = new MemoryStream();
			var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
			cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
			cryptoStream.FlushFinalBlock();
			var cipherTextBytes = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String(cipherTextBytes);
		}

		public static string Decrypt(string cipherText)
		{
			var initVectorBytes = Encoding.UTF8.GetBytes(InitVector);
			var cipherTextBytes = Convert.FromBase64String(cipherText);
			var password = new PasswordDeriveBytes(PassPhrase, null);
			var keyBytes = password.GetBytes(KeySize / 8);
			var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC };
			var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
			var memoryStream = new MemoryStream(cipherTextBytes);
			var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
			var plainTextBytes = new byte[cipherTextBytes.Length];
			var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
			memoryStream.Close();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
		}
	}
}
