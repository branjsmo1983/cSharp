using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvcSuperheroes.DataAccess;
using WebMvcSuperheroes.Models;

namespace WebMvcSuperheroes.Controllers
{
    public class SuperHeroController:Controller

    {
        private AppDbContext _context;

        public SuperHeroController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            SuperHero model;
            if (id == 0)
            {
                model = new SuperHero();
            }
            else
            {
                model = _context.SuperHeroes.Single(x => x.Id == id);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(SuperHero model)
        {
            if (model.Id == 0)
            {
                _context.SuperHeroes.Add(model);
            }
            else
            {
                _context.SuperHeroes.Update(model);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
