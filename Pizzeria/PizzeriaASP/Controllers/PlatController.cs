using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Pizzeria.ASP.Models;
using Pizzeria.DAL;
using Pizzeria.DAL.Entities;

namespace Pizzeria.ASP.Controllers
{
	public class PlatController : Controller
	{
		private readonly PizzeriaContext _dc;
		private readonly IWebHostEnvironment _env;

		public PlatController(PizzeriaContext dc, IWebHostEnvironment env) // injection des dépendances
		{
			_dc = dc;
			_env = env;
		}

		// GET: PageController
		public ActionResult Index([FromQuery]int? filtre)
		{
			PlatCategorieModel model = new()
			{
				Filtre = filtre,
				Plats = _dc.Plats
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
				}),
				Categories = _dc.Categories.Select(
					c => new CategorieModel
					{
						Id = c.Id,
						Nom = c.Nom
					}
					)
			};
			return View(model);
		}

		// GET: PageController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: PageController/Create
		public ActionResult Create()
		{
			PlatAddModel model = new()
			{
				Categories = _dc.Categories.Select(
					c => new CategorieModel
					{
						Id = c.Id,
						Nom = c.Nom
					})
			};
			return View(model);
		}

		// POST: PageController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(PlatAddModel form)
		{
			string fileName = null;
			if (ModelState.IsValid)
			{
				if (form.File != null)
				{
					fileName = Guid.NewGuid() + form.File.FileName;
					string path = Path.Combine(_env.WebRootPath, "uploads");
					using FileStream stream = new FileStream(
						Path.Combine(path, fileName), FileMode.Create);
					form.File.CopyTo(stream);
				}

				Plat p = new Plat
				{
					Nom = form.Nom,
					Description = form.Description,
					Prix = decimal.Parse(form.Prix.Replace('.',',')),
					Image = fileName,
					CategorieId = form.CategorieId
				};
				_dc.Plats.Add(p);
				_dc.SaveChanges();
				TempData["success"] = "Enregistrement effectué";
				return RedirectToAction("Index");
			}
			form.Categories = _dc.Categories.Select(
					c => new CategorieModel
					{
						Id = c.Id,
						Nom = c.Nom
					});
			return View(form);
		}

		// GET: PageController/Edit/5
		public ActionResult Edit(int id)
		{
			PlatEditModel model = new()
			{
				Categories = _dc.Categories.Select(
					c => new CategorieModel
					{
						Id = c.Id,
						Nom = c.Nom
					})
			};
			return View(model);
		}

		// POST: PageController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, PlatEditModel model)
		{
			if (ModelState.IsValid)
			{
				Plat toUpdate = _dc.Plats.Find(id);
				toUpdate.Nom = model.Nom;
				_dc.SaveChanges();
				TempData["success"] = $"la catégorie {toUpdate.Nom} a été modifiée";
				return RedirectToAction("Index");
			}
			return View(model);
		}

		// GET: PageController/Delete/5
		public ActionResult Delete(int id)
		{
			Plat toDelete = _dc.Plats.Find(id);
			_dc.Plats.Remove(toDelete);
			_dc.SaveChanges();
			if (toDelete.Image != null)
			{
				System.IO.File.Delete(
					Path.Combine(
						_env.WebRootPath,
						"uploads",
						toDelete.Image
						));
			}
			return this.RedirectToAction("Index");
		}

		// POST: PageController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, PlatEditModel model)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
