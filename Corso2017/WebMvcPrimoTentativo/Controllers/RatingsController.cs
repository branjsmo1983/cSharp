using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvcPrimoTentativo.Models;
using System.Data.SqlClient;

namespace WebMvcPrimoTentativo.Controllers
{
    public class RatingsController : Controller
    {
        public ViewResult Index()
        {
            var models = GetTeachersFromDatabase();

            return View(models);
        }

        [HttpGet]
        public ViewResult Details(int id)
        {
            var model = GetTeacherFromDatabase(id);

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Details(Teacher teacher)
        {
            var query =
                $"UPDATE Insegnanti " +
                $"SET Name = '{teacher.Name}'," +
                    $"Rating = {teacher.Rating} " +
                $"WHERE Id = {teacher.Id};";

            using (var conn = new SqlConnection("Server=192.168.9.219;Database=ValutazioneCorsi;User Id=corso;Password=corso;"))
            using (var comm = conn.CreateCommand())
            {
                comm.CommandType = System.Data.CommandType.Text;
                comm.CommandText = query;

                conn.Open();

                var result = comm.ExecuteNonQuery();

                //check result

                //return View(teacher);
                return RedirectToAction("Index");
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

        private Teacher GetTeacherFromDatabase(int id)
        {
            using (var conn = new SqlConnection("Server=192.168.9.219;Database=ValutazioneCorsi;User Id=corso;Password=corso;"))
            using (var comm = conn.CreateCommand())
            {
                comm.CommandType = System.Data.CommandType.Text;
                comm.CommandText = $"SELECT Id, Name, Rating FROM Insegnanti WHERE Id = {id}";

                conn.Open();

                using (var reader = comm.ExecuteReader())
                {
                    var hasResult = reader.Read();

                    if (!hasResult)
                        throw new InvalidOperationException("Insegnante non trovato!");

                    var t = new Teacher();
                    t.Id = (int)reader["Id"];
                    t.Name = (string)reader["Name"];
                    t.Rating = (int)reader["Rating"];

                    return t;
                }
            }
        }
    }
}
