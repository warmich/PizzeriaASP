using Microsoft.AspNetCore.Mvc;

using Pizzeria.ASP.Models;
using Pizzeria.ASP.Services;
using Pizzeria.DAL;
using Pizzeria.DAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.ASP.Controllers
{
	public class CategorieController : Controller
	{
		private readonly ICategorieService _categorieService;

		public CategorieController(ICategorieService service)
		{
			_categorieService = service;
		}

		public IActionResult Index()
		{
			return View(_categorieService.GetAll());
		}

		// Afficher le formulaire
		public IActionResult Create()
		{
			return View();
		}

		// Traiter le formulaire
		[HttpPost]
		public IActionResult Create(CategorieAddModel form)
		{
			if (ModelState.IsValid)
			{
				_categorieService.Add(form);
				TempData["success"] = "Enregistrement effectué";
				return RedirectToAction("Index");
			}
			// sinon
			// message d'erreur
			return View(form);
		}

		public IActionResult Delete(int id)
		{
			if (!_categorieService.Delete(id))
			{
				return NotFound();
			}
			TempData["success"] = "la catégorie a été supprimée";
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
			CategorieEditModel model = _categorieService.GetOne(id);
			return View(model);
		}

		[HttpPost]
		public IActionResult Edit(int id, CategorieEditModel model)
		{
			if (ModelState.IsValid)
			{
				if (!_categorieService.Uddate(id, model)) return NotFound();
				TempData["success"] = $"la catégorie a été modifiée";
				return RedirectToAction("Index");
			}
			return View(model);
		}
	}
}
