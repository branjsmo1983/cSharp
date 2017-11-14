using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IDbConnection conn = CreateConnection())
            {
                conn.Open();

                ExecuteScalar(conn);
                ExecuteReader(conn);
                ExecuteNonQuery(conn);
            }

            Console.ReadKey(true);
        }

        private static void ExecuteNonQuery(IDbConnection conn)
        {
            int idAula = 4;
            string cfDocente = "GJKDWT25F2382D";
            int idCorso = 2;

            using (IDbTransaction tran = conn.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                //stesso per DELETE e per INSERT

                //string sql = $"update Corso set Id_aula={ idAula }, CF_Docente='{ cfDocente }' where id={ idCorso }";
                string sql = "update Corso set Id_aula=@idAula, CF_Docente=@cfDocente where id=@idCorso";
                var cmd = conn.CreateCommand();
                cmd.Transaction = tran;
                cmd.CommandText = sql;

                var idAulaParam = cmd.CreateParameter();
                //idAulaParam.DbType = DbType.Int32;
                //idAulaParam.Direction = ParameterDirection.Input;
                idAulaParam.ParameterName = "idAula";
                idAulaParam.Value = idAula;
                cmd.Parameters.Add(idAulaParam);

                var cfDocenteParam = cmd.CreateParameter();
                cfDocenteParam.ParameterName = "cfDocente";
                cfDocenteParam.Value = cfDocente;
                cmd.Parameters.Add(cfDocenteParam);

                var idCorsoParam = cmd.CreateParameter();
                idCorsoParam.ParameterName = "idCorso";
                idCorsoParam.Value = idCorso;
                cmd.Parameters.Add(idCorsoParam);

                int rows = cmd.ExecuteNonQuery();

                tran.Commit();
            }
        }

        private static void ExecuteReader(IDbConnection conn)
        {
            string sql = "select * from CorsiPerStudente";
            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            StringBuilder sb = new StringBuilder();
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        sb.AppendFormat("col[{0}]={1} | ", i, reader.GetValue(i));
                    }

                    sb.AppendLine();
                }
            }            

            Console.WriteLine(sb.ToString());
        }

        private static void ExecuteScalar(IDbConnection conn)
        {
            IDbCommand cmd = //new SqlCommand("select count(*) from CorsiPerStudente", (SqlConnection)conn);
                            conn.CreateCommand();

            string sql = "select count(*) from CorsiPerStudente";

            cmd.CommandText = sql;

            int result = (int)cmd.ExecuteScalar();

            Console.WriteLine($"{ sql } --> { result }");
        }

        private static IDbConnection CreateConnection()
        {
            return new SqlConnection("Server=192.168.9.219;Database=Corsi;User Id=corso;Password=corso;");
        }
    }
}
