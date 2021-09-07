using Microsoft.AspNetCore.Mvc;

using Pizzeria.ASP.Models;
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
		private readonly PizzeriaContext _dc;

		public CategorieController(PizzeriaContext dc)
		{
			_dc = dc;
		}

		public IActionResult Index()
		{
			return View(_dc.Categories.Select(c => new CategorieModel { Id = c.Id, Nom = c.Nom }));
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
			//bool valid = ModelState.IsValid; //propriété des controllers qui vérifie la validité du controller
			// si le formulaire est valide
			if (ModelState.IsValid)
			{
				//transformer CategorieAddModel => Categorie
				Categorie c = new Categorie { Nom = form.Nom };
				//enregistrer les données
				_dc.Categories.Add(c);
				_dc.SaveChanges();
				//popup enregistrement ok

				// dictionnaire qui permet de récupérer la valeur de la clé dans la vue
				// mais ces valeurs sont perdues après une redirection
				//ViewData["Key"] = "value";
				//ViewBag.Key = "value";
				// TempData dico qui transmet des données à la vue
				// même après une redirection
				TempData["success"] = "Enregistrement effectué";
				//rediriger vers page index
				return RedirectToAction("Index");
			}
			// sinon
			// message d'erreur
			return View(form);
		}


		public IActionResult Delete(int id)
		{
			// récupérer la catégorie dont l'id est passé en paramètre
			Categorie toDelete = _dc.Categories.Find(id);
			if (toDelete == null)
			{
				return NotFound();
			}

			_dc.Categories.Remove(toDelete);
			_dc.SaveChanges();
			TempData["success"] = $"la catégorie {toDelete.Nom} a été supprimée";
			return RedirectToAction("Index");
		}

		public IActionResult Update(int id)
		{
			// récupérer l'objet dont l'id est passé en paramètre
			Categorie toUdate = _dc.Categories.Find(id);
			CategorieEditModel model = new()
			{
				Nom = toUdate.Nom
			};
			return View(model);
		}

		[HttpPost]
		public IActionResult Update(int id, CategorieEditModel model)
		{
			// si le formulaire est valide
			if (ModelState.IsValid)
			{
				Categorie toUpdate = _dc.Categories.Find(id);
				toUpdate.Nom = model.Nom;
				_dc.SaveChanges();
				TempData["success"] = $"la catégorie {toUpdate.Nom} a été modifiée";
				return RedirectToAction("Index");
			}
			return View(model);
		}
	}
}
