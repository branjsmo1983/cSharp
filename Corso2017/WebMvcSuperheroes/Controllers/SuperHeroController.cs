﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvcSuperheroes.DataAccess;
using WebMvcSuperheroes.Models;

namespace WebMvcSuperheroes.Controllers
{
    public class SuperHeroController : Controller
    {
        private AppDbContext _context;

        public SuperHeroController(AppDbContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            var models = _context.SuperHeroes.ToList();

            return View(models);
        }

        public ViewResult Edit(int id)
        {
            SuperHero model;

            if (id == 0)
                model = new SuperHero();
            else
                model = _context.SuperHeroes.Single(x => x.Id == id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(SuperHero model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                if (model.Id == 0)
                    _context.SuperHeroes.Add(model);
                else
                    _context.SuperHeroes.Update(model);

                _context.SaveChanges();

                TempData["message"] = "Hero updated with success";
            }
            catch (Exception)
            {
                TempData["message"] = "Error on updating Hero!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
