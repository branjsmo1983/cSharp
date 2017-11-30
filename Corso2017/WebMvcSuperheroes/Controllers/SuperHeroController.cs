using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvcSuperheroes.DataAccess;

namespace WebMvcSuperheroes.Controllers
{
    public class SuperHeroController : Controller
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
    }
}
