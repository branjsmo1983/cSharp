using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebMvcPrimoTentativo.Models;

namespace WebMvcPrimoTentativo.DataAccess
{
    public class Repository : IRepository<Teacher>
    {
        public void DeleteFromDatabase(int id)
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

        public List<Teacher> GetListFromDatabase()
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

        public Teacher GetSingleFromDatabase(int id)
        {
            using (var conn = new SqlConnection("Server=192.168.9.219;Database=ValutazioneCorsi;User Id=corso;Password=corso;"))
            using (var comm = conn.CreateCommand())
            {
                comm.CommandType = CommandType.Text;

                //dovrei usare i parameters per questioni di sicurezza!
                comm.CommandText = $"SELECT Id, Name, Rating FROM Insegnanti WHERE Id = {id};";

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

        public void UpdateInDatabase(Teacher model)
        {
            // Nelle query successive
            // dovrei usare i parameters per questioni di sicurezza!
            // Qui le costruisco a mano
            // e verifico come effettuare un attacco di SQL Injection!

            string query;

            if (model.Id == 0)
            {
                query = $"INSERT INTO Insegnanti "
                    + $"(Name, Rating) "
                    + $"VALUES "
                    + $"('{model.Name}', {model.Rating});";
            }
            else
            {
                query =
                    $"UPDATE Insegnanti " +
                    $"SET Name = '{model.Name}'," +
                        $"Rating = {model.Rating} " +
                    $"WHERE Id = {model.Id};";
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
