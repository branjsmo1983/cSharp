using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvcPrimoTentativo.Models;
using System.Data.SqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMvcPrimoTentativo.Controllers
{
    public class RatingsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var models = GetTeachersFromDatabase();

            return View(models);

        }

        [HttpGet]
        public ViewResult Details(int id)
        {
            Teacher model;

            if(id == 0)
            {
                model = new Teacher();
            }
            else
            {
                model = GetTeacherFromDatabase(id);
            }

            return View(model);
        }

        [HttpGet]
        public ViewResult New()
        {
            return View(nameof(Details),new Teacher() { Rating = 1}); //per dirgli quale view scegliere, se non metto il nome della View avrebbe preso quella del nome del controller, in questo caso avrebbe cercato una nuova View
        }

        [HttpPost]
        public RedirectToActionResult Delete(int id)
        {
            DeleteTeacherFromDB(id);
            return RedirectToAction(nameof(RatingsController.Index));
        }

        private void DeleteTeacherFromDB(int id)
        {
            var query = $"DELETE FROM Insegnanti  WHERE Id={id}";
            using (var conn = new SqlConnection("Server=192.168.9.219;Database=ValutazioneCorsi;User Id=corso;Password=corso;"))
            using (var comm = conn.CreateCommand())
            {
                comm.CommandType = System.Data.CommandType.Text;
                comm.CommandText = query;

                conn.Open();

                var result = comm.ExecuteNonQuery();
                //check su result TO DO
                //return View(teacher); se voglio rimanere dentro la pagina del dettaglio
               // return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public RedirectToActionResult Details(Teacher teacher)
        {
            string query;
            if(teacher.Id == 0)
            {
                query = $"INSERT INTO Insegnanti (Name, Ratings) VALUES ({ teacher.Name}, {teacher.Rating });";
            }
            else
            {
                query = $"UPDATE Insegnanti SET Name = '{teacher.Name}', Rating = {teacher.Rating} WHERE Id={teacher.Id}";
            }

            
            using (var conn = new SqlConnection("Server=192.168.9.219;Database=ValutazioneCorsi;User Id=corso;Password=corso;"))
            using (var comm = conn.CreateCommand())
            {
                comm.CommandType = System.Data.CommandType.Text;
                comm.CommandText = query;

                conn.Open();

                var result = comm.ExecuteNonQuery();
                //check su result TO DO
                //return View(teacher); se voglio rimanere dentro la pagina del dettaglio
                return RedirectToAction(nameof(RatingsController.Index));
            }
        }

        private Teacher GetTeacherFromDatabase(int id)
        {

            using (var conn = new SqlConnection("Server=192.168.9.219;Database=ValutazioneCorsi;User Id=corso;Password=corso;"))
            using (var comm = conn.CreateCommand())
            {
                comm.CommandType = System.Data.CommandType.Text;
                comm.CommandText = $"SELECT Id, Name, Rating FROM Insegnanti WHERE Id ={id}";

                conn.Open();

                using (var reader = comm.ExecuteReader())
                {
                    var hasResult = reader.Read();

                    if (!hasResult)
                    {
                        throw new InvalidOperationException("insegnante non trovato");
                    }

                    var t = new Teacher
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Rating = (int)reader["Rating"]
                    };




                    return t;
                }
            }

        }

        private List<Teacher> GetTeachersFromDatabase()
        {
            using (var conn = new SqlConnection("Server=192.168.9.219;Database=ValutazioneCorsi;User Id=corso;Password=corso;"))
            using (var comm = conn.CreateCommand())
            {
                comm.CommandType = System.Data.CommandType.Text;
                comm.CommandText = "SELECT Id, Name, Rating FROM Insegnanti ORDER BY Name";

                conn.Open();

                using (var reader = comm.ExecuteReader())
                {
                    var teacherList = new List<Teacher>();

                    while (reader.Read())
                    {
                        var t = new Teacher();
                        t.Id = (int)reader["Id"];
                        t.Name = (string)reader["Name"];
                        t.Rating = (int)reader["Rating"];

                        teacherList.Add(t);
                    }

                    return teacherList;
                }
            }
        }
    }
}
