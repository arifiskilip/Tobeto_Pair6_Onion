using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
	public static class HashingHelper
	{
		public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
			}
		}

		public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512(passwordSalt))
			{
				byte[] computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
				return computeHash.SequenceEqual(passwordHash) ? true : false;
			}
		}
	}
}
