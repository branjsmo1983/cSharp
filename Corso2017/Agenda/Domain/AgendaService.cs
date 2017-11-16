using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain
{
    class AgendaService
    {
        private const string SQL_SELECT_PEOPLE = "select p.id, p.name, p.surname, p.dateofbirth, p.nationalityid, n.name nationality from person p inner join nationality n on p.nationalityid = n.id";
        private const string SQL_SELECT_PERSON = "select p.id, p.name, p.surname, p.dateofbirth, p.nationalityid, n.name nationality from person p inner join nationality n on p.nationalityid = n.id where p.id=@id";
        private const string SQL_INSERT_PERSON = "insert into person (name, surname, dateofbirth, nationalityid) values (@name, @surname, @dateofbirth, @nationalityid)";
        private const string SQL_UPDATE_PERSON = "update person set name=@name, surname=@surname, dateofbirth=@dateofbirth, nationalityid=@nationalityid where id=@id";
        private const string SQL_DELETE_PERSON = "delete from person where id=@id";
        private const string SQL_SELECT_NATIONALITIES = "select id, name from nationality order by name";
        private const string SQL_SELECT_NATIONALITY = "select id, name from nationality where id=@id";

        private readonly string _connectionString;

        public AgendaService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Person> GetPeople()
        {
            return GetList(SQL_SELECT_PEOPLE, PersonMapper);
        }

        internal Person GetPerson(int value)
        {
            return GetSingle(SQL_SELECT_PERSON, PersonMapper, new SqlParameter("id", value));
        }

        internal List<Nationality> GetNationalities()
        {
            return GetList(SQL_SELECT_NATIONALITIES, NationalityMapper);
        }

        #region Mappers 

        private Nationality NationalityMapper(DbDataReader reader)
        {
            return new Nationality
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            };
        }

        private Person PersonMapper(DbDataReader reader)
        {
            return new Person
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Surname = reader.GetString(2),
                DateOfBirth = reader.GetDateTime(3),
                Nationality = new Nationality
                {
                    Id = reader.GetInt32(4),
                    Name = reader.GetString(5)
                }
            };
        }

        internal void SavePerson(Person person)
        {
            using (var conn = CreateConnection())
            using (var cmd = conn.CreateCommand())
            {
                if (person.Id == -1)
                    cmd.CommandText = SQL_INSERT_PERSON;
                else
                    cmd.CommandText = SQL_UPDATE_PERSON;

                cmd.Parameters.Add(new SqlParameter("id", person.Id));
                cmd.Parameters.Add(new SqlParameter("name", person.Name));
                cmd.Parameters.Add(new SqlParameter("surname", person.Surname));
                cmd.Parameters.Add(new SqlParameter("dateofbirth", person.DateOfBirth));
                cmd.Parameters.Add(new SqlParameter("nationalityid", person.Nationality.Id));

                var rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected != 1)
                {
                    throw new InvalidOperationException("No records inserted");
                }
            }
        }

        internal void DeletePerson(int id)
        {
            using (var conn = CreateConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = SQL_DELETE_PERSON;

                cmd.Parameters.Add(new SqlParameter("id", id));

                var rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected != 1)
                {
                    throw new InvalidOperationException("No records inserted");
                }
            }
        }

        #endregion

        #region Common methods

        private T GetSingle<T>(string sql, Func<SqlDataReader, T> mapper, params SqlParameter[] parameters)
        {
            using (var conn = CreateConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters.ToArray());

                var reader = cmd.ExecuteReader();
                List<T> results = new List<T>();
                while (reader.Read())
                {
                    results.Add(mapper(reader));
                }

                if (results.Count > 1)
                    throw new InvalidOperationException($"More than one record found for { sql }");

                return results[0];
            }
        }

        private List<T> GetList<T>(string sql, Func<SqlDataReader, T> mapper)
        {
            List<T> results = new List<T>();

            using (var conn = CreateConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(mapper(reader));
                }
            }

            return results;
        }

        private SqlConnection CreateConnection()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }

        #endregion
    }
}