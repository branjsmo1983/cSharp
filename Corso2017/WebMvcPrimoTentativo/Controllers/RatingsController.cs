using System;
using Microsoft.AspNetCore.Mvc;
using WebMvcPrimoTentativo.Models;
using WebMvcPrimoTentativo.DataAccess;

namespace WebMvcPrimoTentativo.Controllers
{
    public class RatingsController : Controller
    {
        private IRepository<Teacher> _rep;

        public RatingsController(IRepository<Teacher> repository)
        {
            _rep = repository;
        }

        public ViewResult Index()
        {
            var models = _rep.GetListFromDatabase();

            return View(models);
        }

        [HttpGet]
        public ViewResult Details(int id)
        {
            Teacher model;

            if (id == 0)
            {
                model = new Teacher();
            }
            else
            {
                model = _rep.GetSingleFromDatabase(id);
            }

            return View(model);

            #region Esempio di codice meno buono
            // con il codice qui sotto scriverei meno codice ma duplico certe logiche
            // --> meno opportuno

            //if (id == 0)
            //{
            //    return View(new Teacher());
            //}
            //else
            //{
            //    return View(GetTeacherFromDatabase(id));
            //}
            #endregion
        }

        [HttpGet]
        public ViewResult New()
        {
            return View(nameof(Details), new Teacher() { Rating = 1 });
        }

        [HttpPost]
        public IActionResult Details(Teacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher));

            if (!ModelState.IsValid)
                return View(teacher);

            _rep.UpdateInDatabase(teacher);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public RedirectToActionResult Delete(int id)
        {
            _rep.DeleteFromDatabase(id);

            return RedirectToAction("Index");
        }
    }
}
