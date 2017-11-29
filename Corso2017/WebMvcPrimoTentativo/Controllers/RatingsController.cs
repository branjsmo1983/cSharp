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
            Teacher model;

            if (id == 0)
            {
                model = new Teacher();
            }
            else
            {
                model = GetTeacherFromDatabase(id);
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

            UpdateTeacherInDatabase(teacher);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public RedirectToActionResult Delete(int id)
        {
            DeleteTeacherFromDatabase(id);

            return RedirectToAction("Index");
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

        private void DeleteTeacherFromDatabase(int id)
        {
            //dovrei usare i parameters per questioni di sicurezza!

            var query =
                $"DELETE FROM Insegnanti " +
                $"WHERE Id = {id};";

            using (var conn = new SqlConnection("Server=192.168.9.219;Database=ValutazioneCorsi;User Id=corso;Password=corso;"))
            using (var comm = conn.CreateCommand())
            {
                comm.CommandType = System.Data.CommandType.Text;
                comm.CommandText = query;

                conn.Open();

                var result = comm.ExecuteNonQuery();

                //check result
            }
        }

        private void UpdateTeacherInDatabase(Teacher teacher)
        {
            // Nelle query successive
            // dovrei usare i parameters per questioni di sicurezza!
            // Qui le costruisco a mano
            // e verifico come effettuare un attacco di SQL Injection!

            string query;

            if (teacher.Id == 0)
            {
                query = $"INSERT INTO Insegnanti "
                    + $"(Name, Rating) "
                    + $"VALUES "
                    + $"('{teacher.Name}', {teacher.Rating});";
            }
            else
            {
                query =
                    $"UPDATE Insegnanti " +
                    $"SET Name = '{teacher.Name}'," +
                        $"Rating = {teacher.Rating} " +
                    $"WHERE Id = {teacher.Id};";
            }

            using (var conn = new SqlConnection("Server=192.168.9.219;Database=ValutazioneCorsi;User Id=corso;Password=corso;"))
            using (var comm = conn.CreateCommand())
            {
                comm.CommandType = System.Data.CommandType.Text;
                comm.CommandText = query;

                conn.Open();

                var result = comm.ExecuteNonQuery();

                //check result
            }
        }
    }
}
