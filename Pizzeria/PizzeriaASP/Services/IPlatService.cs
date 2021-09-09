using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Pizzeria.ASP.Models;
using Pizzeria.DAL.Entities;

namespace Pizzeria.ASP.Services
{
	public interface IPlatService
	{
		IEnumerable<PlatModel> GetAll(int? filtre);
		void Create(PlatAddModel form);
		Plat Delete(int id);
	}
}
