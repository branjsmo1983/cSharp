using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebMvcSuperheroes.DataAccess;
using WebMvcSuperheroes.Models;
using Microsoft.EntityFrameworkCore;

namespace WebMvcSuperheroes.Controllers
{
    public class VillainController : Controller
    {
        private AppDbContext _context;

        public VillainController(AppDbContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            var models = _context.Villains
                .Include(x => x.Nemesis)
                .ToList();

            return View(models);
        }

        public ViewResult Edit(int id)
        {
            Villain model;

            if (id == 0)
                model = new Villain();
            else
                model = _context.Villains
                    .Include(x => x.Nemesis)
                    .Single(x => x.Id == id);

            var heroes = _context.SuperHeroes.ToList();

            ViewData["heroes"] = heroes;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Villain model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                if (model.Id == 0)
                    _context.Villains.Add(model);
                else
                    _context.Villains.Update(model);

                _context.SaveChanges();

                TempData["message"] = "Villain updated with success";
            }
            catch (Exception)
            {
                TempData["message"] = "Error on updating Villain!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
