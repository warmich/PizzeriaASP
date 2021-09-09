using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Pizzeria.ASP.Models;
using Pizzeria.DAL;
using Pizzeria.DAL.Entities;

namespace Pizzeria.ASP.Services
{
	public class ClientService : IClientService
	{
		private readonly PizzeriaContext _dc;

		public ClientService(PizzeriaContext dc)
		{
			_dc = dc;
		}

		public void Create(RegisterModel form, Guid salt, string hashed)
		{
			Client toSave = new()
			{
				Nom = form.Nom,
				Email = form.Email,
				Telephone = form.Tel,
				Salt = salt,
				Password = hashed,
				Role = "Customer"
			};
			_dc.Clients.Add(toSave);
			_dc.SaveChanges();
		}

		public Client GetByEmail(string email)
		{
			return _dc.Clients.SingleOrDefault(c => c.Email == email);
		}
	}
}
