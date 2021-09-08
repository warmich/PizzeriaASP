using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Pizzeria.ASP.Models;
using Pizzeria.DAL;
using Pizzeria.DAL.Entities;

namespace Pizzeria.ASP.Services
{
	public class CategorieService : ICategorieService
	{
		private readonly PizzeriaContext _dc;

		public CategorieService(PizzeriaContext dc)
		{
			_dc = dc;
		}

		public void Add(CategorieAddModel form)
		{
			Categorie c = new Categorie { Nom = form.Nom };
			_dc.Categories.Add(c);
			_dc.SaveChanges();
		}

		public bool Delete(int id)
		{
			Categorie toDelete = _dc.Categories.Find(id);
			if (toDelete == null)
			{
				return false;
			}

			_dc.Categories.Remove(toDelete);
			_dc.SaveChanges();
			return true;
		}

		public IEnumerable<CategorieModel> GetAll()
		{
			return _dc.Categories.Select(c => new CategorieModel { Id = c.Id, Nom = c.Nom });
		}

		public CategorieEditModel GetOne(int id)
		{
			Categorie toUdate = _dc.Categories.Find(id);
			CategorieEditModel model = new()
			{
				Nom = toUdate.Nom
			};
			return model;
		}

		public bool Uddate(int id, CategorieEditModel form)
		{
			Categorie toUpdate = _dc.Categories.Find(id);
			if (toUpdate == null) return false;
			toUpdate.Nom = form.Nom;
			_dc.SaveChanges();
			return true;
		}
	}
}
