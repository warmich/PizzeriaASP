using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Pizzeria.ASP.Models;

namespace Pizzeria.ASP.Services
{
	public interface ICategorieService
	{
		IEnumerable<CategorieModel> GetAll();

		CategorieEditModel GetOne(int id);

		void Add(CategorieAddModel form);

		bool Uddate(int id, CategorieEditModel form);

		bool Delete(int id);
	}
}
