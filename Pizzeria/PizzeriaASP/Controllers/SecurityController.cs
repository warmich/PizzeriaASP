using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Pizzeria.ASP.Models;
using Pizzeria.ASP.Services;
using Pizzeria.DAL.Entities;

namespace Pizzeria.ASP.Controllers
{
	public class SecurityController : Controller
	{
		private readonly IClientService _clientService;
		private readonly IHashService _hashService;

		public SecurityController(IClientService clientService, IHashService hashService)
		{
			_clientService = clientService;
			_hashService = hashService;
		}

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(LoginModel form)
		{
			Client client = _clientService.GetByEmail(form.Email);
			if (client == null || client.Password != _hashService.Hash(form.PlainPassword, client.Salt.ToString()))
			{
				TempData["error"] = "Erreur connection";
				return View(form);
			}
			else
			{
				TempData["success"] = "Bienvenue" + client.Nom;
				HttpContext.Session.SetString("Role", client.Role);
				HttpContext.Session.SetInt32("Id", client.Id);
				return RedirectToAction("Index", "Home");
			}
		}

		public IActionResult Register() { return View(); }

		[HttpPost]
		public IActionResult Register(RegisterModel form)
		{
			if (ModelState.IsValid)
			{
				Guid salt = Guid.NewGuid();
				string hashed = _hashService.Hash(form.Password, salt.ToString());
				_clientService.Create(form, salt, hashed);
				TempData["success"] = "Client créé";
				return this.RedirectToAction("Login");
			}
			return View(form);
		}
	}
}
