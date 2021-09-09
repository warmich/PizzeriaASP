using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;

using Pizzeria.ASP.Models;
using Pizzeria.DAL;
using Pizzeria.DAL.Entities;

namespace Pizzeria.ASP.Services
{
	public class PlatService : IPlatService
	{
		private readonly PizzeriaContext _dc;
		private readonly IWebHostEnvironment _env;
		private readonly IFileService _fs;

		public PlatService(PizzeriaContext dc, IWebHostEnvironment env, IFileService fs)
		{
			_dc = dc;
			_env = env;
			_fs = fs;
		}

		public void Create(PlatAddModel form)
		{
			string fileName = null;
			if (form.File != null)
			{
				fileName = _fs.AddFile(form.File);
			}

			Plat p = new Plat
			{
				Nom = form.Nom,
				Description = form.Description,
				Prix = decimal.Parse(form.Prix.Replace('.', ',')),
				Image = fileName,
				CategorieId = form.CategorieId
			};
			_dc.Plats.Add(p);
			_dc.SaveChanges();
		}

		public Plat Delete(int id)
		{
			Plat toDelete = _dc.Plats.Find(id);
			if (toDelete == null) return null;
			_dc.Plats.Remove(toDelete);
			_dc.SaveChanges();
			if (toDelete.Image != null)
			{
				_fs.Delete(toDelete.Image);
			}
			return toDelete;
		}

		public IEnumerable<PlatModel> GetAll(int? filtre)
		{
			return _dc.Plats
				.Where(p => p.CategorieId == filtre || filtre == null)
				.Select(p => new PlatModel
				{
					Id = p.Id,
					Nom = p.Nom,
					Prix = p.Prix,
					Description = p.Description,
					Image = p.Image,
					CategorieId = p.CategorieId,
					Categorie = p.Categorie
				});
		}
	}
}
