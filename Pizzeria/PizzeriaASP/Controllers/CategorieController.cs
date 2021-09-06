using Microsoft.AspNetCore.Mvc;
using Pizzeria.ASP.Models;
using Pizzeria.DAL;
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

        public IActionResult Add()
        {
            return View();
        }
    }
}
