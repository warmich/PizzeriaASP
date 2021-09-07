using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

		public PlatController(PizzeriaContext dc)
		{
			_dc = dc;
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
			return View();
		}

		// POST: PageController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(PlatEditModel form)
		{
			if (ModelState.IsValid)
			{
				Plat p = new Plat
				{
					Nom = form.Nom,
					Description = form.Description,
					Prix = form.Prix,
					Image = form.Image,
					Categorie = form.Categorie
				};
				_dc.Plats.Add(p);
				_dc.SaveChanges();
				TempData["success"] = "Enregistrement effectué";
				return RedirectToAction("Index");
			}
			return View(form);
		}

		// GET: PageController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: PageController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
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

		// GET: PageController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: PageController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
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
