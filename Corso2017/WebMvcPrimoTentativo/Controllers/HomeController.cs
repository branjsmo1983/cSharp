﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebMvcPrimoTentativo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMvcPrimoTentativo.Controllers
{
    [Route(template:"")]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Ratings()
        {
            var models = GetTeachersFromDatabase();
            return View(models);
        }

     

        List<Teacher> GetTeachersFromDatabase()
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
