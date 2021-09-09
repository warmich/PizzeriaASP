using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.ASP.Services
{
	public class HashService : IHashService
	{
		public string Hash(string password, string salt = null)
		{
			SHA512CryptoServiceProvider provider = new();
			byte[] bytes = Encoding.UTF8.GetBytes(password + (salt ?? ""));
			byte[] encoded = provider.ComputeHash(bytes);
			return Encoding.UTF8.GetString(encoded);
		}
	}
}
