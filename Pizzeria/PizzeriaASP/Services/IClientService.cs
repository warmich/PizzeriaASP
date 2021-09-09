using System;

using Pizzeria.ASP.Models;
using Pizzeria.DAL.Entities;

namespace Pizzeria.ASP.Services
{
	public interface IClientService
	{
		Client GetByEmail(string email);
		void Create(RegisterModel form, Guid salt, string hashed);
	}
}