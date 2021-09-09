using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Pizzeria.ASP.Models;
using Pizzeria.ASP.Security;
using Pizzeria.ASP.Services;
using Pizzeria.DAL;
using Pizzeria.DAL.Entities;

namespace Pizzeria.ASP.Controllers
{
	// [CustomAuthorisation("Admin")]
	public class PlatController : Controller
	{
		private readonly PizzeriaContext _dc;
		private readonly IWebHostEnvironment _env;
		private readonly ICategorieService _catService;
		private readonly IPlatService _platService;

		public PlatController(ICategorieService catService, IPlatService platService, PizzeriaContext dc, IWebHostEnvironment env) // injection des dépendances
		{
			_dc = dc;
			_env = env;
			_catService = catService;
			_platService = platService;
		}

		// GET: PageController
		public IActionResult Index([FromQuery]int? filtre)
		{
			PlatCategorieModel model = new()
			{
				Filtre = filtre,
				Plats = _platService.GetAll(filtre),
				Categories = _catService.GetAll()
			};
			return View(model);
		}

		// GET: PageController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: PageController/Create
		[CustomAuthorisation("Admin")]
		public ActionResult Create()
		{
			PlatAddModel model = new()
			{
				Categories = _catService.GetAll()
			};
			return View(model);
		}

		// POST: PageController/Create
		[CustomAuthorisation("Admin")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(PlatAddModel form)
		{
			if (ModelState.IsValid)
			{
				_platService.Create(form);
				TempData["success"] = "Enregistrement effectué";
				return RedirectToAction("Index");
			}
			form.Categories = _catService.GetAll();
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
			Plat value = _platService.Delete(id);
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
